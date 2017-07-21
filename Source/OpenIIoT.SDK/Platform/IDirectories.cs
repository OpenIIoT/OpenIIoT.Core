/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █    ▄█  ████████▄
      █   ███  ███   ▀███
      █   ███▌ ███    ███  █     █████    ▄█████  ▄██████     ██     ██████     █████  █     ▄█████   ▄█████
      █   ███▌ ███    ███ ██    ██  ██   ██   █  ██    ██ ▀███████▄ ██    ██   ██  ██ ██    ██   █    ██  ▀
      █   ███▌ ███    ███ ██▌  ▄██▄▄█▀  ▄██▄▄    ██    ▀      ██  ▀ ██    ██  ▄██▄▄█▀ ██▌  ▄██▄▄      ██
      █   ███  ███    ███ ██  ▀███████ ▀▀██▀▀    ██    ▄      ██    ██    ██ ▀███████ ██  ▀▀██▀▀    ▀███████
      █   ███  ███   ▄███ ██    ██  ██   ██   █  ██    ██     ██    ██    ██   ██  ██ ██    ██   █     ▄  ██
      █   █▀   ████████▀  █     ██  ██   ███████ ██████▀     ▄██▀    ██████    ██  ██ █     ███████  ▄████▀
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

using System.Collections.Generic;

namespace OpenIIoT.SDK.Platform
{
    /// <summary>
    ///     Encapsulates the filesystem directories needed to run the application.
    /// </summary>
    public interface IDirectories
    {
        #region Public Properties

        /// <summary>
        ///     Gets the Data directory
        /// </summary>
        string Data { get; }

        /// <summary>
        ///     Gets the Log directory
        /// </summary>
        string Logs { get; }

        /// <summary>
        ///     Gets the Package directory
        /// </summary>
        string Packages { get; }

        /// <summary>
        ///     Gets the Persistence directory
        /// </summary>
        string Persistence { get; }

        /// <summary>
        ///     Gets the Plugin directory
        /// </summary>
        string Plugins { get; }

        /// <summary>
        ///     Gets the Root directory; the directory from which the main executable is running.
        /// </summary>
        string Root { get; }

        /// <summary>
        ///     Gets the Temporary directory
        /// </summary>
        string Temp { get; }

        /// <summary>
        ///     Gets the Web directory
        /// </summary>
        /// <remarks>Web content is served from this directory; anything placed here will be exposed.</remarks>
        string Web { get; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        ///     Returns a dictionary containing all of the program directories keyed by name.
        /// </summary>
        /// <returns>A dictionary containing all of the program directories keyed by name.</returns>
        IDictionary<string, string> ToDictionary();

        #endregion Public Methods
    }
}