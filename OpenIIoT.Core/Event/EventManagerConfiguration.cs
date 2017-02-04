using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenIIoT.Core.Event
{
    public class EventManagerConfiguration
    {
        public EventManagerConfiguration()
        {
            Events = new List<string>();
        }

        public List<string> Events { get; set; }
    }
}