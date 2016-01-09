using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Symbiote.Core.Configuration
{
    public class Configuration
    {

    }

    [JsonObject]
    public class ConfigurationItem
    {
        public string Name { get; private set; }
        public object Value { get; private set; }
        public List<ConfigurationItem> Children { get; private set; }
    }
}
