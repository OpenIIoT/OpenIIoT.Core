using System.Collections.Generic;
using Newtonsoft.Json;

namespace Symbiote.Core.Configuration.Plugin
{
    [JsonObject]
    public class ConfigurationPluginSection
    {
        public bool AuthorizeNewPlugins { get; set; }
        public List<ConfigurationPluginAssembly> Assemblies { get; set; }
        public List<ConfigurationPluginInstance> Instances { get; set; }

        public ConfigurationPluginSection()
        {
            Assemblies = new List<ConfigurationPluginAssembly>();
            Instances = new List<ConfigurationPluginInstance>();
        }
    }
}
