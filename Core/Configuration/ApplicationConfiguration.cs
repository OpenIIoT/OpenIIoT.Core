using Newtonsoft.Json;
using Symbiote.Core.Configuration.Model;
using Symbiote.Core.Configuration.Plugin;
using Symbiote.Core.Configuration.App;
using System.Collections.Generic;
using System;

namespace Symbiote.Core.Configuration
{
    [JsonObject]
    public class ApplicationConfiguration
    {
        public string Symbiote;
        public ConfigurationWebSection Web;
        public ConfigurationModelSection Model;
        public ConfigurationPluginSection Plugins;
        public ConfigurationAppSection Apps;
        public Dictionary<Type, Dictionary<string, object>> UglyConfiguration { get; private set; }

        public ApplicationConfiguration()
        {
            Web = new ConfigurationWebSection();
            Model = new ConfigurationModelSection();
            Plugins = new ConfigurationPluginSection();
            Apps = new ConfigurationAppSection();
            UglyConfiguration = new Dictionary<Type, Dictionary<string, object>>();
        }
    }
}
