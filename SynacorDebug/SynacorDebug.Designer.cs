namespace SynacorDebug
{
    partial class SynacorDebug
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.historyBx = new System.Windows.Forms.RichTextBox();
            this.dumpVMBtn = new System.Windows.Forms.Button();
            this.stepBtn = new System.Windows.Forms.Button();
            this.stopBtn = new System.Windows.Forms.Button();
            this.startBtn = new System.Windows.Forms.Button();
            this.resetBtn = new System.Windows.Forms.Button();
            this.newFromBinBtn = new System.Windows.Forms.Button();
            this.saveStateBtn = new System.Windows.Forms.Button();
            this.loadStateBtn = new System.Windows.Forms.Button();
            this.r7Bx = new System.Windows.Forms.NumericUpDown();
            this.pointerBx = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.r6Bx = new System.Windows.Forms.NumericUpDown();
            this.r5Bx = new System.Windows.Forms.NumericUpDown();
            this.r4Bx = new System.Windows.Forms.NumericUpDown();
            this.r3Bx = new System.Windows.Forms.NumericUpDown();
            this.r2Bx = new System.Windows.Forms.NumericUpDown();
            this.r1Bx = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.r0Bx = new System.Windows.Forms.NumericUpDown();
            this.consoleOutBx = new System.Windows.Forms.RichTextBox();
            this.consoleInBx = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.exitBtn = new System.Windows.Forms.Button();
            this.setRegisters = new System.Windows.Forms.Button();
            this.maxBtn = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.historyCheckBx = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.stepsLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.stepsSpeedLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.textQueueLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.delayBx = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.r7Bx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointerBx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.r6Bx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.r5Bx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.r4Bx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.r3Bx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.r2Bx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.r1Bx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.r0Bx)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.delayBx)).BeginInit();
            this.SuspendLayout();
            // 
            // historyBx
            // 
            this.historyBx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.historyBx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.historyBx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.historyBx.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.historyBx.ForeColor = System.Drawing.Color.White;
            this.historyBx.HideSelection = false;
            this.historyBx.Location = new System.Drawing.Point(12, 47);
            this.historyBx.Name = "historyBx";
            this.historyBx.ReadOnly = true;
            this.historyBx.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.historyBx.Size = new System.Drawing.Size(231, 440);
            this.historyBx.TabIndex = 0;
            this.historyBx.Text = "";
            // 
            // dumpVMBtn
            // 
            this.dumpVMBtn.BackgroundImage = global::SynacorDebug.Properties.Resources.memory;
            this.dumpVMBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.dumpVMBtn.Enabled = false;
            this.dumpVMBtn.FlatAppearance.BorderSize = 0;
            this.dumpVMBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dumpVMBtn.Location = new System.Drawing.Point(51, 17);
            this.dumpVMBtn.Name = "dumpVMBtn";
            this.dumpVMBtn.Size = new System.Drawing.Size(35, 35);
            this.dumpVMBtn.TabIndex = 16;
            this.toolTip.SetToolTip(this.dumpVMBtn, "Dump VM State");
            this.dumpVMBtn.UseVisualStyleBackColor = false;
            this.dumpVMBtn.Click += new System.EventHandler(this.DumpVMBtn_Click);
            // 
            // stepBtn
            // 
            this.stepBtn.BackgroundImage = global::SynacorDebug.Properties.Resources.down;
            this.stepBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.stepBtn.Enabled = false;
            this.stepBtn.FlatAppearance.BorderSize = 0;
            this.stepBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stepBtn.Location = new System.Drawing.Point(331, 5);
            this.stepBtn.Name = "stepBtn";
            this.stepBtn.Size = new System.Drawing.Size(35, 35);
            this.stepBtn.TabIndex = 13;
            this.toolTip.SetToolTip(this.stepBtn, "Execute One Instruction");
            this.stepBtn.UseVisualStyleBackColor = false;
            this.stepBtn.Click += new System.EventHandler(this.StepBtn_Click);
            // 
            // stopBtn
            // 
            this.stopBtn.BackgroundImage = global::SynacorDebug.Properties.Resources.pause1;
            this.stopBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.stopBtn.Enabled = false;
            this.stopBtn.FlatAppearance.BorderSize = 0;
            this.stopBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stopBtn.Location = new System.Drawing.Point(290, 5);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(35, 35);
            this.stopBtn.TabIndex = 12;
            this.toolTip.SetToolTip(this.stopBtn, "Pause Execution");
            this.stopBtn.UseVisualStyleBackColor = false;
            this.stopBtn.Click += new System.EventHandler(this.StopBtn_Click);
            // 
            // startBtn
            // 
            this.startBtn.BackgroundImage = global::SynacorDebug.Properties.Resources.play1;
            this.startBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.startBtn.Enabled = false;
            this.startBtn.FlatAppearance.BorderSize = 0;
            this.startBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startBtn.Location = new System.Drawing.Point(249, 5);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(35, 35);
            this.startBtn.TabIndex = 11;
            this.toolTip.SetToolTip(this.startBtn, "Resume Execution");
            this.startBtn.UseVisualStyleBackColor = false;
            this.startBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // resetBtn
            // 
            this.resetBtn.BackgroundImage = global::SynacorDebug.Properties.Resources.reset;
            this.resetBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.resetBtn.FlatAppearance.BorderSize = 0;
            this.resetBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resetBtn.Location = new System.Drawing.Point(554, 5);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(35, 35);
            this.resetBtn.TabIndex = 9;
            this.toolTip.SetToolTip(this.resetBtn, "Reset All");
            this.resetBtn.UseVisualStyleBackColor = false;
            this.resetBtn.Click += new System.EventHandler(this.ResetBtn_Click);
            // 
            // newFromBinBtn
            // 
            this.newFromBinBtn.BackgroundImage = global::SynacorDebug.Properties.Resources._new;
            this.newFromBinBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.newFromBinBtn.FlatAppearance.BorderSize = 0;
            this.newFromBinBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newFromBinBtn.Location = new System.Drawing.Point(431, 5);
            this.newFromBinBtn.Name = "newFromBinBtn";
            this.newFromBinBtn.Size = new System.Drawing.Size(35, 35);
            this.newFromBinBtn.TabIndex = 8;
            this.toolTip.SetToolTip(this.newFromBinBtn, "Load New From .bin");
            this.newFromBinBtn.UseVisualStyleBackColor = false;
            this.newFromBinBtn.Click += new System.EventHandler(this.NewFromBinBtn_Click);
            // 
            // saveStateBtn
            // 
            this.saveStateBtn.BackgroundImage = global::SynacorDebug.Properties.Resources.save;
            this.saveStateBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.saveStateBtn.Enabled = false;
            this.saveStateBtn.FlatAppearance.BorderSize = 0;
            this.saveStateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveStateBtn.Location = new System.Drawing.Point(472, 5);
            this.saveStateBtn.Name = "saveStateBtn";
            this.saveStateBtn.Size = new System.Drawing.Size(35, 35);
            this.saveStateBtn.TabIndex = 6;
            this.toolTip.SetToolTip(this.saveStateBtn, "Save VM State");
            this.saveStateBtn.UseVisualStyleBackColor = false;
            this.saveStateBtn.Click += new System.EventHandler(this.SaveStateBtn_Click);
            // 
            // loadStateBtn
            // 
            this.loadStateBtn.BackgroundImage = global::SynacorDebug.Properties.Resources.open;
            this.loadStateBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.loadStateBtn.FlatAppearance.BorderSize = 0;
            this.loadStateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadStateBtn.Location = new System.Drawing.Point(513, 5);
            this.loadStateBtn.Name = "loadStateBtn";
            this.loadStateBtn.Size = new System.Drawing.Size(35, 35);
            this.loadStateBtn.TabIndex = 5;
            this.toolTip.SetToolTip(this.loadStateBtn, "Load Saved VM State");
            this.loadStateBtn.UseVisualStyleBackColor = false;
            this.loadStateBtn.Click += new System.EventHandler(this.LoadStateBtn_Click);
            // 
            // r7Bx
            // 
            this.r7Bx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(123)))), ((int)(((byte)(160)))));
            this.r7Bx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.r7Bx.ForeColor = System.Drawing.Color.White;
            this.r7Bx.Location = new System.Drawing.Point(1126, 14);
            this.r7Bx.Maximum = new decimal(new int[] {
            32768,
            0,
            0,
            0});
            this.r7Bx.Name = "r7Bx";
            this.r7Bx.Size = new System.Drawing.Size(59, 18);
            this.r7Bx.TabIndex = 32;
            this.r7Bx.Tag = "requireMachine";
            this.r7Bx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.r7Bx.ThousandsSeparator = true;
            // 
            // pointerBx
            // 
            this.pointerBx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(148)))));
            this.pointerBx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pointerBx.ForeColor = System.Drawing.Color.White;
            this.pointerBx.Location = new System.Drawing.Point(156, 34);
            this.pointerBx.Maximum = new decimal(new int[] {
            32768,
            0,
            0,
            0});
            this.pointerBx.Name = "pointerBx";
            this.pointerBx.Size = new System.Drawing.Size(59, 18);
            this.pointerBx.TabIndex = 16;
            this.pointerBx.Tag = "requireMachine";
            this.pointerBx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.pointerBx.ThousandsSeparator = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(156, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 14);
            this.label3.TabIndex = 15;
            this.label3.Text = "Pointer";
            // 
            // r6Bx
            // 
            this.r6Bx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(123)))), ((int)(((byte)(160)))));
            this.r6Bx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.r6Bx.ForeColor = System.Drawing.Color.White;
            this.r6Bx.Location = new System.Drawing.Point(1061, 14);
            this.r6Bx.Maximum = new decimal(new int[] {
            32768,
            0,
            0,
            0});
            this.r6Bx.Name = "r6Bx";
            this.r6Bx.Size = new System.Drawing.Size(59, 18);
            this.r6Bx.TabIndex = 30;
            this.r6Bx.Tag = "requireMachine";
            this.r6Bx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.r6Bx.ThousandsSeparator = true;
            // 
            // r5Bx
            // 
            this.r5Bx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(123)))), ((int)(((byte)(160)))));
            this.r5Bx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.r5Bx.ForeColor = System.Drawing.Color.White;
            this.r5Bx.Location = new System.Drawing.Point(996, 14);
            this.r5Bx.Maximum = new decimal(new int[] {
            32768,
            0,
            0,
            0});
            this.r5Bx.Name = "r5Bx";
            this.r5Bx.Size = new System.Drawing.Size(59, 18);
            this.r5Bx.TabIndex = 28;
            this.r5Bx.Tag = "requireMachine";
            this.r5Bx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.r5Bx.ThousandsSeparator = true;
            // 
            // r4Bx
            // 
            this.r4Bx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(123)))), ((int)(((byte)(160)))));
            this.r4Bx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.r4Bx.ForeColor = System.Drawing.Color.White;
            this.r4Bx.Location = new System.Drawing.Point(931, 14);
            this.r4Bx.Maximum = new decimal(new int[] {
            32768,
            0,
            0,
            0});
            this.r4Bx.Name = "r4Bx";
            this.r4Bx.Size = new System.Drawing.Size(59, 18);
            this.r4Bx.TabIndex = 26;
            this.r4Bx.Tag = "requireMachine";
            this.r4Bx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.r4Bx.ThousandsSeparator = true;
            // 
            // r3Bx
            // 
            this.r3Bx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(123)))), ((int)(((byte)(160)))));
            this.r3Bx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.r3Bx.ForeColor = System.Drawing.Color.White;
            this.r3Bx.Location = new System.Drawing.Point(866, 14);
            this.r3Bx.Maximum = new decimal(new int[] {
            32768,
            0,
            0,
            0});
            this.r3Bx.Name = "r3Bx";
            this.r3Bx.Size = new System.Drawing.Size(59, 18);
            this.r3Bx.TabIndex = 24;
            this.r3Bx.Tag = "requireMachine";
            this.r3Bx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.r3Bx.ThousandsSeparator = true;
            // 
            // r2Bx
            // 
            this.r2Bx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(123)))), ((int)(((byte)(160)))));
            this.r2Bx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.r2Bx.ForeColor = System.Drawing.Color.White;
            this.r2Bx.Location = new System.Drawing.Point(801, 14);
            this.r2Bx.Maximum = new decimal(new int[] {
            32768,
            0,
            0,
            0});
            this.r2Bx.Name = "r2Bx";
            this.r2Bx.Size = new System.Drawing.Size(59, 18);
            this.r2Bx.TabIndex = 22;
            this.r2Bx.Tag = "requireMachine";
            this.r2Bx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.r2Bx.ThousandsSeparator = true;
            // 
            // r1Bx
            // 
            this.r1Bx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(123)))), ((int)(((byte)(160)))));
            this.r1Bx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.r1Bx.ForeColor = System.Drawing.Color.White;
            this.r1Bx.Location = new System.Drawing.Point(736, 14);
            this.r1Bx.Maximum = new decimal(new int[] {
            32768,
            0,
            0,
            0});
            this.r1Bx.Name = "r1Bx";
            this.r1Bx.Size = new System.Drawing.Size(59, 18);
            this.r1Bx.TabIndex = 20;
            this.r1Bx.Tag = "requireMachine";
            this.r1Bx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.r1Bx.ThousandsSeparator = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(595, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 14);
            this.label5.TabIndex = 6;
            this.label5.Text = "Registers";
            // 
            // r0Bx
            // 
            this.r0Bx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(123)))), ((int)(((byte)(160)))));
            this.r0Bx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.r0Bx.ForeColor = System.Drawing.Color.White;
            this.r0Bx.Location = new System.Drawing.Point(671, 14);
            this.r0Bx.Maximum = new decimal(new int[] {
            32768,
            0,
            0,
            0});
            this.r0Bx.Name = "r0Bx";
            this.r0Bx.Size = new System.Drawing.Size(59, 18);
            this.r0Bx.TabIndex = 18;
            this.r0Bx.Tag = "requireMachine";
            this.r0Bx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.r0Bx.ThousandsSeparator = true;
            // 
            // consoleOutBx
            // 
            this.consoleOutBx.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.consoleOutBx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.consoleOutBx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.consoleOutBx.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.consoleOutBx.ForeColor = System.Drawing.Color.White;
            this.consoleOutBx.HideSelection = false;
            this.consoleOutBx.Location = new System.Drawing.Point(249, 47);
            this.consoleOutBx.Name = "consoleOutBx";
            this.consoleOutBx.ReadOnly = true;
            this.consoleOutBx.Size = new System.Drawing.Size(1019, 429);
            this.consoleOutBx.TabIndex = 36;
            this.consoleOutBx.Text = "";
            // 
            // consoleInBx
            // 
            this.consoleInBx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.consoleInBx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(123)))), ((int)(((byte)(160)))));
            this.consoleInBx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.consoleInBx.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.consoleInBx.ForeColor = System.Drawing.Color.White;
            this.consoleInBx.Location = new System.Drawing.Point(258, 482);
            this.consoleInBx.Multiline = true;
            this.consoleInBx.Name = "consoleInBx";
            this.consoleInBx.Size = new System.Drawing.Size(997, 39);
            this.consoleInBx.TabIndex = 37;
            this.consoleInBx.TextChanged += new System.EventHandler(this.ConsoleInBx_TextChanged);
            this.consoleInBx.Resize += new System.EventHandler(this.Resize_RoundedControl);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 14);
            this.label4.TabIndex = 39;
            this.label4.Text = "Instruction History";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.label1.Location = new System.Drawing.Point(76, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 28);
            this.label1.TabIndex = 41;
            this.label1.Text = "SYNACOR";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SynacorDebug_MouseDown);
            // 
            // exitBtn
            // 
            this.exitBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exitBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.exitBtn.FlatAppearance.BorderSize = 0;
            this.exitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitBtn.Font = new System.Drawing.Font("Cooper Black", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.exitBtn.Location = new System.Drawing.Point(1233, 6);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(35, 35);
            this.exitBtn.TabIndex = 42;
            this.exitBtn.Text = "✕";
            this.toolTip.SetToolTip(this.exitBtn, "Exit");
            this.exitBtn.UseVisualStyleBackColor = false;
            this.exitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // setRegisters
            // 
            this.setRegisters.BackgroundImage = global::SynacorDebug.Properties.Resources.edit;
            this.setRegisters.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.setRegisters.FlatAppearance.BorderSize = 0;
            this.setRegisters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setRegisters.Location = new System.Drawing.Point(95, 17);
            this.setRegisters.Name = "setRegisters";
            this.setRegisters.Size = new System.Drawing.Size(35, 35);
            this.setRegisters.TabIndex = 43;
            this.setRegisters.Tag = "requireMachine";
            this.toolTip.SetToolTip(this.setRegisters, "Update Registers and Pointer");
            this.setRegisters.UseVisualStyleBackColor = false;
            this.setRegisters.Click += new System.EventHandler(this.SetRegisters_Click);
            // 
            // maxBtn
            // 
            this.maxBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maxBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.maxBtn.FlatAppearance.BorderSize = 0;
            this.maxBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.maxBtn.Font = new System.Drawing.Font("Cooper Black", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.maxBtn.Location = new System.Drawing.Point(1192, 6);
            this.maxBtn.Name = "maxBtn";
            this.maxBtn.Size = new System.Drawing.Size(35, 35);
            this.maxBtn.TabIndex = 42;
            this.maxBtn.Text = "🗖";
            this.toolTip.SetToolTip(this.maxBtn, "Maximize");
            this.maxBtn.UseVisualStyleBackColor = false;
            this.maxBtn.Click += new System.EventHandler(this.MaxBtn_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.panel1.Controls.Add(this.setRegisters);
            this.panel1.Controls.Add(this.dumpVMBtn);
            this.panel1.Controls.Add(this.pointerBx);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(12, 482);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(231, 68);
            this.panel1.TabIndex = 49;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.panel2.Controls.Add(this.historyCheckBx);
            this.panel2.Controls.Add(this.statusStrip1);
            this.panel2.Location = new System.Drawing.Point(249, 470);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1019, 77);
            this.panel2.TabIndex = 50;
            // 
            // historyCheckBx
            // 
            this.historyCheckBx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.historyCheckBx.AutoSize = true;
            this.historyCheckBx.Location = new System.Drawing.Point(736, 55);
            this.historyCheckBx.Name = "historyCheckBx";
            this.historyCheckBx.Size = new System.Drawing.Size(159, 18);
            this.historyCheckBx.TabIndex = 44;
            this.historyCheckBx.Text = "Instruction History";
            this.historyCheckBx.UseVisualStyleBackColor = true;
            this.historyCheckBx.CheckedChanged += new System.EventHandler(this.HistoryCheckBx_CheckedChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.stepsLabel,
            this.stepsSpeedLabel,
            this.textQueueLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 55);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1019, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 0;
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(118, 17);
            this.statusLabel.Text = "toolStripStatusLabel1";
            // 
            // stepsLabel
            // 
            this.stepsLabel.Margin = new System.Windows.Forms.Padding(15, 3, 0, 2);
            this.stepsLabel.Name = "stepsLabel";
            this.stepsLabel.Size = new System.Drawing.Size(118, 17);
            this.stepsLabel.Text = "toolStripStatusLabel1";
            // 
            // stepsSpeedLabel
            // 
            this.stepsSpeedLabel.Margin = new System.Windows.Forms.Padding(15, 3, 0, 2);
            this.stepsSpeedLabel.Name = "stepsSpeedLabel";
            this.stepsSpeedLabel.Size = new System.Drawing.Size(118, 17);
            this.stepsSpeedLabel.Text = "toolStripStatusLabel1";
            // 
            // textQueueLabel
            // 
            this.textQueueLabel.Margin = new System.Windows.Forms.Padding(15, 3, 0, 2);
            this.textQueueLabel.Name = "textQueueLabel";
            this.textQueueLabel.Size = new System.Drawing.Size(118, 17);
            this.textQueueLabel.Text = "toolStripStatusLabel1";
            // 
            // delayBx
            // 
            this.delayBx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(123)))), ((int)(((byte)(160)))));
            this.delayBx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.delayBx.DecimalPlaces = 3;
            this.delayBx.ForeColor = System.Drawing.Color.White;
            this.delayBx.Location = new System.Drawing.Point(366, 21);
            this.delayBx.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.delayBx.Name = "delayBx";
            this.delayBx.Size = new System.Drawing.Size(59, 18);
            this.delayBx.TabIndex = 46;
            this.delayBx.Tag = "requireMachine";
            this.delayBx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.delayBx.ThousandsSeparator = true;
            this.delayBx.ValueChanged += new System.EventHandler(this.DelayBx_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(366, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 45;
            this.label2.Text = "MS Delay";
            // 
            // SynacorDebug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(148)))));
            this.ClientSize = new System.Drawing.Size(1280, 546);
            this.ControlBox = false;
            this.Controls.Add(this.delayBx);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.maxBtn);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.resetBtn);
            this.Controls.Add(this.r7Bx);
            this.Controls.Add(this.newFromBinBtn);
            this.Controls.Add(this.r6Bx);
            this.Controls.Add(this.saveStateBtn);
            this.Controls.Add(this.r5Bx);
            this.Controls.Add(this.loadStateBtn);
            this.Controls.Add(this.r4Bx);
            this.Controls.Add(this.r3Bx);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.stepBtn);
            this.Controls.Add(this.r2Bx);
            this.Controls.Add(this.stopBtn);
            this.Controls.Add(this.consoleInBx);
            this.Controls.Add(this.r1Bx);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.consoleOutBx);
            this.Controls.Add(this.r0Bx);
            this.Controls.Add(this.historyBx);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(1280, 281);
            this.Name = "SynacorDebug";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "https://coolors.co/13293d-006494-247ba0-1b98e0-e8f1f2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnFormClosed);
            this.Load += new System.EventHandler(this.SynacorDebug_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SynacorDebug_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.r7Bx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointerBx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.r6Bx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.r5Bx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.r4Bx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.r3Bx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.r2Bx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.r1Bx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.r0Bx)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.delayBx)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox historyBx;
        private System.Windows.Forms.Button saveStateBtn;
        private System.Windows.Forms.Button loadStateBtn;
        private System.Windows.Forms.Button resetBtn;
        private System.Windows.Forms.Button newFromBinBtn;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Button stepBtn;
        private System.Windows.Forms.Button stopBtn;
        private System.Windows.Forms.NumericUpDown r7Bx;
        private System.Windows.Forms.NumericUpDown r6Bx;
        private System.Windows.Forms.NumericUpDown r5Bx;
        private System.Windows.Forms.NumericUpDown r4Bx;
        private System.Windows.Forms.NumericUpDown r3Bx;
        private System.Windows.Forms.NumericUpDown r2Bx;
        private System.Windows.Forms.NumericUpDown r1Bx;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown pointerBx;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown r0Bx;
        private System.Windows.Forms.RichTextBox consoleOutBx;
        private System.Windows.Forms.TextBox consoleInBx;
        private System.Windows.Forms.Button dumpVMBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.Button setRegisters;
        private System.Windows.Forms.Button maxBtn;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripStatusLabel stepsLabel;
        private System.Windows.Forms.ToolStripStatusLabel stepsSpeedLabel;
        private System.Windows.Forms.ToolStripStatusLabel textQueueLabel;
        private System.Windows.Forms.NumericUpDown delayBx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox historyCheckBx;
    }
}
