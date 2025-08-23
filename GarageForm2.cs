using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Linq;
using System.Xml;
using System.Text;
using System.Windows.Forms;
using EpServerEngine.cs;
using System.Diagnostics;
using System.Globalization;
using EpLibrary.cs;
using System.IO;
using System.Xml.Serialization;
using System.Drawing;
using System.Timers;
using static EpServerEngineSampleClient.FrmSampleClient;

namespace EpServerEngineSampleClient
{
    public partial class GarageForm2: Form
    {
		private INetworkClient m_client;
		private bool m_wait = false;
		ServerCmds svrcmd = new ServerCmds();
		//private List<int> CurrentList = new List<int>();
		private bool m_pause = false;
		bool allon = false;
		int single_select = 0;
		int timer_tick = 10;
		int pump_timer_tick = 10;
		int no_lights = 8;

		List<String> on_label_list = new List<String>();
		//List<String> off_label_list = new List<String>();
		public System.Collections.Generic.List<ButtonList> button_list;
		public GarageForm2(string xml_file_location, INetworkClient client, bool primary_wincl)
        {
            InitializeComponent();
			m_client = client;
			svrcmd.SetClient(m_client);
			svrcmd.SetPrimaryWinCl(primary_wincl);
/*			
			XmlReader xmlfile = null;
			DataSet ds = new DataSet();
			var filePath = xml_file_location;
			xmlfile = XmlReader.Create(filePath, new XmlReaderSettings());
			ds.ReadXml(xmlfile);
*/
			on_label_list.Add("WATER_HEATER");
			on_label_list.Add("WATER_VALVE1");
			on_label_list.Add("WATER_VALVE2");
			on_label_list.Add("WATER_VALVE3");
			on_label_list.Add("WATER_PUMP");

			button_list = new List<ButtonList>();
			Control sCtl = this.btnWaterHeater;
			//for (int i = 0; i < this.Controls.Count; i++)
			for (int i = 0; i < 13; i++)
			{
				if (sCtl.GetType() == typeof(Button))
				{
					button_list.Add(new ButtonList()
					{
						TabOrder = sCtl.TabIndex,
						Ctl = (Button)sCtl,
						Enabled = sCtl.Enabled,
						Name = sCtl.Name
					});
					AddMsg(button_list[i].Name + " " + button_list[i].TabOrder.ToString());
					sCtl = GetNextControl(sCtl, true);
				}
			}
        }
		delegate void AddMsg_Involk(string message);
		public void Enable_Dlg(bool wait)
		{
			m_wait = wait;
		}

		public void AddMsg(string message)
		{
			if (tbAddMsg.InvokeRequired)
			{
				AddMsg_Involk CI = new AddMsg_Involk(AddMsg);
				tbAddMsg.Invoke(CI, message);
			}
			else
			{
				//tbReceived.Text += message + "\r\n";
				tbAddMsg.AppendText(message + "\r\n");
			}
		}
		private bool SendCmd(int which, string str)
		{
			string cmd = on_label_list[which];
			int offset = svrcmd.GetCmdIndexI(cmd);
			return svrcmd.Change_PortCmd(offset, 3,str);
		}
		private bool SendCmd(int which)
		{
			string cmd = on_label_list[which];
			int offset = svrcmd.GetCmdIndexI(cmd);
			return svrcmd.Change_PortCmd(offset, 3);
		}
		private bool SendCmd(int which, bool onoff)
		{
			string cmd = on_label_list[which];
			int offset = svrcmd.GetCmdIndexI(cmd);
			return svrcmd.Change_PortCmd(offset, 3, onoff);		// this is bad
		}
		public void ToggleButton(int which, bool state)
		{
			if (state)
			{
				button_list[which].Ctl.Text = "ON";
				button_list[which].Ctl.BackColor = Color.Aqua;
			}
			else
			{
				button_list[which].Ctl.Text = "OFF";
				button_list[which].Ctl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			}
		}
		public void ToggleButton(int which)
		{
			if (SendCmd(which))
			{
				button_list[which].Ctl.Text = "ON";
				button_list[which].Ctl.BackColor = Color.Aqua;
			}
			else
			{
				button_list[which].Ctl.Text = "OFF";
				button_list[which].Ctl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			}
		}
		private void btnWaterHeater_Click(object sender, EventArgs e)
		{
			ToggleButton(0);
			AddMsg("water heater");
		}

		private void btnValve1_Click(object sender, EventArgs e)
		{
			ToggleButton(1);
			AddMsg("valve 1");
		}

		private void btnValve2_Click(object sender, EventArgs e)
		{
			ToggleButton(2);
			AddMsg("valve 2");
		}

		private void btnValve3_Click(object sender, EventArgs e)
		{
			ToggleButton(3);
			AddMsg("valve 3");
		}
		private void btnWaterPump_Click(object sender, EventArgs e)
		{
			ToggleButton(4);
			AddMsg("water pump");
			timer1.Enabled = true;
			pump_timer_tick = 10;
		}
		private void timer_int(object sender, EventArgs e)
		{
			AddMsg(pump_timer_tick.ToString());
			if (pump_timer_tick-- == 0)
			{
				ToggleButton(4, SendCmd(4,"OFF"));
				timer1.Enabled = false;
			}
		}
		public void RunWaterPump(int seconds)
		{
			ToggleButton(4);
			AddMsg("pump on");
			timer1.Enabled = true;
			pump_timer_tick = seconds;
		}
	}
}
