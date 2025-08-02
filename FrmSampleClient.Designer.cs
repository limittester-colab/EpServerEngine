namespace EpServerEngineSampleClient
{
    partial class FrmSampleClient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			this.tbReceived = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tbPort = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.table = new System.Data.DataTable();
			this.tbConnected = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cbIPAdress = new System.Windows.Forms.ComboBox();
			this.btnFnc3 = new System.Windows.Forms.Button();
			this.btnClear = new System.Windows.Forms.Button();
			this.btnFnc1 = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.lbAvailClients = new System.Windows.Forms.ListBox();
			this.tbTodaysDate = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.tbTime = new System.Windows.Forms.TextBox();
			this.btnFnc2 = new System.Windows.Forms.Button();
			this.btnMinimize = new System.Windows.Forms.Button();
			this.btnFnc4 = new System.Windows.Forms.Button();
			this.btnFnc5 = new System.Windows.Forms.Button();
			this.btnSendSort = new System.Windows.Forms.Button();
			this.label9 = new System.Windows.Forms.Label();
			this.timer3 = new System.Windows.Forms.Timer(this.components);
			this.AlertLabel = new System.Windows.Forms.Label();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.clientControlsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cabinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.garageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.testbenchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.outdoorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.utilsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.dS1620ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.minimizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.clearScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.assignFunctionKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.clientListActionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showTimeUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.getTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.setTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.rebootToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToShellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.shutdownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.getStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sendMessageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sendClientListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.btnConnect = new System.Windows.Forms.Button();
			this.btnExit = new System.Windows.Forms.Button();
			this.btnWaterTimeShort = new System.Windows.Forms.Button();
			this.btnWaterTimeMedium = new System.Windows.Forms.Button();
			this.btnWaterTimeLong = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.SendMessageBox = new System.Windows.Forms.TextBox();
			this.btnFnc6 = new System.Windows.Forms.Button();
			this.btnFnc7 = new System.Windows.Forms.Button();
			this.tbMinTemp = new System.Windows.Forms.TextBox();
			this.btn_light_list = new System.Windows.Forms.Button();
			this.tbHeaterTimeOn = new System.Windows.Forms.TextBox();
			this.tbHeaterTimeOff = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.btnHeaterApply = new System.Windows.Forms.Button();
			this.btnHeaterTimer = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.table)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbReceived
			// 
			this.tbReceived.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.tbReceived.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbReceived.Location = new System.Drawing.Point(230, 219);
			this.tbReceived.Multiline = true;
			this.tbReceived.Name = "tbReceived";
			this.tbReceived.ReadOnly = true;
			this.tbReceived.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbReceived.Size = new System.Drawing.Size(193, 205);
			this.tbReceived.TabIndex = 16;
			this.tbReceived.TabStop = false;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(24, 74);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(46, 20);
			this.label2.TabIndex = 3;
			this.label2.Text = "port:";
			// 
			// tbPort
			// 
			this.tbPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbPort.Location = new System.Drawing.Point(103, 69);
			this.tbPort.Name = "tbPort";
			this.tbPort.Size = new System.Drawing.Size(90, 29);
			this.tbPort.TabIndex = 1;
			this.tbPort.Text = "5193";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(24, 31);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(49, 20);
			this.label1.TabIndex = 1;
			this.label1.Text = "host:";
			// 
			// tbConnected
			// 
			this.tbConnected.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbConnected.Location = new System.Drawing.Point(102, 108);
			this.tbConnected.Name = "tbConnected";
			this.tbConnected.ReadOnly = true;
			this.tbConnected.Size = new System.Drawing.Size(171, 29);
			this.tbConnected.TabIndex = 13;
			this.tbConnected.TabStop = false;
			this.tbConnected.Text = "not connected";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(23, 113);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(67, 20);
			this.label3.TabIndex = 7;
			this.label3.Text = "Status:";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.cbIPAdress);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.tbConnected);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.tbPort);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(479, 172);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(300, 160);
			this.groupBox1.TabIndex = 34;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "TCP Status";
			// 
			// cbIPAdress
			// 
			this.cbIPAdress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbIPAdress.FormattingEnabled = true;
			this.cbIPAdress.Location = new System.Drawing.Point(102, 28);
			this.cbIPAdress.Name = "cbIPAdress";
			this.cbIPAdress.Size = new System.Drawing.Size(171, 28);
			this.cbIPAdress.TabIndex = 0;
			this.cbIPAdress.SelectedIndexChanged += new System.EventHandler(this.IPAddressChanged);
			// 
			// btnFnc3
			// 
			this.btnFnc3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.btnFnc3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnFnc3.Location = new System.Drawing.Point(139, 42);
			this.btnFnc3.Name = "btnFnc3";
			this.btnFnc3.Size = new System.Drawing.Size(52, 47);
			this.btnFnc3.TabIndex = 24;
			this.btnFnc3.Text = "F3";
			this.btnFnc3.UseVisualStyleBackColor = false;
			this.btnFnc3.Click += new System.EventHandler(this.Function3Click);
			// 
			// btnClear
			// 
			this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnClear.Location = new System.Drawing.Point(23, 104);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(193, 38);
			this.btnClear.TabIndex = 6;
			this.btnClear.Text = "Clear Screen";
			this.btnClear.UseVisualStyleBackColor = false;
			this.btnClear.Click += new System.EventHandler(this.ClearScreen);
			// 
			// btnFnc1
			// 
			this.btnFnc1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.btnFnc1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnFnc1.Location = new System.Drawing.Point(23, 42);
			this.btnFnc1.Name = "btnFnc1";
			this.btnFnc1.Size = new System.Drawing.Size(52, 47);
			this.btnFnc1.TabIndex = 22;
			this.btnFnc1.Text = "F1";
			this.btnFnc1.UseVisualStyleBackColor = false;
			this.btnFnc1.Click += new System.EventHandler(this.Function1Click);
			// 
			// timer1
			// 
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.myTimerTick);
			// 
			// lbAvailClients
			// 
			this.lbAvailClients.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbAvailClients.FormattingEnabled = true;
			this.lbAvailClients.ItemHeight = 15;
			this.lbAvailClients.Location = new System.Drawing.Point(707, 42);
			this.lbAvailClients.Name = "lbAvailClients";
			this.lbAvailClients.Size = new System.Drawing.Size(92, 94);
			this.lbAvailClients.TabIndex = 35;
			this.lbAvailClients.SelectedIndexChanged += new System.EventHandler(this.AvailClientSelIndexChanged);
			// 
			// tbTodaysDate
			// 
			this.tbTodaysDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbTodaysDate.Location = new System.Drawing.Point(509, 42);
			this.tbTodaysDate.Name = "tbTodaysDate";
			this.tbTodaysDate.Size = new System.Drawing.Size(183, 44);
			this.tbTodaysDate.TabIndex = 15;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label10.Location = new System.Drawing.Point(450, 55);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(53, 20);
			this.label10.TabIndex = 57;
			this.label10.Text = "Date:";
			// 
			// tbTime
			// 
			this.tbTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tbTime.Location = new System.Drawing.Point(509, 99);
			this.tbTime.Name = "tbTime";
			this.tbTime.Size = new System.Drawing.Size(183, 44);
			this.tbTime.TabIndex = 16;
			// 
			// btnFnc2
			// 
			this.btnFnc2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.btnFnc2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnFnc2.Location = new System.Drawing.Point(81, 42);
			this.btnFnc2.Name = "btnFnc2";
			this.btnFnc2.Size = new System.Drawing.Size(52, 47);
			this.btnFnc2.TabIndex = 23;
			this.btnFnc2.Text = "F2";
			this.btnFnc2.UseVisualStyleBackColor = false;
			this.btnFnc2.Click += new System.EventHandler(this.Function2Click);
			// 
			// btnMinimize
			// 
			this.btnMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnMinimize.Location = new System.Drawing.Point(23, 157);
			this.btnMinimize.Name = "btnMinimize";
			this.btnMinimize.Size = new System.Drawing.Size(193, 38);
			this.btnMinimize.TabIndex = 7;
			this.btnMinimize.Text = "Minimize";
			this.btnMinimize.UseVisualStyleBackColor = false;
			this.btnMinimize.Click += new System.EventHandler(this.Minimize_Click);
			// 
			// btnFnc4
			// 
			this.btnFnc4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.btnFnc4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnFnc4.Location = new System.Drawing.Point(197, 42);
			this.btnFnc4.Name = "btnFnc4";
			this.btnFnc4.Size = new System.Drawing.Size(52, 47);
			this.btnFnc4.TabIndex = 25;
			this.btnFnc4.Text = "F4";
			this.btnFnc4.UseVisualStyleBackColor = false;
			this.btnFnc4.Click += new System.EventHandler(this.btnFnc4_Click);
			// 
			// btnFnc5
			// 
			this.btnFnc5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.btnFnc5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnFnc5.Location = new System.Drawing.Point(255, 42);
			this.btnFnc5.Name = "btnFnc5";
			this.btnFnc5.Size = new System.Drawing.Size(52, 47);
			this.btnFnc5.TabIndex = 26;
			this.btnFnc5.Text = "F5";
			this.btnFnc5.UseVisualStyleBackColor = false;
			this.btnFnc5.Click += new System.EventHandler(this.btnFcn5_Click);
			// 
			// btnSendSort
			// 
			this.btnSendSort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.btnSendSort.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSendSort.Location = new System.Drawing.Point(230, 157);
			this.btnSendSort.Name = "btnSendSort";
			this.btnSendSort.Size = new System.Drawing.Size(193, 38);
			this.btnSendSort.TabIndex = 15;
			this.btnSendSort.Text = "Display Sort";
			this.btnSendSort.UseVisualStyleBackColor = false;
			this.btnSendSort.Click += new System.EventHandler(this.btnSendSort_Click);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(449, 110);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(52, 20);
			this.label9.TabIndex = 88;
			this.label9.Text = "Time:";
			// 
			// timer3
			// 
			this.timer3.Interval = 1200000;
			this.timer3.Tick += new System.EventHandler(this.timer3_tick);
			// 
			// AlertLabel
			// 
			this.AlertLabel.AutoSize = true;
			this.AlertLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AlertLabel.Location = new System.Drawing.Point(805, 124);
			this.AlertLabel.Name = "AlertLabel";
			this.AlertLabel.Size = new System.Drawing.Size(0, 20);
			this.AlertLabel.TabIndex = 0;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientControlsToolStripMenuItem,
            this.utilsToolStripMenuItem,
            this.clientListActionToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(979, 24);
			this.menuStrip1.TabIndex = 92;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// clientControlsToolStripMenuItem
			// 
			this.clientControlsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cabinToolStripMenuItem,
            this.garageToolStripMenuItem,
            this.testbenchToolStripMenuItem,
            this.outdoorToolStripMenuItem});
			this.clientControlsToolStripMenuItem.Name = "clientControlsToolStripMenuItem";
			this.clientControlsToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
			this.clientControlsToolStripMenuItem.Text = "Client Controls";
			// 
			// cabinToolStripMenuItem
			// 
			this.cabinToolStripMenuItem.Name = "cabinToolStripMenuItem";
			this.cabinToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
			this.cabinToolStripMenuItem.Text = "Cabin";
			this.cabinToolStripMenuItem.Click += new System.EventHandler(this.cabinToolStripMenuItem_Click);
			// 
			// garageToolStripMenuItem
			// 
			this.garageToolStripMenuItem.Name = "garageToolStripMenuItem";
			this.garageToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
			this.garageToolStripMenuItem.Text = "Garage";
			this.garageToolStripMenuItem.Click += new System.EventHandler(this.garageToolStripMenuItem_Click);
			// 
			// testbenchToolStripMenuItem
			// 
			this.testbenchToolStripMenuItem.Name = "testbenchToolStripMenuItem";
			this.testbenchToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
			this.testbenchToolStripMenuItem.Text = "Testbench";
			this.testbenchToolStripMenuItem.Click += new System.EventHandler(this.testbenchToolStripMenuItem_Click);
			// 
			// outdoorToolStripMenuItem
			// 
			this.outdoorToolStripMenuItem.Name = "outdoorToolStripMenuItem";
			this.outdoorToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
			this.outdoorToolStripMenuItem.Text = "Outdoor";
			this.outdoorToolStripMenuItem.Click += new System.EventHandler(this.outdoorToolStripMenuItem_Click);
			// 
			// utilsToolStripMenuItem
			// 
			this.utilsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dS1620ToolStripMenuItem,
            this.minimizeToolStripMenuItem,
            this.clearScreenToolStripMenuItem,
            this.assignFunctionKeyToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.utilsToolStripMenuItem.Name = "utilsToolStripMenuItem";
			this.utilsToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
			this.utilsToolStripMenuItem.Text = "Utils";
			// 
			// dS1620ToolStripMenuItem
			// 
			this.dS1620ToolStripMenuItem.Name = "dS1620ToolStripMenuItem";
			this.dS1620ToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.dS1620ToolStripMenuItem.Text = "DS1620";
			this.dS1620ToolStripMenuItem.Click += new System.EventHandler(this.dS1620ToolStripMenuItem_Click);
			// 
			// minimizeToolStripMenuItem
			// 
			this.minimizeToolStripMenuItem.Name = "minimizeToolStripMenuItem";
			this.minimizeToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.minimizeToolStripMenuItem.Text = "Minimize";
			this.minimizeToolStripMenuItem.Click += new System.EventHandler(this.minimizeToolStripMenuItem_Click);
			// 
			// clearScreenToolStripMenuItem
			// 
			this.clearScreenToolStripMenuItem.Name = "clearScreenToolStripMenuItem";
			this.clearScreenToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.clearScreenToolStripMenuItem.Text = "Clear Screen";
			this.clearScreenToolStripMenuItem.Click += new System.EventHandler(this.clearScreenToolStripMenuItem_Click);
			// 
			// assignFunctionKeyToolStripMenuItem
			// 
			this.assignFunctionKeyToolStripMenuItem.Name = "assignFunctionKeyToolStripMenuItem";
			this.assignFunctionKeyToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.assignFunctionKeyToolStripMenuItem.Text = "Assign Function Key";
			this.assignFunctionKeyToolStripMenuItem.Click += new System.EventHandler(this.assignFunctionKeyToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// clientListActionToolStripMenuItem
			// 
			this.clientListActionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showTimeUpToolStripMenuItem,
            this.getTimeToolStripMenuItem,
            this.setTimeToolStripMenuItem,
            this.rebootToolStripMenuItem,
            this.exitToShellToolStripMenuItem,
            this.shutdownToolStripMenuItem,
            this.getStatusToolStripMenuItem,
            this.sendMessageToolStripMenuItem,
            this.sendClientListToolStripMenuItem});
			this.clientListActionToolStripMenuItem.Name = "clientListActionToolStripMenuItem";
			this.clientListActionToolStripMenuItem.Size = new System.Drawing.Size(109, 20);
			this.clientListActionToolStripMenuItem.Text = "Client List Action";
			// 
			// showTimeUpToolStripMenuItem
			// 
			this.showTimeUpToolStripMenuItem.Name = "showTimeUpToolStripMenuItem";
			this.showTimeUpToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
			this.showTimeUpToolStripMenuItem.Text = "Show Time Up";
			this.showTimeUpToolStripMenuItem.Click += new System.EventHandler(this.showTimeUpToolStripMenuItem_Click);
			// 
			// getTimeToolStripMenuItem
			// 
			this.getTimeToolStripMenuItem.Name = "getTimeToolStripMenuItem";
			this.getTimeToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
			this.getTimeToolStripMenuItem.Text = "Get Time";
			this.getTimeToolStripMenuItem.Click += new System.EventHandler(this.getTimeToolStripMenuItem_Click);
			// 
			// setTimeToolStripMenuItem
			// 
			this.setTimeToolStripMenuItem.Name = "setTimeToolStripMenuItem";
			this.setTimeToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
			this.setTimeToolStripMenuItem.Text = "Set Time";
			this.setTimeToolStripMenuItem.Click += new System.EventHandler(this.setTimeToolStripMenuItem_Click);
			// 
			// rebootToolStripMenuItem
			// 
			this.rebootToolStripMenuItem.Name = "rebootToolStripMenuItem";
			this.rebootToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
			this.rebootToolStripMenuItem.Text = "Reboot";
			this.rebootToolStripMenuItem.Click += new System.EventHandler(this.rebootToolStripMenuItem_Click);
			// 
			// exitToShellToolStripMenuItem
			// 
			this.exitToShellToolStripMenuItem.Name = "exitToShellToolStripMenuItem";
			this.exitToShellToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
			this.exitToShellToolStripMenuItem.Text = "Exit to Shell";
			this.exitToShellToolStripMenuItem.Click += new System.EventHandler(this.exitToShellToolStripMenuItem_Click);
			// 
			// shutdownToolStripMenuItem
			// 
			this.shutdownToolStripMenuItem.Name = "shutdownToolStripMenuItem";
			this.shutdownToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
			this.shutdownToolStripMenuItem.Text = "Shutdown";
			this.shutdownToolStripMenuItem.Click += new System.EventHandler(this.shutdownToolStripMenuItem_Click);
			// 
			// getStatusToolStripMenuItem
			// 
			this.getStatusToolStripMenuItem.Name = "getStatusToolStripMenuItem";
			this.getStatusToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
			this.getStatusToolStripMenuItem.Text = "Get Status";
			this.getStatusToolStripMenuItem.Click += new System.EventHandler(this.getStatusToolStripMenuItem_Click);
			// 
			// sendMessageToolStripMenuItem
			// 
			this.sendMessageToolStripMenuItem.Name = "sendMessageToolStripMenuItem";
			this.sendMessageToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
			this.sendMessageToolStripMenuItem.Text = "Send Message";
			this.sendMessageToolStripMenuItem.Click += new System.EventHandler(this.sendMessageToolStripMenuItem_Click);
			// 
			// sendClientListToolStripMenuItem
			// 
			this.sendClientListToolStripMenuItem.Name = "sendClientListToolStripMenuItem";
			this.sendClientListToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
			this.sendClientListToolStripMenuItem.Text = "Update Client Table";
			this.sendClientListToolStripMenuItem.Click += new System.EventHandler(this.sendClientListToolStripMenuItem_Click);
			// 
			// btnConnect
			// 
			this.btnConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnConnect.Location = new System.Drawing.Point(230, 105);
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.Size = new System.Drawing.Size(193, 38);
			this.btnConnect.TabIndex = 93;
			this.btnConnect.Text = "Connect";
			this.btnConnect.UseVisualStyleBackColor = false;
			this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
			// 
			// btnExit
			// 
			this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnExit.Location = new System.Drawing.Point(23, 208);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(193, 38);
			this.btnExit.TabIndex = 94;
			this.btnExit.Text = "Exit";
			this.btnExit.UseVisualStyleBackColor = false;
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// btnWaterTimeShort
			// 
			this.btnWaterTimeShort.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnWaterTimeShort.Location = new System.Drawing.Point(22, 28);
			this.btnWaterTimeShort.Name = "btnWaterTimeShort";
			this.btnWaterTimeShort.Size = new System.Drawing.Size(98, 33);
			this.btnWaterTimeShort.TabIndex = 109;
			this.btnWaterTimeShort.Text = "Short";
			this.btnWaterTimeShort.UseVisualStyleBackColor = true;
			this.btnWaterTimeShort.Click += new System.EventHandler(this.btnWaterTimeShort_Click);
			// 
			// btnWaterTimeMedium
			// 
			this.btnWaterTimeMedium.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnWaterTimeMedium.Location = new System.Drawing.Point(22, 69);
			this.btnWaterTimeMedium.Name = "btnWaterTimeMedium";
			this.btnWaterTimeMedium.Size = new System.Drawing.Size(98, 33);
			this.btnWaterTimeMedium.TabIndex = 110;
			this.btnWaterTimeMedium.Text = "Medium";
			this.btnWaterTimeMedium.UseVisualStyleBackColor = true;
			this.btnWaterTimeMedium.Click += new System.EventHandler(this.btnWaterTimeMedium_Click);
			// 
			// btnWaterTimeLong
			// 
			this.btnWaterTimeLong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnWaterTimeLong.Location = new System.Drawing.Point(22, 110);
			this.btnWaterTimeLong.Name = "btnWaterTimeLong";
			this.btnWaterTimeLong.Size = new System.Drawing.Size(98, 33);
			this.btnWaterTimeLong.TabIndex = 111;
			this.btnWaterTimeLong.Text = "Long";
			this.btnWaterTimeLong.UseVisualStyleBackColor = true;
			this.btnWaterTimeLong.Click += new System.EventHandler(this.btnWaterTimeLong_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.btnWaterTimeMedium);
			this.groupBox2.Controls.Add(this.btnWaterTimeLong);
			this.groupBox2.Controls.Add(this.btnWaterTimeShort);
			this.groupBox2.Location = new System.Drawing.Point(818, 42);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(144, 153);
			this.groupBox2.TabIndex = 112;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Water Pump";
			// 
			// SendMessageBox
			// 
			this.SendMessageBox.Location = new System.Drawing.Point(479, 356);
			this.SendMessageBox.Name = "SendMessageBox";
			this.SendMessageBox.Size = new System.Drawing.Size(188, 20);
			this.SendMessageBox.TabIndex = 113;
			// 
			// btnFnc6
			// 
			this.btnFnc6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.btnFnc6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnFnc6.Location = new System.Drawing.Point(313, 42);
			this.btnFnc6.Name = "btnFnc6";
			this.btnFnc6.Size = new System.Drawing.Size(52, 47);
			this.btnFnc6.TabIndex = 114;
			this.btnFnc6.Text = "F6";
			this.btnFnc6.UseVisualStyleBackColor = false;
			this.btnFnc6.Click += new System.EventHandler(this.btnFnc6_Click);
			// 
			// btnFnc7
			// 
			this.btnFnc7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.btnFnc7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnFnc7.Location = new System.Drawing.Point(371, 42);
			this.btnFnc7.Name = "btnFnc7";
			this.btnFnc7.Size = new System.Drawing.Size(52, 47);
			this.btnFnc7.TabIndex = 115;
			this.btnFnc7.Text = "F7";
			this.btnFnc7.UseVisualStyleBackColor = false;
			this.btnFnc7.Click += new System.EventHandler(this.btnFnc7_Click);
			// 
			// tbMinTemp
			// 
			this.tbMinTemp.Location = new System.Drawing.Point(707, 356);
			this.tbMinTemp.Name = "tbMinTemp";
			this.tbMinTemp.Size = new System.Drawing.Size(43, 20);
			this.tbMinTemp.TabIndex = 116;
			this.tbMinTemp.TextChanged += new System.EventHandler(this.minTempChanged);
			// 
			// btn_light_list
			// 
			this.btn_light_list.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_light_list.Location = new System.Drawing.Point(840, 213);
			this.btn_light_list.Name = "btn_light_list";
			this.btn_light_list.Size = new System.Drawing.Size(98, 33);
			this.btn_light_list.TabIndex = 117;
			this.btn_light_list.Text = "List";
			this.btn_light_list.UseVisualStyleBackColor = true;
			this.btn_light_list.Click += new System.EventHandler(this.button1_Click);
			// 
			// tbHeaterTimeOn
			// 
			this.tbHeaterTimeOn.Location = new System.Drawing.Point(880, 275);
			this.tbHeaterTimeOn.Name = "tbHeaterTimeOn";
			this.tbHeaterTimeOn.Size = new System.Drawing.Size(60, 20);
			this.tbHeaterTimeOn.TabIndex = 118;
			this.tbHeaterTimeOn.TextChanged += new System.EventHandler(this.tbHeaterTimeOn_TextChanged);
			// 
			// tbHeaterTimeOff
			// 
			this.tbHeaterTimeOff.Location = new System.Drawing.Point(880, 321);
			this.tbHeaterTimeOff.Name = "tbHeaterTimeOff";
			this.tbHeaterTimeOff.Size = new System.Drawing.Size(60, 20);
			this.tbHeaterTimeOff.TabIndex = 119;
			this.tbHeaterTimeOff.TextChanged += new System.EventHandler(this.tbHeaterTimeOff_TextChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(856, 257);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(82, 13);
			this.label4.TabIndex = 120;
			this.label4.Text = "Heater Time On";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(856, 305);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(82, 13);
			this.label5.TabIndex = 121;
			this.label5.Text = "Heater Time Off";
			// 
			// btnHeaterApply
			// 
			this.btnHeaterApply.Location = new System.Drawing.Point(865, 356);
			this.btnHeaterApply.Name = "btnHeaterApply";
			this.btnHeaterApply.Size = new System.Drawing.Size(75, 23);
			this.btnHeaterApply.TabIndex = 122;
			this.btnHeaterApply.Text = "Apply";
			this.btnHeaterApply.UseVisualStyleBackColor = true;
			this.btnHeaterApply.Click += new System.EventHandler(this.btnHeaterApply_Click);
			// 
			// btnHeaterTimer
			// 
			this.btnHeaterTimer.Location = new System.Drawing.Point(865, 385);
			this.btnHeaterTimer.Name = "btnHeaterTimer";
			this.btnHeaterTimer.Size = new System.Drawing.Size(75, 23);
			this.btnHeaterTimer.TabIndex = 123;
			this.btnHeaterTimer.Text = "Heater Off";
			this.btnHeaterTimer.UseVisualStyleBackColor = true;
			this.btnHeaterTimer.Click += new System.EventHandler(this.btnHeaterTimer_Click);
			// 
			// FrmSampleClient
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.ClientSize = new System.Drawing.Size(979, 446);
			this.Controls.Add(this.btnHeaterTimer);
			this.Controls.Add(this.btnHeaterApply);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.tbHeaterTimeOff);
			this.Controls.Add(this.tbHeaterTimeOn);
			this.Controls.Add(this.btn_light_list);
			this.Controls.Add(this.tbMinTemp);
			this.Controls.Add(this.btnFnc7);
			this.Controls.Add(this.btnFnc6);
			this.Controls.Add(this.SendMessageBox);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.btnConnect);
			this.Controls.Add(this.AlertLabel);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.btnSendSort);
			this.Controls.Add(this.btnFnc5);
			this.Controls.Add(this.btnFnc4);
			this.Controls.Add(this.btnMinimize);
			this.Controls.Add(this.btnFnc2);
			this.Controls.Add(this.tbTime);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.tbTodaysDate);
			this.Controls.Add(this.lbAvailClients);
			this.Controls.Add(this.btnFnc1);
			this.Controls.Add(this.btnClear);
			this.Controls.Add(this.btnFnc3);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.tbReceived);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.Name = "FrmSampleClient";
			this.ShowIcon = false;
			this.Text = "SampleClient";
			this.Load += new System.EventHandler(this.FrmSampleClient_Load);
			((System.ComponentModel.ISupportInitialize)(this.table)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbReceived;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Label label1;
        private System.Data.DataTable table;
        private System.Windows.Forms.TextBox tbConnected;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnFnc3;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnFnc1;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.ComboBox cbIPAdress;
		private System.Windows.Forms.ListBox lbAvailClients;
		private System.Windows.Forms.TextBox tbTodaysDate;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox tbTime;
		private System.Windows.Forms.Button btnFnc2;
		private System.Windows.Forms.Button btnMinimize;
		private System.Windows.Forms.Button btnFnc4;
		private System.Windows.Forms.Button btnFnc5;
		private System.Windows.Forms.Button btnSendSort;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Timer timer3;
		private System.Windows.Forms.Label AlertLabel;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem clientControlsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cabinToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem garageToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem testbenchToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem outdoorToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem utilsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem dS1620ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem minimizeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem clearScreenToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem assignFunctionKeyToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem clientListActionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToShellToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem showTimeUpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem getTimeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem setTimeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem rebootToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem shutdownToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem getStatusToolStripMenuItem;
		private System.Windows.Forms.Button btnConnect;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.Button btnWaterTimeShort;
		private System.Windows.Forms.Button btnWaterTimeMedium;
		private System.Windows.Forms.Button btnWaterTimeLong;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ToolStripMenuItem sendMessageToolStripMenuItem;
		private System.Windows.Forms.TextBox SendMessageBox;
		private System.Windows.Forms.Button btnFnc6;
		private System.Windows.Forms.Button btnFnc7;
		private System.Windows.Forms.TextBox tbMinTemp;
		private System.Windows.Forms.Button btn_light_list;
		private System.Windows.Forms.ToolStripMenuItem sendClientListToolStripMenuItem;
		private System.Windows.Forms.TextBox tbHeaterTimeOn;
		private System.Windows.Forms.TextBox tbHeaterTimeOff;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btnHeaterApply;
		private System.Windows.Forms.Button btnHeaterTimer;
	}
}

