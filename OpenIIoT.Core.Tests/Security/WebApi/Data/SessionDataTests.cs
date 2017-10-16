/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄████████                                                  ████████▄
      █     ███    ███                                                  ███   ▀███
      █     ███    █▀     ▄█████   ▄█████   ▄█████  █   ██████  ██▄▄▄▄  ███    ███   ▄█████      ██      ▄█████
      █     ███          ██   █    ██  ▀    ██  ▀  ██  ██    ██ ██▀▀▀█▄ ███    ███   ██   ██ ▀███████▄   ██   ██
      █   ▀███████████  ▄██▄▄      ██       ██     ██▌ ██    ██ ██   ██ ███    ███   ██   ██     ██  ▀   ██   ██
      █            ███ ▀▀██▀▀    ▀███████ ▀███████ ██  ██    ██ ██   ██ ███    ███ ▀████████     ██    ▀████████
      █      ▄█    ███   ██   █     ▄  ██    ▄  ██ ██  ██    ██ ██   ██ ███   ▄███   ██   ██     ██      ██   ██
      █    ▄████████▀    ███████  ▄████▀   ▄████▀  █    ██████   █   █  ████████▀    ██   █▀    ▄██▀     ██   █▀
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
      █  Unit tests for the SessionData class.
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

namespace OpenIIoT.Core.Tests.Security.WebApi.Data
{
    using System;
    using System.Security.Claims;
    using Moq;
    using OpenIIoT.Core.Security.WebApi.Data;
    using OpenIIoT.SDK.Security;
    using Xunit;

    /// <summary>
    ///     Unit tests for the <see cref="SessionData"/> class.
    /// </summary>
    public class SessionDataTests
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="SessionDataTests"/> class.
        /// </summary>
        public SessionDataTests()
        {
            SetupMocks();
        }

        #endregion Public Constructors

        #region Private Properties

        /// <summary>
        ///     Gets or sets the <see cref="ClaimsIdentity"/> for the unit tests.
        /// </summary>
        private ClaimsIdentity Identity { get; set; }

        /// <summary>
        ///     Gets or sets the <see cref="ISession"/> mockup for the unit tests.
        /// </summary>
        private Mock<ISession> Session { get; set; }

        /// <summary>
        ///     Gets or sets the <see cref="IUser"/> mockup for the unit tests.
        /// </summary>
        private Mock<IUser> User { get; set; }

        #endregion Private Properties

        #region Public Methods

        /// <summary>
        ///     Tests the constructor and all properties.
        /// </summary>
        [Fact]
        public void Constructor()
        {
            SessionData test = new SessionData(Session.Object);

            Assert.IsType<SessionData>(test);
            Assert.Equal(User.Object.Name, test.User.Name);
            Assert.Equal(Session.Object.Token, test.Token);
            Assert.Equal(Session.Object.Created, test.Created);
            Assert.Equal(Session.Object.Expires, test.Expires);

            Assert.True(test.DataAnnotationIsValid());
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        ///     Configures the mockups for the unit tests.
        /// </summary>
        private void SetupMocks()
        {
            User = new Mock<IUser>();
            User.Setup(u => u.Name).Returns("name");
            User.Setup(u => u.DisplayName).Returns("display name");
            User.Setup(u => u.Email).Returns("name@email.com");
            User.Setup(u => u.PasswordHash).Returns("hash");
            User.Setup(u => u.Role).Returns(Role.Reader);

            Identity = new ClaimsIdentity();
            Identity.AddClaim(new Claim(ClaimTypes.Name, User.Object.Name));
            Identity.AddClaim(new Claim(ClaimTypes.Role, User.Object.Role.ToString()));

            Session = new Mock<ISession>();
            Session.Setup(s => s.User).Returns(User.Object);
            Session.Setup(s => s.Identity).Returns(Identity);
            Session.Setup(s => s.Token).Returns("token");
            Session.Setup(s => s.Created).Returns(DateTime.UtcNow);
            Session.Setup(s => s.Expires).Returns(DateTime.UtcNow.AddHours(1));
        }

        #endregion Private Methods
    }
}