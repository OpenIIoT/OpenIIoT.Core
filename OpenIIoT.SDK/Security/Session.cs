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

using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.Owin.Security;
using Newtonsoft.Json;

namespace OpenIIoT.SDK.Security
{
    /// <summary>
    ///     Session information for a <see cref="User"/> Session.
    /// </summary>
    public class Session
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Session"/> class.
        /// </summary>
        /// <param name="ticket">The AuthenticationTicket for the Session.</param>
        public Session(AuthenticationTicket ticket)
        {
            Ticket = ticket;
        }

        #endregion Public Constructors

        #region Private Properties

        /// <summary>
        ///     Gets the expiration timestamp of the Ticket, in UTC.
        /// </summary>
        [JsonProperty(Order = 4)]
        public DateTimeOffset? Expires => Ticket?.Properties.ExpiresUtc;

        /// <summary>
        ///     Gets a value indicating whether the Session is expired.
        /// </summary>
        [JsonProperty(Order = 5)]
        public bool IsExpired => (Ticket?.Properties.ExpiresUtc ?? default(DateTimeOffset)) < DateTime.UtcNow;

        /// <summary>
        ///     Gets the issued timestamp of the Ticket, in UTC.
        /// </summary>
        [JsonProperty(Order = 3)]
        public DateTimeOffset? Issued => Ticket?.Properties.IssuedUtc;

        /// <summary>
        ///     Gets the Name claim from the <see cref="Ticket"/>.
        /// </summary>
        [JsonProperty(Order = 0)]
        public string Name => GetClaim(Ticket, ClaimTypes.Name) ?? string.Empty;

        /// <summary>
        ///     Gets the Role claim from the <see cref="Ticket"/>.
        /// </summary>
        [JsonProperty(Order = 1)]
        public Role Role => (Role)Enum.Parse(typeof(Role), GetClaim(Ticket, ClaimTypes.Role) ?? default(Role).ToString());

        /// <summary>
        ///     Gets the AuthenticationTicket for the Session.
        /// </summary>
        [JsonProperty(Order = 6)]
        public AuthenticationTicket Ticket { get; }

        /// <summary>
        ///     Gets the token for the Session.
        /// </summary>
        [JsonProperty(Order = 2)]
        public string Token => GetClaim(Ticket, ClaimTypes.Hash) ?? string.Empty;

        #endregion Private Properties

        #region Private Methods

        /// <summary>
        ///     Returns the specified Claim <paramref name="type"/> within the specified <paramref name="ticket"/>.
        /// </summary>
        /// <param name="ticket">The Ticket from which the Claim is to be retrieved.</param>
        /// <param name="type">The type of Claim to retrieve.</param>
        /// <returns>The retrieved Claim value.</returns>
        private string GetClaim(AuthenticationTicket ticket, string type)
        {
            return ticket?.Identity?.Claims?.Where(c => c.Type == type).FirstOrDefault()?.Value;
        }

        #endregion Private Methods
    }
}