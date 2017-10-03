/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █       ███
      █   ▀█████████▄
      █      ▀███▀▀██  █   ▄██████    █  █▄      ▄█████     ██
      █       ███   ▀ ██  ██    ██   ██ ▄██▀    ██   █  ▀███████▄
      █       ███     ██▌ ██    ▀    ██▐█▀     ▄██▄▄        ██  ▀
      █       ███     ██  ██    ▄  ▀▀████     ▀▀██▀▀        ██
      █       ███     ██  ██    ██   ██ ▀██▄    ██   █      ██
      █      ▄████▀   █   ██████▀    ▀█   ▀█▀   ███████    ▄██▀
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  An authentication Ticket.
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
    using System.Security.Claims;

    /// <summary>
    ///     An authentication Ticket.
    /// </summary>
    public class Ticket
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Ticket"/> class with the specified <paramref name="identity"/>.
        /// </summary>
        /// <param name="identity">The <see cref="ClaimsIdentity"/> instance associated with the Ticket.</param>
        public Ticket(ClaimsIdentity identity)
            : this(identity, null)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Ticket"/> class with the specified <paramref name="identity"/> and <paramref name="expiresUtc"/>.
        /// </summary>
        /// <param name="identity">The <see cref="ClaimsIdentity"/> instance associated with the Ticket.</param>
        /// <param name="expiresUtc">The time at which the Ticket was issued, in UTC.</param>
        public Ticket(ClaimsIdentity identity, DateTimeOffset? expiresUtc)
        {
            Identity = identity;
            IssuedUtc = DateTime.UtcNow;
            ExpiresUtc = expiresUtc;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        ///     Gets or sets the time at which the Ticket expires.
        /// </summary>
        public DateTimeOffset? ExpiresUtc { get; set; }

        /// <summary>
        ///     Gets the <see cref="ClaimsIdentity"/> instance associated with the Ticket.
        /// </summary>
        public ClaimsIdentity Identity { get; private set; }

        /// <summary>
        ///     Gets the time at which the Ticket was issued.
        /// </summary>
        public DateTimeOffset IssuedUtc { get; private set; }

        #endregion Public Properties
    }
}