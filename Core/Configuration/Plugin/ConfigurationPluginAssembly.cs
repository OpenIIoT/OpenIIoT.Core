using Newtonsoft.Json;
using Symbiote.Core.Plugin;

namespace Symbiote.Core.Configuration.Plugin
{
    [JsonObject]
    public class ConfigurationPluginAssembly
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Version { get; set; }
        public string PluginType { get; set; }
        public string FileName { get; set; }
        public string Checksum { get; set; }
        public PluginAuthorization Authorization { get; set; }

    }
}
