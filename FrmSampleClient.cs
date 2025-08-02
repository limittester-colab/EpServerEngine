using System;
using System.Collections.Generic;
using System.Data;
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
using System.Collections;
using System.Xml.Serialization;
using System.Drawing;
using System.Timers;
using System.Runtime.InteropServices;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Windows.Forms.DataVisualization.Charting;

namespace EpServerEngineSampleClient
{
    public partial class FrmSampleClient : Form, INetworkClientCallback
    {

        ConfigParams cfg_params = new ConfigParams();
        private DlgSetParams dlgsetparams = null;
        //private bool valid_cfg = false;
        ServerCmds svrcmd = new ServerCmds();
        INetworkClient m_client = new IocpTcpClient();
        private List<Ddata> mycdata = null;
        string outfile;
        bool light_list = false;

        //private PlayerDlg playdlg = null;
        private GarageForm garageform = null;
        private TestBench testbench = null;
        private Cabin cabin = null;
        private Outdoor outdoor = null;
        private DS1620Mgt ds1620 = null;
        private int AvailClientCurrentSection = 0;
        private bool[] status = new bool[8];
        private List<ClientParams> client_params;
        private List<ClientsAvail> clients_avail;
		private string subdirectory = @"textTimeDate\";
        private int heaterTimeOn, heaterTimeOff, heater_counter;
        private bool heaterStatus = false;
        private bool heaterTimerOn = false;

		private int selected_address = 0;
        private int disconnect_attempts = 0;
        private string m_hostname;
        private string m_portno;
        //private int server_up_seconds = 0;
        private bool client_connected = false;
        //private int timer_offset;
        //private string sendmsgtext;
        int tick = 0;
        //int connected_tick = 0;
        //bool client_alert = false;
        int cur_day = -1;

		private string initial_data_directory = "c:\\Users\\daniel\\DS1620Data\\";
        private string initial_directory = "c:\\Users\\daniel\\ClientProgramData\\";
        private string xml_params_location = "";
        //private string xml_params_location = initial_directory + "ClientParams.xml";
        //private string xml_params_location = "c:\\Users\\daniel\\ClientProgramData\\ClientParams.xml";
        private string xml_clients_avail_location = ""; //"c:\\Users\\daniel\\ClientProgramData\\ClientsAvail.xml";
        private string temp_data_location = ""; //"c:\\Users\\daniel\\ClientProgramData\\";

        private int hour;
        private int minute;
        private int second;
        private int MinTemp;
        private bool bMinTemp;
        private bool easy_button1 = false;
		private bool easy_button2 = false;
		private bool easy_button3 = false;
		private bool easy_button4 = false;
		private bool easy_button5 = false;
		private bool easy_button6 = false;
		private bool easy_button7 = false;
		//bool clk_oneoff = true;

		private DateTime now;
        List<int> temp_list_int = null;
        bool primary_wincl;
        /* remove the min/max/close buttons in the 'frame' */
        /* or you can just set 'Control Box' to false in the properties pane for the form */
        private const int CP_NOCLOSE_BUTTON = 0x200;
        private const int WS_CAPTION = 0x00C00000;
        // Removes the close button in the caption bar
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;

                // This disables the close button
                // myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;

                // this appears to completely remove the close button
                myCp.Style &= WS_CAPTION;

                return myCp;
            }
        }
        public FrmSampleClient()
        {
            InitializeComponent();
            svrcmd.SetClient(m_client);
            dlgsetparams = new DlgSetParams(cfg_params);
            dlgsetparams.SetClient(m_client);
            cbIPAdress.Enabled = true;
            tbReceived.Enabled = true;
            tbPort.Enabled = true;
            timer1.Enabled = true;
			mycdata = new List<Ddata>();
            temp_list_int = new List<int>();

            heaterTimeOn = 60;
            heaterTimeOff = 50;
            heater_counter = 0;

			xml_params_location = initial_directory + "ClientParams.xml";
            xml_clients_avail_location = initial_directory +  "ClientsAvail.xml";
            /*
            try
			{
                StreamReader sr = new StreamReader(initial_directory + "this_ip_address.txt");
                this_ip_address = sr.ReadLine();
                this_machine_name = sr.ReadLine();
                sr.Close();
			}
            catch(Exception e)
			{
                MessageBox.Show("Exception: " + e.Message);
			}
            for (int i = 0; i < 8; i++)
            {
                status[i] = false;
            }
            tbReceived.Clear();
            AddMsg("this ip add: " + this_ip_address);
            AddMsg("this machine name: " + this_machine_name);
            */
            client_params = new List<ClientParams>();
            ClientParams item = null;
            if (!File.Exists(xml_params_location))
            {
                MessageBox.Show("can't find " + xml_params_location);
                return;
            }
            XmlReader xmlFile = XmlReader.Create(xml_params_location);
            DataSet ds = new DataSet();
            ds.ReadXml(xmlFile);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                item = new ClientParams();
                item.AutoConn = Convert.ToBoolean(dr.ItemArray[0]);
                item.IPAdress = dr.ItemArray[1].ToString();
                item.PortNo = Convert.ToUInt16(dr.ItemArray[2]);
                item.Primary = Convert.ToBoolean(dr.ItemArray[3]);
                item.AttemptsToConnect = Convert.ToInt16(dr.ItemArray[4]);
                //AddMsg(item.IPAdress + " " + item.PortNo.ToString());
                client_params.Add(item);
                item = null;
            }
            
            clients_avail = new List<ClientsAvail>();
            ClientsAvail item3 = null;
            //AddMsg("adding clients avail...");
            DataSet ds2 = new DataSet();
            if (!File.Exists(xml_clients_avail_location))
            {
                MessageBox.Show("can't find " + xml_clients_avail_location);
                return;
            }
            xmlFile = XmlReader.Create(xml_clients_avail_location);
            ds2.ReadXml(xmlFile);
            int lb_index = 0;

            foreach (DataRow dr in ds2.Tables[0].Rows)
            {
                //string temp = "";
                item3 = new ClientsAvail();
                item3.lbindex = -1;
                //                item2.index = Convert.ToInt16(dr.ItemArray[1]);
                item3.index = lb_index;
                item3.ip_addr = dr.ItemArray[0].ToString();
                //temp += item2.ip_addr;
                //temp += "  ";
                item3.label = dr.ItemArray[1].ToString();
                //temp += item2.label;
                //temp += "  ";
                item3.socket = Convert.ToInt16(dr.ItemArray[2]);
                //temp += item2.socket.ToString();
                item3.type = Convert.ToInt16(dr.ItemArray[3]);  // type is: 0 - win client; 1 - TS_CLIENT; 2 - TS_SERVER (only one of these)
                                                                //AddMsg(item2.label.ToString() + " " + item2.ip_addr.ToString() + " " + item2.socket.ToString());
                item3.time_string = "";
                item3.flag = 0;
                clients_avail.Add(item3);
                AddMsg(item3.ip_addr + " " + item3.label);

                item3 = null;
                lb_index++;
            }
            //AddMsg(svrcmd.GetPrimaryWinCl().ToString());
            //AddMsg(clients_avail[0].ip_addr + " " + clients_avail[1].ip_addr);

            bool found = false;
            if (clients_avail[0].ip_addr != "158")
                primary_wincl = false;
            else primary_wincl = true;
            //AddMsg("primary_wincl: " + primary_wincl);
            svrcmd.SetPrimaryWinCl(primary_wincl);
            //AddMsg("dest: " + svrcmd.GetDestIndex().ToString());

            garageform = new GarageForm("c:\\users\\daniel\\dev\\adc_list.xml", m_client, primary_wincl);
            testbench = new TestBench("c:\\users\\daniel\\dev\\adc_list.xml", m_client, primary_wincl);
            cabin = new Cabin(m_client, primary_wincl);
            outdoor = new Outdoor(m_client, primary_wincl);
            ds1620 = new DS1620Mgt(m_client);
            btnFnc1.Enabled = false;
            btnFnc2.Enabled = false;
            btnFnc3.Enabled = false;

            for (int i = 0; i < client_params.Count(); i++)
            {
                //                if (client_params[i].AutoConn == true)
                if (client_params[i].Primary)
                {
                    m_hostname = cbIPAdress.Text = client_params[i].IPAdress;
                    selected_address = i;
                    m_portno = tbPort.Text = client_params[i].PortNo.ToString();
                    //AddMsg("primary: " + m_hostname + " " + m_portno.ToLower());
                    found = true;
                }
                cbIPAdress.Items.Add(client_params[i].IPAdress);
                //AddMsg("selected address: " + selected_address.ToString() + " selected address: " + selected_address.ToString());
                found = true;
            }

            if (!found)
            {
                AddMsg("no primary address found in xml file");
            }
            now = DateTime.Now;
            string t2date = now.Date.ToString();
            //string smonth = DateTime.

            int space = t2date.IndexOf(" ");
            t2date = t2date.Remove(space);
            tbTodaysDate.Text = t2date;
            MinTemp = 32;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (true)
            {
                if (!client_connected)      // let's connect here! (see timer callback at end of file)
                {
                    m_hostname = cbIPAdress.Items[selected_address].ToString();
                    m_portno = tbPort.Text;
                    AddMsg("trying to connect to:    " + m_hostname + ":" + m_portno.ToString() + "...");
                    ClientOps ops = new ClientOps(this, m_hostname, m_portno);
                    // set the timeout to 5ms - by default it's 0 which causes it to wait a long time
                    // and slows down the UI
                    ops.ConnectionTimeOut = 500;
                    m_client.Connect(ops);
                    disconnect_attempts++;
                    //timer1.Enabled = true;
                    tick = 0;
                    btnConnect.Text = "Disconnect";
                    client_connected = true;
                    //connected_tick = 0;
                    //AddMsg(GetLocalIPAddress());
                }
                else
                {
                    //playdlg.Dispose();
                    svrcmd.Send_ClCmd(svrcmd.GetCmdIndexI("DISCONNECT"), 5, "disconnect\0");
                    disconnect_attempts = 0;
                    AddMsg("disconnecting");
                    btnConnect.Text = "Connect";
                    //timer1.Enabled = false;
                    client_connected = false;
                    connect_buttons(false);
                    m_client.Disconnect();
                    lbAvailClients.Items.Clear();
                }
            }
            else AddMsg("chose which client this is");
        }
        public void OnConnected(INetworkClient client, ConnectStatus status)
        {
            //AddMsg(client.HostName);
            if (client.HostName == m_hostname)
            {
                if (m_client.IsConnectionAlive)
                {
                    tbConnected.Text = "connected";     // comment all these out in debug
                                                        //            cblistCommon.Enabled = true;      this one stays commneted out
                    //btnConnect.Text = "Disconnect";
                    cbIPAdress.Enabled = false;     /// from here to MPH should be commented out when in debugger
					tbPort.Enabled = false;
                    //tbServerTime.Text = "";
                    //AddMsg("server_up_seconds: " + server_up_seconds.ToString());
                    //btnShowParams.Enabled = valid_cfg;
                    clients_avail[5].socket = 1;        // 5 is _SERVER (this is bad!)
                    //timer1.Enabled = true;
                    AddMsg("connected");
                    connect_buttons(true);
                }
            }
            else AddMsg(client.HostName);
        }
        private void connect_buttons(bool btnstate)
		{
            btnFnc1.Enabled = btnstate;
            btnFnc2.Enabled = btnstate;
            btnFnc3.Enabled = btnstate;
            btnFnc4.Enabled = btnstate;
            btnFnc5.Enabled = btnstate;
        }
        public void OnDisconnect(INetworkClient client)
        {
            if (client.HostName == m_hostname)
            {
                cbIPAdress.Enabled = true;
                tbPort.Enabled = true;
                btnConnect.Text = "Connect";
                tbConnected.Text = "not connected";
                connect_buttons(false);
            }
        }
        protected override void OnClosed(EventArgs e)
        {
            AddMsg("closing...");
            if (m_client.IsConnectionAlive)
            {
            }
            //play_aliens_clip();
            garageform.Dispose();
            testbench.Dispose();
            //winclmsg.Dispose();

            //setnextclient.Dispose();
            //            if(player_active)
            //              playdlg.Dispose();
            base.OnClosed(e);
        }
        public void OnReceived(INetworkClient client, Packet receivedPacket)
        {
            // anything that gets sent here gets sent to home server if it's up
           
            if (garageform.Visible == true)
            {
                garageform.Process_Msg(receivedPacket.PacketRaw);
            }
            else if (testbench.Visible == true)
            {
                testbench.Process_Msg(receivedPacket.PacketRaw);
            }
            else
                Process_Msg(receivedPacket.PacketRaw);
        }
        private void RedrawClientListBox()
        {
            lbAvailClients.Items.Clear();
            int i = 0;
            foreach (ClientsAvail j in clients_avail)
            {
                if (j.socket > 0 && j.type != 0)
                {
                    //string temp = j.label + " " + j.ip_addr + " " + j.socket.ToString();
                    string temp = j.label + "  " + j.time_string;
                 
                    lbAvailClients.Items.Add(temp);
                    j.lbindex = i;
                   
                    //AddMsg(j.ip_addr + " " + j.label + " " + j.socket.ToString() + " " + j.type);
                    i++;
                }
                else j.lbindex = -1;
            }
        }
        private void Process_Msg(byte[] bytes)
        {
            string substr;
            int type_msg;
            string ret = null;
            int i = 0;
            string[] words;
            char[] chars = new char[bytes.Length / sizeof(char) + 2];
            char[] chars2 = new char[bytes.Length / sizeof(char)];
            // src srcoffset dest destoffset len
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            type_msg = chars[0];
            System.Buffer.BlockCopy(bytes, 2, chars2, 0, bytes.Length - 2);
            ret = new string(chars2);
            //AddMsg("test: " + ret);
            string str = svrcmd.GetName(type_msg);
            //AddMsg(str);
            bool iparam;
            int temp = 0;

            switch (str)
            {
                case "SET_PROPERTIES":  // not used
                    AddMsg(ret);
                    substr = "";
					iparam = false;
					words = ret.Split(' ');
                    i = 0;
                    foreach (var word in words)
                    {
                        switch (i)
                        {
                            case 0:
                                if(word == "ON")
                                //AddMsg(word);
                                    iparam = true;
                                else iparam = false;
                                break;
                            case 1:
                                substr = word;
								//AddMsg(substr + " " + iparam.ToString());
								break;
						}
						i++;
                    }
					svrcmd.SetProperties(iparam, substr);
					AddMsg("set prop: " + substr + " " + iparam.ToString());
					break;

                case "DS1620_MSG":
					string fileName = initial_data_directory + "rtddata.txt";
					try
					{
						using (StreamWriter writer = new StreamWriter(fileName))
						{
							writer.Write(ret);
                            AddMsg(ret);
                            //writer.Close();
						}
					}
					catch (Exception exp)
					{
						Console.Write(exp.Message);
					}

					int hour, minute, second;
					now = DateTime.Now;
					hour = now.Hour;
					minute = now.Minute;
					second = now.Second;
					int day = now.Day;
					string date = now.ToString();
                    int nMinTemp;
					words = ret.Split(' ');
					i = 0;
                    foreach (var word in words)
                    {
                        switch (i)
                        {
                            case 4:
                                nMinTemp = Convert.ToInt16(word);
                                if (nMinTemp >= MinTemp)
                                {
                                    //AddMsg("true");
                                    bMinTemp = true;
                                }
                                else
                                {
                                    //AddMsg("false");
                                    bMinTemp = false;
                                }
                                break;
                        }
                        i++;
                    }


						if (day != cur_day)
					{
						// rename output file to new date and save
						// yesterday's file 
						cur_day = day;
						date = now.ToString();
						outfile = initial_data_directory + subdirectory + now.Month.ToString() + "-" + now.Day.ToString() + ".txt";
						//AddMsg(outfile);
					}
					try
					{
						using (StreamWriter w = File.AppendText(outfile))
						{
							w.WriteLine(ret);
						}
					}
					catch (Exception exp)
					{
						Console.Write(exp.Message);
					}

					break;

                case "UPTIME_MSG":
                    //AddMsg("ret: " + ret);
                    words = ret.Split(' ');
                    i = 0;
                    int j = 0;
                    int k = 0;
					int hours = 0;
                    foreach (var word in words)
                    {
                        switch (i)
                        {
                            case 0:
                                j = int.Parse(word);
                                //AddMsg(word + " " + j.ToString());
                                //AddMsg(clients_avail[j].label + " uptime:");
                                //AddMsg(word);
                                clients_avail[j].time_string = " ";
                                clients_avail[j].flag = 0;
                                k = j;
                                break;
                            case 1:
                                j = int.Parse(word);
                                if (j > 0)
                                {
                                    clients_avail[k].time_string += j.ToString() + " days ";
                                }
                                break;
                            case 2:
                                j = int.Parse(word);
								hours = j;
                                if (j > 0)
                                    clients_avail[k].time_string += j.ToString() + " hrs ";
                                break;
                            case 3:
                                j = int.Parse(word);
                                clients_avail[k].time_string += j.ToString() + " mins ";
                                break;
                            case 4:
                                j = int.Parse(word);
								if(hours == 0)
									clients_avail[k].time_string += j.ToString() + " secs";
                               //AddMsg(clients_avail[k].time_string);
                                /*
                                if (clients_avail[k].time_string == clients_avail[k].prev_time_string)
                                {
                                    AddMsg("Alert 2: " + clients_avail[k].label);
                                }
                                clients_avail[k].prev_time_string = clients_avail[k].time_string;
                                */
                                RedrawClientListBox();
                                break;
                            default:
                                AddMsg("?");
                                break;
                        }
                        i++;
                    }//AddMsg("uptime_msg");
                    break;

                case "SEND_MESSAGE":
                    AddMsg(ret);
                    break;

                case "CURRENT_TIME":
                    //ListMsg(ret, true);
                    break;

                case "SEND_CLIENT_LIST":
                    words = ret.Split(' ');
                    i = 0;
                    j = 0;
                    int sock = -1;
                    AddMsg(ret);
                    string clmsg = " ";
                    foreach (var word in words)
                    {
                        switch (i)
                        {
                            case 0:     // index into clients_avail list
                                j = int.Parse(word);
                                //AddMsg(j.ToString());
                                clmsg = word + "  ";
                                break;
                            case 1:     // ip address
                                        //AddMsg(word);
                                clmsg += word + "  ";
                                break;
                            case 2:     // port no.
                                        //if(clients_avail[i].socket < 0)
                                        //avail = true;
                                sock = clients_avail[j].socket = int.Parse(word);
                                //AddMsg(clients_avail[j].socket.ToString());
                                clmsg += word + " " + sock.ToString();
                                //if(avail)
                                RedrawClientListBox();
                                //AddMsg(clmsg);
                                break;
                            default:
                                AddMsg("?");
                                break;
                        }
                        i++;
                    }
                    break;

                case "GET_TIME":
                    //ListMsg(ret, true);
                    break;

                case "SEND_STATUS":
                    //svrcmd.Send_ClCmd(svrcmd.GetCmdIndexI("SEND_MESSAGE"), 5, "ABCDA");
                    //AddMsg("SEND_STATUS");
                    break;

                case "SEND_MESSAGE2":
                    AddMsg(ret);
                    break;

                default:
                    break;
            }
        }
        byte[] BytesFromString(String str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }
        public void OnSent(INetworkClient client, SendStatus status, Packet sentPacket)
        {
            switch (status)
            {
                case SendStatus.SUCCESS:
                    Debug.WriteLine("SEND Success");
                    break;
                case SendStatus.FAIL_CONNECTION_CLOSING:
                    AddMsg(status.ToString());
                    Debug.WriteLine("SEND failed due to connection closing");
                    break;
                case SendStatus.FAIL_INVALID_PACKET:
                    AddMsg(status.ToString());
                    Debug.WriteLine("SEND failed due to invalid socket");
                    break;
                case SendStatus.FAIL_NOT_CONNECTED:
                    AddMsg(status.ToString());
                    Debug.WriteLine("SEND failed due to no connection");
                    break;
                case SendStatus.FAIL_SOCKET_ERROR:
                    AddMsg(status.ToString());
                    Debug.WriteLine("SEND Socket Error");
                    break;
            }
        }
        delegate void AddMsg_Involk(string message);
        public void AddMsg(string message)
        {
            if (tbReceived.InvokeRequired)
            {
                AddMsg_Involk CI = new AddMsg_Involk(AddMsg);
                tbReceived.Invoke(CI, message);
            }
            else
            {
                //tbReceived.Text += message + "\r\n";
                tbReceived.AppendText(message + "\r\n");
            }
        }
        String StringFromByteArr(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }
        private void connect(object sender, EventArgs e)
        {
            btnConnect_Click(sender, e);
        }
        // start/stop engine
        // Insert logic for processing found files here.
        private void UpdateClientInfo()
        {
            string msg = "UPDATE_CLIENT_INFO";
            int icmd = svrcmd.GetCmdIndexI(msg);
            foreach (ClientsAvail cl in clients_avail)
            {
                if (cl.type == 1 && cl.socket > 0)
                {
                    svrcmd.Send_ClCmd(icmd, cl.index, cl.index);
                }
            }
        }
        /*private void SendTimeup(int which)      // not used
        {
            string msg = "SEND_TIMEUP";
            int icmd = svrcmd.GetCmdIndexI(msg);
            foreach (ClientsAvail cl in clients_avail)
            {
                if (cl.type > 0 && cl.socket > 0 && cl.index == which)
                {
                    svrcmd.Send_ClCmd(icmd, cl.index, cl.index);
                    //AddMsg(icmd.ToString());
                }
            }
        }*/
        public static byte[] ReadFile(string filePath)
        {
            byte[] buffer;
            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            try
            {
                int length = (int)fileStream.Length;  // get file length
                buffer = new byte[length];            // create buffer
                int count;                            // actual number of bytes read
                int sum = 0;                          // total number of bytes read

                // read until Read method returns 0 (end of the stream has been reached)
                while ((count = fileStream.Read(buffer, sum, length - sum)) > 0)
                    sum += count;  // sum is a buffer offset for next reading
            }
            finally
            {
                fileStream.Close();
            }
            return buffer;
        }
        private void ClearScreen(object sender, EventArgs e)
        {
            tbReceived.Clear();
        }
      
        private void myTimerTick(object sender, EventArgs e)
        {
            now = DateTime.Now;
            tick++;
           
            if(true)
            //if ((tick % 3) == 0)
            {
                //AddMsg(tick.ToString());
                hour = now.Hour;
                minute = now.Minute;
                second = now.Second;
                //AddMsg(hour.ToString() + " " + minute.ToString() + " " + second.ToString());
                string tTime = now.TimeOfDay.ToString();
                tTime = tTime.Substring(0, 5);
                tbTime.Text = tTime;
                heater_counter++;

                if (heaterTimerOn)
                {
                    if (heaterStatus && (heater_counter > heaterTimeOn))
                    {
                        svrcmd.Send_ClCmd(svrcmd.GetCmdIndexI("CABIN7"), 1, "OFF");
                        //AddMsg("heater off");
                        heaterStatus = false;
                    }
                    if (!heaterStatus && (heater_counter > heaterTimeOn + heaterTimeOff))
                    {
                        svrcmd.Send_ClCmd(svrcmd.GetCmdIndexI("CABIN7"), 1, "ON");
                        //AddMsg("heater on");
                        heaterStatus = true;
                        heater_counter = 0;
                    }
                }

				if (hour == 0 && minute == 0 && second == 0)
                {
                    DateTime now2 = DateTime.Now;
                    string t2date = now2.Date.ToString();
                    int space = t2date.IndexOf(" ");
                    t2date = t2date.Remove(space);
                    tbTodaysDate.Text = t2date;

                    //play_tone(9);
                    //AddMsg("midnight");
                    foreach (ClientsAvail cl in clients_avail)
                    {
                        if ((cl.type == 1 || cl.type == 2) && cl.socket > 0)  // set the time on any server/clients in the active list
                        {
                            svrcmd.Send_ClCmd(svrcmd.GetCmdIndexI("DLLIST_SAVE"), cl.index, "dll_list");
                            //AddMsg("DLLIST_SAVE: " + cl.label);
                        }
                    }
                }
                else if (hour == 0 && minute == 1 && second == 0)
                {
                    AddMsg("one minute after midnight");
                }

				if(bMinTemp && ((minute % 5) == 0) && second == 0)
				{
                    // turn water pump on
                    //AddMsg("pump on");
					//svrcmd.Send_ClCmd(svrcmd.GetCmdIndexI("WATER_HEATER"), 5, "ON");
				}
				if(bMinTemp && ((minute % 5) == 0) && second == 2)
				{
					// turn water pump off
                    bMinTemp = false;
					//svrcmd.Send_ClCmd(svrcmd.GetCmdIndexI("WATER_HEATER"), 5, "OFF");
					//AddMsg("pump off");
				}
            }
            if (tick == 5)
            {
                if (m_client.IsConnectionAlive)
                {
                    svrcmd.Send_ClCmd(svrcmd.GetCmdIndexI("SET_CLIENT_NAME"), 5, "Windows Client\0");
					AddMsg("send msg 1");
//					svrcmd.Send_Cmd(2);
					
                    //AddMsg("send client list");
                    RedrawClientListBox();
                }

            }
			if(tick == 7)
			{
                if (m_client.IsConnectionAlive)
                {
					svrcmd.Send_ClCmd(svrcmd.GetCmdIndexI("SEND_CLIENT_LIST"), 5, "send client list\0");
					AddMsg("send msg 2");
				}
			}
            if (tick == 20)
            {
                //AddMsg("set time");
                if (m_client.IsConnectionAlive)
                {
                    foreach (ClientsAvail cl in clients_avail)
                    {
                        if ((cl.type == 1 || cl.type == 2) && cl.socket > 0)  // set the time on any server/clients in the active list
                            // type 1 is TS_CLIENT type 2 is TS_SERVER
                        {
                            //AddMsg(cl.label);
//                            SetTime(cl.index);
                        }
                    }
                }
            }
        }
        private void IPAddressChanged(object sender, EventArgs e)
        {
            if (!client_connected)
            {
                selected_address = cbIPAdress.SelectedIndex;
                m_hostname = client_params[selected_address].IPAdress;
                tbPort.Text = m_portno = client_params[selected_address].PortNo.ToString();
                AddMsg(selected_address.ToString() + " " + m_hostname + " " + m_portno.ToString());
            }
        }
        private void FrmSampleClient_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);
            //AddMsg("loaded");
        }
        private void SetTime(int dest)
        {
            if (m_client.IsConnectionAlive)
            {
                DateTime localDate = DateTime.Now;
                String cultureName = "en-US";
                var culture = new CultureInfo(cultureName);
                //AddMsg(clients_avail[dest].label);
                //AddMsg(localDate.ToString(culture));
                int temp1 = dest;
                byte[] bytes1 = BitConverter.GetBytes(temp1);
                byte[] bytes2 = BytesFromString(localDate.ToString(culture));
                byte[] bytes3 = new byte[bytes1.Count() + bytes2.Length + 2];
                System.Buffer.BlockCopy(bytes1, 0, bytes3, 2, bytes1.Count());
                System.Buffer.BlockCopy(bytes2, 0, bytes3, 4, bytes2.Length);
                string set_time = "SET_TIME";
                bytes3[0] = svrcmd.GetCmdIndexB(set_time);
                Packet packet = new Packet(bytes3, 0, bytes3.Count(), false);
                m_client.Send(packet);
            }
        }
        private void SetTime(int dest,int hours, int minutes)
        {
            if (m_client.IsConnectionAlive)
            {
                DateTime localDate = DateTime.Now;
                localDate = localDate.AddHours(hours);
                localDate = localDate.AddMinutes(minutes);
                //AddMsg(localDate.ToString());
                
                String cultureName = "en-US";
                var culture = new CultureInfo(cultureName);
                //AddMsg(clients_avail[dest].label);
                //AddMsg(localDate.ToString(culture));
                int temp1 = dest;
                byte[] bytes1 = BitConverter.GetBytes(temp1);
                byte[] bytes2 = BytesFromString(localDate.ToString(culture));
                byte[] bytes3 = new byte[bytes1.Count() + bytes2.Length + 2];
                System.Buffer.BlockCopy(bytes1, 0, bytes3, 2, bytes1.Count());
                System.Buffer.BlockCopy(bytes2, 0, bytes3, 4, bytes2.Length);
                string set_time = "SET_TIME";
                bytes3[0] = svrcmd.GetCmdIndexB(set_time);
                Packet packet = new Packet(bytes3, 0, bytes3.Count(), false);
                m_client.Send(packet);
            }
        }
        private void ListMsg(string msg, bool show_date)
        {
            string temp = "";
            DateTime localDate = DateTime.Now;
            String cultureName = "en-US";
            var culture = new CultureInfo(cultureName);
            temp = localDate.ToString(culture);
            if (show_date)
                AddMsg(msg + " " + temp);
            else
            {
                int index = temp.IndexOf(' ');
                //AddMsg(index.ToString());
                temp = temp.Substring(index);
                AddMsg(msg + " " + temp);
            }
        }
        private void AvailClientSelIndexChanged(object sender, EventArgs e)
        {
            AvailClientCurrentSection = lbAvailClients.SelectedIndex;
        }
        private void ReportAllTimeUp(int index)
		{
            foreach (ClientsAvail cl in clients_avail)
            {
                //if(cl.socket > 0 && (cl.type == 2 || cl.type == 1) && cl.lbindex == index)
                if (cl.socket > 0 && cl.type == 1)
                {
                    //AddMsg("testing: " + cl.label + " " + cl.flag.ToString());
                    //svrcmd.Send_ClCmd(svrcmd.GetCmdIndexI("SEND_TIMEUP"), cl.index, " ");
                    if (cl.flag > 1)
                    {
                        AddMsg("Alert: " + cl.label + " " + (cl.flag - 1).ToString());
                        AlertLabel.Visible = true;
                        AlertLabel.Text = "Alert: " + cl.label + " " + (cl.flag - 1).ToString();
                        AlertLabel.ForeColor = Color.Red;
                        //client_alert = true;
                    }
                    cl.flag++;
                }
            }
        }
/*
        private void btnWinClMsg_Click(object sender, EventArgs e)
        {
            winclmsg = new WinCLMsg();
            winclmsg.SetClient(m_client);
            winclmsg.Enable_Dlg(true);
            winclmsg.StartPosition = FormStartPosition.Manual;
            winclmsg.Location = new Point(100, 10);

            if (winclmsg.ShowDialog(this) == DialogResult.OK)
            {
            }
            else
            {
                //                this.txtResult.Text = "Cancelled";
            }
            winclmsg.Enable_Dlg(false);
            winclmsg.Dispose();
        }       // unused
*/
        private void Function1Click(object sender, EventArgs e)
		{
            int type, port;
            //AddMsg(Properties.Settings.Default["func1_type"].ToString());
            //AddMsg(Properties.Settings.Default["func1_port"].ToString());
            type = (int)Properties.Settings.Default["func1_type"];
            port = (int)Properties.Settings.Default["func1_port"];
            svrcmd.Change_PortCmd(port, type);
            if(!easy_button1)
                btnFnc1.BackColor = Color.Aqua;
            else btnFnc1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            easy_button1 = !easy_button1;
		}
        private void Function2Click(object sender, EventArgs e)
		{
            int type, port;
            type = (int)Properties.Settings.Default["func2_type"];
            port = (int)Properties.Settings.Default["func2_port"];
            svrcmd.Change_PortCmd(port, type);
			if (!easy_button2)
				btnFnc2.BackColor = Color.Aqua;
			else btnFnc2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			easy_button2 = !easy_button2;
		}
		private void Function3Click(object sender, EventArgs e)
        {
            int type, port;
            type = (int)Properties.Settings.Default["func3_type"];
            port = (int)Properties.Settings.Default["func3_port"];
            svrcmd.Change_PortCmd(port, type);
			if (!easy_button3)
				btnFnc3.BackColor = Color.Aqua;
			else btnFnc3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			easy_button3 = !easy_button3;
		}
		private void btnFnc4_Click(object sender, EventArgs e)
        {
            int type, port;
            type = (int)Properties.Settings.Default["func4_type"];
            port = (int)Properties.Settings.Default["func4_port"];
            //AddMsg(type.ToString()+ " " + port.ToString());
            svrcmd.Change_PortCmd(port, type);
			if (!easy_button4)
				btnFnc4.BackColor = Color.Aqua;
			else btnFnc4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			easy_button4 = !easy_button4;
		}
		private void btnFcn5_Click(object sender, EventArgs e)
        {
            int type, port;
            type = (int)Properties.Settings.Default["func5_type"];
            port = (int)Properties.Settings.Default["func5_port"];
            svrcmd.Change_PortCmd(port, type);
			if (!easy_button5)
				btnFnc5.BackColor = Color.Aqua;
			else btnFnc5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			easy_button5 = !easy_button5;
		}
		private void btnFnc6_Click(object sender, EventArgs e)
		{
			int type, port;
			type = (int)Properties.Settings.Default["func6_type"];
			port = (int)Properties.Settings.Default["func6_port"];
			svrcmd.Change_PortCmd(port, type);
			if (!easy_button6)
				btnFnc6.BackColor = Color.Aqua;
			else btnFnc6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			easy_button6 = !easy_button6;
		}
		private void btnFnc7_Click(object sender, EventArgs e)
		{
			int type, port;
			type = (int)Properties.Settings.Default["func7_type"];
			port = (int)Properties.Settings.Default["func7_port"];
			svrcmd.Change_PortCmd(port, type);
			if (!easy_button7)
				btnFnc7.BackColor = Color.Aqua;
			else btnFnc7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			easy_button7 = !easy_button7;
		}
		private void Minimize_Click(object sender, EventArgs e)
		{
            this.WindowState = FormWindowState.Minimized;
        }
		private void btnSendSort_Click(object sender, EventArgs e)
		{
            int dest = -1;
            foreach (ClientsAvail cl in clients_avail)
            {
                if (lbAvailClients.SelectedIndex > -1 && cl.lbindex == lbAvailClients.SelectedIndex)
                {
                    dest = cl.index;
//                    svrcmd.Send_ClCmd(svrcmd.GetCmdIndexI("DISCONNECT"), dest, "test");
                }
            }
        }
		private void timer3_tick(object sender, EventArgs e)
		{
            button1_Click(new object(), new EventArgs());
            AddMsg("turning lights off automatically");
        }
		
		private void btnGetTemp_Click(object sender, EventArgs e)
		{
        }
        private void cabinToolStripMenuItem_Click(object sender, EventArgs e)
		{
            cabin.StartPosition = FormStartPosition.Manual;
            cabin.Location = new Point(100, 10);
            if (cabin.ShowDialog(this) == DialogResult.OK)
            {
            }
            else
            {
            }
        }

		private void garageToolStripMenuItem_Click(object sender, EventArgs e)
		{
            garageform.Enable_Dlg(true);
            //garageform.SetStatus(status);
            garageform.StartPosition = FormStartPosition.Manual;
            garageform.Location = new Point(100, 10);
            if (garageform.ShowDialog(this) == DialogResult.OK)
            {
            }
            else
            {
            }
            garageform.Enable_Dlg(false);
        }

		private void testbenchToolStripMenuItem_Click(object sender, EventArgs e)
		{
            testbench.Enable_Dlg(true);
            testbench.StartPosition = FormStartPosition.Manual;
            testbench.Location = new Point(100, 10);
            if (testbench.ShowDialog(this) == DialogResult.OK)
            {
            }
            else
            {
            }
            testbench.Enable_Dlg(false);
        }

        private void outdoorToolStripMenuItem_Click(object sender, EventArgs e)
		{
            outdoor.StartPosition = FormStartPosition.Manual;
            outdoor.Location = new Point(100, 10);
            if (outdoor.ShowDialog(this) == DialogResult.OK)
            {
            }
            else
            {
            }
        }

		private void dS1620ToolStripMenuItem_Click(object sender, EventArgs e)
		{
            ds1620.StartPosition = FormStartPosition.Manual;
            ds1620.Location = new Point(100, 10);
            if (ds1620.ShowDialog(this) == DialogResult.OK)
            {
            }
            else
            {
            }
        }
		private void minimizeToolStripMenuItem_Click(object sender, EventArgs e)
		{
            this.WindowState = FormWindowState.Minimized;
        }

		private void clearScreenToolStripMenuItem_Click(object sender, EventArgs e)
		{
            tbReceived.Clear();
        }

		private void clearAlertToolStripMenuItem_Click(object sender, EventArgs e)
		{
          
        }

        private void assignFunctionKeyToolStripMenuItem_Click(object sender, EventArgs e)
		{
            int func = 0;
            EasyButtonForm easyButton = new EasyButtonForm();
            easyButton.StartPosition = FormStartPosition.Manual;
            easyButton.Location = new Point(100, 0);
            if (easyButton.ShowDialog(this) == DialogResult.OK)
            {
                func = easyButton.getFunc();
                switch (func)
                {
                    case 1:
                        //AddMsg("func 1");
                        Properties.Settings.Default["func1_type"] = easyButton.getType();
                        Properties.Settings.Default["func1_port"] = easyButton.getPort();
                        //btnFnc1.Text = easyButton.getType().ToString() + " " + easyButton.getPort().ToString();
                        break;
                    case 2:
                        //AddMsg("func 2");
                        Properties.Settings.Default["func2_type"] = easyButton.getType();
                        Properties.Settings.Default["func2_port"] = easyButton.getPort();
                        //btnFnc2.Text = easyButton.getType().ToString() + " " + easyButton.getPort().ToString();
                        break;
                    case 3:
                        //AddMsg("func 2");
                        Properties.Settings.Default["func3_type"] = easyButton.getType();
                        Properties.Settings.Default["func3_port"] = easyButton.getPort();
                        //btnFnc3.Text = easyButton.getType().ToString() + " " + easyButton.getPort().ToString();
                        break;
                    case 4:
                        Properties.Settings.Default["func4_type"] = easyButton.getType();
                        Properties.Settings.Default["func4_port"] = easyButton.getPort();
                        //btnFnc3.Text = easyButton.getType().ToString() + " " + easyButton.getPort().ToString();
                        break;
                    case 5:
                        Properties.Settings.Default["func5_type"] = easyButton.getType();
                        Properties.Settings.Default["func5_port"] = easyButton.getPort();
                        //btnFnc3.Text = easyButton.getType().ToString() + " " + easyButton.getPort().ToString();
                        break;
					case 6:
						Properties.Settings.Default["func6_type"] = easyButton.getType();
						Properties.Settings.Default["func6_port"] = easyButton.getPort();
						//btnFnc3.Text = easyButton.getType().ToString() + " " + easyButton.getPort().ToString();
						break;
					case 7:
						Properties.Settings.Default["func7_type"] = easyButton.getType();
						Properties.Settings.Default["func7_port"] = easyButton.getPort();
						//btnFnc3.Text = easyButton.getType().ToString() + " " + easyButton.getPort().ToString();
						break;
					default:
                        break;
                }
                Properties.Settings.Default.Save();
                //AddMsg("type: " + easyButton.getType().ToString());
                //AddMsg("port: " + easyButton.getPort().ToString());
            }
            else
            {

            }
            easyButton.Dispose();
        }

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
            if (client_connected)
            {
                svrcmd.Send_ClCmd(svrcmd.GetCmdIndexI("DISCONNECT"), 4, " ");
                disconnect_attempts = 0;
                AddMsg("disconnecting");
                btnConnect.Text = "Connect";
                //timer1.Enabled = false;
                client_connected = false;
                m_client.Disconnect();
            }
            garageform.Dispose();
            testbench.Dispose();
            this.Close();
        }
        private void SendClientMsg(int msg, string param, bool remove)
        {
            foreach (ClientsAvail cl in clients_avail)
            {
                //AddMsg(cl.label + " " + cl.lbindex.ToString());
                if (lbAvailClients.SelectedIndex > -1 && cl.lbindex == lbAvailClients.SelectedIndex)
                {
                    //AddMsg("send msg: " + cl.label + " " + cl.index);
                    if (remove)
                    {
                        cl.lbindex = -1;
                        cl.socket = -1;
                    }
                    svrcmd.Send_ClCmd(msg, cl.index, param);
                    //AddMsg(cl.index.ToString());
                    // if cl.index == server then set disconnected flag

                    //if ((cl.index == 5) && (msg == REBOOT_IOBOX))
                    if (false)
                    {
                        btnConnect.Text = "Connect";
                        //timer1.Enabled = false;
                        client_connected = false;
                    }
                    RedrawClientListBox();
                    if (!remove)
                    {
                        lbAvailClients.SetSelected(cl.lbindex, true);
                    }
                }
            }
        }
        private void SendClientMsg(int msg, int param, bool remove)
        {
            foreach (ClientsAvail cl in clients_avail)
            {
                //AddMsg(cl.label + " " + cl.lbindex.ToString());
                if (lbAvailClients.SelectedIndex > -1 && cl.lbindex == lbAvailClients.SelectedIndex)
                {
                    //AddMsg("send msg: " + cl.label + " " + cl.index);
                    if (remove)
                    {
                        cl.lbindex = -1;
                        cl.socket = -1;
                    }
                    svrcmd.Send_ClCmd(msg, cl.index, param);
                    //AddMsg(cl.index.ToString());
                    // if cl.index == server then set disconnected flag

                    //if ((cl.index == 8) && (msg == REBOOT_IOBOX))
                    if (false)
                    {
                        btnConnect.Text = "Connect";
                        //timer1.Enabled = false;
                        client_connected = false;
                    }
                    RedrawClientListBox();
                    if (!remove)
                    {
                        lbAvailClients.SetSelected(cl.lbindex, true);
                    }
                }
            }
        }

        private void exitToShellToolStripMenuItem_Click(object sender, EventArgs e)
		{
            SendClientMsg(svrcmd.GetCmdIndexI("EXIT_TO_SHELL"), " ", true);

            AlertLabel.Text = "";
            AlertLabel.Visible = false;
            //client_alert = false;
        }

		private void showTimeUpToolStripMenuItem_Click(object sender, EventArgs e)
		{
            foreach (ClientsAvail cl in clients_avail)
            {
                if (lbAvailClients.SelectedIndex > -1 && cl.lbindex == lbAvailClients.SelectedIndex)
                //  if(cl.socket > 0)   // to do all at once
                {
                    //AddMsg(cl.label + " " + cl.index.ToString() + " " + cl.lbindex.ToString());
                    svrcmd.Send_ClCmd(svrcmd.GetCmdIndexI("SEND_TIMEUP"), cl.index, " ");
                    //svrcmd.Send_ClCmd(svrcmd.GetCmdIndexI("GET_CONFIG2"), cl.index, " ");
                }
            }
        }

        private void getTimeToolStripMenuItem_Click(object sender, EventArgs e)
		{
            foreach (ClientsAvail cl in clients_avail)
            {
                if (lbAvailClients.SelectedIndex > -1 && cl.lbindex == lbAvailClients.SelectedIndex)
                {
                    svrcmd.Send_ClCmd(svrcmd.GetCmdIndexI("GET_TIME"), cl.index, " ");
                }
            }
        }

        private void setTimeToolStripMenuItem_Click(object sender, EventArgs e)
		{
            foreach (ClientsAvail cl in clients_avail)
            {
                if (lbAvailClients.SelectedIndex > -1 && cl.lbindex == lbAvailClients.SelectedIndex)
                {
                    //AddMsg(cl.label);
                    SetTime(cl.index);
                }
            }
        }

        private void rebootToolStripMenuItem_Click(object sender, EventArgs e)
		{
            SendClientMsg(svrcmd.GetCmdIndexI("REBOOT_IOBOX"), " ", true);
        }

		private void shutdownToolStripMenuItem_Click(object sender, EventArgs e)
		{
            SendClientMsg(svrcmd.GetCmdIndexI("SHUTDOWN_IOBOX"), " ", true);
        }

		private void getStatusToolStripMenuItem_Click(object sender, EventArgs e)
		{
            SendClientMsg(svrcmd.GetCmdIndexI("SEND_STATUS"), "status", false);
        }

		private void btnExit_Click(object sender, EventArgs e)
		{
            DialogResult ret = MessageBox.Show("Do you want to exit?",
                "Important Question",
                MessageBoxButtons.YesNo);
            if (ret == DialogResult.Yes)
                exitToolStripMenuItem_Click(new object(), new EventArgs());
        }

		private void loadTempFileToolStripMenuItem_Click(object sender, EventArgs e)
		{
                   }
        private string ChooseTXTFileName()
        {
            OpenFileDialog openFileDialog2 = new OpenFileDialog
            {
                InitialDirectory = initial_directory,
                Title = "Browse TXT Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.TXT",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                //tbFileName.Text = openFileDialog2.FileName;
                return openFileDialog2.FileName;
            }
            else return "";

        }
        private string ChooseDATFileName()
        {
            OpenFileDialog openFileDialog2 = new OpenFileDialog
            {
                InitialDirectory = initial_data_directory,
                Title = "Browse dat Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "dat",
                Filter = "dat files (*.dat)|*.DAT",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                //tbFileName.Text = openFileDialog2.FileName;
                return openFileDialog2.FileName;
            }
            else return "";

        }
		private void btnWaterTimeShort_Click(object sender, EventArgs e)
		{
            garageform.RunWaterPump(10);
		}

		private void btnWaterTimeMedium_Click(object sender, EventArgs e)
		{
			garageform.RunWaterPump(30);
		}

		private void btnWaterTimeLong_Click(object sender, EventArgs e)
		{
			garageform.RunWaterPump(52);
		}

		private void sendMessageToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SendClientMsg(svrcmd.GetCmdIndexI("SEND_MESSAGE2"), SendMessageBox.Text, false);
		}

		private void minTempChanged(object sender, EventArgs e)
		{
			MinTemp = Convert.ToInt32(tbMinTemp.Text);
            AddMsg(MinTemp.ToString());
		}

		private void btnTest_Click(object sender, EventArgs e)
		{
            svrcmd.Send_ClCmd(svrcmd.GetCmdIndexI("WATER_HEATER"), 5, "ON");
            AddMsg("pump on");
		}

		private void btnPumpOff_Click(object sender, EventArgs e)
		{
			svrcmd.Send_ClCmd(svrcmd.GetCmdIndexI("WATER_HEATER"), 5, "OFF");
			AddMsg("pump off");
		}

        private void button1_Click(object sender, EventArgs e)
        {

            if (light_list)
            {
                light_list = false;
				svrcmd.Send_ClCmd(svrcmd.GetCmdIndexI("NORTHWEST_LIGHT"), 5, "OFF");
				svrcmd.Send_ClCmd(svrcmd.GetCmdIndexI("MIDDLE_LIGHT"), 5, "OFF");
				svrcmd.Send_ClCmd(svrcmd.GetCmdIndexI("BENCH_LIGHT1"), 2, "OFF");
				/*
				svrcmd.Send_ClCmd(svrcmd.GetCmdIndexI("CABIN_SOUTH"), 1, "OFF");
				svrcmd.Send_ClCmd(svrcmd.GetCmdIndexI("CABIN_KITCHEN"), 1, "OFF");
                */
				btn_light_list.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
                btn_light_list.Text = "OFF";
                timer3.Enabled = false;
			}
			else
            {
                light_list = true;
				svrcmd.Send_ClCmd(svrcmd.GetCmdIndexI("NORTHWEST_LIGHT"), 5, "ON");
				svrcmd.Send_ClCmd(svrcmd.GetCmdIndexI("MIDDLE_LIGHT"), 5, "ON");
				svrcmd.Send_ClCmd(svrcmd.GetCmdIndexI("BENCH_LIGHT1"), 2, "ON");
				/*
				svrcmd.Send_ClCmd(svrcmd.GetCmdIndexI("CABIN_SOUTH"), 1, "ON");
				svrcmd.Send_ClCmd(svrcmd.GetCmdIndexI("CABIN_KITCHEN"), 1, "ON");
                */
				btn_light_list.BackColor = Color.Aqua;
				btn_light_list.Text = "ON";
                timer3.Enabled = true;
			}
		}

		private void sendClientListToolStripMenuItem_Click(object sender, EventArgs e)
		{
            string str = "";
			if (m_client.IsConnectionAlive)
			{
				//str = String.Format("{0,-2} {1,-2}", 0, 0);
				//svrcmd.Send_ClCmd(svrcmd.GetCmdIndexI("UPDATE_CLIENT_TABLE"), 5, str);

				foreach (ClientsAvail cl in clients_avail)
				{
					if ((cl.type == 1) && cl.socket > 0)  // set the time on any server/clients in the active list
																		  // type 1 is TS_CLIENT type 2 is TS_SERVER
					{
						str = String.Format("{0,-2} {1,-2}",cl.index, cl.socket);
                        AddMsg(str);
						//svrcmd.Send_ClCmd(svrcmd.GetCmdIndexI("UPDATE_CLIENT_TABLE"), 5, str);
					}

				}
			}

		}
		private void btnHeaterApply_Click(object sender, EventArgs e)
		{
			svrcmd.Send_ClCmd(svrcmd.GetCmdIndexI("CABIN7"), 1, "ON");
            heater_counter = 0;
            heaterStatus = true;
            //AddMsg("heater on");
		}

		private void btnHeaterTimer_Click(object sender, EventArgs e)
		{
            if(!heaterTimerOn)
            {
                btnHeaterApply.Enabled = true;
                tbHeaterTimeOn.Enabled = true;
                tbHeaterTimeOff.Enabled = true;
                heaterTimerOn = true;
                heaterStatus = true;
                btnHeaterTimer.Text = "Heater On";
            }
            else
            {
				btnHeaterApply.Enabled = false;
				tbHeaterTimeOn.Enabled = false;
				tbHeaterTimeOff.Enabled = false;
                heaterTimerOn = false;
				svrcmd.Send_ClCmd(svrcmd.GetCmdIndexI("CABIN7"), 1, "OFF");
				AddMsg("heater off");
				heaterStatus = false;
				btnHeaterTimer.Text = "Heater Off";
			}

		}

		private void tbHeaterTimeOn_TextChanged(object sender, EventArgs e)
		{
			heaterTimeOn = Convert.ToInt16(tbHeaterTimeOn.Text);
			//AddMsg(heaterTimeOn.ToString());
		}

		private void tbHeaterTimeOff_TextChanged(object sender, EventArgs e)
		{
			heaterTimeOff = Convert.ToInt16(tbHeaterTimeOff.Text);
			//AddMsg(heaterTimeOff.ToString());
		}
	}
}