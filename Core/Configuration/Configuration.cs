using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Symbiote.Core.Platform;
using Symbiote.Core.Plugin;

namespace Symbiote.Core.Configuration
{
    [JsonObject]
    public class Configuration
    {
        public string Symbiote;
        public PluginSection Plugins;

        public Configuration() { }
    }

    [JsonObject]
    public class PluginSection
    {
        public bool AuthorizeNewPlugins { get; set; }
        public List<PluginSectionList> Assemblies { get; set; }
    }

    [JsonObject]
    public class PluginSectionList
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
