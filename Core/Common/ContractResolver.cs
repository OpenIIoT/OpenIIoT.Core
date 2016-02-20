using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using NLog;

namespace Symbiote.Core
{
    /// <summary>
    /// The ContractResolver acts as a generic Data Contract Resolver, allowing for a list of ignored properties to be passed in on construction.
    /// </summary>
    class ContractResolver : DefaultContractResolver
    {
        #region Variables

        /// <summary>
        /// The ProgramManager for the application.
        /// </summary>
        private static ProgramManager manager = ProgramManager.Instance();

        /// <summary>
        /// The Logger for this class.
        /// </summary>
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The list of properties to either include or exclude, depending on contractResolverType.
        /// </summary>
        private List<string> propertyList;

        /// <summary>
        /// Enumeration representing the type of contract resolver to use; OptIn or OptOut.
        /// </summary>
        /// <remarks>
        /// The OptIn type includes only the properties listed in propertyList while OptOut includes all properties except those listed.
        /// </remarks>
        private ContractResolverType contractResolverType;

        /// <summary>
        /// True if the secondary types defined in the Plugin.Connector namespace should be serialized with the result.
        /// </summary>
        private bool includeSecondaryTypes;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates an instance of ContractResolver with an empty property list, resolver type of OptOut and with includeSecondaryTypes = false.  Serializes all unignored properties in the given class.
        /// </summary>
        public ContractResolver() : this(new List<string>(), ContractResolverType.OptOut, false) { }

        /// <summary>
        /// Creates an instance of ContractResolver with the supplied properties list and the supplied value for includeSecondaryTypes.
        /// </summary>
        /// <param name="propertyList">A list of properties to include or exclude from serialization.</param>
        /// <param name="includeSecondaryTypes">If true, includes fields from classes defined within the 'Plugin.Connector' namespace in the serialization results.</param>
        public ContractResolver(List<string> propertyList, bool includeSecondaryTypes) : this(propertyList, ContractResolverType.OptIn, includeSecondaryTypes) { }

        /// <summary>
        /// Creates an instance of ContractResolver with the supplied properties list, resolver type and includeSecondaryTypes value.
        /// </summary>
        /// <param name="propertyList">A list of properties to include or exclude from serialization.</param>
        /// <param name="contractResolverType">The type of contract resolver; determines whether the supplied list will be included or excluded from serialization.</param>
        /// <param name="includeSecondaryTypes">If true, includes fields from classes defined within the 'Plugin.Connector' namespace in the serialization results.</param>
        public ContractResolver(List<string> propertyList, ContractResolverType contractResolverType = ContractResolverType.OptIn, bool includeSecondaryTypes = false) : base()
        {
            this.propertyList = propertyList;
            this.contractResolverType = contractResolverType;
            this.includeSecondaryTypes = includeSecondaryTypes;
        }

        #endregion

        #region Instance Methods

        /// <summary>
        /// Creates a list of JsonProperties based on the default serialization of the class, removes any properties whose
        /// name matches any entry in the list of ignoredProperties, and returns the modified list.
        /// </summary>
        /// <param name="type">The Type of the serialized class.</param>
        /// <param name="memberSerialization">Specifies the member serialization options for the JsonSerializer.</param>
        /// <returns>A filtered list of JsonProperties to serialize.</returns>
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            IEnumerable<JsonProperty> baseProperties = base.CreateProperties(type, memberSerialization);
            IEnumerable<JsonProperty> resolvedProperties = new List<JsonProperty>();
            IEnumerable<JsonProperty> secondaryProperties = new List<JsonProperty>();

            // stash the list of secondary properties
            secondaryProperties = baseProperties.Where(p => p.DeclaringType.Namespace.Contains("Plugin.Connector"));

            // remove the secondary properties so we can manipulate the base type properties unambiguously
            baseProperties = baseProperties.Where(p => !p.DeclaringType.Namespace.Contains("Plugin.Connector"));

            // if the resolver type is OptIn, filter baseProperties of any fields that don't appear in the supplied list of properties
            if (contractResolverType == ContractResolverType.OptIn)
            {
                resolvedProperties = baseProperties.Where(p => propertyList.Contains(p.PropertyName)).ToList();
            }

            // if the resolver type is OptOut, filter baseProperties of any fields that appear in the supplied list of properties
            else if (contractResolverType == ContractResolverType.OptOut)
            {
                resolvedProperties = baseProperties.Where(p => !propertyList.Contains(p.PropertyName)).ToList();
            }

            // if we want to include the secondary properties, add them back to resolvedProperties.
            if (includeSecondaryTypes)
                resolvedProperties = resolvedProperties.Union(secondaryProperties);

            return resolvedProperties.ToList();
        }

        #endregion
    }
}
