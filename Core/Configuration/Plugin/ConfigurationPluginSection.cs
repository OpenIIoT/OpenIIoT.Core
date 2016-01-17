using System.Collections.Generic;
using Newtonsoft.Json;

namespace Symbiote.Core.Configuration.Plugin
{
    [JsonObject]
    public class ConfigurationPluginSection
    {
        public bool AuthorizeNewPlugins { get; set; }
        public List<ConfigurationPluginItem> Assemblies { get; set; }

        public ConfigurationPluginSection()
        {
            Assemblies = new List<ConfigurationPluginItem>();
        }
    }
}
