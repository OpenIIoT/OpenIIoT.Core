/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄████████
      █     ███    ███
      █     ███    █▀     ▄█████     ██        ██     █  ██▄▄▄▄     ▄████▄    ▄█████
      █     ███          ██   █  ▀███████▄ ▀███████▄ ██  ██▀▀▀█▄   ██    ▀    ██  ▀
      █   ▀███████████  ▄██▄▄        ██  ▀     ██  ▀ ██▌ ██   ██  ▄██         ██
      █            ███ ▀▀██▀▀        ██        ██    ██  ██   ██ ▀▀██ ███▄  ▀███████
      █      ▄█    ███   ██   █      ██        ██    ██  ██   ██   ██    ██    ▄  ██
      █    ▄████████▀    ███████    ▄██▀      ▄██▀   █    █   █    ██████▀   ▄████▀
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using OpenIIoT.Core.Common.Exceptions;

namespace OpenIIoT.Core.Common
{
    /// <summary>
    ///     Application settings, sourced from App.config.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Classes derived from this class should contain settings that:
    ///         <list type="bullet">
    ///             <item>Are low level (pertaining to the application at the OS/framework level)</item>
    ///             <item>Would generally require an application restart if changed</item>
    ///             <item>Contain values that need to be retrieved prior to the startup of the ConfigurationManager.</item>
    ///         </list>
    ///     </para>
    ///     <para>All other settings should be stored in the Configuration for their respective Managers.</para>
    /// </remarks>
    public abstract class Settings
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Settings"/> class.
        /// </summary>
        public Settings()
        {
            Initialize();
        }

        #endregion Public Constructors

        #region Protected Properties

        /// <summary>
        ///     Gets or sets a dictionary containing previously retrieved settings stored in the application's XML configuration file.
        /// </summary>
        protected IDictionary<string, object> SettingsCache { get; set; }

        #endregion Protected Properties

        #region Public Methods

        /// <summary>
        ///     Clears the settings cache and re-initializes the values from the application's XML configuration file.
        /// </summary>
        /// <returns>This <see cref="Settings"/> instance.</returns>
        public Settings ResetCache()
        {
            SettingsCache.Clear();
            Initialize();

            return this;
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        ///     Retrieves the setting corresponding to the specified setting from the app.exe.config file and converts it to the
        ///     specified Type. If the setting isn't found, returns the provided defaultSetting.
        /// </summary>
        /// <remarks>
        ///     Excluded from code coverage because it isn't possible to directly test ConfigurationManager under XUnit.
        /// </remarks>
        /// <typeparam name="T">The Type to which the retrieved value should be converted.</typeparam>
        /// <param name="key">The setting to retrieve.</param>
        /// <param name="defaultSetting">The default setting to return if the setting can't be retrieved.</param>
        /// <returns>The string value of the retrieved setting.</returns>
        /// <exception cref="XMLConfigurationException">
        ///     Thrown when an Exception is encountered reading or converting the value of the specified setting.
        /// </exception>
        [ExcludeFromCodeCoverage]
        protected T GetSetting<T>(string key, T defaultSetting)
        {
            T retVal = default(T);

            if (SettingsCache.ContainsKey(key))
            {
                retVal = (T)SettingsCache[key];
            }
            else
            {
                string setting = default(string);

                if (System.Configuration.ConfigurationManager.AppSettings.AllKeys.Contains(key))
                {
                    try
                    {
                        setting = System.Configuration.ConfigurationManager.AppSettings[key];
                    }
                    catch (Exception ex)
                    {
                        throw new XMLConfigurationException($"Failed to retrieve XML configuration setting '{key}'.  See inner Exception for details.", ex);
                    }
                }

                if (setting == default(string))
                {
                    retVal = defaultSetting;
                }
                else
                {
                    try
                    {
                        TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
                        retVal = (T)converter.ConvertFromString(setting);
                    }
                    catch (Exception ex)
                    {
                        throw new XMLConfigurationException($"Failed to convert value supplied for '{key}' to Type {typeof(T).Name}.  See inner Exception for details.", ex);
                    }
                }

                SettingsCache.Add(key, retVal);
            }

            return retVal;
        }

        /// <summary>
        ///     Initializes the settings cache and tests each setting by attempting to retrieve initial values.
        /// </summary>
        /// <remarks>
        ///     Excluded from code coverage because it isn't possible to directly test ConfigurationManager under XUnit.
        /// </remarks>
        /// <exception cref="XMLConfigurationException">Thrown when an Exception is encountered during initialization.</exception>
        [ExcludeFromCodeCoverage]
        protected void Initialize()
        {
            SettingsCache = new Dictionary<string, object>();

            try
            {
                foreach (PropertyInfo property in GetType().GetProperties())
                {
                    object value = property.GetValue(this);
                }
            }
            catch (Exception ex)
            {
                throw new XMLConfigurationException($"Failed to initialize XML configuration.  See inner Exception for details.", ex);
            }
        }

        #endregion Protected Methods
    }
}