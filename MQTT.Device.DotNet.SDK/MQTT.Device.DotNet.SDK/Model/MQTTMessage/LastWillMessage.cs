using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQTT.Device.DotNet.SDK.Model
{
    public class LastWillMessage : BaseMessage
    {
        [JsonProperty(PropertyName = "d")]
        public Dictionary<string, DObject> ScadaList { get; set; }

        public LastWillMessage()
        {
        }

        public class DObject
        {
            [JsonProperty( PropertyName = "UeD" )]
            public int UeD { get; set; }

            public DObject()
            {
                UeD = 1;
            }
        }
    }
}
