/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄███████▄
      █     ███    ███
      █     ███    ███   ▄█████   ▄██████    █  █▄     ▄█████     ▄████▄     ▄█████
      █     ███    ███   ██   ██ ██    ██   ██ ▄██▀    ██   ██   ██    ▀    ██   █
      █   ▀█████████▀    ██   ██ ██    ▀    ██▐█▀      ██   ██  ▄██        ▄██▄▄
      █     ███        ▀████████ ██    ▄  ▀▀████     ▀████████ ▀▀██ ███▄  ▀▀██▀▀
      █     ███          ██   ██ ██    ██   ██ ▀██▄    ██   ██   ██    ██   ██   █
      █    ▄████▀        ██   █▀ ██████▀    ▀█   ▀█▀   ██   █▀   ██████▀    ███████
      █
      █      ▄████████                                        ▄████████
      █     ███    ███                                        ███    ███
      █     ███    █▀   █    █     ▄█████ ██▄▄▄▄      ██      ███    ███    █████    ▄████▄    ▄█████
      █    ▄███▄▄▄     ██    ██   ██   █  ██▀▀▀█▄ ▀███████▄   ███    ███   ██  ██   ██    ▀    ██  ▀
      █   ▀▀███▀▀▀     ██    ██  ▄██▄▄    ██   ██     ██  ▀ ▀███████████  ▄██▄▄█▀  ▄██         ██
      █     ███    █▄  ██    ██ ▀▀██▀▀    ██   ██     ██      ███    ███ ▀███████ ▀▀██ ███▄  ▀███████
      █     ███    ███  █▄  ▄█    ██   █  ██   ██     ██      ███    ███   ██  ██   ██    ██    ▄  ██
      █     ██████████   ▀██▀     ███████  █   █     ▄██▀     ███    █▀    ██  ██   ██████▀   ▄████▀
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Event arguments for Package events.
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

namespace OpenIIoT.SDK.Packaging
{
    using System;

    /// <summary>
    ///     Event arguments for <see cref="Package"/> events.
    /// </summary>
    public class PackageEventArgs : EventArgs
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="PackageEventArgs"/> class.
        /// </summary>
        /// <param name="package">The <see cref="IPackage"/> associated with the event.</param>
        public PackageEventArgs(IPackage package)
        {
            Package = package;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        ///     Gets the <see cref="IPackage"/> associated with the event.
        /// </summary>
        public IPackage Package { get; }

        #endregion Public Properties
    }
}