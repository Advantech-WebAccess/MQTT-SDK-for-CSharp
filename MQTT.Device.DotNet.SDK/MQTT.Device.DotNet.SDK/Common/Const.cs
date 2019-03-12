using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQTT.Device.DotNet.SDK
{
    public class MQTTTopic
    {
        public const string ConfigTopic = "iot-2/evt/wacfg/fmt/{0}";
        public const string DataTopic = "iot-2/evt/wadata/fmt/{0}";

        public const string ScadaConnTopic = "iot-2/evt/waconn/fmt/{0}";

        public const string ScadaCmdTopic = "iot-2/evt/wacmd/fmt/{0}";
        public const string DeviceCmdTopic = "iot-2/evt/wacmd/fmt/{0}/{1}";
    }

    public class DataRecover
    {
        public const string DatabaseFileName = "recover.sqlite";
    }

    public class Limit
    {
        public const int DataMaxTagCount = 100;
    }
}
