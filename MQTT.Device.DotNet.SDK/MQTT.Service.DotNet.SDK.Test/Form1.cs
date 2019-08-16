using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

using MQTT.Service.DotNet.SDK;
using MQTT.Service.DotNet.SDK.Model;

namespace MQTT.Service.DotNet.SDK.Test
{
    public partial class Form1 : Form
    {

        private EdgeAgent _edgeAgent;

        public Form1()
        {
            Form1.CheckForIllegalCrossThreadCalls = false;

            InitializeComponent();

            comboBoxComm.Items.Add("Websocket");
            comboBoxComm.Items.Add("TCP");
            textBoxGroupId.Text = textBoxCloudProject.Text +"_" + textBoxCloudNode.Text;
            comboBoxComm.Text = "TCP";
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
            if (listBoxLogger2.Items.Count >= 1000)
            {
                listBoxLogger2.Items.Clear();
            }

            JObject jObj = JObject.Parse(e.Message.ToString());

            listBoxLogger2.Items.Add(e.Message.ToString());
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

                    Type = EdgeType.Device,

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
        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            if (_edgeAgent == null)
                return;

            _edgeAgent.Disconnect();

            _edgeAgent = null;
        }

        private void LblStatus_Click(object sender, EventArgs e)
        {

        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            listBoxLogger2.Items.Clear();
        }
    }
}
