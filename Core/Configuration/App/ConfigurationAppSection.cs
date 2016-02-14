using System.Collections.Generic;
using Newtonsoft.Json;

namespace Symbiote.Core.Configuration.Plugin
{
    [JsonObject]
    public class ConfigurationAppSection
    {
        public bool AutomaticUpdates;

        public ConfigurationAppSection()
        {
        }
    }
}
