using System.Collections.Generic;
using Newtonsoft.Json;

namespace Symbiote.Core.Configuration.Model
{
    [JsonObject]
    public class ConfigurationModelSection
    {
        public List<ConfigurationModelItem> Items { get; set; }

        public ConfigurationModelSection()
        {
            Items = new List<ConfigurationModelItem>();
        }
    }
}
