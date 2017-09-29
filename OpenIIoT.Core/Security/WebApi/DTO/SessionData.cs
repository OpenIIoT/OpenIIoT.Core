/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄████████                                                  ████████▄
      █     ███    ███                                                  ███   ▀███
      █     ███    █▀     ▄█████   ▄█████   ▄█████  █   ██████  ██▄▄▄▄  ███    ███   ▄█████      ██      ▄█████
      █     ███          ██   █    ██  ▀    ██  ▀  ██  ██    ██ ██▀▀▀█▄ ███    ███   ██   ██ ▀███████▄   ██   ██
      █   ▀███████████  ▄██▄▄      ██       ██     ██▌ ██    ██ ██   ██ ███    ███   ██   ██     ██  ▀   ██   ██
      █            ███ ▀▀██▀▀    ▀███████ ▀███████ ██  ██    ██ ██   ██ ███    ███ ▀████████     ██    ▀████████
      █      ▄█    ███   ██   █     ▄  ██    ▄  ██ ██  ██    ██ ██   ██ ███   ▄███   ██   ██     ██      ██   ██
      █    ▄████████▀    ███████  ▄████▀   ▄████▀  █    ██████   █   █  ████████▀    ██   █▀    ▄██▀     ██   █▀
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Data Transfer Object used when returning Session objects.
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
using Newtonsoft.Json;
using OpenIIoT.SDK.Common;
using OpenIIoT.SDK.Security;

namespace OpenIIoT.Core.Security.WebApi.DTO
{
    /// <summary>
    ///     Data Transfer Object used when returning <see cref="Session"/> objects.
    /// </summary>
    public class SessionData
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="SessionData"/> class with the specified <see cref="Session"/>.
        /// </summary>
        /// <param name="session">The <see cref="Session"/> from which data is sourced.</param>
        public SessionData(Session session)
        {
            this.CopyPropertyValuesFrom(session);

            User = new UserData(session.User);
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        ///     Gets or sets the <see cref="Session"/><see cref="Session.Expires"/> date.
        /// </summary>
        [JsonProperty(Order = 4)]
        public DateTimeOffset? Expires { get; set; }

        /// <summary>
        ///     Gets or sets the <see cref="Session"/><see cref="Session.Issued"/> date.
        /// </summary>
        [JsonProperty(Order = 3)]
        public DateTimeOffset? Issued { get; set; }

        /// <summary>
        ///     Gets or sets the <see cref="Session"/><see cref="Session.Token"/>.
        /// </summary>
        [JsonProperty(Order = 2)]
        public string Token { get; set; }

        /// <summary>
        ///     Gets or sets the <see cref="Session"/><see cref="Session.User"/>.
        /// </summary>
        [JsonProperty(Order = 1)]
        public UserData User { get; set; }

        #endregion Public Properties
    }
}