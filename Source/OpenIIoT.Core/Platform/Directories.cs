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
using System.Reflection;
using NLog.xLogger;
using OpenIIoT.SDK.Common.Exceptions;
using OpenIIoT.SDK.Platform;

namespace OpenIIoT.Core.Platform
{
    /// <summary>
    ///     Encapsulates the filesystem directories needed to run the application.
    /// </summary>
    public class Directories : IDirectories
    {
        #region Private Fields

        /// <summary>
        ///     The Logger for this class.
        /// </summary>
        private static xLogger logger = xLogManager.GetCurrentClassxLogger();

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Directories"/> class with a blank dictionary.
        /// </summary>
        public Directories()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Directories"/> class with the specified dictionary.
        /// </summary>
        /// <param name="directories">A dictionary containing the name and directory for each of the program directories.</param>
        /// <exception cref="DirectoryConfigurationException">
        ///     Thrown when the directory configuration is determined to be malformed.
        /// </exception>
        public Directories(Dictionary<string, string> directories)
        {
            logger.EnterMethod(xLogger.Params(xLogger.Exclude(), directories));

            try
            {
                Root = System.IO.Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
                Data = System.IO.Path.Combine(Root, directories["Data"]);
                Packages = System.IO.Path.Combine(Root, directories["Packages"]);
                Plugins = System.IO.Path.Combine(Root, directories["Plugins"]);
                Temp = System.IO.Path.Combine(Root, directories["Temp"]);
                Persistence = System.IO.Path.Combine(Root, directories["Persistence"]);
                Web = System.IO.Path.Combine(Root, directories["Web"]);
                Logs = System.IO.Path.Combine(Root, directories["Logs"]);
            }
            catch (KeyNotFoundException ex)
            {
                logger.Exception(ex);
                throw new DirectoryConfigurationException("The directory configuration is missing one or more directories.", ex);
            }

            logger.ExitMethod();
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
    }
}