/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄████████                                                     ▄████████
      █     ███    ███                                                    ███    ███
      █     ███    █▀     ▄█████   ▄█████   ▄█████  █   ██████  ██▄▄▄▄    ███    █▀    ▄█████   ▄██████     ██     ██████     █████ ▄█   ▄
      █     ███          ██   █    ██  ▀    ██  ▀  ██  ██    ██ ██▀▀▀█▄  ▄███▄▄▄       ██   ██ ██    ██ ▀███████▄ ██    ██   ██  ██ ██   █▄
      █   ▀███████████  ▄██▄▄      ██       ██     ██▌ ██    ██ ██   ██ ▀▀███▀▀▀       ██   ██ ██    ▀      ██  ▀ ██    ██  ▄██▄▄█▀ ▀▀▀▀▀██
      █            ███ ▀▀██▀▀    ▀███████ ▀███████ ██  ██    ██ ██   ██   ███        ▀████████ ██    ▄      ██    ██    ██ ▀███████ ▄█   ██
      █      ▄█    ███   ██   █     ▄  ██    ▄  ██ ██  ██    ██ ██   ██   ███          ██   ██ ██    ██     ██    ██    ██   ██  ██ ██   ██
      █    ▄████████▀    ███████  ▄████▀   ▄████▀  █    ██████   █   █    ███          ██   █▀ ██████▀     ▄██▀    ██████    ██  ██  █████
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Creates and extends Sessions.
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
using System.Security.Claims;
using Microsoft.Owin.Security;
using OpenIIoT.SDK;

namespace OpenIIoT.Core.Security
{
    /// <summary>
    ///     Creates and extends <see cref="Session"/> s.
    /// </summary>
    public class SessionFactory
    {
        #region Public Constructors

        public SessionFactory(IApplicationSettings settings)
        {
            Settings = settings;
        }

        #endregion Public Constructors

        #region Private Properties

        private IApplicationSettings Settings { get; set; }

        #endregion Private Properties

        #region Public Methods

        /// <summary>
        ///     Creates a new <see cref="Session"/> from the specified <see cref="User"/>.
        /// </summary>
        /// <param name="user">The User for which the Session is to be created.</param>
        /// <returns>The created Session.</returns>
        public Session CreateSession(User user)
        {
            ClaimsIdentity identity = new ClaimsIdentity("ApiKey");
            identity.AddClaim(new Claim(ClaimTypes.Name, user.Name));

            for (int r = (int)user.Role; r >= 0; r--)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, ((Role)r).ToString()));
            }

            string hash = SDK.Common.Utility.ComputeSHA512Hash(Guid.NewGuid().ToString());

            identity.AddClaim(new Claim(ClaimTypes.Hash, hash));

            AuthenticationProperties ticketProperties = new AuthenticationProperties();
            ticketProperties.IssuedUtc = DateTime.UtcNow;
            ticketProperties.ExpiresUtc = DateTime.UtcNow.AddMinutes(Settings.SecuritySessionLength);

            AuthenticationTicket ticket = new AuthenticationTicket(identity, ticketProperties);

            return new Session(hash, ticket);
        }

        /// <summary>
        ///     Extends the expiration time of the specified <see cref="Session"/> to the configured session length.
        /// </summary>
        /// <param name="session">The Session to extend.</param>
        /// <returns>The extended Session.</returns>
        public Session ExtendSession(Session session)
        {
            session.Ticket.Properties.ExpiresUtc = DateTime.UtcNow.AddMinutes(Settings.SecuritySessionLength);
            return session;
        }

        #endregion Public Methods
    }
}