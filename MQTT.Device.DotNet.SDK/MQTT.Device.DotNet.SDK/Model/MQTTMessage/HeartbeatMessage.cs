using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQTT.Device.DotNet.SDK.Model
{
    public class HeartbeatMessage : BaseMessage
    {
        [JsonProperty( PropertyName = "d" )]
        public Dictionary<string, ScadaObject> ScadaList { get; set; }

        public HeartbeatMessage()
        {
        }

        public class ScadaObject
        {
            [JsonProperty(PropertyName = "Hbt")]
            public int Hbt { get; set; }

            public ScadaObject()
            {
                Hbt = 1;
            }
        }

      
    }
}
