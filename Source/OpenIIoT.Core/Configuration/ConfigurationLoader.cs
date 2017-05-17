/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █   ▄████████                                                                                                       ▄█
      █   ███    ███                                                                                                     ███
      █   ███    █▀   ██████  ██▄▄▄▄     ▄█████  █     ▄████▄  ██   █     █████   ▄█████      ██     █   ██████  ██▄▄▄▄  ███        ██████    ▄█████  ██████▄     ▄█████    █████
      █   ███        ██    ██ ██▀▀▀█▄   ██   ▀█ ██    ██    ▀  ██   ██   ██  ██   ██   ██ ▀███████▄ ██  ██    ██ ██▀▀▀█▄ ███       ██    ██   ██   ██ ██   ▀██   ██   █    ██  ██
      █   ███        ██    ██ ██   ██  ▄██▄▄    ██▌  ▄██       ██   ██  ▄██▄▄█▀   ██   ██     ██  ▀ ██▌ ██    ██ ██   ██ ███       ██    ██   ██   ██ ██    ██  ▄██▄▄     ▄██▄▄█▀
      █   ███    █▄  ██    ██ ██   ██ ▀▀██▀▀    ██  ▀▀██ ███▄  ██   ██ ▀███████ ▀████████     ██    ██  ██    ██ ██   ██ ███       ██    ██ ▀████████ ██    ██ ▀▀██▀▀    ▀███████
      █   ███    ███ ██    ██ ██   ██   ██      ██    ██    ██ ██   ██   ██  ██   ██   ██     ██    ██  ██    ██ ██   ██ ███▌    ▄ ██    ██   ██   ██ ██   ▄██   ██   █    ██  ██
      █   ████████▀   ██████   █   █    ██      █     ██████▀  ██████    ██  ██   ██   █▀    ▄██▀   █    ██████   █   █  █████▄▄██  ██████    ██   █▀ ██████▀    ███████   ██  ██
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Handles the building, loading, and saving of application configuration files.
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
using Newtonsoft.Json;
using NLog.xLogger;
using OpenIIoT.SDK.Common.Exceptions;
using OpenIIoT.SDK.Platform;
using Utility.OperationResult;

namespace OpenIIoT.Core.Configuration
{
    /// <summary>
    ///     Handles the building, loading, and saving of application configuration files.
    /// </summary>
    public class ConfigurationLoader
    {
        #region Private Fields

        /// <summary>
        ///     The Logger for this class.
        /// </summary>
        private static xLogger logger = xLogManager.GetCurrentClassxLogger();

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ConfigurationLoader"/> class with the specified
        ///     <see cref="IPlatform"/> .
        /// </summary>
        /// <param name="platform">The Platform instance used for file I/O.</param>
        public ConfigurationLoader(IPlatform platform)
        {
            Platform = platform;
        }

        #endregion Public Constructors

        #region Private Properties

        /// <summary>
        ///     Gets or sets the Platform instance used for file I/O.
        /// </summary>
        private IPlatform Platform { get; set; }

        #endregion Private Properties

        #region Public Methods

        /// <summary>
        ///     Manually builds an instance of Configuration with default values.
        /// </summary>
        /// <returns>A Result containing the default instance of a Configuration.</returns>
        public Result<Dictionary<string, Dictionary<string, object>>> BuildNew()
        {
            logger.EnterMethod();
            logger.Debug("Building new configuration...");

            Result<Dictionary<string, Dictionary<string, object>>> retVal = new Result<Dictionary<string, Dictionary<string, object>>>();
            retVal.ReturnValue = new Dictionary<string, Dictionary<string, object>>();

            retVal.LogResult(logger.Debug);
            logger.ExitMethod();
            return retVal;
        }

        /// <summary>
        ///     Reads the specified file and attempts to deserialize it to an instance of the configuration Type.
        /// </summary>
        /// <param name="fileName">The file to read and deserialize.</param>
        /// <returns>A Result containing the result of the operation and the Configuration instance created from the file.</returns>
        /// <exception cref="ConfigurationLoadException">Thrown when a configuration file exists but can not be read.</exception>
        public Result<Dictionary<string, Dictionary<string, object>>> Load(string fileName)
        {
            Guid guid = logger.EnterMethod(xLogger.Params(fileName), true);
            logger.Debug("Attempting to load configuration from '" + fileName + "'...");
            Result<Dictionary<string, Dictionary<string, object>>> retVal = new Result<Dictionary<string, Dictionary<string, object>>>();

            if (!Platform.FileExists(fileName))
            {
                retVal.AddError("File '" + fileName + "' could not be found.");
            }
            else
            {
                logger.Trace("File '" + fileName + "' was found.  Attempting to read...");

                // read the entirety of the configuration file into configFile
                IResult<string> readResult = Platform.ReadFile(fileName);

                if (readResult.ResultCode != ResultCode.Failure)
                {
                    string configFile = Platform.ReadFile(fileName).ReturnValue;

                    logger.Trace("Configuration file loaded from '" + fileName + "'.  Attempting to deserialize...");

                    // attempt to deserialize the contents of the file to an object of type ApplicationConfiguration
                    retVal.ReturnValue = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, object>>>(configFile);

                    logger.Trace("Successfully deserialized the contents of '" + fileName + "' to a Configuration object.");
                }
                else
                {
                    throw new ConfigurationLoadException("Failed to read the contents of the configuration file '" + fileName + "': " + readResult.GetLastError());
                }

                retVal.Incorporate(readResult);
            }

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        /// <summary>
        ///     Saves the given configuration to the specified file.
        /// </summary>
        /// <param name="configuration">The Configuration object to serialize and write to disk.</param>
        /// <param name="fileName">The file in which to save the configuration.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public Result Save(IReadOnlyDictionary<string, Dictionary<string, object>> configuration, string fileName)
        {
            Guid guid = logger.EnterMethod(xLogger.Params(configuration, fileName), true);
            logger.Debug("Attempting to save configuration to '" + fileName + "'...");
            Result retVal = new Result();

            logger.Trace("Serializing configuration...");

            string content = JsonConvert.SerializeObject(configuration, Formatting.Indented, new Newtonsoft.Json.Converters.StringEnumConverter());

            IResult writeResult = Platform.WriteFile(fileName, content);

            retVal.Incorporate(writeResult);

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        #endregion Public Methods
    }
}