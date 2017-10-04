namespace OpenIIoT.Core.Event
{
    using System.Collections.Generic;

    public class EventManagerConfiguration
    {
        public EventManagerConfiguration()
        {
            Events = new List<string>();
        }

        public List<string> Events { get; set; }
    }
}