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
      █  Unit tests for the Session class.
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
    using SDK.Security;
    using Xunit;

    /// <summary>
    ///     Unit tests for the <see cref="Core.Security.Session"/> class.
    /// </summary>
    public class SessionTests
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the User with which to conduct testing.
        /// </summary>
        private IUser User { get; set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        ///     Tests the constructor and all properties.
        /// </summary>
        [Fact]
        public void Constructor()
        {
            Core.Security.Ticket ticket = new Core.Security.Ticket(new ClaimsIdentity(), 15);
            ticket.Identity.AddClaim(new Claim(ClaimTypes.Name, "name"));
            ticket.Identity.AddClaim(new Claim(ClaimTypes.Role, SDK.Security.Role.Reader.ToString()));
            ticket.Identity.AddClaim(new Claim(ClaimTypes.Hash, "hash"));

            User = new Core.Security.User("name", "displayName", "name@test.com", "hash", SDK.Security.Role.Reader);

            ISession test = new Core.Security.Session(User, ticket);

            Assert.IsType<ISession>(test);
            Assert.Equal("hash", test.Token);
            Assert.Equal(ticket, test.Ticket);
            Assert.False(test.IsExpired);
            Assert.Equal("name", test.GetClaim(ClaimTypes.Name));
            Assert.Equal(SDK.Security.Role.Reader, Enum.Parse(typeof(SDK.Security.Role), test.GetClaim(ClaimTypes.Role)));
            Assert.NotNull(test.Expires);
        }

        /// <summary>
        ///     Tests the <see cref="ISession.IsExpired"/> property with an expired Ticket.
        /// </summary>
        [Fact]
        public void IsExpiredExpired()
        {
            Core.Security.Ticket ticket = new Core.Security.Ticket(new ClaimsIdentity(), -15);
            ISession test = new Core.Security.Session(User, ticket);

            Assert.True(test.IsExpired);
            Assert.NotNull(test.Expires);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Security.Session.GetClaim(string)"/> method for the <see cref="ClaimTypes.Name"/> claim.
        /// </summary>
        [Fact]
        public void Name()
        {
            Core.Security.Ticket ticket = new Core.Security.Ticket(new ClaimsIdentity());
            ticket.Identity.AddClaim(new Claim(ClaimTypes.Name, "name"));

            Core.Security.Session test = new Core.Security.Session(User, ticket);

            Assert.Equal("name", test.GetClaim(ClaimTypes.Name));
        }

        /// <summary>
        ///     Tests the <see cref="Core.Security.Session.GetClaim(string)"/> method with a Ticket missing the
        ///     <see cref="ClaimTypes.Name"/> claim.
        /// </summary>
        [Fact]
        public void NameNoClaim()
        {
            Core.Security.Ticket ticket = new Core.Security.Ticket(new ClaimsIdentity());

            Core.Security.Session test = new Core.Security.Session(User, ticket);

            Assert.Equal(null, test.GetClaim(ClaimTypes.Name));
        }

        /// <summary>
        ///     Tests the <see cref="Core.Security.Session.GetClaim(string)"/> method for the <see cref="ClaimTypes.Role"/> claim.
        /// </summary>
        [Fact]
        public void Role()
        {
            Core.Security.Ticket ticket = new Core.Security.Ticket(new ClaimsIdentity());
            ticket.Identity.AddClaim(new Claim(ClaimTypes.Role, SDK.Security.Role.Reader.ToString()));

            Core.Security.Session test = new Core.Security.Session(User, ticket);

            Assert.Equal(SDK.Security.Role.Reader, Enum.Parse(typeof(SDK.Security.Role), test.GetClaim(ClaimTypes.Role)));
        }

        /// <summary>
        ///     Tests the <see cref="Core.Security.Session.GetClaim(string)"/> method for the <see cref="ClaimTypes.Role"/> claim.
        /// </summary>
        [Fact]
        public void RoleNoClaim()
        {
            Core.Security.Ticket ticket = new Core.Security.Ticket(new ClaimsIdentity());

            Core.Security.Session test = new Core.Security.Session(User, ticket);

            Assert.Null(test.GetClaim(ClaimTypes.Role));
        }

        /// <summary>
        ///     Tests the <see cref="Core.Security.Session.Ticket"/> property.
        /// </summary>
        [Fact]
        public void Ticket()
        {
            Core.Security.Ticket ticket = new Core.Security.Ticket(new ClaimsIdentity());

            Core.Security.Session test = new Core.Security.Session(User, ticket);

            Assert.Equal(ticket, test.Ticket);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Security.Session.Ticket"/> property with a null ticket.
        /// </summary>
        [Fact]
        public void TicketNull()
        {
            Core.Security.Session test = new Core.Security.Session(User, null);

            Assert.Equal(null, test.Ticket);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Security.Session.Token"/> property.
        /// </summary>
        [Fact]
        public void Token()
        {
            Core.Security.Ticket ticket = new Core.Security.Ticket(new ClaimsIdentity());
            ticket.Identity.AddClaim(new Claim(ClaimTypes.Hash, "token"));

            Core.Security.Session test = new Core.Security.Session(User, ticket);

            Assert.Equal("token", test.Token);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Security.Session.Token"/> property with a ticket missing the Hash claim..
        /// </summary>
        [Fact]
        public void TokenNoClaim()
        {
            Core.Security.Ticket ticket = new Core.Security.Ticket(new ClaimsIdentity());

            Core.Security.Session test = new Core.Security.Session(User, ticket);

            Assert.Equal(string.Empty, test.Token);
        }

        #endregion Public Methods
    }
}