using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQTT.Device.DotNet.SDK.Model
{
    public class MessageReceivedEventArgs : EventArgs
    {
        private MessageType _type;
        private object _message;

        public MessageType Type
        {
            get
            {
                return _type;
            }
        }

        public object Message
        {
            get
            {
                return _message;
            }
        }

        public MessageReceivedEventArgs( MessageType type, object message )
        {
            _type = type;
            _message = message;
        }
    }
}
