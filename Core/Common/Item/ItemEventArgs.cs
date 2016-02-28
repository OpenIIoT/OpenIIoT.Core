using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core
{
    public class ItemEventArgs : EventArgs
    {
        public object Value { get; private set; }

        public ItemEventArgs(object value)
        {
            Value = value;
        }
    }
}
