using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQTT.Service.DotNet.SDK.Model
{
    public class DataMessage : BaseMessage
    {
        [JsonProperty( PropertyName = "d" )]
        public Dictionary<string, DataObject> D { get; set; }

        public DataMessage()
        {
            D = new Dictionary<string, DataObject>();
        }

        public class DataObject
        {
            [JsonProperty( PropertyName = "Val" )]
            public Dictionary<string, Object> DataObj { get; set; }

            public DataObject()
            {
                DataObj = new Dictionary<string, Object>();
            }

        }
    }
}
