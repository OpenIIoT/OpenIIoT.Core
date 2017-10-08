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

namespace OpenIIoT.Core.Tests.Security
{
    using Core.Security;
    using SDK.Security;
    using System;
    using System.Security.Claims;
    using Xunit;

    /// <summary>
    ///     Unit tests for the <see cref="Core.Security.SessionFactory"/> class.
    /// </summary>
    [Collection("SessionFactory")]
    public class SessionFactoryTests
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="SessionFactoryTests"/> class
        /// </summary>
        public SessionFactoryTests()
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
        ///     Tests the <see cref="SessionFactoryTests.CreateSession(User, int)"/> method.
        /// </summary>
        [Fact]
        public void CreateSession()
        {
            IUser user = new User("test", "user", "test@test.com", "hash", Role.Reader);
            ISession test = Factory.CreateSession(user, 15);

            Assert.IsType<Core.Security.Session>(test);
            Assert.NotNull(test);
            Assert.Equal(128, test.Token.Length);
            Assert.NotEqual(default(Core.Security.Ticket), test.Ticket);
            Assert.True(test.Ticket.Identity.HasClaim(ClaimTypes.Name, "test"));
            Assert.True(test.Ticket.Identity.HasClaim(ClaimTypes.Role, SDK.Security.Role.Reader.ToString()));
            Assert.Equal(test.Ticket.IssuedUtc.AddSeconds(15), test.Ticket.ExpiresUtc);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Security.SessionFactory.CreateSession(Core.Security.User, int)"/> method with an
        ///     administrative user.
        /// </summary>
        [Fact]
        public void CreateSessionAdmin()
        {
            Core.Security.User user = new Core.Security.User("admin", "user", "test@test.com", "hash", SDK.Security.Role.Administrator);
            ISession test = Factory.CreateSession(user, 15);

            Assert.True(test.Ticket.Identity.HasClaim(ClaimTypes.Role, SDK.Security.Role.Reader.ToString()));
            Assert.True(test.Ticket.Identity.HasClaim(ClaimTypes.Role, SDK.Security.Role.ReadWriter.ToString()));
            Assert.True(test.Ticket.Identity.HasClaim(ClaimTypes.Role, SDK.Security.Role.Administrator.ToString()));
        }

        /// <summary>
        ///     Tests the <see cref="Core.Security.SessionFactory.CreateSession(Core.Security.User, int)"/> method with a
        ///     null/default user.
        /// </summary>
        [Fact]
        public void CreateSessionNullUser()
        {
            Core.Security.User user = default(Core.Security.User);
            ISession test = Factory.CreateSession(user, 15);

            Assert.IsType<Core.Security.Session>(test);
            Assert.NotNull(test);
            Assert.Equal(128, test.Token.Length);
            Assert.NotEqual(default(Core.Security.Ticket), test.Ticket);
            Assert.True(test.Ticket.Identity.HasClaim(ClaimTypes.Name, string.Empty));
            Assert.True(test.Ticket.Identity.HasClaim(ClaimTypes.Role, SDK.Security.Role.Reader.ToString()));
        }

        /// <summary>
        ///     Tests the <see cref="Core.Security.SessionFactory.CreateSession(Core.Security.User, int)"/> method with a user with
        ///     the ReadWrite role.
        /// </summary>
        [Fact]
        public void CreateSessionReadWriter()
        {
            Core.Security.User user = new Core.Security.User("admin", "user", "test@test.com", "hash", SDK.Security.Role.ReadWriter);
            ISession test = Factory.CreateSession(user, 15);

            Assert.True(test.Ticket.Identity.HasClaim(ClaimTypes.Role, SDK.Security.Role.Reader.ToString()));
            Assert.True(test.Ticket.Identity.HasClaim(ClaimTypes.Role, SDK.Security.Role.ReadWriter.ToString()));
        }

        /// <summary>
        ///     Tests the <see cref="Core.Security.SessionFactory.ExtendSession(SDK.Security.Session, int)"/> method.
        /// </summary>
        [Fact]
        public void ExtendSession()
        {
            Core.Security.User user = new Core.Security.User("admin", "user", "test@test.com", "hash", SDK.Security.Role.ReadWriter);
            ISession test = Factory.CreateSession(user, 150);

            DateTimeOffset? initialtime = test.Ticket.ExpiresUtc;

            Factory.ExtendSession(test, 300);

            DateTimeOffset? newtime = test.Ticket.ExpiresUtc;

            Assert.True(initialtime < test.Ticket.ExpiresUtc);
        }

        #endregion Public Methods
    }
}