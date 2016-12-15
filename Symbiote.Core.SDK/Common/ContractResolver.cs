/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █   ▄████████                                                                      ▄████████
      █   ███    ███                                                                    ███    ███
      █   ███    █▀   ██████  ██▄▄▄▄      ██       █████   ▄█████   ▄██████     ██     ▄███▄▄▄▄██▀    ▄█████   ▄█████  ██████   █        █    █     ▄█████    █████
      █   ███        ██    ██ ██▀▀▀█▄ ▀███████▄   ██  ██   ██   ██ ██    ██ ▀███████▄ ▀▀███▀▀▀▀▀     ██   █    ██  ▀  ██    ██ ██       ██    ██   ██   █    ██  ██
      █   ███        ██    ██ ██   ██     ██  ▀  ▄██▄▄█▀   ██   ██ ██    ▀      ██  ▀ ▀███████████  ▄██▄▄      ██     ██    ██ ██       ██    ██  ▄██▄▄     ▄██▄▄█▀
      █   ███    █▄  ██    ██ ██   ██     ██    ▀███████ ▀████████ ██    ▄      ██      ███    ███ ▀▀██▀▀    ▀███████ ██    ██ ██       ██    ██ ▀▀██▀▀    ▀███████
      █   ███    ███ ██    ██ ██   ██     ██      ██  ██   ██   ██ ██    ██     ██      ███    ███   ██   █     ▄  ██ ██    ██ ██▌    ▄  █▄  ▄█    ██   █    ██  ██
      █   ████████▀   ██████   █   █     ▄██▀     ██  ██   ██   █▀ ██████▀     ▄██▀     ███    ███   ███████  ▄████▀   ██████  ████▄▄██   ▀██▀     ███████   ██  ██
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Represents a generic Data Contract Resolver, allowing for a list of ignored properties to be passed in upon construction.
      █
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀ ▀ ▀▀▀     ▀▀               ▀
      █  The GNU Affero General Public License (GNU AGPL)
      █
      █  Copyright (C) 2016 JP Dillingham (jp@dillingham.ws)
      █
      █  This program is free software: you can redistribute it and/or modify
      █  it under the terms of the GNU Affero General Public License as published by
      █  the Free Software Foundation, either version 3 of the License, or
      █  (at your option) any later version.
      █
      █  This program is distributed in the hope that it will be useful,
      █  but WITHOUT ANY WARRANTY; without even the implied warranty of
      █  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
      █  GNU Affero General Public License for more details.
      █
      █  You should have received a copy of the GNU Affero General Public License
      █  along with this program.  If not, see <http://www.gnu.org/licenses/>.
      █
      ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀  ▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀██
                                                                                                   ██
                                                                                               ▀█▄ ██ ▄█▀
                                                                                                 ▀████▀
                                                                                                   ▀▀                            */

using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Symbiote.SDK
{
    /// <summary>
    ///     Specifies how the array of properties passed to the constructor of the ContractResolver is to be used.
    /// </summary>
    public enum ContractResolverType
    {
        /// <summary>
        ///     The default type
        /// </summary>
        Undefined,

        /// <summary>
        ///     Resolves the data contract using only the properties in accompanying list of properties
        /// </summary>
        OptIn,

        /// <summary>
        ///     Resolves the data contract using all properties not included in the accompanying list of properties
        /// </summary>
        OptOut
    }

    /// <summary>
    ///     Represents a generic Data Contract Resolver, allowing for a list of ignored properties to be passed in upon construction.
    /// </summary>
    public class ContractResolver : DefaultContractResolver
    {
        #region Private Fields

        /// <summary>
        ///     Enumeration representing the type of contract resolver to use; OptIn or OptOut.
        /// </summary>
        /// <remarks>
        ///     The OptIn type includes only the properties listed in propertyList while OptOut includes all properties except
        ///     those listed.
        /// </remarks>
        private ContractResolverType contractResolverType;

        /// <summary>
        ///     True if the secondary types defined in the Plugin.Connector namespace should be serialized with the result.
        /// </summary>
        private bool includeSecondaryTypes;

        /// <summary>
        ///     The list of properties to either include or exclude, depending on contractResolverType.
        /// </summary>
        private List<string> propertyList;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ContractResolver"/> class with an empty property list, resolver type
        ///     of OptOut and with includeSecondaryTypes = false. Serializes all un-ignored properties in the given class.
        /// </summary>
        public ContractResolver() : this(new List<string>(), ContractResolverType.OptOut, false)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ContractResolver"/> class with the supplied properties list and the
        ///     supplied value for includeSecondaryTypes.
        /// </summary>
        /// <param name="propertyList">A list of properties to include or exclude from serialization.</param>
        /// <param name="includeSecondaryTypes">
        ///     If true, includes fields from classes defined within the 'Plugin.Connector' namespace in the serialization results.
        /// </param>
        public ContractResolver(List<string> propertyList, bool includeSecondaryTypes) : this(propertyList, ContractResolverType.OptIn, includeSecondaryTypes)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ContractResolver"/> class with the supplied properties list, resolver
        ///     type and includeSecondaryTypes value.
        /// </summary>
        /// <param name="propertyList">A list of properties to include or exclude from serialization.</param>
        /// <param name="contractResolverType">
        ///     The type of contract resolver; determines whether the supplied list will be included or excluded from serialization.
        /// </param>
        /// <param name="includeSecondaryTypes">
        ///     If true, includes fields from classes defined within the 'Plugin.Connector' namespace in the serialization results.
        /// </param>
        public ContractResolver(List<string> propertyList, ContractResolverType contractResolverType = ContractResolverType.OptIn, bool includeSecondaryTypes = false) : base()
        {
            this.propertyList = propertyList;
            this.contractResolverType = contractResolverType;
            this.includeSecondaryTypes = includeSecondaryTypes;
        }

        #endregion Public Constructors

        #region Protected Methods

        /// <summary>
        ///     Creates a list of properties based on the default serialization of the class, removes any properties whose name
        ///     matches any entry in the list of ignoredProperties, and returns the modified list.
        /// </summary>
        /// <param name="type">The Type of the serialized class.</param>
        /// <param name="memberSerialization">Specifies the member serialization options for the <see cref="JsonSerializer"/>.</param>
        /// <returns>A filtered list of properties to serialize.</returns>
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
            if (this.contractResolverType == ContractResolverType.OptIn)
            {
                resolvedProperties = baseProperties.Where(p => this.propertyList.Contains(p.PropertyName)).ToList();
            }
            else if (this.contractResolverType == ContractResolverType.OptOut)
            {
                // if the resolver type is OptOut, filter baseProperties of any fields that appear in the supplied list of properties
                resolvedProperties = baseProperties.Where(p => !this.propertyList.Contains(p.PropertyName)).ToList();
            }

            // if we want to include the secondary properties, add them back to resolvedProperties.
            if (this.includeSecondaryTypes)
            {
                resolvedProperties = resolvedProperties.Union(secondaryProperties);
            }

            return resolvedProperties.ToList();
        }

        #endregion Protected Methods
    }
}