using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WISEPaaS.SCADA.DotNet.SDK.Model
{
    public class DeviceStatusMessage : BaseMessage
    {
        [JsonProperty( PropertyName = "d" )]
        public DObject D { get; set; }

        public DeviceStatusMessage()
        {
            D = new DObject();
        }

        public class DObject
        {
            [JsonProperty( PropertyName = "Dev" )]
            public Dictionary<string, int> DeviceList { get; set; }

            public DObject()
            {
                DeviceList = new Dictionary<string, int>();
            }
        }
    }
}
