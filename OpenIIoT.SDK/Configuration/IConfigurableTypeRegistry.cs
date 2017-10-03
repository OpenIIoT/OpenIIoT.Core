/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █    ▄█  ▄████████                                                                                                        ███                                    ▄████████
      █   ███  ███    ███                                                                                                   ▀█████████▄                               ███    ███
      █   ███▌ ███    █▀   ██████  ██▄▄▄▄     ▄█████  █     ▄████▄  ██   █     █████   ▄█████  ▀██████▄   █          ▄█████    ▀███▀▀██ ▄█   ▄     █████▄    ▄█████  ▄███▄▄▄▄██▀    ▄█████    ▄████▄   █    ▄█████     ██       █████ ▄█   ▄
      █   ███▌ ███        ██    ██ ██▀▀▀█▄   ██   ▀█ ██    ██    ▀  ██   ██   ██  ██   ██   ██   ██   ██ ██         ██   █      ███   ▀ ██   █▄   ██   ██   ██   █  ▀▀███▀▀▀▀▀     ██   █    ██    ▀  ██    ██  ▀  ▀███████▄   ██  ██ ██   █▄
      █   ███▌ ███        ██    ██ ██   ██  ▄██▄▄    ██▌  ▄██       ██   ██  ▄██▄▄█▀   ██   ██  ▄██▄▄█▀  ██        ▄██▄▄        ███     ▀▀▀▀▀██   ██   ██  ▄██▄▄    ▀███████████  ▄██▄▄     ▄██       ██▌   ██         ██  ▀  ▄██▄▄█▀ ▀▀▀▀▀██
      █   ███  ███    █▄  ██    ██ ██   ██ ▀▀██▀▀    ██  ▀▀██ ███▄  ██   ██ ▀███████ ▀████████ ▀▀██▀▀█▄  ██       ▀▀██▀▀        ███     ▄█   ██ ▀██████▀  ▀▀██▀▀      ███    ███ ▀▀██▀▀    ▀▀██ ███▄  ██  ▀███████     ██    ▀███████ ▄█   ██
      █   ███  ███    ███ ██    ██ ██   ██   ██      ██    ██    ██ ██   ██   ██  ██   ██   ██   ██   ██ ██▌    ▄   ██   █      ███     ██   ██   ██        ██   █    ███    ███   ██   █    ██    ██ ██     ▄  ██     ██      ██  ██ ██   ██
      █   █▀   ████████▀   ██████   █   █    ██      █     ██████▀  ██████    ██  ██   ██   █▀ ▄██████▀  ████▄▄██   ███████    ▄████▀    █████   ▄███▀      ███████   ███    ███   ███████   ██████▀  █    ▄████▀     ▄██▀     ██  ██  █████
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Maintains a registry of Types implementing the IConfigurable interface.
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

namespace OpenIIoT.SDK.Configuration
{
    using System;
    using System.Collections.Generic;
    using OpenIIoT.SDK.Common.Exceptions;
    using OpenIIoT.SDK.Common.OperationResult;

    /// <summary>
    ///     Maintains a registry of Types implementing the IConfigurable interface.
    /// </summary>
    public interface IConfigurableTypeRegistry
    {
        #region Public Properties

        /// <summary>
        ///     Gets a dictionary containing all registered configurable types and their ConfigurationDefinitions.
        /// </summary>
        IDictionary<Type, IConfigurationDefinition> RegisteredTypes { get; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        ///     Checks to see if the supplied Type is in the RegisteredTypes dictionary.
        /// </summary>
        /// <param name="type">The Type to check.</param>
        /// <returns>A value indicating whether the specified Type was found in the dictionary.</returns>
        bool IsRegistered(Type type);

        /// <summary>
        ///     Registers the supplied Type with the Configuration Manager.
        /// </summary>
        /// <remarks>When called during application startup, throwExceptionOnFailure should be set to true.</remarks>
        /// <param name="type">The Type to register.</param>
        /// <param name="throwExceptionOnFailure">If true, throws an exception on failure.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        /// <exception cref="ConfigurationRegistrationException">Thrown when the specified Type is fails to be registered.</exception>
        IResult RegisterType(Type type, bool throwExceptionOnFailure = false);

        /// <summary>
        ///     Registers each Type within the supplied list which implements the IConfigurable interface.
        /// </summary>
        /// <param name="types">The list of Types to register.</param>
        /// <param name="throwExceptionOnFailure">
        ///     A value indicating whether an exception should be thrown if a registration fails.
        /// </param>
        /// <returns>A Result containing the result of the operation.</returns>
        IResult RegisterTypes(List<Type> types, bool throwExceptionOnFailure = false);

        #endregion Public Methods
    }
}