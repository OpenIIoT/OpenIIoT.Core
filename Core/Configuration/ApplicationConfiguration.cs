using Newtonsoft.Json;
using Symbiote.Core.Configuration.Model;
using Symbiote.Core.Configuration.App;
using System.Collections.Generic;
using System;

namespace Symbiote.Core.Configuration
{
    [JsonObject]
    public class ApplicationConfiguration
    {
        public ConfigurationModelSection Model;
        public ConfigurationAppSection Apps;
        public Dictionary<Type, Dictionary<string, object>> UglyConfiguration { get; private set; }

        public ApplicationConfiguration()
        {
            Model = new ConfigurationModelSection();
            Apps = new ConfigurationAppSection();
            UglyConfiguration = new Dictionary<Type, Dictionary<string, object>>();
        }
    }
}
