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
      █       ███
      █   ▀█████████▄
      █      ▀███▀▀██    ▄█████   ▄█████     ██      ▄█████
      █       ███   ▀   ██   █    ██  ▀  ▀███████▄   ██  ▀
      █       ███      ▄██▄▄      ██         ██  ▀   ██
      █       ███     ▀▀██▀▀    ▀███████     ██    ▀███████
      █       ███       ██   █     ▄  ██     ██       ▄  ██
      █      ▄████▀     ███████  ▄████▀     ▄██▀    ▄████▀
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Unit tests for the SessionFactory class.
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
using Xunit;

namespace OpenIIoT.Core.Tests.Security
{
    /// <summary>
    ///     Unit tests for the <see cref="Core.Security.SessionFactory"/> class.
    /// </summary>
    [Collection("SessionFactory")]
    public class SessionFactory
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="SessionFactory"/> class
        /// </summary>
        public SessionFactory()
        {
            Factory = new Core.Security.SessionFactory();
        }

        #endregion Public Constructors

        #region Private Properties

        /// <summary>
        ///     Gets or sets the <see cref="Core.Security.SessionFactory"/> under test.
        /// </summary>
        private Core.Security.SessionFactory Factory { get; set; }

        #endregion Private Properties

        #region Public Methods

        /// <summary>
        ///     Tests the constructor.
        /// </summary>
        [Fact]
        public void Constructor()
        {
            Assert.IsType<Core.Security.SessionFactory>(Factory);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Security.SessionFactory.CreateSession(SDK.Security.User, int)"/> method.
        /// </summary>
        [Fact]
        public void CreateSession()
        {
            SDK.Security.User user = new SDK.Security.User("test", "hash", SDK.Security.Role.Reader);
            SDK.Security.Session test = Factory.CreateSession(user, 15);

            Assert.IsType<SDK.Security.Session>(test);
            Assert.NotNull(test);
            Assert.Equal(128, test.ApiKey.Length);
            Assert.NotEqual(default(AuthenticationTicket), test.Ticket);
            Assert.True(test.Ticket.Identity.HasClaim(ClaimTypes.Name, "test"));
            Assert.True(test.Ticket.Identity.HasClaim(ClaimTypes.Role, SDK.Security.Role.Reader.ToString()));
            Assert.Equal(test.Ticket.Properties.IssuedUtc.Value.AddSeconds(15), test.Ticket.Properties.ExpiresUtc.Value);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Security.SessionFactory.CreateSession(SDK.Security.User, int)"/> method with an
        ///     administrative user.
        /// </summary>
        [Fact]
        public void CreateSessionAdmin()
        {
            SDK.Security.User user = new SDK.Security.User("admin", "hash", SDK.Security.Role.Administrator);
            SDK.Security.Session test = Factory.CreateSession(user, 15);

            Assert.True(test.Ticket.Identity.HasClaim(ClaimTypes.Role, SDK.Security.Role.Reader.ToString()));
            Assert.True(test.Ticket.Identity.HasClaim(ClaimTypes.Role, SDK.Security.Role.ReadWriter.ToString()));
            Assert.True(test.Ticket.Identity.HasClaim(ClaimTypes.Role, SDK.Security.Role.Administrator.ToString()));
        }

        /// <summary>
        ///     Tests the <see cref="Core.Security.SessionFactory.CreateSession(SDK.Security.User, int)"/> method with a
        ///     null/default user.
        /// </summary>
        [Fact]
        public void CreateSessionNullUser()
        {
            SDK.Security.User user = default(SDK.Security.User);
            SDK.Security.Session test = Factory.CreateSession(user, 15);

            Assert.IsType<SDK.Security.Session>(test);
            Assert.NotNull(test);
            Assert.Equal(128, test.ApiKey.Length);
            Assert.NotEqual(default(AuthenticationTicket), test.Ticket);
            Assert.True(test.Ticket.Identity.HasClaim(ClaimTypes.Name, string.Empty));
            Assert.True(test.Ticket.Identity.HasClaim(ClaimTypes.Role, SDK.Security.Role.Reader.ToString()));
        }

        /// <summary>
        ///     Tests the <see cref="Core.Security.SessionFactory.CreateSession(SDK.Security.User, int)"/> method with a user with
        ///     the ReadWrite role.
        /// </summary>
        [Fact]
        public void CreateSessionReadWriter()
        {
            SDK.Security.User user = new SDK.Security.User("admin", "hash", SDK.Security.Role.ReadWriter);
            SDK.Security.Session test = Factory.CreateSession(user, 15);

            Assert.True(test.Ticket.Identity.HasClaim(ClaimTypes.Role, SDK.Security.Role.Reader.ToString()));
            Assert.True(test.Ticket.Identity.HasClaim(ClaimTypes.Role, SDK.Security.Role.ReadWriter.ToString()));
        }

        /// <summary>
        ///     Tests the <see cref="Core.Security.SessionFactory.ExtendSession(SDK.Security.Session, int)"/> method.
        /// </summary>
        [Fact]
        public void ExtendSession()
        {
            SDK.Security.User user = new SDK.Security.User("admin", "hash", SDK.Security.Role.ReadWriter);
            SDK.Security.Session test = Factory.CreateSession(user, 15);

            DateTimeOffset initial = test.Ticket.Properties.ExpiresUtc.Value;

            Factory.ExtendSession(test, 15);

            Assert.Equal(initial.AddSeconds(15), test.Ticket.Properties.ExpiresUtc.Value);
        }

        #endregion Public Methods
    }
}