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

namespace MQTT.Device.DotNet.SDK.Test
{
    public partial class Form1 : Form
    {
        private EdgeAgent _edgeAgent;
        public Form1()
        {
            InitializeComponent();
        }

        private void _edgeAgent_Connected(object sender, EdgeAgentConnectedEventArgs e)
        {
            BeginInvoke((MethodInvoker)delegate ()
            {
            });
        }
        private void buttonTest_Click(object sender, EventArgs e)
        {
            if (_edgeAgent == null)
            {
                EdgeAgentOptions options = new EdgeAgentOptions()
                {
                    AutoReconnect = true,
                    ReconnectInterval = 1000,
                    ScadaId = "testID",
                    Heartbeat = 2000,   // default is 60 seconds,
                    DataRecover = true,
                    ConnectType = ConnectType.MQTT,
                    UseSecure = true
                };

                switch (options.ConnectType)
                {
                    case ConnectType.MQTT:
                        options.MQTT = new MQTTOptions()
                        {
                            HostName = "172.16.12.62",
                            Port = 8883,
                            Username = "jeremy",
                            Password = "34373437",
                            ProtocolType = Protocol.TCP
                        };
                        break;
                }

                _edgeAgent = new EdgeAgent(options);

                _edgeAgent.Connected += _edgeAgent_Connected;
            }

            //_edgeAgent.Test();
            _edgeAgent.Connect();
        }
    }
}
