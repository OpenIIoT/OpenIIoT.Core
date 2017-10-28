/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄███████▄                                                                         ▄████████
      █     ███    ███                                                                        ███    ███
      █     ███    ███  █         ▄█████      ██       ▄█████  ██████     █████    ▄▄██▄▄▄    ███    █▀     ▄█████     ██        ██     █  ██▄▄▄▄     ▄████▄    ▄█████
      █     ███    ███ ██         ██   ██ ▀███████▄   ██   ▀█ ██    ██   ██  ██  ▄█▀▀██▀▀█▄   ███          ██   █  ▀███████▄ ▀███████▄ ██  ██▀▀▀█▄   ██    ▀    ██  ▀
      █   ▀█████████▀  ██         ██   ██     ██  ▀  ▄██▄▄    ██    ██  ▄██▄▄█▀  ██  ██  ██ ▀███████████  ▄██▄▄        ██  ▀     ██  ▀ ██▌ ██   ██  ▄██         ██
      █     ███        ██       ▀████████     ██    ▀▀██▀▀    ██    ██ ▀███████  ██  ██  ██          ███ ▀▀██▀▀        ██        ██    ██  ██   ██ ▀▀██ ███▄  ▀███████
      █     ███        ██▌    ▄   ██   ██     ██      ██      ██    ██   ██  ██  ██  ██  ██    ▄█    ███   ██   █      ██        ██    ██  ██   ██   ██    ██    ▄  ██
      █    ▄████▀      ████▄▄██   ██   █▀    ▄██▀     ██       ██████    ██  ██   █  ██  █   ▄████████▀    ███████    ▄██▀      ▄██▀   █    █   █    ██████▀   ▄████▀
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Application settings for the Platform namespace, sourced from App.config.
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

namespace OpenIIoT.Core.Platform
{
    using OpenIIoT.Core.Common;

    /// <summary>
    ///     Application settings for the <see cref="Core.Platform"/> namespace, sourced from App.config.
    /// </summary>
    public class PlatformSettings : Settings
    {
        #region Public Properties

        /// <summary>
        ///     Gets the value of the 'Directory.Data' key from the application's XML configuration file.
        /// </summary>
        public virtual string DirectoryData => GetSetting<string>("Directory.Data", "Data");

        /// <summary>
        ///     Gets the value of the 'Directory.Log' key from the application's XML configuration file.
        /// </summary>
        public virtual string DirectoryLogs => GetSetting<string>("Directory.Logs", @"Data\Logs");

        /// <summary>
        ///     Gets the value of the 'Directory.PackageArchives' key from the application's XML configuration file.
        /// </summary>
        public virtual string DirectoryPackageArchives => GetSetting<string>("Directory.PackageArchives", @"Data\Packages\Archives");

        /// <summary>
        ///     Gets the value of the 'Directory.Packages' key from the application's XML configuration file.
        /// </summary>
        public virtual string DirectoryPackages => GetSetting<string>("Directory.Packages", @"Data\Packages");

        /// <summary>
        ///     Gets the value of the 'Directory.Persistence' key from the application's XML configuration file.
        /// </summary>
        public virtual string DirectoryPersistence => GetSetting<string>("Directory.Persistence", @"Data\Persistence");

        /// <summary>
        ///     Gets the value of the 'Directory.Plugins' key from the application's XML configuration file.
        /// </summary>
        public virtual string DirectoryPlugins => GetSetting<string>("Directory.Plugins", "Plugins");

        /// <summary>
        ///     Gets the value of the 'Directory.Temp' key from the application's XML configuration file.
        /// </summary>
        public virtual string DirectoryTemp => GetSetting<string>("Directory.Temp", @"Data\Temp");

        /// <summary>
        ///     Gets the value of the 'Directory.Web' key from the application's XML configuration file.
        /// </summary>
        public virtual string DirectoryWeb => GetSetting<string>("Directory.Web", "Web");

        #endregion Public Properties
    }
}