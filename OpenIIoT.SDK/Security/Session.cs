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

namespace OpenIIoT.SDK.Security
{
    using System;
    using System.Linq;
    using System.Security.Claims;
    using Newtonsoft.Json;

    /// <summary>
    ///     Session information for a <see cref="User"/> Session.
    /// </summary>
    public class Session
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Session"/> class.
        /// </summary>
        /// <param name="user">The User to which the Session belongs.</param>
        /// <param name="ticket">The AuthenticationTicket for the Session.</param>
        public Session(User user, Ticket ticket)
        {
            User = user;
            Ticket = ticket;
        }

        #endregion Public Constructors

        #region Private Properties

        /// <summary>
        ///     Gets the expiration timestamp of the Ticket, in UTC.
        /// </summary>
        [JsonProperty(Order = 4)]
        public DateTimeOffset? Expires => Ticket?.ExpiresUtc;

        /// <summary>
        ///     Gets a value indicating whether the Session is expired.
        /// </summary>
        [JsonProperty(Order = 5)]
        public bool IsExpired => (Ticket?.ExpiresUtc ?? default(DateTimeOffset)) < DateTime.UtcNow;

        /// <summary>
        ///     Gets the issued timestamp of the Ticket, in UTC.
        /// </summary>
        [JsonProperty(Order = 3)]
        public DateTimeOffset? Issued => Ticket?.IssuedUtc;

        /// <summary>
        ///     Gets the AuthenticationTicket for the Session.
        /// </summary>
        [JsonProperty(Order = 6)]
        public Ticket Ticket { get; }

        /// <summary>
        ///     Gets the token for the Session.
        /// </summary>
        [JsonProperty(Order = 2)]
        public string Token => GetClaim(ClaimTypes.Hash) ?? string.Empty;

        /// <summary>
        ///     Gets the User to which the Session belongs.
        /// </summary>
        [JsonProperty(Order = 1)]
        public User User { get; }

        #endregion Private Properties

        #region Private Methods

        /// <summary>
        ///     Returns the specified Claim <paramref name="type"/> within the Session's <see cref="Ticket"/> .
        /// </summary>
        /// <param name="type">The type of Claim to retrieve.</param>
        /// <returns>The retrieved Claim value.</returns>
        public string GetClaim(string type)
        {
            return Ticket?.Identity?.Claims?.Where(c => c.Type == type).FirstOrDefault()?.Value;
        }

        #endregion Private Methods
    }
}