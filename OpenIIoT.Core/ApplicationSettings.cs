/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █     ▄████████                                                                                        ▄████████
      █     ███    ███                                                                                      ███    ███
      █     ███    ███    █████▄    █████▄  █        █   ▄██████   ▄█████      ██     █   ██████  ██▄▄▄▄    ███    █▀     ▄█████     ██        ██     █  ██▄▄▄▄     ▄████▄    ▄█████
      █     ███    ███   ██   ██   ██   ██ ██       ██  ██    ██   ██   ██ ▀███████▄ ██  ██    ██ ██▀▀▀█▄   ███          ██   █  ▀███████▄ ▀███████▄ ██  ██▀▀▀█▄   ██    ▀    ██  ▀
      █   ▀███████████   ██   ██   ██   ██ ██       ██▌ ██    ▀    ██   ██     ██  ▀ ██▌ ██    ██ ██   ██ ▀███████████  ▄██▄▄        ██  ▀     ██  ▀ ██▌ ██   ██  ▄██         ██
      █     ███    ███ ▀██████▀  ▀██████▀  ██       ██  ██    ▄  ▀████████     ██    ██  ██    ██ ██   ██          ███ ▀▀██▀▀        ██        ██    ██  ██   ██ ▀▀██ ███▄  ▀███████
      █     ███    ███   ██        ██      ██▌    ▄ ██  ██    ██   ██   ██     ██    ██  ██    ██ ██   ██    ▄█    ███   ██   █      ██        ██    ██  ██   ██   ██    ██    ▄  ██
      █     ███    █▀   ▄███▀     ▄███▀    ████▄▄██ █   ██████▀    ██   █▀    ▄██▀   █    ██████   █   █   ▄████████▀    ███████    ▄██▀      ▄██▀   █    █   █    ██████▀   ▄████▀
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Application settings, sourced from App.config.
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
using System.ComponentModel;
using OpenIIoT.SDK;

namespace OpenIIoT.Core
{
    /// <summary>
    ///     Application settings, sourced from App.config.
    /// </summary>
    public class ApplicationSettings : IApplicationSettings
    {
        #region Public Properties

        /// <summary>
        ///     Gets the value of the "Application.InstanceName' key from the application's XML configuration file.
        /// </summary>
        public string ApplicationInstanceName => GetSetting<string>("Application.InstanceName", "OpenIIoT");

        /// <summary>
        ///     Gets the value of the 'Configuration.Filename' key from the application's XML configuration file.
        /// </summary>
        public string ConfigurationFileName => GetSetting<string>("Configuration.FileName", "OpenIIoT.json").Replace('|', System.IO.Path.DirectorySeparatorChar);

        /// <summary>
        ///     Gets the value of the 'Directory.Data' key from the application's XML configuration file.
        /// </summary>
        public string DirectoryData => GetSetting<string>("Directory.Data", "Data");

        /// <summary>
        ///     Gets the value of the 'Directory.Log' key from the application's XML configuration file.
        /// </summary>
        public string DirectoryLog => GetSetting<string>("Directory.Log", @"Data\Log");

        /// <summary>
        ///     Gets the value of the 'Directory.Packages' key from the application's XML configuration file.
        /// </summary>
        public string DirectoryPackages => GetSetting<string>("Directory.Packages", @"Data\Packages");

        /// <summary>
        ///     Gets the value of the 'Directory.Persistence' key from the application's XML configuration file.
        /// </summary>
        public string DirectoryPersistence => GetSetting<string>("Directory.Persistence", @"Data\Persistence");

        /// <summary>
        ///     Gets the value of the 'Directory.Plugins' key from the application's XML configuration file.
        /// </summary>
        public string DirectoryPlugins => GetSetting<string>("Directory.Plugins", "Plugins");

        /// <summary>
        ///     Gets the value of the 'Directory.Temp' key from the application's XML configuration file.
        /// </summary>
        public string DirectoryTemp => GetSetting<string>("Directory.Temp", @"Data\Temp");

        /// <summary>
        ///     Gets the value of the 'Directory.Web' key from the application's XML configuration file.
        /// </summary>
        public string DirectoryWeb => GetSetting<string>("Directory.Web", "Web");

        /// <summary>
        ///     Gets the value of the 'Security.DefaultUser' key from the application's XML configuration file.
        /// </summary>
        public string SecurityDefaultUser => GetSetting<string>("Security.DefaultUser", "admin");

        /// <summary>
        ///     Gets the value of the 'Security.DefaultUserPasswordHash' key from the application's XML configuration file.
        /// </summary>
        public string SecurityDefaultUserPasswordHash => GetSetting<string>("Security.DefaultUserPasswordHash", "C7AD44CBAD762A5DA0A452F9E854FDC1E0E7A52A38015F23F3EAB1D80B931DD472634DFAC71CD34EBC35D16AB7FB8A90C81F975113D6C7538DC69DD8DE9077EC");

        /// <summary>
        ///     Gets the value of the 'Security.SessionLength' key from the application's XML configuration file.
        /// </summary>
        public int SecuritySessionLength => GetSetting<int>("security.SessionLength", "15");

        /// <summary>
        ///     Gets the value of the 'Security.SessionPurgeInterval' key from the application's XML configuration file.
        /// </summary>
        public int SecuritySessionPurgeInterval => GetSetting<int>("Security.SessionPurgeInterval", "900000");

        /// <summary>
        ///     Gets a value indicating whether the 'Security.SlidingSessions' value is true in the application's XML configuration file.
        /// </summary>
        public bool SecuritySlidingSessions => GetSetting<bool>("Security.SlidingSessions", "true");

        #endregion Public Properties

        #region Private Methods

        /// <summary>
        ///     Retrieves the setting corresponding to the specified setting from the app.exe.config file and converts it to the
        ///     specified Type. If the setting isn't found, returns the provided defaultSetting and logs a warning.
        /// </summary>
        /// <typeparam name="T">The Type to which the retrieved value should be converted.</typeparam>
        /// <param name="key">The setting to retrieve.</param>
        /// <param name="defaultSetting">The default setting to return if the setting can't be retrieved.</param>
        /// <returns>The string value of the retrieved setting.</returns>
        private static T GetSetting<T>(string key, string defaultSetting)
        {
            string retVal;

            try
            {
                retVal = System.Configuration.ConfigurationManager.AppSettings[key];

                if (retVal == default(string))
                {
                    NLog.LogManager.GetCurrentClassLogger().Warn("Failed to retrieve the setting '" + key + "'.  Defaulting to '" + defaultSetting + "'.");
                    retVal = defaultSetting;
                }

                var converter = TypeDescriptor.GetConverter(typeof(T));
                return (T)converter.ConvertFromString(retVal);
            }
            catch (Exception ex)
            {
                throw new Common.Exceptions.XMLConfigurationException("Failed to retrieve XML configuration setting '{key}'.  See inner Exception for details.", ex);
            }
        }

        #endregion Private Methods
    }
}