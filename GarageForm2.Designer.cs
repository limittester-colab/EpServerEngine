namespace EpServerEngineSampleClient
{
	partial class GarageForm2
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
			this.btnWaterHeater = new System.Windows.Forms.Button();
			this.btnValve1 = new System.Windows.Forms.Button();
			this.btnValve2 = new System.Windows.Forms.Button();
			this.btnValve3 = new System.Windows.Forms.Button();
			this.btnWaterPump = new System.Windows.Forms.Button();
			this.tbAddMsg = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// btnWaterHeater
			// 
			this.btnWaterHeater.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.btnWaterHeater.Location = new System.Drawing.Point(45, 26);
			this.btnWaterHeater.Name = "btnWaterHeater";
			this.btnWaterHeater.Size = new System.Drawing.Size(78, 23);
			this.btnWaterHeater.TabIndex = 0;
			this.btnWaterHeater.Text = "OFF";
			this.btnWaterHeater.UseVisualStyleBackColor = false;
			this.btnWaterHeater.Click += new System.EventHandler(this.btnWaterHeater_Click);
			// 
			// btnValve1
			// 
			this.btnValve1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.btnValve1.Location = new System.Drawing.Point(45, 67);
			this.btnValve1.Name = "btnValve1";
			this.btnValve1.Size = new System.Drawing.Size(78, 23);
			this.btnValve1.TabIndex = 1;
			this.btnValve1.Text = "OFF";
			this.btnValve1.UseVisualStyleBackColor = false;
			this.btnValve1.Click += new System.EventHandler(this.btnValve1_Click);
			// 
			// btnValve2
			// 
			this.btnValve2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.btnValve2.Location = new System.Drawing.Point(45, 111);
			this.btnValve2.Name = "btnValve2";
			this.btnValve2.Size = new System.Drawing.Size(78, 23);
			this.btnValve2.TabIndex = 2;
			this.btnValve2.Text = "OFF";
			this.btnValve2.UseVisualStyleBackColor = false;
			this.btnValve2.Click += new System.EventHandler(this.btnValve2_Click);
			// 
			// btnValve3
			// 
			this.btnValve3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.btnValve3.Location = new System.Drawing.Point(45, 154);
			this.btnValve3.Name = "btnValve3";
			this.btnValve3.Size = new System.Drawing.Size(78, 23);
			this.btnValve3.TabIndex = 3;
			this.btnValve3.Text = "OFF";
			this.btnValve3.UseVisualStyleBackColor = false;
			this.btnValve3.Click += new System.EventHandler(this.btnValve3_Click);
			// 
			// btnWaterPump
			// 
			this.btnWaterPump.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.btnWaterPump.Location = new System.Drawing.Point(45, 198);
			this.btnWaterPump.Name = "btnWaterPump";
			this.btnWaterPump.Size = new System.Drawing.Size(78, 23);
			this.btnWaterPump.TabIndex = 4;
			this.btnWaterPump.Text = "OFF";
			this.btnWaterPump.UseVisualStyleBackColor = false;
			this.btnWaterPump.Click += new System.EventHandler(this.btnWaterPump_Click);
			// 
			// tbAddMsg
			// 
			this.tbAddMsg.Location = new System.Drawing.Point(21, 252);
			this.tbAddMsg.Multiline = true;
			this.tbAddMsg.Name = "tbAddMsg";
			this.tbAddMsg.ReadOnly = true;
			this.tbAddMsg.Size = new System.Drawing.Size(229, 241);
			this.tbAddMsg.TabIndex = 5;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(146, 31);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(71, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "Water Heater";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(146, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(43, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "Valve 1";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(146, 116);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(43, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "Valve 2";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(146, 159);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(43, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "Valve 3";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(146, 203);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(66, 13);
			this.label5.TabIndex = 10;
			this.label5.Text = "Water Pump";
			// 
			// timer1
			// 
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer_int);
			// 
			// GarageForm2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.ClientSize = new System.Drawing.Size(277, 512);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tbAddMsg);
			this.Controls.Add(this.btnWaterPump);
			this.Controls.Add(this.btnValve3);
			this.Controls.Add(this.btnValve2);
			this.Controls.Add(this.btnValve1);
			this.Controls.Add(this.btnWaterHeater);
			this.Name = "GarageForm2";
			this.Text = "GarageForm2";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnWaterHeater;
		private System.Windows.Forms.Button btnValve1;
		private System.Windows.Forms.Button btnValve2;
		private System.Windows.Forms.Button btnValve3;
		private System.Windows.Forms.Button btnWaterPump;
		private System.Windows.Forms.TextBox tbAddMsg;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Timer timer1;
	}
}