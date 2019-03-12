using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WISEPaaS.SCADA.DotNet.SDK.Model
{
    public class DataMessage : BaseMessage
    {
        [JsonProperty( PropertyName = "d" )]
        public Dictionary<string, object> D { get; set; }

        public DataMessage()
        {
            D = new Dictionary<string, object>();
        }
    }
}
