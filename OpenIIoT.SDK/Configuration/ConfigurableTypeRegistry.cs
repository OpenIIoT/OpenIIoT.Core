/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █   ▄████████                                                                                                        ███                                    ▄████████
      █   ███    ███                                                                                                   ▀█████████▄                               ███    ███
      █   ███    █▀   ██████  ██▄▄▄▄     ▄█████  █     ▄████▄  ██   █     █████   ▄█████  ▀██████▄   █          ▄█████    ▀███▀▀██ ▄█   ▄     █████▄    ▄█████  ▄███▄▄▄▄██▀    ▄█████    ▄████▄   █    ▄█████     ██       █████ ▄█   ▄
      █   ███        ██    ██ ██▀▀▀█▄   ██   ▀█ ██    ██    ▀  ██   ██   ██  ██   ██   ██   ██   ██ ██         ██   █      ███   ▀ ██   █▄   ██   ██   ██   █  ▀▀███▀▀▀▀▀     ██   █    ██    ▀  ██    ██  ▀  ▀███████▄   ██  ██ ██   █▄
      █   ███        ██    ██ ██   ██  ▄██▄▄    ██▌  ▄██       ██   ██  ▄██▄▄█▀   ██   ██  ▄██▄▄█▀  ██        ▄██▄▄        ███     ▀▀▀▀▀██   ██   ██  ▄██▄▄    ▀███████████  ▄██▄▄     ▄██       ██▌   ██         ██  ▀  ▄██▄▄█▀ ▀▀▀▀▀██
      █   ███    █▄  ██    ██ ██   ██ ▀▀██▀▀    ██  ▀▀██ ███▄  ██   ██ ▀███████ ▀████████ ▀▀██▀▀█▄  ██       ▀▀██▀▀        ███     ▄█   ██ ▀██████▀  ▀▀██▀▀      ███    ███ ▀▀██▀▀    ▀▀██ ███▄  ██  ▀███████     ██    ▀███████ ▄█   ██
      █   ███    ███ ██    ██ ██   ██   ██      ██    ██    ██ ██   ██   ██  ██   ██   ██   ██   ██ ██▌    ▄   ██   █      ███     ██   ██   ██        ██   █    ███    ███   ██   █    ██    ██ ██     ▄  ██     ██      ██  ██ ██   ██
      █   ████████▀   ██████   █   █    ██      █     ██████▀  ██████    ██  ██   ██   █▀ ▄██████▀  ████▄▄██   ███████    ▄████▀    █████   ▄███▀      ███████   ███    ███   ███████   ██████▀  █    ▄████▀     ▄██▀     ██  ██  █████
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Maintains a registry of Types implementing the IConfigurable interface.
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
using NLog;
using NLog.xLogger;
using Utility.OperationResult;
using System.Reflection;
using OpenIIoT.SDK.Common.Exceptions;

namespace OpenIIoT.SDK.Configuration
{
    /// <summary>
    ///     Maintains a registry of Types implementing the <see cref="IConfigurable{T}"/> interface.
    /// </summary>
    public class ConfigurableTypeRegistry
    {
        #region Private Fields

        /// <summary>
        ///     The Logger for this class.
        /// </summary>
        private static xLogger logger = (xLogger)LogManager.GetCurrentClassLogger(typeof(xLogger));

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ConfigurableTypeRegistry"/> class.
        /// </summary>
        public ConfigurableTypeRegistry()
        {
            RegisteredTypes = new Dictionary<Type, ConfigurationDefinition>();
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        ///     Gets a dictionary containing all registered configurable types and their ConfigurationDefinitions.
        /// </summary>
        public Dictionary<Type, ConfigurationDefinition> RegisteredTypes { get; private set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        ///     Evaluates the specified <see cref="Type"/> to determine whether it can be configured, and returns the result. To be
        ///     configurable, the type must implement <see cref="IConfigurable{T}"/> and must have static methods
        ///     GetConfigurationDefinition and GetDefaultConfiguration.
        /// </summary>
        /// <param name="type">The Type to evaluate.</param>
        /// <returns>
        ///     A Result containing the result of the operation and a boolean value indicating whether the specified Type can be configured.
        /// </returns>
        private Result<bool> IsConfigurable(Type type)
        {
            logger.EnterMethod(xLogger.Params(type));
            Result<bool> retVal = new Result<bool>();
            retVal.ReturnValue = false;

            // check whether the Type implements IConfigurable
            if (!type.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IConfigurable<>)))
            {
                retVal.AddError("The provided type '" + type.Name + "' does not implement IConfigurable.");
            }

            // check whether the Type contains the static method "GetConfigurationDefinition"
            if (type.GetMethod("GetConfigurationDefinition") == default(MethodInfo))
            {
                retVal.AddError("The provided type '" + type.Name + "' is missing the static method 'GetConfigurationDefinition'");
            }

            // check whether the Type contains the static method "GetDefaultConfiguration"
            if (type.GetMethod("GetDefaultConfiguration") == default(MethodInfo))
            {
                retVal.AddError("The provided type '" + type.Name + "' is missing the static method 'GetDefaultConfiguration'");
            }

            // if none of the previous checks failed, the type is configurable.
            if (retVal.ResultCode != ResultCode.Failure)
            {
                retVal.ReturnValue = true;
            }

            retVal.LogResult(logger.Trace);
            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        ///     Checks to see if the supplied Type is in the RegisteredTypes dictionary.
        /// </summary>
        /// <param name="type">The Type to check.</param>
        /// <returns>A value indicating whether the specified Type was found in the dictionary.</returns>
        public bool IsRegistered(Type type)
        {
            logger.EnterMethod(xLogger.Params(type));

            // the type is registered if it exists within the RegisteredTypes dictionary
            bool retVal = RegisteredTypes.ContainsKey(type);

            logger.ExitMethod();
            return retVal;
        }

        /// <summary>
        ///     Registers the supplied Type with the Configuration Manager.
        /// </summary>
        /// <remarks>When called during application startup, throwExceptionOnFailure should be set to true.</remarks>
        /// <param name="type">The Type to register.</param>
        /// <param name="throwExceptionOnFailure">If true, throws an exception on failure.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        /// <exception cref="ConfigurationRegistrationException">Thrown when the specified Type is fails to be registered.</exception>
        public Result RegisterType(Type type, bool throwExceptionOnFailure = false)
        {
            logger.EnterMethod(xLogger.Params(type, throwExceptionOnFailure));
            Result retVal = new Result();

            Result<bool> checkResult = IsConfigurable(type);

            // ensure the provided Type is configurable.
            if (!checkResult.ReturnValue)
            {
                retVal.AddError("The Type '" + type.Name + "' could not be registered: " + checkResult.GetLastError());
            }
            else
            {
                // the type is configurable; try to get the configuration definition
                try
                {
                    ConfigurationDefinition typedef = (ConfigurationDefinition)type.GetMethod("GetConfigurationDefinition").Invoke(null, null);
                    if (typedef == default(ConfigurationDefinition))
                    {
                        retVal.AddError("The ConfigurationDefinition retrieved from the supplied type is invalid.");
                    }
                    else
                    {
                        retVal = RegisterType(type, typedef);
                    }
                }
                catch (Exception ex)
                {
                    retVal.AddError("Exception thrown while registering the type: " + ex);
                }
            }

            if (throwExceptionOnFailure && retVal.ResultCode == ResultCode.Failure)
            {
                throw new ConfigurationRegistrationException("Failed to register the type '" + type.Name + "' for configuration.");
            }

            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        ///     Registers each Type within the supplied list which implements the IConfigurable interface.
        /// </summary>
        /// <param name="types">The list of Types to register.</param>
        /// <param name="throwExceptionOnFailure">
        ///     A value indicating whether an exception should be thrown if a registration fails.
        /// </param>
        /// <returns>A Result containing the result of the operation.</returns>
        public Result RegisterTypes(List<Type> types, bool throwExceptionOnFailure = false)
        {
            logger.EnterMethod(xLogger.Params(types));
            logger.Debug("Attempting to register " + types.Count() + " types...");
            Result retVal = new Result();

            foreach (Type type in types)
            {
                if (type.GetInterfaces().Where(i => i.IsGenericType).Any(i => i.GetGenericTypeDefinition() == typeof(IConfigurable<>)))
                {
                    retVal.Incorporate(RegisterType(type, throwExceptionOnFailure));
                }
                else
                {
                    logger.Trace("The Type '" + type.Name + "' does not implement IConfigurable and was not registered.");
                }
            }

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal);
            return retVal;
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        ///     Registers the supplied Type with the Configuration Manager using the supplied ConfigurationDefinition.
        /// </summary>
        /// <param name="type">The Type to register.</param>
        /// <param name="definition">The ConfigurationDefinition with which to register the Type.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        private Result RegisterType(Type type, ConfigurationDefinition definition)
        {
            logger.EnterMethod();
            logger.Debug("Registering type '" + type.Name + "'...");

            Result retVal = new Result();

            // check to ensure that the type hasn't already been registered
            if (!RegisteredTypes.ContainsKey(type))
            {
                RegisteredTypes.Add(type, definition);
                logger.Debug("Registered type '" + type.Name + "' for configuration.");
            }
            else
            {
                retVal.AddWarning("The Type '" + type.Name + "' has already been registered.  Ignoring.");
            }

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal);
            return retVal;
        }

        #endregion Private Methods
    }
}