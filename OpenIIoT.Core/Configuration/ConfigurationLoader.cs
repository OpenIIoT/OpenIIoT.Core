using Newtonsoft.Json;
using NLog;
using NLog.xLogger;
using OpenIIoT.SDK.Platform;
using System;
using System.Collections.Generic;
using Utility.OperationResult;

namespace OpenIIoT.Core.Configuration
{
    public class ConfigurationLoader
    {
        /// <summary>
        ///     The Logger for this class.
        /// </summary>
        private static xLogger logger = xLogManager.GetCurrentClassxLogger();

        /// <summary>
        ///     Gets the Platform instance used for file I/O.
        /// </summary>
        private IPlatform Platform { get; set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ConfigurationLoader"/> class with the specified
        ///     <see cref="IPlatform"/> .
        /// </summary>
        /// <param name="platform">The Platform instance used for file I/O.</param>
        private ConfigurationLoader(IPlatform platform)
        {
            Platform = platform;
        }

        /// <summary>
        ///     Factory method for the class.
        /// </summary>
        /// <param name="platform">The Platform instance used for file I/O.</param>
        /// <returns>The newly created instance of the class.</returns>
        public static ConfigurationLoader CreateLoader(IPlatform platform)
        {
            return new ConfigurationLoader(platform);
        }

        /// <summary>
        ///     Reads the specified file and attempts to deserialize it to an instance of the configuration Type.
        /// </summary>
        /// <param name="fileName">The file to read and deserialize.</param>
        /// <returns>A Result containing the result of the operation and the Configuration instance created from the file.</returns>
        public Result<Dictionary<string, Dictionary<string, object>>> Load(string fileName)
        {
            Guid guid = logger.EnterMethod(xLogger.Params(fileName), true);

            logger.Info("Loading configuration from '" + fileName + "'...");
            Result<Dictionary<string, Dictionary<string, object>>> retVal = new Result<Dictionary<string, Dictionary<string, object>>>();

            string configFile = string.Empty;

            try
            {
                // read the entirety of the configuration file into configFile
                configFile = Platform.ReadFile(fileName).ReturnValue;
                logger.Trace("Configuration file loaded from '" + fileName + "'.  Attempting to deserialize...");

                // attempt to deserialize the contents of the file to an object of type ApplicationConfiguration
                retVal.ReturnValue = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, object>>>(configFile);
                logger.Trace("Successfully deserialized the contents of '" + fileName + "' to a Configuration object.");
            }
            catch (Exception ex)
            {
                retVal.AddError("Exception thrown while loading Configuration from '" + fileName + "': " + ex);
                logger.Exception(LogLevel.Error, ex, xLogger.Vars(configFile), xLogger.Names("configFile"), guid);
            }

            retVal.LogResult(logger);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        /// <summary>
        ///     Manually builds an instance of Configuration with default values.
        /// </summary>
        /// <returns>A Result containing the default instance of a Configuration.</returns>
        public Result<Dictionary<string, Dictionary<string, object>>> Build()
        {
            logger.EnterMethod();

            Result<Dictionary<string, Dictionary<string, object>>> retVal = new Result<Dictionary<string, Dictionary<string, object>>>();
            retVal.ReturnValue = new Dictionary<string, Dictionary<string, object>>();

            logger.ExitMethod();
            return retVal;
        }

        /// <summary>
        ///     Saves the given configuration to the specified file.
        /// </summary>
        /// <param name="configuration">The Configuration object to serialize and write to disk.</param>
        /// <param name="fileName">The file in which to save the configuration.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public Result Save(Dictionary<string, Dictionary<string, object>> configuration, string fileName)
        {
            Guid guid = logger.EnterMethod(xLogger.Params(configuration, fileName), true);

            logger.Info("Saving configuration to '" + fileName + "'...");
            Result retVal = new Result();

            try
            {
                logger.Trace("Flushing configuration to disk at '" + fileName + "'.");
                Platform.WriteFile(fileName, JsonConvert.SerializeObject(configuration, Formatting.Indented, new Newtonsoft.Json.Converters.StringEnumConverter()));
            }
            catch (Exception ex)
            {
                retVal.AddError("Exception thrown when attempting to save the Configuration to '" + fileName + "': " + ex.Message);
            }

            retVal.LogResult(logger);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }
    }
}