using System.Collections.Generic;

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