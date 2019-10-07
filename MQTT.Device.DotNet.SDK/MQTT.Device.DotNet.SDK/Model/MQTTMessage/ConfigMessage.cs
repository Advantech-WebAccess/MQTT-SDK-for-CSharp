using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQTT.Device.DotNet.SDK.Model
{
    public class ConfigMessage : BaseMessage
    {
        [JsonProperty( PropertyName = "d" )]
        public Dictionary<string, ScadaObject> ScadaList { get; set; }

        public ConfigMessage()
        {
        }

        public class ScadaObject
        {
            //[JsonProperty( PropertyName = "ID" )]
            //public string Id { get; set; }

            [JsonProperty( PropertyName = "TID" )]
            public SCADAConfigType? DeviceType { get; set; }

            [JsonProperty(PropertyName = "Dsc")]
            public string Description { get; set; }

            [JsonProperty( PropertyName = "Hbt" )]
            public int? HeartBeat { get; set; }

            [JsonProperty(PropertyName = "PID")]
            public int? PortNumber { get; set; }

            [JsonProperty( PropertyName = "BID" )]
            public int? BackupDeviceId { get; set; }

            [JsonProperty( PropertyName = "UTg" )]
            public Dictionary<string, TagObject> UpdateTagList { get; set; }

            [JsonProperty(PropertyName = "DTg")]
            public Dictionary<string, TagObject> DeleteTagList { get; set; }

            [JsonProperty(PropertyName = "Del")]
            public int? DeleteAllTags { get; set; }

            public ScadaObject()
            {
            }
        }

        public class TagObject
        {
            public string Name { get; set; }

            [JsonProperty( PropertyName = "TID" )]
            public TagType? Type { get; set; }

            [JsonProperty( PropertyName = "Dsc" )]
            public string Description { get; set; }

            [JsonProperty( PropertyName = "RO" )]
            public int? ReadOnly { get; set; }

            [JsonProperty( PropertyName = "Ary" )]
            public int? ArraySize { get; set; }

        }

        public class AnalogTagObject : TagObject
        {
            [JsonProperty(PropertyName = "Log")]
            public int? NeedLog { get; set; }

            [JsonProperty( PropertyName = "SH" )]
            public double? SpanHigh { get; set; }

            [JsonProperty( PropertyName = "SL" )]
            public double? SpanLow { get; set; }

            [JsonProperty( PropertyName = "EU" )]
            public string EngineerUnit { get; set; }

            [JsonProperty( PropertyName = "DSF" )]
            public string DisplayFormat { get; set; }

            [JsonProperty(PropertyName = "Alm")]
            public bool? AlarmEnable { get; set; }

            [JsonProperty( PropertyName = "HHP" )]
            public int? HHPriority { get; set; }

            [JsonProperty( PropertyName = "HHA" )]
            public double? HHAlarmLimit { get; set; }

            [JsonProperty( PropertyName = "HiP" )]
            public int? HighPriority { get; set; }

            [JsonProperty( PropertyName = "HiA" )]
            public double? HighAlarmLimit { get; set; }

            [JsonProperty( PropertyName = "LoP" )]
            public int? LowPriority { get; set; }

            [JsonProperty( PropertyName = "LoA" )]
            public double? LowAlarmLimit { get; set; }

            [JsonProperty( PropertyName = "LLP" )]
            public int? LLPriority { get; set; }

            [JsonProperty( PropertyName = "LLA" )]
            public double? LLAlarmLimit { get; set; }

            public AnalogTagObject()
            {
            }
        }

        public class DiscreteTagObject : TagObject
        {
            [JsonProperty(PropertyName = "Alm")]
            public bool? AlarmEnable { get; set; }

            [JsonProperty( PropertyName = "S0" )]
            public string State0 { get; set; }
            [JsonProperty( PropertyName = "S1" )]
            public string State1 { get; set; }
            [JsonProperty( PropertyName = "S2" )]
            public string State2 { get; set; }
            [JsonProperty( PropertyName = "S3" )]
            public string State3 { get; set; }
            [JsonProperty( PropertyName = "S4" )]
            public string State4 { get; set; }
            [JsonProperty( PropertyName = "S5" )]
            public string State5 { get; set; }
            [JsonProperty( PropertyName = "S6" )]
            public string State6 { get; set; }
            [JsonProperty( PropertyName = "S7" )]
            public string State7 { get; set; }

            [JsonProperty( PropertyName = "S0P" )]
            public int? State0AlarmPriority { get; set; }
            [JsonProperty( PropertyName = "S1P" )]
            public int? State1AlarmPriority { get; set; }
            [JsonProperty( PropertyName = "S2P" )]
            public int? State2AlarmPriority { get; set; }
            [JsonProperty( PropertyName = "S3P" )]
            public int? State3AlarmPriority { get; set; }
            [JsonProperty( PropertyName = "S4P" )]
            public int? State4AlarmPriority { get; set; }
            [JsonProperty( PropertyName = "S5P" )]
            public int? State5AlarmPriority { get; set; }
            [JsonProperty( PropertyName = "S6P" )]
            public int? State6AlarmPriority { get; set; }
            [JsonProperty( PropertyName = "S7P" )]
            public int? State7AlarmPriority { get; set; }

            public DiscreteTagObject()
            {
            }
        }

        public class TextTagObject : TagObject
        {
            public TextTagObject()
            {
            }
        }
    }
}
