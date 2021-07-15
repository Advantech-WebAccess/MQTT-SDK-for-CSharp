using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQTT.Device.DotNet.SDK.Model
{
    public class DisconnectMessage : BaseMessage
    {
        [JsonProperty(PropertyName = "d")]
        public Dictionary<string, DObject> ScadaList { get; set; }

        public DisconnectMessage()
        {
        }

        public class DObject
        {
            [JsonProperty( PropertyName = "DsC" )]
            public int DsC { get; set; }

            public DObject()
            {
                DsC = 1;
            }
        }
    }
}
