using Newtonsoft.Json;
using Symbiote.Core.App;
using Symbiote.Core.Plugin;
using System;

namespace Symbiote.Core.Configuration.App
{
    [JsonObject]
    public class ConfigurationApp
    {
        public string FQN { get; set; }
        public Version Version { get; set; }
        public AppType AppType { get; set; }
        public string FileName { get; set; }
        public string Configuration { get; set; }
        public ConfigurationDefinition ConfigurationDefinition { get; set; }
    }
}
