﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQTT.Device.DotNet.SDK.Model
{
    public class ConnectAck
    {
        public bool Result { get; set; }
        public ConnectAck()
        {
            Result = false;
        }

    }
}
