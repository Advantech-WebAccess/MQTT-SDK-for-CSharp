using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQTT.Service.DotNet.SDK.Model
{
    public class EdgeConfig
    {
        public ScadaConfig Scada { get; set; }

        public EdgeConfig()
        {
            Scada = new ScadaConfig();
        }

        public class ScadaConfig
        {
            public string Id { get; set; }
            public int DeviceType { get; set; }
            public string Description { get; set; }
            public int HeartBeat { get; set; } //PIP
            public int BackupDeviceId { get; set; } // BIP

            public List<AnalogTagConfig> AnalogTagList { get; set; }
            public List<DiscreteTagConfig> DiscreteTagList { get; set; }
            public List<TextTagConfig> TextTagList { get; set; }

            public ScadaConfig()
            {
                Id = string.Empty;
            }
        }


        public class TagConfig
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public bool? ReadOnly { get; set; }
            public int? ArraySize { get; set; }

            public TagConfig()
            {
                Name = string.Empty;
            }
        }

        public class AnalogTagConfig : TagConfig
        {
            public bool? NeedLog { get; set; }
            public double? SpanHigh { get; set; }
            public double? SpanLow { get; set; }
            public string EngineerUnit { get; set; }

            public string DisplayFormat { get; set; }
            public bool? AlarmEnable { get; set; }
            
            public int? HHPriority { get; set; }
            public double? HHAlarmLimit { get; set; }
            public int? HighPriority { get; set; }
            public double? HighAlarmLimit { get; set; }
            public int? LowPriority { get; set; }
            public double? LowAlarmLimit { get; set; }
            public int? LLPriority { get; set; }
            public double? LLAlarmLimit { get; set; }

            public AnalogTagConfig()
            {
            }
        }

        public class DiscreteTagConfig : TagConfig
        {
            public bool? AlarmEnable { get; set; }
            public string State0 { get; set; }
            public string State1 { get; set; }
            public string State2 { get; set; }
            public string State3 { get; set; }
            public string State4 { get; set; }
            public string State5 { get; set; }
            public string State6 { get; set; }
            public string State7 { get; set; }
            public int? State0AlarmPriority { get; set; }
            public int? State1AlarmPriority { get; set; }
            public int? State2AlarmPriority { get; set; }
            public int? State3AlarmPriority { get; set; }
            public int? State4AlarmPriority { get; set; }
            public int? State5AlarmPriority { get; set; }
            public int? State6AlarmPriority { get; set; }
            public int? State7AlarmPriority { get; set; }

            public DiscreteTagConfig()
            {
            }
        }

        public class TextTagConfig : TagConfig
        {
            public TextTagConfig()
            {
            }
        }
    }
}
