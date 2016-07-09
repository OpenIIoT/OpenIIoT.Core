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
 ▄ ▄▄ █ ▄▄▄▄▄▄▄▄▄  ▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄ 
 █ ██ █ █████████  ████ ██████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █ 
      █  
      █  Defines the interface for the Configuration Manager.
      █  
      ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀  ▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀██ 
                                                                                                   ██ 
                                                                                               ▀█▄ ██ ▄█▀ 
                                                                                                 ▀████▀   
                                                                                                   ▀▀                            */

using System;
using System.Collections.Generic;

namespace Symbiote.Core.Configuration
{
    /// <summary>
    /// Defines the interface for the Configuration Manager.
    /// </summary>
    public interface IConfigurationManager : IStateful, IManager
    {
        #region Properties

        /// <summary>
        /// The current configuration.
        /// </summary>
        Dictionary<string, Dictionary<string, object>> Configuration { get; }

        /// <summary>
        /// The filename of the configuration file.
        /// </summary>
        string ConfigurationFileName { get; }

        /// <summary>
        /// A dictionary containing all registered configuratble types and their ConfigurationDefinitions.
        /// </summary>
        Dictionary<string, ConfigurationDefinition> RegisteredTypes { get; }

        #endregion

        #region Instance Methods

        #region Configuration Management

        /// <summary>
        /// Saves the current configuration to the file specified in app.exe.config.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        Result SaveConfiguration();

        /// <summary>
        /// Validates the current configuration.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        Result ValidateConfiguration();

        #endregion

        #region Instance Registration

        /// <summary>
        /// Evaluates the provided type regarding whether it can be configured and returns the result.
        /// To be configurable, the type must implement IConfigurable and must have static methods GetConfigurationDefinition and 
        /// GetDefaultConfiguration.
        /// </summary>
        /// <param name="type">The Type to evaluate.</param>
        /// <returns>A Result containing the result of the operation and the Type of the configuration.</returns>
        Result<Type> IsConfigurable(Type type);

        /// <summary>
        /// Checks to see if the supplied Type is in the RegisteredTypes dictionary.
        /// </summary>
        /// <param name="type">The Type to check.</param>
        /// <returns>A Result containing the result of the operation and a boolean indicating whether the specified Type was found in the dictionary.</returns>
        Result<bool> IsRegistered(Type type);

        /// <summary>
        /// Registers the supplied Type with the Configuration Manager.
        /// </summary>
        /// <remarks>When called during application startup, throwExceptionOnFailure should be set to true.</remarks>
        /// <param name="type">The Type to register.</param>
        /// <param name="throwExceptionOnFailure">If true, throws an exception on failure.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        Result RegisterType(Type type, bool throwExceptionOnFailure = false);

        #endregion

        #region Instance Configuration Management

        /// <summary>
        /// Determines whether the specified instance of the specified type is configured.
        /// </summary>
        /// <param name="type">The Type of the instance to check.</param>
        /// <param name="instanceName">The name of the instance to check.</param>
        /// <returns>A Result containing the result of the operation and a boolean containing the outcome of the lookup.</returns>
        Result<bool> IsConfigured(Type type, string instanceName = "");

        /// <summary>
        /// Adds the specified configuration to the specified instance of the specified type.
        /// </summary>
        /// <param name="type">The Type of the instance to be configured.</param>
        /// <param name="instanceConfiguration">The Configuration instance of the configuration model of the calling class.</param>
        /// <param name="instanceName">The name of the instance to configure.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        Result<T> AddInstanceConfiguration<T>(Type type, object instanceConfiguration, string instanceName = "");

        /// <summary>
        /// Retrieves the configuration for the instance matching instanceName of the supplied Type.
        /// If the configuration can't be found, returns the default configuration for the Type.
        /// </summary>
        /// <typeparam name="T">The Type matching the Configuration model for the calling class.</typeparam>
        /// <param name="type">The Type of the calling class.</param>
        /// <param name="instanceName">The name of the instance for which to retrieve the configuration.</param>
        /// <returns>A Result containing the result of the operation and an instance of the Configuration model 
        /// for the calling class containing the retrieved configuration.</returns>
        Result<T> GetInstanceConfiguration<T>(Type type, string instanceName = "");

        /// <summary>
        /// Saves the specified Configuration model to the Configuration for the specified instance and Type.
        /// </summary>
        /// <param name="type">The Type of the calling class.</param>
        /// <param name="instanceConfiguration">The Configuration model to save.</param>
        /// <param name="instanceName">The instance of the calling class for which to save the configuration.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        Result UpdateInstanceConfiguration(Type type, object instanceConfiguration, string instanceName = "");

        /// <summary>
        /// Removes the specified instance of the specified type from the configuration.
        /// </summary>
        /// <param name="type">The Type of instance to remove.</param>
        /// <param name="instanceName">The name of the instance to remove from the Type.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        Result RemoveInstanceConfiguration(Type type, string instanceName = "");

        #endregion

        #endregion
    }
}
