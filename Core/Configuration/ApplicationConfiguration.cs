using Newtonsoft.Json;
using System.Collections.Generic;
using System;

namespace Symbiote.Core.Configuration
{
    [JsonObject]
    public class ApplicationConfiguration
    {
        public Dictionary<Type, Dictionary<string, object>> UglyConfiguration { get; private set; }

        public ApplicationConfiguration()
        {
            UglyConfiguration = new Dictionary<Type, Dictionary<string, object>>();
        }
    }
}
