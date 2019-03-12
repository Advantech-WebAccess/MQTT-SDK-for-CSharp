using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQTT.Device.DotNet.SDK.Model
{
    public class DisconnectedEventArgs
    {
        private bool _clientWasConnected;
        private Exception _exception;

        public bool ClientWasConnected 
        {
            get 
            { 
                return _clientWasConnected; 
            } 
        }

        public Exception Exception
        { 
            get
            { 
                return _exception;
            } 
        }

        public DisconnectedEventArgs( bool clientWasConnected, Exception exception )
        {
            _clientWasConnected = clientWasConnected;
            _exception = exception;
        }
    }
}
