using Newtonsoft.Json;
using Symbiote.Core.Plugin;

namespace Symbiote.Core.Configuration.Plugin
{
    [JsonObject]
    public class ConfigurationPluginInstanceAutoBuild
    {
        public bool Enabled { get; set; }
        public string ParentFQN { get; set; }
    }
}
