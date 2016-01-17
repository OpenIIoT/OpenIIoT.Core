using Newtonsoft.Json;
using Symbiote.Core.Configuration.Model;
using Symbiote.Core.Configuration.Plugin;

namespace Symbiote.Core.Configuration
{
    [JsonObject]
    public class Configuration
    {
        public string Symbiote;
        public ConfigurationModelSection Model;
        public ConfigurationPluginSection Plugins;

        public Configuration()
        {
            Model = new ConfigurationModelSection();
            Plugins = new ConfigurationPluginSection();
        }
    }
}
