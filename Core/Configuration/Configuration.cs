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
        public List<ModelItem> Items { get; set; }

        public ModelSection()
        {
            Items = new List<ModelItem>();
        }
    }

    /// <summary>
    /// A generic container for model items within the configuration.
    /// </summary>
    [JsonObject]
    public class ModelItem : ICloneable
    {
        public string FQN { get; set; }
        public string Definition { get; set; }

        public object Clone()
        {
            return new ModelItem() { FQN = this.FQN, Definition = this.Definition };
        }

        public override bool Equals(object obj)
        {
            ModelItem rightSide;

            try
            {
                rightSide = (ModelItem)obj;
            }
            catch (InvalidCastException ex)
            {
                return false;
            }

            return (this.FQN == rightSide.FQN);
        }

        public override int GetHashCode()
        {
            return FQN.GetHashCode();
        }
    }

    [JsonObject]
    public class PluginSection
    {
        public bool AuthorizeNewPlugins { get; set; }
        public List<PluginItem> Assemblies { get; set; }

        public PluginSection()
        {
            Assemblies = new List<PluginItem>();
        }
    }

    [JsonObject]
    public class PluginItem
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
