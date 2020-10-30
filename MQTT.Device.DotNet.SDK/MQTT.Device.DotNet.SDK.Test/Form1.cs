using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MQTT.Device.DotNet.SDK;
using MQTT.Device.DotNet.SDK.Model;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace MQTT.Device.DotNet.SDK.Test
{
    public partial class Form1 : Form
    {
        private EdgeAgent _edgeAgent;
        public Form1()
        {
            InitializeComponent();

            comboBoxComm.Items.Add("Websocket");
            comboBoxComm.Items.Add("TCP");
            textBoxGroupId.Text = textBoxCloudProject.Text +"_" + textBoxCloudNode.Text;
            comboBoxComm.Text = "TCP";
        }

        int gloublev = 0;
        private EdgeData prepareData()
        {
            Random random = new Random();

            EdgeData data = new EdgeData();

            //gloublev++;

            for (int j = 1; j <= numATagCount.Value; j++)
            {

                // simulation data
                int indexData, indexQCODE;
                indexData = gloublev;
                indexQCODE = gloublev % 3;

                JObject jObj = new JObject(
                    new JProperty("0", indexData),
                    new JProperty("1", indexQCODE));

                EdgeData.Tag aTag = new EdgeData.Tag()
                {
                    DeviceId = textBoxGroupId.Text,
                    TagName = "ATag" + j,
                    Value = jObj
                };
                data.TagList.Add(aTag);
            }
            for (int j = 1; j <= numDTagCount.Value; j++)
            {
                EdgeData.Tag dTag = new EdgeData.Tag()
                {
                    DeviceId = textBoxGroupId.Text,
                    TagName = "DTag" + j,
                    Value = j % 2
                };
                data.TagList.Add(dTag);
            }
            for (int j = 1; j <= numTTagCount.Value; j++)
            {
                EdgeData.Tag tTag = new EdgeData.Tag()
                {
                    DeviceId = textBoxGroupId.Text,
                    TagName = "TTag" + j,
                    Value = "TEST " + j.ToString()
                };
                data.TagList.Add(tTag);
            }
            
            data.Timestamp = DateTime.Now;  
            return data;
        }
        private void _edgeAgent_Connected(object sender, EdgeAgentConnectedEventArgs e)
        {
            if (this.lblStatus.InvokeRequired)
            {
                BeginInvoke((MethodInvoker)delegate ()
                {
                    lblStatus.Text = "CONNECTED";
                    lblStatus.BackColor = Color.Green;
                });
            }
        }
        private void _edgeAgent_Disconnected(object sender, DisconnectedEventArgs e)
        {
            if (this.lblStatus.InvokeRequired)
            {
                BeginInvoke((MethodInvoker)delegate ()
                {
                    lblStatus.Text = "DISCONNECTED";
                    lblStatus.BackColor = Color.Silver;
                });
            }
        }

        private void _edgeAgent_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            switch (e.Type)
            {
                case MessageType.WriteValue:
                    WriteValueCommand wvcMsg = (WriteValueCommand)e.Message;
                    foreach (var device in wvcMsg.DeviceList)
                    {
                        foreach (var tag in device.TagList)
                        {                       
                            if (tag.Value.GetType() == typeof(JObject))
                            {
                                //Array Tag
                                JObject arrayTag = JObject.Parse(tag.Value.ToString());
                                string index = arrayTag.First.Path;
                                var value = arrayTag.First.First;
                                Console.WriteLine("TagName: {0}, Index: {1}, Value: {2}", tag.Name, index , value.ToString());
                            }
                            else
                            {
                                //Non-Array Tag
                                Console.WriteLine("TagName: {0}, Value: {1}", tag.Name, tag.Value.ToString());
                            }
                           
                        }
                    }
                    break;
                /*case MessageType.WriteConfig:
                    break;*/
                case MessageType.TimeSync:  // when received this message
                    TimeSyncCommand tscMsg = (TimeSyncCommand)e.Message;
                    Console.WriteLine("UTC Time: {0}", tscMsg.UTCTime.ToString());
                    break;
                case MessageType.ConfigAck:
                    ConfigAck cfgAckMsg = (ConfigAck)e.Message;
                    MessageBox.Show(string.Format("Upload Config Result: {0}", cfgAckMsg.Result.ToString()));
                    break;
            }
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (_edgeAgent == null)
            {
                EdgeAgentOptions options = new EdgeAgentOptions()
                {
                    AutoReconnect = true,

                    ReconnectInterval = 1000,

                    ScadaId = textBoxGroupId.Text,

                    Type = EdgeType.Gateway,

                    Heartbeat = 60000,   // default is 60 seconds,

                    DataRecover = true,

                    ConnectType = ConnectType.MQTT,

                    UseSecure = checkBoxSSL.Checked
                };

                switch (options.ConnectType)
                {
                    case ConnectType.MQTT:
                        options.MQTT = new MQTTOptions()
                        {
                            HostName = textBoxIp.Text,
                            Port = Convert.ToInt32(textBoxPort.Text),
                            Username = textBoxUser.Text,
                            Password = textBoxPwd.Text,
                            ProtocolType = Protocol.TCP
                        };
                        break;
                }

                _edgeAgent = new EdgeAgent(options);

                _edgeAgent.Connected += _edgeAgent_Connected;
                _edgeAgent.Disconnected += _edgeAgent_Disconnected;
                _edgeAgent.MessageReceived += _edgeAgent_MessageReceived;
            }
            _edgeAgent.Connect();
        }

        private void textBoxCloudProject_TextChanged(object sender, EventArgs e)
        {
            textBoxGroupId.Text = textBoxCloudProject.Text + "_" + textBoxCloudNode.Text;
        }

        private void textBoxCloudNode_TextChanged(object sender, EventArgs e)
        {
            textBoxGroupId.Text = textBoxCloudProject.Text +"_"+ textBoxCloudNode.Text;
        }

        private void comboBoxComm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxComm.Text == "Websocket") {
                textBoxPort.Text = "51328";
            }
            if (comboBoxComm.Text == "TCP")
            {
                textBoxPort.Text = "1883";
            }

        }

        private void buttonUploadConfig_Click(object sender, EventArgs e)
        {
            if (_edgeAgent == null)
                return;

            EdgeConfig config = new EdgeConfig();
            config.Scada = new EdgeConfig.ScadaConfig()
            {
                Id = textBoxGroupId.Text.Trim(),
                Description = "descrp",
                PortNumber = (int)numericUpDownPort.Value,
                HeartBeat = 60,
                BackupDeviceId = 0
                
            };

            config.Scada.AnalogTagList = new List<EdgeConfig.AnalogTagConfig> ();
            config.Scada.DiscreteTagList = new List<EdgeConfig.DiscreteTagConfig>();
            config.Scada.TextTagList = new List<EdgeConfig.TextTagConfig>();

            for (int j = 1; j <= numATagCount.Value; j++)
            {
                EdgeConfig.AnalogTagConfig analogTag = new EdgeConfig.AnalogTagConfig()
                {
                    Name = "ATag" + j,
                    Description = "ATag " + j,
                    ReadOnly = false,
                    ArraySize = 2, 

                    NeedLog = true,
                    SpanHigh = 1000,
                    SpanLow = 0,
                    EngineerUnit = string.Empty,
                    DisplayFormat = "4.2",
                    AlarmEnable = false,
                    HHPriority = 0,
                    HHAlarmLimit = 0,
                    HighPriority = 0,
                    HighAlarmLimit = 0,
                    LowPriority = 0,
                    LowAlarmLimit = 0,
                    LLPriority = 0,
                    LLAlarmLimit = 0
                };
                config.Scada.AnalogTagList.Add(analogTag);
            }
            for (int j = 1; j <= numDTagCount.Value; j++)
            {
                EdgeConfig.DiscreteTagConfig discreteTag = new EdgeConfig.DiscreteTagConfig()
                {
                    Name = "DTag" + j,
                    Description = "DTag " + j,
                    ReadOnly = false,
                    ArraySize = 0,

                    AlarmEnable = false,
                    State0 = "0",
                    State1 = "1",
                    State2 = string.Empty,
                    State3 = string.Empty,
                    State4 = string.Empty,
                    State5 = string.Empty,
                    State6 = string.Empty,
                    State7 = string.Empty,
                    State0AlarmPriority = 0,
                    State1AlarmPriority = 0,
                    State2AlarmPriority = 0,
                    State3AlarmPriority = 0,
                    State4AlarmPriority = 0,
                    State5AlarmPriority = 0,
                    State6AlarmPriority = 0,
                    State7AlarmPriority = 0
                };
                config.Scada.DiscreteTagList.Add(discreteTag);
            }
            for (int j = 1; j <= numTTagCount.Value; j++)
            {
                EdgeConfig.TextTagConfig textTag = new EdgeConfig.TextTagConfig()
                {
                    Name = "TTag" + j,
                    Description = "TTag " + j,
                    ReadOnly = false,
                    ArraySize = 2,
                };
                config.Scada.TextTagList.Add(textTag);
            }

            bool result = _edgeAgent.UploadConfig(ActionType.Create, config).Result;
        }

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            if (_edgeAgent == null)
                return;

            _edgeAgent.Disconnect();

            _edgeAgent = null;
        }

        private void buttonSendData_Click(object sender, EventArgs e)
        {
            if (_edgeAgent == null)
                return;

            timer1.Interval = (int)numDataFreq.Value * 1000;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_edgeAgent == null)
                return;

            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Reset();
            sw.Start();

            EdgeData data = prepareData();
            bool result = _edgeAgent.SendData(data).Result;

            sw.Stop();
            Console.WriteLine(sw.Elapsed.TotalMilliseconds.ToString());
        }
    }
}
