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
        public ConfigurationModelSection Model;
        public ConfigurationPluginSection Plugins;

        public Configuration()
        {
            Model = new ConfigurationModelSection();
            Plugins = new ConfigurationPluginSection();
        }
    }

    [JsonObject]
    public class ConfigurationModelSection
    {
        public List<ConfigurationModelItem> Items { get; set; }

        public ConfigurationModelSection()
        {
            Items = new List<ConfigurationModelItem>();
        }
    }

    /// <summary>
    /// A generic container for model items within the configuration.
    /// </summary>
    [JsonObject]
    public class ConfigurationModelItem : ICloneable
    {
        public string FQN { get; set; }
        public string Definition { get; set; }

        public object Clone()
        {
            return new ConfigurationModelItem() { FQN = this.FQN, Definition = this.Definition };
        }

        public override bool Equals(object obj)
        {
            ConfigurationModelItem rightSide;

            try
            {
                rightSide = (ConfigurationModelItem)obj;
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

        public override string ToString()
        {
            return "FQN = " + FQN + "; Definition = " + Definition;
        }
    }

    [JsonObject]
    public class ConfigurationPluginSection
    {
        public bool AuthorizeNewPlugins { get; set; }
        public List<ConfigurationPluginItem> Assemblies { get; set; }

        public ConfigurationPluginSection()
        {
            Assemblies = new List<ConfigurationPluginItem>();
        }
    }

    [JsonObject]
    public class ConfigurationPluginItem
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
