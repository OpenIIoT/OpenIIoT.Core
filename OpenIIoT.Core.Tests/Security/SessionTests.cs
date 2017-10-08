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
    using OpenIIoT.Core.Security;
    using OpenIIoT.SDK.Security;
    using Xunit;

    /// <summary>
    ///     Unit tests for the <see cref="Session"/> class.
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
            Ticket ticket = new Ticket(new ClaimsIdentity(), 15);
            ticket.Identity.AddClaim(new Claim(ClaimTypes.Name, "name"));
            ticket.Identity.AddClaim(new Claim(ClaimTypes.Role, SDK.Security.Role.Reader.ToString()));
            ticket.Identity.AddClaim(new Claim(ClaimTypes.Hash, "hash"));

            User = new User("name", "displayName", "name@test.com", "hash", SDK.Security.Role.Reader);

            ISession test = new Session(User, ticket);

            Assert.IsType<Session>(test);
            Assert.IsAssignableFrom<ISession>(test);
            Assert.Equal("hash", test.Token);
            Assert.Equal(ticket, test.Ticket);
            Assert.False(test.IsExpired);
            Assert.Equal("name", test.GetClaim(ClaimTypes.Name));
            Assert.Equal(SDK.Security.Role.Reader, Enum.Parse(typeof(Role), test.GetClaim(ClaimTypes.Role)));
            Assert.NotNull(test.Expires);
        }

        /// <summary>
        ///     Tests the <see cref="ISession.IsExpired"/> property with an expired Ticket.
        /// </summary>
        [Fact]
        public void IsExpiredExpired()
        {
            Ticket ticket = new Ticket(new ClaimsIdentity(), -15);
            ISession test = new Session(User, ticket);

            Assert.True(test.IsExpired);
            Assert.NotNull(test.Expires);
        }

        /// <summary>
        ///     Tests the <see cref="Session.GetClaim(string)"/> method for the <see cref="ClaimTypes.Name"/> claim.
        /// </summary>
        [Fact]
        public void Name()
        {
            Ticket ticket = new Ticket(new ClaimsIdentity());
            ticket.Identity.AddClaim(new Claim(ClaimTypes.Name, "name"));

            Session test = new Session(User, ticket);

            Assert.Equal("name", test.GetClaim(ClaimTypes.Name));
        }

        /// <summary>
        ///     Tests the <see cref="Session.GetClaim(string)"/> method with a Ticket missing the <see cref="ClaimTypes.Name"/> claim.
        /// </summary>
        [Fact]
        public void NameNoClaim()
        {
            Ticket ticket = new Ticket(new ClaimsIdentity());

            Session test = new Session(User, ticket);

            Assert.Equal(null, test.GetClaim(ClaimTypes.Name));
        }

        /// <summary>
        ///     Tests the <see cref="Session.GetClaim(string)"/> method for the <see cref="ClaimTypes.Role"/> claim.
        /// </summary>
        [Fact]
        public void Role()
        {
            Ticket ticket = new Ticket(new ClaimsIdentity());
            ticket.Identity.AddClaim(new Claim(ClaimTypes.Role, SDK.Security.Role.Reader.ToString()));

            Session test = new Session(User, ticket);

            Assert.Equal(SDK.Security.Role.Reader, Enum.Parse(typeof(Role), test.GetClaim(ClaimTypes.Role)));
        }

        /// <summary>
        ///     Tests the <see cref="Session.GetClaim(string)"/> method for the <see cref="ClaimTypes.Role"/> claim.
        /// </summary>
        [Fact]
        public void RoleNoClaim()
        {
            Ticket ticket = new Ticket(new ClaimsIdentity());

            Session test = new Session(User, ticket);

            Assert.Null(test.GetClaim(ClaimTypes.Role));
        }

        /// <summary>
        ///     Tests the <see cref="Session.Ticket"/> property.
        /// </summary>
        [Fact]
        public void Ticket()
        {
            Ticket ticket = new Ticket(new ClaimsIdentity());

            Session test = new Session(User, ticket);

            Assert.Equal(ticket, test.Ticket);
        }

        /// <summary>
        ///     Tests the <see cref="Session.Ticket"/> property with a null ticket.
        /// </summary>
        [Fact]
        public void TicketNull()
        {
            Session test = new Session(User, null);

            Assert.Equal(null, test.Ticket);
        }

        /// <summary>
        ///     Tests the <see cref="Session.Token"/> property.
        /// </summary>
        [Fact]
        public void Token()
        {
            Ticket ticket = new Ticket(new ClaimsIdentity());
            ticket.Identity.AddClaim(new Claim(ClaimTypes.Hash, "token"));

            Session test = new Session(User, ticket);

            Assert.Equal("token", test.Token);
        }

        /// <summary>
        ///     Tests the <see cref="Session.Token"/> property with a ticket missing the Hash claim..
        /// </summary>
        [Fact]
        public void TokenNoClaim()
        {
            Ticket ticket = new Ticket(new ClaimsIdentity());

            Session test = new Session(User, ticket);

            Assert.Equal(string.Empty, test.Token);
        }

        #endregion Public Methods
    }
}