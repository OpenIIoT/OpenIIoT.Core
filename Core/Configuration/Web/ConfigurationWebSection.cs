using System.Collections.Generic;
using Newtonsoft.Json;

namespace Symbiote.Core.Configuration.Plugin
{
    [JsonObject]
    public class ConfigurationWebSection
    {
        public int Port { get; set; }
        public string Root { get; set; }

        public ConfigurationWebSection()
        {
        }
    }
}
