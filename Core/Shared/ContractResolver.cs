using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Symbiote.Core
{
    class ContractResolver : DefaultContractResolver
    {
        private string[] ignoredProperties;

        public ContractResolver(string[] ignoredProperties)
        {
            this.ignoredProperties = ignoredProperties;
        }

        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            IEnumerable<JsonProperty> properties = base.CreateProperties(type, memberSerialization);

            foreach (string ignoredProperty in ignoredProperties)
            {
                properties = properties.Where(p => p.PropertyName.ToString() != ignoredProperty);
            }
            return properties.ToList<JsonProperty>();
        }
    }
}
