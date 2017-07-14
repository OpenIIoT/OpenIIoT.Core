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
      █  Copyright (C) 2016-2017 JP Dillingham (jp@dillingham.ws)
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

namespace OpenIIoT.SDK.Common
{
    /// <summary>
    ///     Specifies how the array of properties passed to the constructor of the ContractResolver is to be used.
    /// </summary>
    public enum ContractResolverType
    {
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
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ContractResolver"/> class with an empty property list, resolver type
        ///     of OptOut and with includeSecondaryTypes = false. Serializes all un-ignored properties in the given class.
        /// </summary>
        public ContractResolver()
            : this(ContractResolverType.OptOut)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ContractResolver"/> class with the supplied properties list and the
        ///     supplied value for includeSecondaryTypes.
        /// </summary>
        /// <param name="properties">A list of properties to include or exclude from serialization.</param>
        public ContractResolver(params string[] properties)
            : this(ContractResolverType.OptIn, properties)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ContractResolver"/> class with the supplied properties list, resolver
        ///     type and includeSecondaryTypes value.
        /// </summary>
        /// <param name="resolverType">
        ///     The type of contract resolver; determines whether the supplied list will be included or excluded from serialization.
        /// </param>
        /// <param name="properties">A list of properties to include or exclude from serialization.</param>
        public ContractResolver(ContractResolverType resolverType, params string[] properties)
            : base()
        {
            Properties = properties;
            ResolverType = resolverType;
        }

        #endregion Public Constructors

        #region Private Properties

        /// <summary>
        ///     Gets or sets the list of properties to either include or exclude, depending on contractResolverType.
        /// </summary>
        private string[] Properties { get; set; }

        /// <summary>
        ///     Gets or sets the enumeration representing the type of contract resolver to use; OptIn or OptOut.
        /// </summary>
        /// <remarks>
        ///     The OptIn type includes only the properties listed in propertyList while OptOut includes all properties except
        ///     those listed.
        /// </remarks>
        private ContractResolverType ResolverType { get; set; }

        #endregion Private Properties

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

            // if the resolver type is OptIn, filter baseProperties of any fields that don't appear in the supplied list of properties
            if (ResolverType == ContractResolverType.OptIn)
            {
                resolvedProperties = baseProperties.Where(p => Properties.Contains(p.PropertyName)).ToList();
            }
            else
            {
                // if the resolver type is OptOut, filter baseProperties of any fields that appear in the supplied list of properties
                resolvedProperties = baseProperties.Where(p => !Properties.Contains(p.PropertyName)).ToList();
            }

            return resolvedProperties.ToList();
        }

        #endregion Protected Methods
    }
}