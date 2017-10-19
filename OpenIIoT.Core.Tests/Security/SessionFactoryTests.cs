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
    using System;
    using System.Security.Claims;
    using OpenIIoT.Core.Security;
    using OpenIIoT.SDK.Security;
    using Xunit;

    /// <summary>
    ///     Unit tests for the <see cref="SessionFactory"/> class.
    /// </summary>
    public class SessionFactoryTests
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="SessionFactoryTests"/> class
        /// </summary>
        public SessionFactoryTests()
        {
            Factory = new SessionFactory();
        }

        #endregion Public Constructors

        #region Private Properties

        /// <summary>
        ///     Gets or sets the <see cref="SessionFactory"/> under test.
        /// </summary>
        private SessionFactory Factory { get; set; }

        #endregion Private Properties

        #region Public Methods

        /// <summary>
        ///     Tests the constructor.
        /// </summary>
        [Fact]
        public void Constructor()
        {
            Assert.IsType<SessionFactory>(Factory);
        }

        /// <summary>
        ///     Tests the <see cref="SessionFactory.CreateSession(IUser, int)"/> method.
        /// </summary>
        [Fact]
        public void CreateSession()
        {
            IUser user = new User("test", "user", "test@test.com", "hash", Role.Reader);
            ISession test = Factory.CreateSession(user, 15);

            Assert.IsType<Session>(test);
            Assert.NotNull(test);
            Assert.Equal(128, test.Token.Length);
            Assert.True(test.Identity.HasClaim(ClaimTypes.Name, "test"));
            Assert.True(test.Identity.HasClaim(ClaimTypes.Role, Role.Reader.ToString()));
            Assert.Equal(test.Created.AddSeconds(15), test.Expires);
        }

        /// <summary>
        ///     Tests the <see cref="SessionFactory.CreateSession(IUser, int)"/> method with an administrative user.
        /// </summary>
        [Fact]
        public void CreateSessionAdmin()
        {
            User user = new User("admin", "user", "test@test.com", "hash", Role.Administrator);
            ISession test = Factory.CreateSession(user, 15);

            Assert.True(test.Identity.HasClaim(ClaimTypes.Role, Role.Reader.ToString()));
            Assert.True(test.Identity.HasClaim(ClaimTypes.Role, Role.ReadWriter.ToString()));
            Assert.True(test.Identity.HasClaim(ClaimTypes.Role, Role.Administrator.ToString()));
        }

        /// <summary>
        ///     Tests the <see cref="SessionFactory.CreateSession(IUser, int)"/> method with a null/default user.
        /// </summary>
        [Fact]
        public void CreateSessionNullUser()
        {
            User user = default(User);
            ISession test = Factory.CreateSession(user, 15);

            Assert.IsType<Session>(test);
            Assert.NotNull(test);
            Assert.Equal(128, test.Token.Length);
            Assert.True(test.Identity.HasClaim(ClaimTypes.Name, string.Empty));
            Assert.True(test.Identity.HasClaim(ClaimTypes.Role, Role.Reader.ToString()));
        }

        /// <summary>
        ///     Tests the <see cref="SessionFactory.CreateSession(IUser, int)"/> method with a user with the ReadWrite role.
        /// </summary>
        [Fact]
        public void CreateSessionReadWriter()
        {
            User user = new User("admin", "user", "test@test.com", "hash", Role.ReadWriter);
            ISession test = Factory.CreateSession(user, 15);

            Assert.True(test.Identity.HasClaim(ClaimTypes.Role, Role.Reader.ToString()));
            Assert.True(test.Identity.HasClaim(ClaimTypes.Role, Role.ReadWriter.ToString()));
        }

        /// <summary>
        ///     Tests the <see cref="SessionFactory.ExtendSession(ISession, int)"/> method.
        /// </summary>
        [Fact]
        public void ExtendSession()
        {
            User user = new User("admin", "user", "test@test.com", "hash", Role.ReadWriter);
            ISession test = Factory.CreateSession(user, 150);

            DateTimeOffset initialtime = test.Expires;

            Factory.ExtendSession(test, 300);

            DateTimeOffset newtime = test.Expires;

            Assert.True(initialtime < test.Expires);
        }

        #endregion Public Methods
    }
}