using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQTT.Device.DotNet.SDK.Model
{
    public class WriteValueCommand
    {
        public List<Device> DeviceList { get; set; }
        public DateTime Timestamp { get; set; }

        public WriteValueCommand()
        {
            DeviceList = new List<Device>();
            Timestamp = DateTime.UtcNow;
        }

        public class Device
        {
            public string Id { get; set; }
            public List<Tag> TagList { get; set; }

            public Device()
            {
                Id = string.Empty;
                TagList = new List<Tag>();
            }
        }

        public class Tag
        {
            public string Name { get; set; }
            public object Value { get; set; }

            public Tag()
            {
                Name = string.Empty;
                Value = new object();
            }
        }
    }
}
