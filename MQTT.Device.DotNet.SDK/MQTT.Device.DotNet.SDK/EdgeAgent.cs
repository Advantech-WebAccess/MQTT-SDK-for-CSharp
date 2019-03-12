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
using MQTT.Device.DotNet.SDK.Model;

namespace MQTT.Device.DotNet.SDK
{
    public class EdgeAgent
    {
        public const int DEAFAULT_HEARTBEAT_INTERVAL = 60000;
        public const int DEAFAULT_DATARECOVER_INTERVAL = 3000;
        public const int DEAFAULT_DATARECOVER_COUNT = 1;

        private ManagedMqttClient _mqttClient;
        private DataRecoverHelper _recoverHelper;

        private string _configTopic;
        private string _dataTopic;
        private string _scadaConnTopic;
        private string _deviceConnTopic;
        private string _cmdTopic;
        private string _ackTopic;
        private string _cfgAckTopic;

        private Timer _heartbeatTimer;
        private Timer _dataRecoverTimer;

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

            _heartbeatTimer = new Timer();
            _heartbeatTimer.Interval = _options.Heartbeat;
            _heartbeatTimer.Elapsed += _heartbeatTimer_Elapsed;

            if (options.DataRecover)
            {
                _recoverHelper = new DataRecoverHelper();
                _dataRecoverTimer = new Timer();
                _dataRecoverTimer.Interval = DEAFAULT_DATARECOVER_INTERVAL;
                _dataRecoverTimer.Elapsed += _dataRecoverTimer_Elapsed;
                _dataRecoverTimer.Enabled = true;
            }

            MqttTcpChannel.CustomCertificateValidationCallback = (x509Certificate, x509Chain, sslPolicyErrors, mqttClientTcpOptions) => { return true; };
        }

        #region >>> Private Method <<<

        private void _dataRecoverTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (_mqttClient.IsConnected == false)
                return;

            if (_recoverHelper != null && _recoverHelper.DataAvailable())
            {
                List<string> records = _recoverHelper.Read(DEAFAULT_DATARECOVER_COUNT);
                foreach (var record in records)
                {
                    var message = new MqttApplicationMessageBuilder()
                    .WithTopic(_dataTopic)
                    .WithPayload(record)
                    .WithAtLeastOnceQoS()
                    .WithRetainFlag(false)
                    .Build();

                    _mqttClient.PublishAsync(message);
                }
            }
        }

        private void _heartbeatTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            HeartbeatMessage heartbeatMsg = new HeartbeatMessage();
            string payload = JsonConvert.SerializeObject(heartbeatMsg);

            var message = new MqttApplicationMessageBuilder()
            .WithTopic((_options.Type == EdgeType.Gateway) ? _scadaConnTopic : _deviceConnTopic)
            .WithPayload(payload)
            .WithAtLeastOnceQoS()
            .WithRetainFlag(true)
            .Build();

            _mqttClient.PublishAsync(message);
        }

        private void _test() {
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
            }
            catch (Exception ex)
            {
                //_logger.Error( ex.ToString() );
            }
        }

        private bool _uploadConfig(ActionType action, EdgeConfig edgeConfig)
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                //_logger.Error( ex.ToString() );
                return false;
            }
        }

        /*
        private bool _sendData(EdgeData data)
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                //_logger.Error( ex.ToString() );
                return false;
            }
        }

        private bool _sendDeviceStatus(EdgeDeviceStatus deviceStatus)
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                //_logger.Error( ex.ToString() );
                return false;
            }
        }
        */
        private void mqttClient_MessageReceived(object sender, MqttApplicationMessageReceivedEventArgs e)
        {
            try
            {
               
            }
            catch (Exception ex)
            {
                //_logger.Error( ex.ToString() );
                Console.WriteLine(ex.ToString());
            }
        }

        private void mqttClient_Connected(object sender, MqttClientConnectedEventArgs e)
        {
            try
            {
                //_logger.Info( "MQTT Connect Success !" );

                if (string.IsNullOrEmpty(_options.ScadaId) == false)
                {
                    /*
                    public const string ConfigTopic = "iot-2/evt/wacfg/fmt/{0}";
                    public const string DataTopic = "iot-2/evt/wadata/fmt/{0}";

                    public const string ScadaConnTopic = "iot-2/evt/waconn/fmt/{0}";

                    public const string ScadaCmdTopic = "iot-2/evt/wacmd/fmt/{0}";
                    public const string DeviceCmdTopic = "iot-2/evt/wacmd/fmt/{0}/{1}";
                    */

                    string scadaCmdTopic = string.Format("iot-2/evt/wacmd/fmt/{0}", _options.ScadaId);
                    string deviceCmdTopic = string.Format("iot-2/evt/wacmd/fmt/{0}/{1}", _options.ScadaId, _options.DeviceId);

                    _configTopic = string.Format("iot-2/evt/wacfg/fmt/{0}", _options.ScadaId);
                    _dataTopic = string.Format("iot-2/evt/wadata/fmt/{0}", _options.ScadaId);
                    _scadaConnTopic = string.Format("iot-2/evt/waconn/fmt/{0}", _options.ScadaId);

                    if (_options.Type == EdgeType.Gateway)
                        _cmdTopic = scadaCmdTopic;
                    else
                        _cmdTopic = deviceCmdTopic;
                }

                if (_options.Heartbeat > 0)
                {
                    if (_heartbeatTimer == null)
                        _heartbeatTimer = new Timer();

                    _heartbeatTimer.Enabled = false;
                    _heartbeatTimer.Interval = _options.Heartbeat;
                }

                if (Connected != null)
                    Connected(this, new EdgeAgentConnectedEventArgs(e.IsSessionPresent));

                // subscribe
                _mqttClient.SubscribeAsync(new TopicFilterBuilder().WithTopic(_cmdTopic).WithAtLeastOnceQoS().Build());
                _mqttClient.SubscribeAsync(new TopicFilterBuilder().WithTopic(_ackTopic).WithAtLeastOnceQoS().Build());

                // publish
                ConnectMessage connectMsg = new ConnectMessage();
                string payload = JsonConvert.SerializeObject(connectMsg);
                var message = new MqttApplicationMessageBuilder()
                .WithTopic((_options.Type == EdgeType.Gateway) ? _scadaConnTopic : _deviceConnTopic)
                .WithPayload(payload)
                .WithAtLeastOnceQoS()
                .WithRetainFlag(true)
                .Build();

                _mqttClient.PublishAsync(message);

                // start heartbeat timer
                _heartbeatTimer.Enabled = true;
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
                
            }
            catch (Exception ex)
            {
                //_logger.Error( ex.ToString() );
            }
        }

        #endregion

        #region Public Method

        public Task Test() {
            return Task.Run( ()=> _test());
        }

        public Task Connect()
        {
            return Task.Run(() => _connect());
        }
        #endregion
    }
}
