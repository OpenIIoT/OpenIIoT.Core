/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █   ████████▄
      █   ███   ▀███
      █   ███    ███  █     █████    ▄█████  ▄██████     ██     ██████     █████  █     ▄█████   ▄█████
      █   ███    ███ ██    ██  ██   ██   █  ██    ██ ▀███████▄ ██    ██   ██  ██ ██    ██   █    ██  ▀
      █   ███    ███ ██▌  ▄██▄▄█▀  ▄██▄▄    ██    ▀      ██  ▀ ██    ██  ▄██▄▄█▀ ██▌  ▄██▄▄      ██
      █   ███    ███ ██  ▀███████ ▀▀██▀▀    ██    ▄      ██    ██    ██ ▀███████ ██  ▀▀██▀▀    ▀███████
      █   ███   ▄███ ██    ██  ██   ██   █  ██    ██     ██    ██    ██   ██  ██ ██    ██   █     ▄  ██
      █   ████████▀  █     ██  ██   ███████ ██████▀     ▄██▀    ██████    ██  ██ █     ███████  ▄████▀
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Encapsulates the filesystem directories needed to run the application.
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
using System.IO;
using System.Reflection;
using OpenIIoT.SDK;
using OpenIIoT.SDK.Common.Exceptions;
using OpenIIoT.SDK.Platform;

namespace OpenIIoT.Core.Platform
{
    /// <summary>
    ///     Encapsulates the filesystem directories needed to run the application.
    /// </summary>
    public class Directories : IDirectories
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Directories"/> class with a blank dictionary.
        /// </summary>
        /// <param name="settings">The application settings.</param>
        public Directories(PlatformSettings settings)
        {
            Settings = settings;

            try
            {
                Root = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
                Data = NormalizePath(Path.Combine(Root, Settings.DirectoryData));
                Packages = NormalizePath(Path.Combine(Root, Settings.DirectoryPackages));
                Plugins = NormalizePath(Path.Combine(Root, Settings.DirectoryPlugins));
                Temp = NormalizePath(Path.Combine(Root, Settings.DirectoryTemp));
                Persistence = NormalizePath(Path.Combine(Root, Settings.DirectoryPersistence));
                Web = NormalizePath(Path.Combine(Root, Settings.DirectoryWeb));
                Logs = NormalizePath(Path.Combine(Root, Settings.DirectoryLogs));
            }
            catch (Exception ex)
            {
                throw new DirectoryConfigurationException($"Failed to configure application Directories.  See inner Exception for details.", ex);
            }
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        ///     Gets the data directory
        /// </summary>
        public string Data { get; private set; }

        /// <summary>
        ///     Gets the log directory
        /// </summary>
        public string Logs { get; private set; }

        /// <summary>
        ///     Gets the archive directory
        /// </summary>
        public string Packages { get; private set; }

        /// <summary>
        ///     Gets the persistence directory
        /// </summary>
        public string Persistence { get; private set; }

        /// <summary>
        ///     Gets the plugin directory
        /// </summary>
        public string Plugins { get; private set; }

        /// <summary>
        ///     Gets the root directory; the directory from which the main executable is running.
        /// </summary>
        public string Root { get; private set; }

        /// <summary>
        ///     Gets the temporary directory
        /// </summary>
        public string Temp { get; private set; }

        /// <summary>
        ///     Gets the web directory
        /// </summary>
        /// <remarks>Web content is served from this directory; anything placed here will be exposed.</remarks>
        public string Web { get; private set; }

        #endregion Public Properties

        #region Private Properties

        /// <summary>
        ///     Gets or sets the application settings.
        /// </summary>
        private PlatformSettings Settings { get; set; }

        #endregion Private Properties

        #region Public Methods

        /// <summary>
        ///     Returns a dictionary containing all of the program directories keyed by name.
        /// </summary>
        /// <returns>A dictionary containing all of the program directories keyed by name.</returns>
        public IDictionary<string, string> ToDictionary()
        {
            IDictionary<string, string> dictionary = new Dictionary<string, string>();

            foreach (PropertyInfo p in GetType().GetProperties())
            {
                dictionary.Add(p.Name, (string)p.GetValue(this));
            }

            return dictionary;
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        ///     Normalizes the specified path to the current platform.
        /// </summary>
        /// <param name="path">The path to normalize.</param>
        /// <returns>The normalized path.</returns>
        private string NormalizePath(string path)
        {
            return Path.GetFullPath(new Uri(path).LocalPath)
                       .TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
        }

        #endregion Private Methods
    }
}