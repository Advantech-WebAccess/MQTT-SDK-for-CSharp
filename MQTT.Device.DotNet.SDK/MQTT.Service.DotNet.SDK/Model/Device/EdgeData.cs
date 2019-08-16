using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQTT.Service.DotNet.SDK.Model
{
    public class EdgeData
    {
        public List<Tag> TagList { get; set; }
        public DateTime Timestamp { get; set; }

        public EdgeData()
        {
            TagList = new List<Tag>();
            Timestamp = DateTime.UtcNow;
        }

        public class Tag
        {
            public string DeviceId { get; set; }
            public string TagName { get; set; }
            public object Value { get; set; }

            public Tag()
            {
                DeviceId = string.Empty;
                TagName = string.Empty;
                Value = new object();
            }
        }
    }
}
