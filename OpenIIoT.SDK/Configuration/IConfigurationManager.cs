/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █    ▄█  ▄████████                                                                                                         ▄▄▄▄███▄▄▄▄
      █   ███  ███    ███                                                                                                      ▄██▀▀▀███▀▀▀██▄
      █   ███▌ ███    █▀   ██████  ██▄▄▄▄     ▄█████  █     ▄████▄  ██   █     █████   ▄█████      ██     █   ██████  ██▄▄▄▄   ███   ███   ███   ▄█████  ██▄▄▄▄    ▄█████     ▄████▄     ▄█████    █████
      █   ███▌ ███        ██    ██ ██▀▀▀█▄   ██   ▀█ ██    ██    ▀  ██   ██   ██  ██   ██   ██ ▀███████▄ ██  ██    ██ ██▀▀▀█▄  ███   ███   ███   ██   ██ ██▀▀▀█▄   ██   ██   ██    ▀    ██   █    ██  ██
      █   ███▌ ███        ██    ██ ██   ██  ▄██▄▄    ██▌  ▄██       ██   ██  ▄██▄▄█▀   ██   ██     ██  ▀ ██▌ ██    ██ ██   ██  ███   ███   ███   ██   ██ ██   ██   ██   ██  ▄██        ▄██▄▄     ▄██▄▄█▀
      █   ███  ███    █▄  ██    ██ ██   ██ ▀▀██▀▀    ██  ▀▀██ ███▄  ██   ██ ▀███████ ▀████████     ██    ██  ██    ██ ██   ██  ███   ███   ███ ▀████████ ██   ██ ▀████████ ▀▀██ ███▄  ▀▀██▀▀    ▀███████
      █   ███  ███    ███ ██    ██ ██   ██   ██      ██    ██    ██ ██   ██   ██  ██   ██   ██     ██    ██  ██    ██ ██   ██  ███   ███   ███   ██   ██ ██   ██   ██   ██   ██    ██   ██   █    ██  ██
      █   █▀   ████████▀   ██████   █   █    ██      █     ██████▀  ██████    ██  ██   ██   █▀    ▄██▀   █    ██████   █   █    ▀█   ███   █▀    ██   █▀  █   █    ██   █▀   ██████▀    ███████   ██  ██
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Defines the interface for the Configuration Manager.
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

using OpenIIoT.SDK;
using OpenIIoT.SDK.Common;

using OpenIIoT.SDK.Common;

using OpenIIoT.SDK.Configuration;
using System;
using System.Collections.Generic;
using Utility.OperationResult;

namespace OpenIIoT.SDK.Configuration
{
    /// <summary>
    ///     Defines the interface for the Configuration Manager.
    /// </summary>
    public interface IConfigurationManager : IStateful, IManager
    {
        #region Properties

        /// <summary>
        ///     Gets the current configuration.
        /// </summary>
        Dictionary<string, Dictionary<string, object>> Configuration { get; }

        /// <summary>
        ///     Gets the filename of the configuration file.
        /// </summary>
        string ConfigurationFileName { get; }

        /// <summary>
        ///     Gets a dictionary containing all registered configurable types and their ConfigurationDefinitions.
        /// </summary>
        Dictionary<Type, ConfigurationDefinition> RegisteredTypes { get; }

        #endregion Properties

        #region Methods

        #region Configuration Management

        /// <summary>
        ///     Saves the current configuration to the file specified in app.exe.config.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        Result SaveConfiguration();

        /// <summary>
        ///     Validates the current configuration.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        Result ValidateConfiguration();

        #endregion Configuration Management

        #region Instance Registration

        /// <summary>
        ///     Evaluates the provided type regarding whether it can be configured and returns the result. To be configurable, the
        ///     type must implement IConfigurable and must have static methods GetConfigurationDefinition and GetDefaultConfiguration.
        /// </summary>
        /// <param name="type">The Type to evaluate.</param>
        /// <returns>A Result containing the result of the operation and the Type of the configuration.</returns>
        Result<Type> IsConfigurable(Type type);

        /// <summary>
        ///     Checks to see if the supplied Type is in the RegisteredTypes dictionary.
        /// </summary>
        /// <param name="type">The Type to check.</param>
        /// <returns>
        ///     A Result containing the result of the operation and a boolean indicating whether the specified Type was found in
        ///     the dictionary.
        /// </returns>
        Result<bool> IsRegistered(Type type);

        /// <summary>
        ///     Registers each Type within the supplied list which implements the IConfigurable interface.
        /// </summary>
        /// <param name="types">The list of Types to register.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        Result RegisterTypes(List<Type> types);

        /// <summary>
        ///     Registers the supplied Type with the Configuration Manager.
        /// </summary>
        /// <remarks>When called during application startup, throwExceptionOnFailure should be set to true.</remarks>
        /// <param name="type">The Type to register.</param>
        /// <param name="throwExceptionOnFailure">If true, throws an exception on failure.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        Result RegisterType(Type type, bool throwExceptionOnFailure = false);

        #endregion Instance Registration

        #region Instance Configuration Management

        /// <summary>
        ///     Determines whether the specified instance of the specified type is configured.
        /// </summary>
        /// <param name="type">The Type of the instance to check.</param>
        /// <param name="instanceName">The name of the instance to check.</param>
        /// <returns>A Result containing the result of the operation and a boolean containing the outcome of the lookup.</returns>
        Result<bool> IsConfigured(Type type, string instanceName = "");

        /// <summary>
        ///     Adds the specified configuration to the specified instance of the specified type.
        /// </summary>
        /// <typeparam name="T">The Type of the configuration.</typeparam>
        /// <param name="type">The Type of the instance to be configured.</param>
        /// <param name="instanceConfiguration">The Configuration instance of the configuration model of the calling class.</param>
        /// <param name="instanceName">The name of the instance to configure.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        Result<T> AddInstanceConfiguration<T>(Type type, object instanceConfiguration, string instanceName = "");

        /// <summary>
        ///     Retrieves the configuration for the instance matching instanceName of the supplied Type. If the configuration can't
        ///     be found, returns the default configuration for the Type.
        /// </summary>
        /// <typeparam name="T">The Type matching the Configuration model for the calling class.</typeparam>
        /// <param name="type">The Type of the calling class.</param>
        /// <param name="instanceName">The name of the instance for which to retrieve the configuration.</param>
        /// <returns>
        ///     A Result containing the result of the operation and an instance of the Configuration model for the calling class
        ///     containing the retrieved configuration.
        /// </returns>
        Result<T> GetInstanceConfiguration<T>(Type type, string instanceName = "");

        /// <summary>
        ///     Saves the specified Configuration model to the Configuration for the specified instance and Type.
        /// </summary>
        /// <param name="type">The Type of the calling class.</param>
        /// <param name="instanceConfiguration">The Configuration model to save.</param>
        /// <param name="instanceName">The instance of the calling class for which to save the configuration.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        Result UpdateInstanceConfiguration(Type type, object instanceConfiguration, string instanceName = "");

        /// <summary>
        ///     Removes the specified instance of the specified type from the configuration.
        /// </summary>
        /// <param name="type">The Type of instance to remove.</param>
        /// <param name="instanceName">The name of the instance to remove from the Type.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        Result RemoveInstanceConfiguration(Type type, string instanceName = "");

        #endregion Instance Configuration Management

        #endregion Methods
    }
}