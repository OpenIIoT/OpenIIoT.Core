using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Symbiote.Core
{
    /// <summary>
    /// The ContractResolver acts as a generic Data Contract Resolver, allowing for a list of ignored properties to be passed in on construction.
    /// </summary>
    class ContractResolver : DefaultContractResolver
    {
        private string[] ignoredProperties;

        /// <summary>
        /// Instantiates a new ContractResolver with the supplied ignored properties list.
        /// </summary>
        /// <param name="ignoredProperties">A list of properties to exclude from serialization.</param>
        public ContractResolver(string[] ignoredProperties) : base()
        {
            this.ignoredProperties = ignoredProperties;
        }

        /// <summary>
        /// Creates a list of JsonProperties based on the default serialization of the class, removes any properties whose
        /// name matches any entry in the list of ignoredProperties, and returns the modified list.
        /// </summary>
        /// <param name="type">The Type of the serialized class.</param>
        /// <param name="memberSerialization">Specifies the member serialization options for the JsonSerializer.</param>
        /// <returns>A filtered list of JsonProperties to serialize.</returns>
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
