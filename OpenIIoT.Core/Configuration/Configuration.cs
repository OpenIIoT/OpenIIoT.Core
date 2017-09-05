/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █   ▄████████
      █   ███    ███
      █   ███    █▀   ██████  ██▄▄▄▄     ▄█████  █     ▄████▄  ██   █     █████   ▄█████      ██     █   ██████  ██▄▄▄▄
      █   ███        ██    ██ ██▀▀▀█▄   ██   ▀█ ██    ██    ▀  ██   ██   ██  ██   ██   ██ ▀███████▄ ██  ██    ██ ██▀▀▀█▄
      █   ███        ██    ██ ██   ██  ▄██▄▄    ██▌  ▄██       ██   ██  ▄██▄▄█▀   ██   ██     ██  ▀ ██▌ ██    ██ ██   ██
      █   ███    █▄  ██    ██ ██   ██ ▀▀██▀▀    ██  ▀▀██ ███▄  ██   ██ ▀███████ ▀████████     ██    ██  ██    ██ ██   ██
      █   ███    ███ ██    ██ ██   ██   ██      ██    ██    ██ ██   ██   ██  ██   ██   ██     ██    ██  ██    ██ ██   ██
      █   ████████▀   ██████   █   █    ██      █     ██████▀  ██████    ██  ██   ██   █▀    ▄██▀   █    ██████   █   █
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  The configuration for the application and all instances of Types implementing the IConfigurable interface.
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
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using NLog.xLogger;
using OpenIIoT.SDK.Configuration;
using Utility.OperationResult;

namespace OpenIIoT.Core.Configuration
{
    /// <summary>
    ///     The configuration for the application and all instances of Types implementing the IConfigurable interface.
    /// </summary>
    public class Configuration : IConfiguration
    {
        #region Private Fields

        /// <summary>
        ///     The Logger for this class.
        /// </summary>
        private static xLogger logger = xLogManager.GetCurrentClassxLogger();

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Configuration"/> class with the specified Type registry.
        /// </summary>
        /// <param name="registry">The Type registry with which to initialize the configuration.</param>
        public Configuration(IConfigurableTypeRegistry registry)
            : this(registry, new Dictionary<string, IDictionary<string, object>>())
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Configuration"/> class with the specified Type registry and collection
        ///     of instance configurations.
        /// </summary>
        /// <param name="registry">The Type registry with which to initialize the configuration.</param>
        /// <param name="instances">The collection of instance configurations with which to initialize the configuration.</param>
        public Configuration(IConfigurableTypeRegistry registry, IDictionary<string, IDictionary<string, object>> instances)
        {
            TypeRegistry = registry;
            InstanceDictionary = instances;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        ///     Gets the collection of instance configurations.
        /// </summary>
        public IReadOnlyDictionary<string, IDictionary<string, object>> Instances => new ReadOnlyDictionary<string, IDictionary<string, object>>(InstanceDictionary);

        #endregion Public Properties

        #region Private Properties

        /// <summary>
        ///     Gets or sets tThe collection of instance configurations.
        /// </summary>
        private IDictionary<string, IDictionary<string, object>> InstanceDictionary { get; set; }

        /// <summary>
        ///     Gets or sets the registry of configurable Types.
        /// </summary>
        private IConfigurableTypeRegistry TypeRegistry { get; set; }

        #endregion Private Properties

        #region Public Methods

        /// <summary>
        ///     Adds the specified configuration to the default instance of the specified type.
        /// </summary>
        /// <typeparam name="T">The configuration Type.</typeparam>
        /// <param name="type">The Type of the instance to be configured.</param>
        /// <param name="instanceConfiguration">The ApplicationConfiguration instance to which to add the new configuration.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public IResult<T> AddInstance<T>(Type type, object instanceConfiguration)
        {
            return AddInstance<T>(type, instanceConfiguration, string.Empty);
        }

        /// <summary>
        ///     Adds the specified configuration to the specified instance of the specified type.
        /// </summary>
        /// <typeparam name="T">The configuration Type.</typeparam>
        /// <param name="type">The Type of the instance to be configured.</param>
        /// <param name="instanceConfiguration">The ApplicationConfiguration instance to which to add the new configuration.</param>
        /// <param name="instanceName">The name of the instance to configure.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public IResult<T> AddInstance<T>(Type type, object instanceConfiguration, string instanceName)
        {
            logger.EnterMethod(xLogger.Params(type, instanceConfiguration, new xLogger.ExcludedParam(), instanceName));

            Result<T> retVal = new Result<T>();

            if (!TypeRegistry.IsRegistered(type))
            {
                retVal.AddError("The type '" + type.Name + "' is configurable but has not been registered.");
            }
            else if (!IsInstanceConfigured(type, instanceName).ReturnValue)
            {
                // ensure the configuration doesn't already exist
                logger.Trace("Inserting configuration into the Configuration dictionary...");

                // if the configuration doesn't contain a section for the type, add it
                if (!InstanceDictionary.ContainsKey(type.FullName))
                {
                    InstanceDictionary.Add(type.FullName, new Dictionary<string, object>());
                }

                // add the default configuration for the requested type/instance to the configuration.
                InstanceDictionary[type.FullName].Add(instanceName, instanceConfiguration);

                retVal.ReturnValue = (T)instanceConfiguration;

                logger.Trace("The configuration was inserted successfully.");
            }
            else
            {
                retVal.AddError("The configuration for instance '" + instanceName + "' of type '" + type.Name + "' already exists.");
            }

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal);
            return retVal;
        }

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
        public IResult<T> GetInstance<T>(Type type, string instanceName)
        {
            logger.EnterMethod(xLogger.Params(type, new xLogger.ExcludedParam(), instanceName));

            Result<T> retVal = new Result<T>();

            // ensure the specified type and instance is configured
            if (IsInstanceConfigured(type, instanceName).ReturnValue)
            {
                try
                {
                    // json.net needs to know the type when it deserializes; we can't cast or convert after the fact. the solution
                    // is to grab our object, serialize it again, then deserialize it into the required type.
                    var rawObject = InstanceDictionary[type.FullName][instanceName];
                    var newSerializedObject = JsonConvert.SerializeObject(rawObject);
                    var newDeSerializedObject = JsonConvert.DeserializeObject<T>(newSerializedObject);
                    retVal.ReturnValue = newDeSerializedObject;
                }
                catch (Exception ex)
                {
                    retVal.AddError("Error retrieving and re-serializing the data from the configuration for type '" + type.Name + "', instance '" + instanceName + "': " + ex);
                }
            }
            else
            {
                retVal.AddError("The specified type '" + type.Name + "' is not configured.");
            }

            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        ///     Retrieves the configuration for the default instance of the supplied Type. If the configuration can't be found,
        ///     returns the default configuration for the Type.
        /// </summary>
        /// <typeparam name="T">The Type matching the Configuration model for the calling class.</typeparam>
        /// <param name="type">The Type of the calling class.</param>
        /// <returns>
        ///     A Result containing the result of the operation and an instance of the Configuration model for the calling class
        ///     containing the retrieved configuration.
        /// </returns>
        public IResult<T> GetInstance<T>(Type type)
        {
            return GetInstance<T>(type, string.Empty);
        }

        /// <summary>
        ///     Determines whether the specified instance of the specified type is configured.
        /// </summary>
        /// <param name="type">The Type of the instance to check.</param>
        /// <param name="instanceName">The name of the instance to check.</param>
        /// <returns>A Result containing the result of the operation and a boolean containing the outcome of the lookup.</returns>
        public IResult<bool> IsInstanceConfigured(Type type, string instanceName)
        {
            logger.EnterMethod(xLogger.Params(type, new xLogger.ExcludedParam(), instanceName));
            Result<bool> retVal = new Result<bool>();

            // check to see if the type is in the comfiguration
            if (InstanceDictionary.ContainsKey(type.FullName))
            {
                // check to see if the specified instance is in the type configuration
                if (!InstanceDictionary[type.FullName].ContainsKey(instanceName))
                {
                    retVal.AddError("The specified instance name '" + instanceName + "' wasn't found in the configuration for type '" + type.Name + "'.");
                }
            }
            else
            {
                retVal.AddError("The specified type '" + type.Name + "' was not found in the configuration.");
            }

            // if any messages were generated the configuration wasn't found, so return false.
            retVal.ReturnValue = retVal.ResultCode != ResultCode.Failure;

            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        ///     Determines whether the default instance of the specified type is configured.
        /// </summary>
        /// <param name="type">The Type of the instance to check.</param>
        /// <returns>A Result containing the result of the operation and a boolean containing the outcome of the lookup.</returns>
        public IResult<bool> IsInstanceConfigured(Type type)
        {
            return IsInstanceConfigured(type, string.Empty);
        }

        /// <summary>
        ///     Sets value of the Instance property to the specified instance configuration collection.
        /// </summary>
        /// <param name="instances">The collection of instance configurations to which the Instances property is to be set.</param>
        public void LoadInstancesFrom(IDictionary<string, IDictionary<string, object>> instances)
        {
            if (instances != default(IDictionary<string, IDictionary<string, object>>))
            {
                InstanceDictionary = instances;
            }
        }

        /// <summary>
        ///     Removes the specified instance of the specified type from the configuration.
        /// </summary>
        /// <param name="type">The Type of instance to remove.</param>
        /// <param name="instanceName">The name of the instance to remove from the Type.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public IResult RemoveInstance(Type type, string instanceName)
        {
            logger.EnterMethod(xLogger.Params(type, instanceName));

            logger.Debug("Removing configuration for instance '" + instanceName + "' of type '" + type.Name + "'...");
            Result retVal = new Result();

            if (IsInstanceConfigured(type, instanceName).ReturnValue)
            {
                InstanceDictionary[type.FullName].Remove(instanceName);
            }
            else
            {
                retVal.AddError("The specified instance '" + instanceName + "' of type '" + type.Name + "' was not found in the configuration.");
            }

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        ///     Removes the default instance of the specified type from the configuration.
        /// </summary>
        /// <param name="type">The Type of instance to remove.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public IResult RemoveInstance(Type type)
        {
            return RemoveInstance(type, string.Empty);
        }

        /// <summary>
        ///     Saves the specified Configuration model to the Configuration for the specified instance and Type.
        /// </summary>
        /// <param name="type">The Type of the calling class.</param>
        /// <param name="instanceConfiguration">The Configuration model to save.</param>
        /// <param name="instanceName">The instance of the calling class for which to save the configuration.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public IResult UpdateInstance(Type type, object instanceConfiguration, string instanceName)
        {
            logger.EnterMethod(xLogger.Params(type, instanceConfiguration, new xLogger.ExcludedParam(), instanceName));

            logger.Debug("Updating configuration for instance '" + instanceName + "' of type '" + type.Name + "'...");
            Result retVal = new Result();

            if (IsInstanceConfigured(type, instanceName).ReturnValue)
            {
                InstanceDictionary[type.FullName][instanceName] = instanceConfiguration;
            }
            else
            {
                retVal.AddError("The specified instance '" + instanceName + "' of type '" + type.Name + "' was not found in the configuration.");
            }

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        ///     Saves the specified Configuration model to the Configuration for the default instance and Type.
        /// </summary>
        /// <param name="type">The Type of the calling class.</param>
        /// <param name="instanceConfiguration">The Configuration model to save.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public IResult UpdateInstance(Type type, object instanceConfiguration)
        {
            return UpdateInstance(type, instanceConfiguration, string.Empty);
        }

        #endregion Public Methods
    }
}