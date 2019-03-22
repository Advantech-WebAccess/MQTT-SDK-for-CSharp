using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MQTT.Device.DotNet.SDK.Model; 

namespace MQTT.Device.DotNet.SDK
{
    public class Converter
    {
        public Converter()
        { }

        public static bool ConvertCreateOrUpdateConfig( EdgeConfig config, ref string payload, int heartbeat = EdgeAgent.DEAFAULT_HEARTBEAT_INTERVAL )
        {
            try
            {
                if ( config == null )
                    return false;

                ConfigMessage msg = new ConfigMessage();

                msg.ScadaList = new Dictionary<string, ConfigMessage.ScadaObject>();

                ConfigMessage.ScadaObject scadaObj  = new ConfigMessage.ScadaObject()
                {
                    //Id = config.Scada.Id,
                    //DeviceType = config.Scada.DeviceType,

                    DeviceType = SCADAConfigType.SCADA,

                    Description = config.Scada.Description,

                    HeartBeat = config.Scada.HeartBeat,

                    BackupDeviceId = config.Scada.BackupDeviceId
              
                };

                scadaObj.UpdateTagList = new Dictionary<string, ConfigMessage.TagObject>();

                if (config.Scada.AnalogTagList != null )
                {
                    foreach ( var analogTag in config.Scada.AnalogTagList )
                    {
                        ConfigMessage.AnalogTagObject analogTagObject = new ConfigMessage.AnalogTagObject()
                        {
                            // Common
                            Name = analogTag.Name,

                            Type = TagType.Analog,

                            Description = analogTag.Description,

                            ReadOnly = ( analogTag.ReadOnly != null ) ? Convert.ToInt32( analogTag.ReadOnly ) : ( int? ) null,

                            ArraySize = analogTag.ArraySize,

                            // Detail
                            AlarmEnable = analogTag.AlarmEnable,

                            NeedLog = ( analogTag.NeedLog != null ) ? Convert.ToInt32( analogTag.NeedLog ) : ( int? ) null,

                            SpanHigh = analogTag.SpanHigh,

                            SpanLow = analogTag.SpanLow,

                            EngineerUnit = analogTag.EngineerUnit,

                            DisplayFormat = analogTag.DisplayFormat
                        };

                        if ( analogTag.AlarmEnable == true )
                        {
                            analogTagObject.HHPriority = analogTag.HHPriority;
                            analogTagObject.HHAlarmLimit = analogTag.HHAlarmLimit;
                            analogTagObject.HighPriority = analogTag.HighPriority;
                            analogTagObject.HighAlarmLimit = analogTag.HighAlarmLimit;
                            analogTagObject.LowPriority = analogTag.LowPriority;
                            analogTagObject.LowAlarmLimit = analogTag.LowAlarmLimit;
                            analogTagObject.LLPriority = analogTag.LLPriority;
                            analogTagObject.LLAlarmLimit = analogTag.LLAlarmLimit;
                        }

                        scadaObj.UpdateTagList.Add(analogTagObject.Name, analogTagObject);
                    }
                }

                if (config.Scada.DiscreteTagList != null )
                {
                    foreach ( var discreteTag in config.Scada.DiscreteTagList )
                    {
                        ConfigMessage.DiscreteTagObject discreteTagObject = new ConfigMessage.DiscreteTagObject()
                        {
                            // Common
                            Name = discreteTag.Name,

                            Type = TagType.Discrete,

                            Description = discreteTag.Description,

                            ReadOnly = (discreteTag.ReadOnly != null) ? Convert.ToInt32(discreteTag.ReadOnly) : (int?)null,

                            ArraySize = discreteTag.ArraySize,

                            // Detail
                            AlarmEnable = discreteTag.AlarmEnable,

                            State0 = discreteTag.State0,
                            State1 = discreteTag.State1,
                            State2 = discreteTag.State2,
                            State3 = discreteTag.State3,
                            State4 = discreteTag.State4,
                            State5 = discreteTag.State5,
                            State6 = discreteTag.State6,
                            State7 = discreteTag.State7
                        };
                        if ( discreteTag.AlarmEnable == true )
                        {
                            discreteTagObject.State0AlarmPriority = discreteTag.State0AlarmPriority;
                            discreteTagObject.State1AlarmPriority = discreteTag.State1AlarmPriority;
                            discreteTagObject.State2AlarmPriority = discreteTag.State2AlarmPriority;
                            discreteTagObject.State3AlarmPriority = discreteTag.State3AlarmPriority;
                            discreteTagObject.State4AlarmPriority = discreteTag.State4AlarmPriority;
                            discreteTagObject.State5AlarmPriority = discreteTag.State5AlarmPriority;
                            discreteTagObject.State6AlarmPriority = discreteTag.State6AlarmPriority;
                            discreteTagObject.State7AlarmPriority = discreteTag.State7AlarmPriority;
                        }

                        scadaObj.UpdateTagList.Add(discreteTagObject.Name, discreteTagObject);
                    }
                }

                if (config.Scada.TextTagList != null )
                {
                    foreach ( var textTag in config.Scada.TextTagList )
                    {
                        ConfigMessage.TextTagObject textTagObject = new ConfigMessage.TextTagObject()
                        {
                            // Common
                            Name = textTag.Name,

                            Type = TagType.Text,

                            Description = textTag.Description,

                            ReadOnly = (textTag.ReadOnly != null) ? Convert.ToInt32(textTag.ReadOnly) : (int?)null,

                            ArraySize = textTag.ArraySize,
                        };

                        scadaObj.UpdateTagList.Add(textTagObject.Name, textTagObject);
                    }
                }

                msg.ScadaList.Add(config.Scada.Id, scadaObj);
                //msg.D.Id = scadaObj.Id;
                //msg.D.UpdateTagList = scadaObj.UpdateTagList;
                //msg.D.ScadaList.Add( config.Scada.Id, scadaObj );

                payload = JsonConvert.SerializeObject( msg, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore } );
                return true;
            }
            catch ( Exception ex )
            {
                Console.WriteLine( ex.ToString() );
                return false;
            }
        }


        public static bool ConvertDeleteConfig( EdgeConfig config, ref string payload )
        {
            return true;
        }

        public static bool ConvertData(EdgeData data, ref List<string> payloads)
        {
            try
            {
                if (data == null)
                    return false;

                // split message by limited count
                int count = 0;
                var list = data.TagList.OrderBy(t => t.DeviceId).ToList();
                DataMessage msg = null;

                DataMessage.DataObject dataObj = new DataMessage.DataObject();

                for (int i = 0; i < list.Count; i++)
                {
                    var tag = list[i];

                    if (msg == null)
                    {
                        msg = new DataMessage();
                    }

                    if (msg.D.ContainsKey(tag.DeviceId) == false)
                    {
                        msg.D[tag.DeviceId] = new DataMessage.DataObject();
                    }

                    msg.D[tag.DeviceId].DataObj.Add(tag.TagName, tag.Value);

                    count++;

                    if (count == Limit.DataMaxTagCount || i == list.Count - 1)
                    {
                        msg.Timestamp = data.Timestamp.ToUniversalTime();
                        payloads.Add(JsonConvert.SerializeObject(msg));

                        count = 0;
                        msg = null;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

    }
}
