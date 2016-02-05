using Newtonsoft.Json;
using Symbiote.Core.Plugin;

namespace Symbiote.Core.Configuration.Plugin
{
    [JsonObject]
    public class ConfigurationPluginInstance
    {
        public string InstanceName { get; set; }
        public string AssemblyName { get; set; }
        public string Configuration { get; set; }
        public ConfigurationPluginInstanceAutoBuild AutoBuild { get; set; }
    }
}
