using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using Newtonsoft.Json;

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

        public SynacorDebug()
        {
            InitializeComponent();
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
                Machine is null ? "Nothing loaded." :
                Machine.Halted ? "Program finished." :
                WaitingForInput ? "Waiting for input." :
                ControlState == 0 ? "Stopped." :
                ControlState == 1 ? "Stepping once." :
                ControlState == 2 ? "Processing..." :
                "Unkown.");

            stepsLabel.Text = "Instructions Completed: " + InstructionCount;
            stepsSpeedLabel.Text = "Time Per Instruction: " +
            (AverageInstructionTime * 1000).ToString("0.0") +
            " microseconds";

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

            saveStateBtn.Enabled = Machine is not null && ControlState == 0 && !WaitingForInput;
            stepBtn.Enabled = Machine is not null && ControlState == 0 && !WaitingForInput;
            startBtn.Enabled = Machine is not null && ControlState == 0 && !Machine.Halted && !WaitingForInput;
            stopBtn.Enabled = Machine is not null && ControlState == 2 && !Machine.Halted;

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
            Machine = new VM(shorts)
            {
                In = () =>
                {
                    WaitingForInput = true;
                    while (InputQueue.Count <= 0)
                    {
                        Thread.Sleep(1);
                    }
                    var c = InputQueue[0][0];
                    InputQueue[0] = InputQueue[0][1..];
                    if (InputQueue[0].Length == 0)
                    {
                        InputQueue.RemoveAt(0);
                    }
                    WaitingForInput = false;
                    return c;
                },
                Out = (o) =>Invoke(new Action(() => consoleOutBx.AppendText(o.ToString()))),
                InstructionExecuted = (i) => instructionsToDebug.Add(i),
            };

            startBtn.Enabled = true;
            stopBtn.Enabled = true;
            stepBtn.Enabled = true;
        }

        private void StepBtn_Click(object a, EventArgs e) => ControlState = 1;
        private void StartBtn_Click(object a, EventArgs e) => ControlState = 2;
        private void StopBtn_Click(object a, EventArgs e) => ControlState = 0;
        private void OnFormClosed(object a, FormClosedEventArgs e)
        {
            ControlState = 0;
            Environment.Exit(0);
        }

        private void ResetBtn_Click(object a, EventArgs e) => Reset();

        private void SaveStateBtn_Click(object a, EventArgs e)
        {
            if (ControlState != 0) { return; }
            while (Machine.IsStepping) { Thread.Sleep(50); }
            var json = JsonConvert.SerializeObject(Machine);

            var dia = new SaveFileDialog()
            {
                Filter = "Synacor Save State|*.syn.json",
                OverwritePrompt = true,
            };

            if (dia.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(dia.FileName, json);
            }
        }

        private void LoadStateBtn_Click(object a, EventArgs e)
        {

        }

        private void PointerBx_ValueChanged(object a, EventArgs e) => Machine.Pointer = (int)pointerBx.Value;

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
    }
}
