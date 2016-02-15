using System.Collections.Generic;
using Newtonsoft.Json;

namespace Symbiote.Core.Configuration.App
{
    [JsonObject]
    public class ConfigurationAppSection
    {
        public bool AutomaticUpdates;
        public List<ConfigurationApp> Apps;

        public ConfigurationAppSection()
        {
            Apps = new List<ConfigurationApp>();
        }
    }
}
