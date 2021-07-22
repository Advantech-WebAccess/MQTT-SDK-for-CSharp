using System;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Implementations;
using MQTTnet.ManagedClient;
using MQTTnet.Protocol;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Timers;
using MQTT.Service.DotNet.SDK.Model;

namespace MQTT.Service.DotNet.SDK
{
    public class EdgeAgent
    {

        private ManagedMqttClient _mqttClient;

        private string _configTopic;
        private string _dataTopic;
        private string _scadaConnTopic;
        private string _wastTopic;

        private string _cmdTopic;

        private Timer _heartbeatTimer;

        private EdgeAgentOptions _options;

        public EdgeAgentOptions Options
        {
            get { return _options; }
            set { _options = value; }
        }

        public bool IsConnected
        {
            get { return _mqttClient.IsConnected; }
        }

        public event EventHandler<EdgeAgentConnectedEventArgs> Connected;
        public event EventHandler<DisconnectedEventArgs> Disconnected;
        public event EventHandler<MessageReceivedEventArgs> MessageReceived;

        public EdgeAgent(EdgeAgentOptions options)
        {
            Options = options;
            _mqttClient = new MqttFactory().CreateManagedMqttClient() as ManagedMqttClient;

            _mqttClient.ApplicationMessageReceived += mqttClient_MessageReceived;
            _mqttClient.Connected += mqttClient_Connected;
            _mqttClient.Disconnected += mqttClient_Disconnected;

            MqttTcpChannel.CustomCertificateValidationCallback = (x509Certificate, x509Chain, sslPolicyErrors, mqttClientTcpOptions) => { return true; };
        }

        #region >>> Private Method <<<

        private void _connect()
        {
            try
            {
                if (_mqttClient != null && _mqttClient.IsConnected)
                    return;

                if (Options == null)
                    return;

                LastWillMessage lastWillMsg = new LastWillMessage();
                string payload = JsonConvert.SerializeObject(lastWillMsg);
                MqttApplicationMessage msg = new MqttApplicationMessage()
                {
                    Payload = Encoding.UTF8.GetBytes(payload),
                    QualityOfServiceLevel = MqttQualityOfServiceLevel.AtLeastOnce,
                    Retain = true,
                    Topic = string.Format(MQTTTopic.ScadaConnTopic, Options.ScadaId)
                };

                string clientId = "EdgeAgent_" + Guid.NewGuid().ToString("N");
                var ob = new MqttClientOptionsBuilder();
                ob.WithClientId(clientId)
                .WithCredentials(Options.MQTT.Username, Options.MQTT.Password)
                .WithCleanSession()
                .WithWillMessage(msg);

                switch (Options.MQTT.ProtocolType)
                {
                    case Protocol.TCP:
                        ob.WithTcpServer(Options.MQTT.HostName, Options.MQTT.Port);
                        break;
                    case Protocol.WebSocket:
                        ob.WithWebSocketServer(Options.MQTT.HostName);
                        break;
                    default:
                        ob.WithTcpServer(Options.MQTT.HostName, Options.MQTT.Port);
                        break;
                }

                if (Options.UseSecure)
                {
                    ob.WithTls();
                }

                var mob = new ManagedMqttClientOptionsBuilder()
                .WithAutoReconnectDelay(TimeSpan.FromMilliseconds(Options.ReconnectInterval))
                .WithClientOptions(ob.Build())
                .Build();

                _mqttClient.StartAsync(mob);
            }
            catch (Exception ex)
            {
                //_logger.Error( ex.ToString() );
            }
        }

        private void _disconnect()
        {
            try
            {
                if (_mqttClient != null && _mqttClient.IsConnected == false)
                    return;

                DisconnectMessage disconnectMsg = new DisconnectMessage();
                string payload = JsonConvert.SerializeObject(disconnectMsg);

                var message = new MqttApplicationMessageBuilder()
                    .WithTopic(_scadaConnTopic)
                    .WithPayload(payload)
                    .WithAtLeastOnceQoS()
                    .WithRetainFlag(true)
                    .Build();

                _mqttClient.PublishAsync(message).ContinueWith(t => _mqttClient.StopAsync());
            }
            catch (Exception ex)
            {
                //_logger.Error( ex.ToString() );
            }
        }

        private void mqttClient_MessageReceived(object sender, MqttApplicationMessageReceivedEventArgs e)
        {
            try
            {
                if (MessageReceived == null)
                    return;

                string payload = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);

                JObject jObj = JObject.Parse(payload);
                if (jObj == null || jObj["d"] == null){
                    return;
                }

                object output = null;
                if (jObj["d"][_options.ScadaId]["UTg"] != null){
                    output = jObj["d"][_options.ScadaId]["UTg"];
                }
                if (jObj["d"][_options.ScadaId]["Val"] != null) {
                    output = jObj["d"][_options.ScadaId]["Val"];
                }

                dynamic obj = jObj as dynamic;

                MessageReceived(sender, new MessageReceivedEventArgs(MessageType.WriteValue, output));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void mqttClient_Connected(object sender, MqttClientConnectedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(_options.ScadaId) == false)
                {
                    string scadaCmdTopic = string.Format("iot-2/evt/wacmd/fmt/{0}", _options.ScadaId);
                    string deviceCmdTopic = string.Format("iot-2/evt/wacmd/fmt/{0}/{1}", _options.ScadaId, _options.ScadaId);

                    _configTopic = string.Format("iot-2/evt/wacfg/fmt/{0}", _options.ScadaId);
                    _dataTopic = string.Format("iot-2/evt/wadata/fmt/{0}", _options.ScadaId);
                    _scadaConnTopic = string.Format("iot-2/evt/waconn/fmt/{0}", _options.ScadaId);
                    _wastTopic = string.Format("iot-2/evt/wast/fmt/{0}", _options.ScadaId);
                }

                if (Connected != null)
                    Connected(this, new EdgeAgentConnectedEventArgs(e.IsSessionPresent));

                // subscribe
                _mqttClient.SubscribeAsync(new TopicFilterBuilder().WithTopic(_configTopic).WithAtLeastOnceQoS().Build());
                _mqttClient.SubscribeAsync(new TopicFilterBuilder().WithTopic(_dataTopic).WithAtLeastOnceQoS().Build());

                // publish
                ConnectMessage connectMsg = new ConnectMessage();
                string payload = JsonConvert.SerializeObject(connectMsg);
                var message = new MqttApplicationMessageBuilder()
                .WithTopic(_scadaConnTopic)
                .WithPayload(payload)
                .WithAtLeastOnceQoS()
                .WithRetainFlag(true)
                .Build();

                _mqttClient.PublishAsync(message);


                var message1 = new MqttApplicationMessageBuilder()
                .WithTopic(_wastTopic)
                .WithPayload(payload)
                .WithAtLeastOnceQoS()
                .WithRetainFlag(true)
                .Build();

                _mqttClient.PublishAsync(message1);
            }
            catch (Exception ex)
            {
                //_logger.Error( ex.ToString() );
            }
        }

        private void mqttClient_Disconnected(object sender, MqttClientDisconnectedEventArgs e)
        {
            try
            {
                DisconnectMessage disconnectMsg = new DisconnectMessage();
                string payload = JsonConvert.SerializeObject(disconnectMsg);

                var message = new MqttApplicationMessageBuilder()
                .WithTopic(_wastTopic)
                .WithPayload(payload)
                .WithAtLeastOnceQoS()
                .WithRetainFlag(true)
                .Build();

                _mqttClient.PublishAsync(message);

                if (Disconnected != null)
                    Disconnected(this, new DisconnectedEventArgs(e.ClientWasConnected, e.Exception));

                // stop heartbeat timer
                _heartbeatTimer.Enabled = false;
            }
            catch (Exception ex)
            {
                //_logger.Error( ex.ToString() );
            }
        }


        #endregion

        #region Public Method

        public Task Connect()
        {
            return Task.Run(() => _connect());
        }

        public Task Disconnect()
        {
            return Task.Run(() => _disconnect());
        }
        #endregion
    }
}
