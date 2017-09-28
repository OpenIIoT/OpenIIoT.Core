/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄████████                                                     ▄████████                                        ████████▄
      █     ███    ███                                                    ███    ███                                        ███   ▀███
      █     ███    █▀     ▄█████   ▄█████   ▄█████  █   ██████  ██▄▄▄▄    ███    █▀      ██      ▄█████     █████     ██    ███    ███   ▄█████      ██      ▄█████
      █     ███          ██   █    ██  ▀    ██  ▀  ██  ██    ██ ██▀▀▀█▄   ███        ▀███████▄   ██   ██   ██  ██ ▀███████▄ ███    ███   ██   ██ ▀███████▄   ██   ██
      █   ▀███████████  ▄██▄▄      ██       ██     ██▌ ██    ██ ██   ██ ▀███████████     ██  ▀   ██   ██  ▄██▄▄█▀     ██  ▀ ███    ███   ██   ██     ██  ▀   ██   ██
      █            ███ ▀▀██▀▀    ▀███████ ▀███████ ██  ██    ██ ██   ██          ███     ██    ▀████████ ▀███████     ██    ███    ███ ▀████████     ██    ▀████████
      █      ▄█    ███   ██   █     ▄  ██    ▄  ██ ██  ██    ██ ██   ██    ▄█    ███     ██      ██   ██   ██  ██     ██    ███   ▄███   ██   ██     ██      ██   ██
      █    ▄████████▀    ███████  ▄████▀   ▄████▀  █    ██████   █   █   ▄████████▀     ▄██▀     ██   █▀   ██  ██    ▄██▀   ████████▀    ██   █▀    ▄██▀     ██   █▀
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Data Transfer Object used when starting a Session.
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

using Newtonsoft.Json;
using OpenIIoT.SDK.Security;

namespace OpenIIoT.Core.Security.WebApi.DTO
{
    /// <summary>
    ///     Data Transfer Object used when starting a <see cref="Session"/>.
    /// </summary>
    public class SessionStartData
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="SessionStartData"/> class.
        /// </summary>
        /// <param name="name">The <see cref="User"/><see cref="User.Name"/> with which to start the <see cref="Session"/>.</param>
        /// <param name="password">The <see cref="User"/> password with which to start the <see cref="Session"/>.</param>
        public SessionStartData(string name, string password)
        {
            Name = name;
            Password = password;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        ///     Gets the <see cref="User"/><see cref="User.Name"/> with which to start the <see cref="Session"/>.
        /// </summary>
        [JsonProperty(Order = 1)]
        public string Name { get; }

        /// <summary>
        ///     Gets the <see cref="User"/> password with which to start the <see cref="Session"/>.
        /// </summary>
        [JsonProperty(Order = 2)]
        public string Password { get; }

        #endregion Public Properties
    }
}