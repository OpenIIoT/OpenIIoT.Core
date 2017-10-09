/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄████████
      █     ███    ███
      █     ███    █▀     ▄█████   ▄█████   ▄█████  █   ██████  ██▄▄▄▄
      █     ███          ██   █    ██  ▀    ██  ▀  ██  ██    ██ ██▀▀▀█▄
      █   ▀███████████  ▄██▄▄      ██       ██     ██▌ ██    ██ ██   ██
      █            ███ ▀▀██▀▀    ▀███████ ▀███████ ██  ██    ██ ██   ██
      █      ▄█    ███   ██   █     ▄  ██    ▄  ██ ██  ██    ██ ██   ██
      █    ▄████████▀    ███████  ▄████▀   ▄████▀  █    ██████   █   █
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Session information for a User Session.
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

namespace OpenIIoT.Core.Security
{
    using System;
    using System.Linq;
    using System.Security.Claims;
    using Newtonsoft.Json;
    using SDK.Security;

    /// <summary>
    ///     Session information for a <see cref="User"/> Session.
    /// </summary>
    public class Session : ISession
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Session"/> class with the specified <paramref name="user"/> and
        ///     <paramref name="identity"/>, an issue time of now, and default duration <see cref="SecurityConstants.DefaultSessionLength"/>.
        /// </summary>
        /// <param name="user">The <see cref="User"/> instance asssociated with the Session.</param>
        /// <param name="identity">The <see cref="ClaimsIdentity"/> instance associated with the Session.</param>
        public Session(IUser user, ClaimsIdentity identity)
            : this(user, identity, DateTime.UtcNow, SecurityConstants.DefaultSessionLength)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Session"/> class with the specified <paramref name="user"/> and
        ///     <paramref name="identity"/>, an issue time of now, and with the specified <paramref name="duration"/>.
        /// </summary>
        /// <param name="user">The <see cref="User"/> instance asssociated with the Session.</param>
        /// <param name="identity">The <see cref="ClaimsIdentity"/> instance associated with the Session.</param>
        /// <param name="duration">The duration of the Session, in seconds.</param>
        public Session(IUser user, ClaimsIdentity identity, int duration)
            : this(user, identity, DateTime.UtcNow, duration)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Session"/> class with the specified <paramref name="user"/> and
        ///     <paramref name="identity"/>, a creation time <paramref name="created"/>, and default duration <see cref="SecurityConstants.DefaultSessionLength"/>.
        /// </summary>
        /// <param name="user">The <see cref="User"/> instance asssociated with the Session.</param>
        /// <param name="identity">The <see cref="ClaimsIdentity"/> instance associated with the Session.</param>
        /// <param name="created">The time at which the Session was created, in Utc.</param>
        public Session(IUser user, ClaimsIdentity identity, DateTimeOffset created)
            : this(user, identity, created, SecurityConstants.DefaultSessionLength)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Session"/> class with the specified <paramref name="user"/> and
        ///     <paramref name="identity"/>, a creation time <paramref name="created"/>, and with the specified <paramref name="duration"/>.
        /// </summary>
        /// <param name="user">The <see cref="User"/> instance asssociated with the Session.</param>
        /// <param name="identity">The <see cref="ClaimsIdentity"/> instance associated with the Session.</param>
        /// <param name="created">The time at which the Session was created, in Utc.</param>
        /// <param name="duration">The duration of the Session, in seconds.</param>
        public Session(IUser user, ClaimsIdentity identity, DateTimeOffset created, int duration)
        {
            User = user;
            Identity = identity;
            Created = created;
            Expires = Created.AddSeconds(duration);
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        ///     Gets the time at which the Session was created, in Utc.
        /// </summary>
        [JsonProperty(Order = 3)]
        public DateTimeOffset Created { get; private set; }

        /// <summary>
        ///     Gets or sets the time at which the Session expires, in Utc.
        /// </summary>
        [JsonProperty(Order = 6)]
        public DateTimeOffset Expires { get; set; }

        /// <summary>
        ///     Gets the <see cref="ClaimsIdentity"/> instance associated with the Session.
        /// </summary>
        [JsonIgnore]
        public ClaimsIdentity Identity { get; private set; }

        /// <summary>
        ///     Gets a value indicating whether the Session is expired.
        /// </summary>
        [JsonProperty(Order = 5)]
        public bool IsExpired => Expires < DateTime.UtcNow;

        /// <summary>
        ///     Gets the token for the Session.
        /// </summary>
        [JsonProperty(Order = 2)]
        public string Token => GetClaim(ClaimTypes.Hash) ?? string.Empty;

        /// <summary>
        ///     Gets the User to which the Session belongs.
        /// </summary>
        [JsonProperty(Order = 1)]
        public IUser User { get; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        ///     Returns the specified Claim <paramref name="type"/> within the Session's <see cref="Ticket"/> .
        /// </summary>
        /// <param name="type">The type of Claim to retrieve.</param>
        /// <returns>The retrieved Claim value.</returns>
        public string GetClaim(string type)
        {
            return Identity?.Claims?.Where(c => c.Type == type).FirstOrDefault()?.Value;
        }

        #endregion Public Methods
    }
}