using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQTT.Service.DotNet.SDK.Model
{
    public class EdgeAgentOptions
    {
        public bool AutoReconnect { get; set; }
        public int ReconnectInterval { get; set; }
        public string ScadaId { get; set; }
        public string DeviceId { get; set; }
        public EdgeType Type { get; set; }
        public ConnectType ConnectType { get; set; }
        public bool UseSecure { get; set; }

        public MQTTOptions MQTT;

        public EdgeAgentOptions()
        {
            AutoReconnect = false;
            ReconnectInterval = 1000;
            ScadaId = string.Empty;
            DeviceId = string.Empty;
            Type = EdgeType.Gateway;
            ConnectType = ConnectType.MQTT;
            UseSecure = false;

            MQTT = new MQTTOptions();
        }
    }

    public class MQTTOptions
    {
        public string HostName { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Protocol ProtocolType { get; set; }

        public MQTTOptions()
        {
            HostName = string.Empty;
            Port = 1883;
            Username = string.Empty;
            Password = string.Empty;
            ProtocolType = Protocol.TCP;
        }

        public MQTTOptions( string host, int port, string username, string password, Protocol protocol = Protocol.TCP )
        {
            HostName = host;
            Port = port;
            Username = username;
            Password = password;
            ProtocolType = protocol;
        }
    }

}
