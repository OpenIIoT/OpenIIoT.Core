/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █   ███    █▄                              ████████▄
      █   ███    ███                             ███   ▀███
      █   ███    ███   ▄█████    ▄█████    █████ ███    ███   ▄█████      ██      ▄█████
      █   ███    ███   ██  ▀    ██   █    ██  ██ ███    ███   ██   ██ ▀███████▄   ██   ██
      █   ███    ███   ██      ▄██▄▄     ▄██▄▄█▀ ███    ███   ██   ██     ██  ▀   ██   ██
      █   ███    ███ ▀███████ ▀▀██▀▀    ▀███████ ███    ███ ▀████████     ██    ▀████████
      █   ███    ███    ▄  ██   ██   █    ██  ██ ███   ▄███   ██   ██     ██      ██   ██
      █   ████████▀   ▄████▀    ███████   ██  ██ ████████▀    ██   █▀    ▄██▀     ██   █▀
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Data Transfer Object used when returning User objects.
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

namespace OpenIIoT.Core.Security.WebApi.Data
{
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using OpenIIoT.SDK.Common;
    using OpenIIoT.SDK.Security;

    /// <summary>
    ///     Data Transfer Object used when returning <see cref="User"/> objects.
    /// </summary>
    [DataContract]
    public class UserData
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="UserData"/> class with the specified <see cref="User"/>.
        /// </summary>
        /// <param name="user">The <see cref="User"/> from which data is sourced.</param>
        public UserData(IUser user)
        {
            this.CopyPropertyValuesFrom(user);
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        ///     Gets or sets the <see cref="User"/><see cref="User.DisplayName"/>.
        /// </summary>
        [JsonProperty(Order = 2)]
        [DataMember(Order = 2)]
        public string DisplayName { get; set; }

        /// <summary>
        ///     Gets or sets the <see cref="User"/><see cref="User.Email"/>.
        /// </summary>
        [JsonProperty(Order = 3)]
        [DataMember(Order = 3)]
        public string Email { get; set; }

        /// <summary>
        ///     Gets or sets the <see cref="User"/><see cref="User.Name"/>.
        /// </summary>
        [JsonProperty(Order = 1)]
        [DataMember(Order = 1)]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the <see cref="User"/><see cref="User.Role"/>.
        /// </summary>
        [JsonProperty(Order = 4)]
        [DataMember(Order = 4)]
        public Role Role { get; set; }

        #endregion Public Properties
    }
}