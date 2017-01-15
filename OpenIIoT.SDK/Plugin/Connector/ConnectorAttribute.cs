/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █   ▄████████                                                                            ▄████████
      █   ███    ███                                                                           ███    ███
      █   ███    █▀   ██████  ██▄▄▄▄  ██▄▄▄▄     ▄█████  ▄██████     ██     ██████     █████   ███    ███     ██        ██       █████  █  ▀██████▄  ██   █      ██       ▄█████
      █   ███        ██    ██ ██▀▀▀█▄ ██▀▀▀█▄   ██   █  ██    ██ ▀███████▄ ██    ██   ██  ██   ███    ███ ▀███████▄ ▀███████▄   ██  ██ ██    ██   ██ ██   ██ ▀███████▄   ██   █
      █   ███        ██    ██ ██   ██ ██   ██  ▄██▄▄    ██    ▀      ██  ▀ ██    ██  ▄██▄▄█▀ ▀███████████     ██  ▀     ██  ▀  ▄██▄▄█▀ ██▌  ▄██▄▄█▀  ██   ██     ██  ▀  ▄██▄▄
      █   ███    █▄  ██    ██ ██   ██ ██   ██ ▀▀██▀▀    ██    ▄      ██    ██    ██ ▀███████   ███    ███     ██        ██    ▀███████ ██  ▀▀██▀▀█▄  ██   ██     ██    ▀▀██▀▀
      █   ███    ███ ██    ██ ██   ██ ██   ██   ██   █  ██    ██     ██    ██    ██   ██  ██   ███    ███     ██        ██      ██  ██ ██    ██   ██ ██   ██     ██      ██   █
      █   ████████▀   ██████   █   █   █   █    ███████ ██████▀     ▄██▀    ██████    ██  ██   ███    █▀     ▄██▀      ▄██▀     ██  ██ █   ▄██████▀  ██████     ▄██▀     ███████
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Creates the Connector Attribute used to identify classes implementing the IConnector interface.
      █
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀ ▀ ▀▀▀     ▀▀               ▀
      █  The GNU Affero General Public License (GNU AGPL)
      █
      █  Copyright (C) 2016 JP Dillingham (jp@dillingham.ws)
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
using System.Diagnostics.CodeAnalysis;

namespace OpenIIoT.SDK.Plugin.Connector
{
    /// <summary>
    ///     Creates the Connector <see cref="Attribute"/> used to identify classes implementing the <see cref="IConnector"/> interface.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [AttributeUsage(AttributeTargets.Class)]
    public class ConnectorAttribute : Attribute
    {
        /// <summary>
        ///     Gets or sets the Connector's ConnectorType.
        /// </summary>
        public ConnectorType Type { get; set; }
    }
}