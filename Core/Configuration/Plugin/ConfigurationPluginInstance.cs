using Newtonsoft.Json;
using Symbiote.Core.Plugin;

namespace Symbiote.Core.Configuration.Plugin
{
    [JsonObject]
    public class ConfigurationPluginInstance
    {
        public string InstanceName { get; set; }
        public string AssemblyName { get; set; }
        public bool AutoBuildItems { get; set; }
        public string AutoBuildParentFQN { get; set; }
    }
}
