using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using SynacorExecutor;

namespace SynacorDebug
{
    public partial class SynacorDebug : Form
    {
        public VM Machine;

        public Thread VMThread;
        public Thread DebugThread;

        // 0 = Paused, 1 = Step once, 2 = Step continuously
        public int ControlState;

        public List<Instruction> instructionsToDebug;
        public int InstructionCount = 0;
        public double AverageInstructionTime = 0;

        public List<string> InputQueue = new();
        public bool WaitingForInput;
        public bool InputCancelled;

        public SynacorDebug()
        {
            InitializeComponent();
            DoubleBuffered = true;
            SetStyle(ControlStyles.ResizeRedraw, true);
        }

        private void SynacorDebug_Load(object a, EventArgs e)
        {
            VMThread = new Thread(VMThreadMethod);
            VMThread.Start();
            DebugThread = new Thread(UpdateDebugValuesThread);
            DebugThread.Start();
        }

        public void UpdateDebugValues()
        {
            statusLabel.Text = "Status: " + (
                Machine is null ? "No VM Loaded" :
                Machine.Halted ? "Program Halted" :
                WaitingForInput ? "Waiting For Input" :
                ControlState == 0 ? "Paused" :
                ControlState == 1 ? "Stepping Once" :
                ControlState == 2 ? "Processing..." :
                "Unkown");

            stepsLabel.Text = "Instructions Completed: " + InstructionCount;
            //stepsSpeedLabel.Text = "Time Per Instruction: " +
            //(AverageInstructionTime * 1000).ToString("0.0") +
            //" microseconds";
            stepsSpeedLabel.Text = "Speed: " + 
                (1000 / AverageInstructionTime).ToString("#,#.#") + " /second";

            if (ControlState != 0)
            {
                UpdateDebugBoxes();
            }

            this.ForAllControls(c =>
            {
                if (c.Tag?.ToString() == "requireMachine")
                {
                    c.Enabled = Machine is not null;
                }

                if (c is Button)
                {
                    c.Visible = c.Enabled;
                }
            });

            saveStateBtn.Enabled = Machine is not null && (ControlState == 0 || WaitingForInput);
            stepBtn.Enabled = Machine is not null && ControlState == 0 && !WaitingForInput;
            startBtn.Enabled = Machine is not null && ControlState == 0 && !Machine.Halted && !WaitingForInput;
            stopBtn.Enabled = Machine is not null && ControlState == 2 && !Machine.Halted;
            dumpVMBtn.Enabled = Machine is not null;

            textQueueLabel.Text =
                InputQueue.Count <= 0 ?
                "No Text Queued" :
                "Queued Text: " + InputQueue[0].Replace("\n", "") + " ⮯";
        }

        public void UpdateDebugValuesThread()
        {
            while (true)
            {
                Invoke(new Action(UpdateDebugValues));
                Thread.Sleep(100);
            }
        }

        public void VMThreadMethod()
        {
            var stepWatch = Stopwatch.StartNew();

            void Step()
            {
                stepWatch.Start();
                var o = Machine.Step();
                stepWatch.Stop();
                if (o == OpCode.Cancelled) { return; }
                if (o != OpCode.In)
                {
                    AverageInstructionTime =
                        (AverageInstructionTime * InstructionCount + stepWatch.Elapsed.TotalMilliseconds) /
                        (InstructionCount + 1);
                }

                InstructionCount++;
                stepWatch.Reset();
            }

            start:;

            while (Machine is null || ControlState == 0)
            {
                Thread.Sleep(1);
            }

            if (ControlState == 1) // Step Once
            {
                Step();
                ControlState = 0;
                goto start;
            }

            while (ControlState == 2 && Machine is not null && !Machine.Halted) // Step until stopped or halted
            {
                Step();
            }
            ControlState = 0;
            goto start;
        }

        private void Reset()
        {
            Machine = null;
            if (WaitingForInput)
            {
                InputQueue.Add("\n");
                while (WaitingForInput) { Thread.Sleep(1); }
            }
            InstructionCount = 0;
            AverageInstructionTime = 0;
            historyBx.Clear();
            InputQueue = new();
            consoleInBx.Clear();
            consoleOutBx.Clear();
            instructionsToDebug = new(10000000);
        }

        private void NewFromBinBtn_Click(object a, EventArgs e)
        {
            var dia = new OpenFileDialog() { Filter = "Raw BIN|*.bin", };

            if (dia.ShowDialog() != DialogResult.OK) { return; }

            Reset();
            var bytes = File.ReadAllBytes(dia.FileName);
            var shorts = Utility.ConvertFromBytes(bytes);
            Machine = new VM(shorts);
            SetupVM();

            startBtn.Enabled = true;
            stopBtn.Enabled = true;
            stepBtn.Enabled = true;
        }

        public void SetupVM()
        {
            Machine.In = () =>
            {
                WaitingForInput = true;
                while (InputQueue.Count <= 0 && !InputCancelled)
                {
                    Thread.Sleep(1);
                }
                WaitingForInput = false;
                if (InputCancelled) { InputCancelled = false; return null; }
                var c = InputQueue[0][0];
                InputQueue[0] = InputQueue[0][1..];
                if (InputQueue[0].Length == 0)
                {
                    InputQueue.RemoveAt(0);
                }
                return c;
            };
            Machine.Out = (o) => Invoke(new Action(() => consoleOutBx.AppendText(o.ToString())));
            Machine.InstructionExecuted = (i) => instructionsToDebug.Add(i);
        }

        public void UpdateDebugBoxes()
        {
            if (Machine is not null)
            {
                r0Bx.Value = Machine.Registers[0];
                r1Bx.Value = Machine.Registers[1];
                r2Bx.Value = Machine.Registers[2];
                r3Bx.Value = Machine.Registers[3];
                r4Bx.Value = Machine.Registers[4];
                r5Bx.Value = Machine.Registers[5];
                r6Bx.Value = Machine.Registers[6];
                r7Bx.Value = Machine.Registers[7];

                pointerBx.Value = Machine.Pointer;

            }
        }

        private void StepBtn_Click(object a, EventArgs e) => ControlState = 1;
        private void StartBtn_Click(object a, EventArgs e) => ControlState = 2;
        private void StopBtn_Click(object a, EventArgs e)
        {
            ControlState = 0;
            if (WaitingForInput) { InputCancelled = true; }
            while (Machine.IsStepping) { Thread.Sleep(1); }
            UpdateDebugBoxes();
        }
        private void OnFormClosed(object a, FormClosedEventArgs e)
        {
            ControlState = 0;
            Environment.Exit(0);
        }

        private void ResetBtn_Click(object a, EventArgs e) => Reset();

        private void SaveStateBtn_Click(object a, EventArgs e)
        {
            var dia = new SaveFileDialog() { Filter = "Synacor Save State|*.synacor", };
            if (dia.ShowDialog() != DialogResult.OK) { return; }

            var instQueue = new List<byte>(10 * instructionsToDebug.Count);
            foreach (var i in instructionsToDebug)
            {
                instQueue.AddRange(BitConverter.GetBytes(i.Pointer));
                instQueue.Add((byte)i.OpCode);
                instQueue.Add((byte)i.Parameters.Length);
                foreach (var p in i.Parameters)
                {
                    instQueue.AddRange(BitConverter.GetBytes(p));
                }
            }

            var toSave = new JObject
            {
                ["memory"] = Convert.ToBase64String(Utility.ConvertToBytes(Machine.Memory)),
                ["pointer"] = Machine.Pointer,
                ["stack"] = new JArray(Machine.Stack),
                ["registers"] = new JArray(Machine.Registers),
                ["halted"] = Machine.Halted,
                ["outBx"] = consoleOutBx.Text,
                ["inBx"] = consoleInBx.Text,
                ["inQueue"] = new JArray(InputQueue),
                ["historyBx"] = historyBx.Text,
                ["instructionQueue"] = Convert.ToBase64String(instQueue.ToArray()),
                ["instructionsCompleted"] = InstructionCount,
            };

            File.WriteAllText(dia.FileName, toSave.ToString(Formatting.Indented).Compress());
            MessageBox.Show("Save complete.", "Finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LoadStateBtn_Click(object a, EventArgs e)
        {
            var dia = new OpenFileDialog() { Filter = "Synacor Save State|*.synacor", };
            if (dia.ShowDialog() != DialogResult.OK) { return; }

            Reset();

            var obj = JObject.Parse(File.ReadAllText(dia.FileName).Decompress());
            Machine = new VM(Utility.ConvertFromBytes(Convert.FromBase64String(obj["memory"].Value<string>())))
            {
                Pointer = obj["pointer"].Value<ushort>(),
                Stack = new Stack<ushort>((obj["stack"] as JArray).Select(j => j.Value<ushort>()).Reverse()),
                Registers = (obj["registers"] as JArray).Select(j => j.Value<ushort>()).ToArray(),
                Halted = obj["halted"].Value<bool>(),
            };
            SetupVM();

            consoleOutBx.AppendText(obj["outBx"].Value<string>());
            consoleInBx.AppendText(obj["inBx"].Value<string>());
            historyBx.AppendText(obj["historyBx"].Value<string>());

            InputQueue = (obj["inQueue"] as JArray).Select(j => j.Value<string>()).ToList();
            InstructionCount = obj["instructionsCompleted"].Value<int>();

            var instBytes = Convert.FromBase64String(obj["instructionQueue"].Value<string>());
            for (var i = 0; i < instBytes.Length; )
            {
                var inst = new Instruction()
                {
                    Pointer = BitConverter.ToUInt16(instBytes, i),
                    OpCode = (OpCode)instBytes[i + 2],
                };

                var paramCount = instBytes[i + 3];
                inst.Parameters = new ushort[paramCount];
                i += 4;
                for (var j = 0; j < paramCount; j++)
                {
                    inst.Parameters[j] = BitConverter.ToUInt16(instBytes, i);
                    i += 2;
                }

                instructionsToDebug.Add(inst);
            }

            MessageBox.Show("Load complete.", "Finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void PointerBx_ValueChanged(object a, EventArgs e) => Machine.Pointer = (ushort)pointerBx.Value;

        private void ConsoleInBx_TextChanged(object sender, EventArgs e)
        {
            if (!consoleInBx.Text.Contains("\n")) { return; }

            var items = consoleInBx.Text.Split("\n", StringSplitOptions.RemoveEmptyEntries)
                .Select(i => i.Replace("\r", "") + "\n").ToList();

            items.ForEach(i => InputQueue.Add(i));

            consoleInBx.Clear();
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        static extern bool ReleaseCapture();

        private void SynacorDebug_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                _ = SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void SetRegisters_Click(object sender, EventArgs e)
        {
            Machine.Registers[0] = (ushort)r0Bx.Value;
            Machine.Registers[1] = (ushort)r1Bx.Value;
            Machine.Registers[2] = (ushort)r2Bx.Value;
            Machine.Registers[3] = (ushort)r3Bx.Value;
            Machine.Registers[3] = (ushort)r3Bx.Value;
            Machine.Registers[5] = (ushort)r5Bx.Value;
            Machine.Registers[6] = (ushort)r6Bx.Value;
            Machine.Registers[7] = (ushort)r7Bx.Value;
        }

        private void LoadHistoryBtn_Click(object sender, EventArgs e)
        {
            var b = new StringBuilder();
            foreach (var item in instructionsToDebug)
            {
                if (item.OpCode == OpCode.Noop) { continue; }

                var pointer = item.Pointer.ToString().PadRight(6, ' ');

                b.Append($"{pointer} {item.OpCode} ");
                if (item.OpCode == OpCode.Out)
                {
                    b.Append(((char)item.Parameters[0]).ToString().Replace("\n", "\\n"));
                }
                else
                {
                    b.Append(string.Join(' ', item.Parameters));
                }

                b.Append('\n');
            }
            instructionsToDebug.Clear();
            historyBx.AppendText(b.ToString());
        }

        private void MaxBtn_Click(object sender, EventArgs e)
        {
            MaximizedBounds = Screen.GetWorkingArea(this);
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
            else
            {
                WindowState = FormWindowState.Maximized;
            }
        }

        private const int cGrip = 16;      // Grip size

        protected override void OnPaint(PaintEventArgs e)
        {
            var rc = new Rectangle(ClientSize.Width - cGrip, ClientSize.Height - cGrip, cGrip, cGrip);
            ControlPaint.DrawSizeGrip(e.Graphics, BackColor, rc);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {  // Trap WM_NCHITTEST
                var pos = new Point(m.LParam.ToInt32());
                pos = PointToClient(pos);
                if (pos.X >= ClientSize.Width - cGrip && pos.Y >= ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17; // HTBOTTOMRIGHT
                    return;
                }
            }
            base.WndProc(ref m);
        }

        private void DumpVMBtn_Click(object sender, EventArgs e)
        {
            var dia = new SaveFileDialog() { Filter = "VM Dump (Cannot be reloaded)|*.json", };
            if (dia.ShowDialog() != DialogResult.OK) { return; }

            File.WriteAllText(dia.FileName, JsonConvert.SerializeObject(Machine, Formatting.Indented));
            MessageBox.Show("VM Dumped\n\n" + dia.FileName, "Dump Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
