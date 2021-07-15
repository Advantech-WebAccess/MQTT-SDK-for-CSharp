using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQTT.Device.DotNet.SDK.Model
{
    public class ConnectMessage : BaseMessage
    {
        [JsonProperty(PropertyName = "d")]
        public Dictionary<string, DObject> ScadaList { get; set; }

        public ConnectMessage()
        {
        }

        public class DObject
        {
            [JsonProperty( PropertyName = "Con" )]
            public int Con { get; set; }

            public DObject()
            {
                Con = 1;
            }
        }
    }
}
