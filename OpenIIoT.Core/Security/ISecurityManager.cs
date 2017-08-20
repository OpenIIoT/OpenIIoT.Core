/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █    ▄█     ▄████████                                                              ▄▄▄▄███▄▄▄▄
      █   ███    ███    ███                                                            ▄██▀▀▀███▀▀▀██▄
      █   ███▌   ███    █▀     ▄█████  ▄██████ ██   █     █████  █      ██    ▄█   ▄   ███   ███   ███   ▄█████  ██▄▄▄▄    ▄█████     ▄████▄     ▄█████    █████
      █   ███▌   ███          ██   █  ██    ██ ██   ██   ██  ██ ██  ▀███████▄ ██   █▄  ███   ███   ███   ██   ██ ██▀▀▀█▄   ██   ██   ██    ▀    ██   █    ██  ██
      █   ███▌ ▀███████████  ▄██▄▄    ██    ▀  ██   ██  ▄██▄▄█▀ ██▌     ██  ▀ ▀▀▀▀▀██  ███   ███   ███   ██   ██ ██   ██   ██   ██  ▄██        ▄██▄▄     ▄██▄▄█▀
      █   ███           ███ ▀▀██▀▀    ██    ▄  ██   ██ ▀███████ ██      ██    ▄█   ██  ███   ███   ███ ▀████████ ██   ██ ▀████████ ▀▀██ ███▄  ▀▀██▀▀    ▀███████
      █   ███     ▄█    ███   ██   █  ██    ██ ██   ██   ██  ██ ██      ██    ██   ██  ███   ███   ███   ██   ██ ██   ██   ██   ██   ██    ██   ██   █    ██  ██
      █   █▀    ▄████████▀    ███████ ██████▀  ██████    ██  ██ █      ▄██▀    █████    ▀█   ███   █▀    ██   █▀  █   █    ██   █▀   ██████▀    ███████   ██  ██
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Manages the security subsystem.
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
using System.Collections.Generic;
using OpenIIoT.SDK.Common;
using OpenIIoT.SDK.Common.Provider.EventProvider;
using Utility.OperationResult;

namespace OpenIIoT.Core.Security
{
    /// <summary>
    ///     Manages the security subsystem.
    /// </summary>
    public interface ISecurityManager : IManager
    {
        #region Public Events

        /// <summary>
        ///     Occurs when a Session is ended.
        /// </summary>
        [Event(Description = "Occurs when a Session is ended.")]
        event EventHandler<SessionEventArgs> SessionEnded;

        /// <summary>
        ///     Occurs when a Session is extended.
        /// </summary>
        [Event(Description = "Occurs when a Session is extended.")]
        event EventHandler<SessionEventArgs> SessionExtended;

        /// <summary>
        ///     Occurs when a Session is started.
        /// </summary>
        [Event(Description = "Occurs when a Session is started.")]
        event EventHandler<SessionEventArgs> SessionStarted;

        /// <summary>
        ///     Occurs when a User is created.
        /// </summary>
        [Event(Description = "Occurs when a User is created.")]
        event EventHandler<UserEventArgs> UserCreated;

        /// <summary>
        ///     Occurs when a User is deleted.
        /// </summary>
        [Event(Description = "Occurs when a User is deleted.")]
        event EventHandler<UserEventArgs> UserDeleted;

        /// <summary>
        ///     Occurs when a User is updated.
        /// </summary>
        [Event(Description = "Occurs when a User is updated.")]
        event EventHandler<UserEventArgs> UserUpdated;

        #endregion Public Events

        #region Public Properties

        /// <summary>
        ///     Gets the list of built-in <see cref="UserRole"/> s.
        /// </summary>
        IReadOnlyList<UserRole> Roles { get; }

        /// <summary>
        ///     Gets the list of active <see cref="Session"/> s.
        /// </summary>
        IReadOnlyList<Session> Sessions { get; }

        /// <summary>
        ///     Gets the list of configured <see cref="User"/> s.
        /// </summary>
        IReadOnlyList<User> Users { get; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        ///     Creates a new <see cref="User"/>.
        /// </summary>
        /// <param name="name">The name of the new User.</param>
        /// <param name="password">The plaintext password for the new User.</param>
        /// <param name="role">The Role for the new User.</param>
        /// <returns>A Result containing the result of the operation and the newly created User.</returns>
        IResult<User> CreateUser(string name, string password, UserRole role);

        /// <summary>
        ///     Deletes the specified <see cref="User"/> from the list of <see cref="Users"/>.
        /// </summary>
        /// <param name="name">The name of the User to delete.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        IResult DeleteUser(string name);

        /// <summary>
        ///     Ends the specified <see cref="Session"/>.
        /// </summary>
        /// <param name="session">The Session to end.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        IResult EndSession(Session session);

        /// <summary>
        ///     Extends the specified <see cref="Session"/> to the configured session length.
        /// </summary>
        /// <param name="session">The Session to extend.</param>
        /// <returns>A Result containing the result of the operation and the extended Session.</returns>
        IResult<Session> ExtendSession(Session session);

        /// <summary>
        ///     Finds the <see cref="Session"/> matching the specified <paramref name="apiKey"/>.
        /// </summary>
        /// <param name="apiKey">The ApiKey for the requested Session.</param>
        /// <returns>The found Session.</returns>
        Session FindSession(string apiKey);

        /// <summary>
        ///     Finds the <see cref="User"/> matching the specified <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the requested User.</param>
        /// <returns>The found User.</returns>
        User FindUser(string name);

        /// <summary>
        ///     Finds the <see cref="Session"/> belonging to the specified <see cref="User"/>.
        /// </summary>
        /// <param name="user">The User for which the Session is to be retrieved.</param>
        /// <returns>The found Session.</returns>
        Session FindUserSession(User user);

        /// <summary>
        ///     Starts a new <see cref="Session"/> with the specified <paramref name="userName"/> and <paramref name="password"/>
        /// </summary>
        /// <param name="userName">The user for which the Session is to be started.</param>
        /// <param name="password">The password with which to authenticate the user.</param>
        /// <returns>A Result containing the result of the operation and the created Session.</returns>
        IResult<Session> StartSession(string userName, string password);

        /// <summary>
        ///     Updates the specified <see cref="User"/> with the optionally specified <paramref name="password"/> and/or <paramref name="role"/>.
        /// </summary>
        /// <param name="userName">The name of the User to update.</param>
        /// <param name="password">The updated plaintext password for the User.</param>
        /// <param name="role">The updated Role for the user.</param>
        /// <returns>A Result containing the result of the operation and the updated User.</returns>
        IResult<User> UpdateUser(string userName, string password = null, UserRole role = UserRole.NotSpecified);

        #endregion Public Methods
    }
}