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
        public ModelSection Model;
        public PluginSection Plugins;

        public Configuration()
        {
            Model = new ModelSection();
            Plugins = new PluginSection();
        }
    }

    [JsonObject]
    public class ModelSection
    {
        public List<string> Items { get; set; }

        public ModelSection()
        {
            Items = new List<string>();
        }
    }

    [JsonObject]
    public class PluginSection
    {
        public bool AuthorizeNewPlugins { get; set; }
        public List<PluginSectionList> Assemblies { get; set; }

        public PluginSection()
        {
            Assemblies = new List<PluginSectionList>();
        }
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
