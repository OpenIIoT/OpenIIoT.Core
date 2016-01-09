using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Symbiote.Core.Platform;

namespace Symbiote.Core.Configuration
{
    [JsonObject]
    public class Configuration
    {
        public string Symbiote;
        public SectionPlugins Plugins;

        public static Configuration Load(string fileName, IPlatform platform)
        {
            string configFile = platform.ReadFile(fileName);

            return JsonConvert.DeserializeObject<Configuration>(configFile);
        }

        public void Save(string fileName, IPlatform platform)
        {
            platform.WriteFile(fileName, JsonConvert.SerializeObject(this));
        }

        public string GetJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static Configuration BuildNew()
        {
            Configuration config = new Configuration();

            config.Symbiote = "0.1.0";
            config.Plugins = new SectionPlugins();
            config.Plugins.Authorized = new List<SectionPluginsList>();
            config.Plugins.Authorized.Add(
                new SectionPluginsList()
                {
                    Name = "Symbiote.Plugin.Connector.Simulation",
                    Version = "0.1.0",
                    Checksum = "123413rea"
                });

            config.Plugins.Unauthorized = new List<SectionPluginsList>();
            return config;
        }
    }

    [JsonObject]
    public class SectionPlugins
    {
        public List<SectionPluginsList> Authorized { get; set; }
        public List<SectionPluginsList> Unauthorized { get; set; }
    }

    [JsonObject]
    public class SectionPluginsList
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public string Checksum { get; set; }
    }
}
