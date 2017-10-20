/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █    ▄█     ▄████████
      █   ███    ███    ███
      █   ███▌   ███    █▀     ▄█████   ▄█████   ▄█████  █   ██████  ██▄▄▄▄
      █   ███▌   ███          ██   █    ██  ▀    ██  ▀  ██  ██    ██ ██▀▀▀█▄
      █   ███▌ ▀███████████  ▄██▄▄      ██       ██     ██▌ ██    ██ ██   ██
      █   ███           ███ ▀▀██▀▀    ▀███████ ▀███████ ██  ██    ██ ██   ██
      █   ███     ▄█    ███   ██   █     ▄  ██    ▄  ██ ██  ██    ██ ██   ██
      █   █▀    ▄████████▀    ███████  ▄████▀   ▄████▀  █    ██████   █   █
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
    using System.Security.Claims;

    /// <summary>
    ///     Session information for a <see cref="User"/> Session.
    /// </summary>
    public interface ISession
    {
        #region Public Properties

        /// <summary>
        ///     Gets the time at which the Session was created, in Utc.
        /// </summary>
        DateTimeOffset Created { get; }

        /// <summary>
        ///     Gets or sets the time at which the Session expires, in Utc.
        /// </summary>
        DateTimeOffset Expires { get; set; }

        /// <summary>
        ///     Gets the <see cref="ClaimsIdentity"/> instance associated with the Session.
        /// </summary>
        ClaimsIdentity Identity { get; }

        /// <summary>
        ///     Gets a value indicating whether the Session is expired.
        /// </summary>
        bool IsExpired { get; }

        /// <summary>
        ///     Gets the token for the Session.
        /// </summary>
        string Token { get; }

        /// <summary>
        ///     Gets the User to which the Session belongs.
        /// </summary>
        IUser User { get; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        ///     Returns the specified Claim <paramref name="type"/> within the Session's <see cref="Identity"/> .
        /// </summary>
        /// <param name="type">The type of Claim to retrieve.</param>
        /// <returns>The retrieved Claim value.</returns>
        string GetClaim(string type);

        #endregion Public Methods
    }
}