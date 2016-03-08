using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core.Plugin.Connector
{
    public class ConnectorEventArgs : EventArgs
    {
        public string FQN { get; set; }
        public object Value { get; set; }

        public ConnectorEventArgs(string fqn, object value): base()
        {
            FQN = fqn;
            Value = value;
        }
    }
}
