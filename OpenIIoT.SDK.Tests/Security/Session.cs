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

using System;
using System.Security.Claims;
using Xunit;

namespace OpenIIoT.SDK.Tests.Security
{
    /// <summary>
    ///     Unit tests for the <see cref="SDK.Security.Session"/> class.
    /// </summary>
    public class Session
    {
        #region Public Methods

        private SDK.Security.User User { get; set; }

        /// <summary>
        ///     Tests the constructor and all properties.
        /// </summary>
        [Fact]
        public void Constructor()
        {
            SDK.Security.Ticket ticket = new SDK.Security.Ticket(new ClaimsIdentity(), 15);
            ticket.Identity.AddClaim(new Claim(ClaimTypes.Name, "name"));
            ticket.Identity.AddClaim(new Claim(ClaimTypes.Role, SDK.Security.Role.Reader.ToString()));
            ticket.Identity.AddClaim(new Claim(ClaimTypes.Hash, "hash"));

            User = new SDK.Security.User("name", "displayName", "name@test.com", "hash", SDK.Security.Role.Reader);

            SDK.Security.Session test = new SDK.Security.Session(User, ticket);

            Assert.IsType<SDK.Security.Session>(test);
            Assert.Equal("hash", test.Token);
            Assert.Equal(ticket, test.Ticket);
            Assert.False(test.IsExpired);
            Assert.Equal("name", test.GetClaim(ClaimTypes.Name));
            Assert.Equal(SDK.Security.Role.Reader, Enum.Parse(typeof(SDK.Security.Role), test.GetClaim(ClaimTypes.Role)));
            Assert.NotNull(test.Expires);
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Security.Session.IsExpired"/> property with an expired Ticket.
        /// </summary>
        [Fact]
        public void IsExpiredExpired()
        {
            SDK.Security.Ticket ticket = new SDK.Security.Ticket(new ClaimsIdentity(), -15);
            SDK.Security.Session test = new SDK.Security.Session(User, ticket);

            Assert.True(test.IsExpired);
            Assert.NotNull(test.Expires);
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Security.Session.IsExpired"/> property with a Ticket which does not contain the ExpiresUtc property.
        /// </summary>
        [Fact]
        public void IsExpiredNullProperty()
        {
            SDK.Security.Ticket ticket = new SDK.Security.Ticket(new ClaimsIdentity());
            SDK.Security.Session test = new SDK.Security.Session(User, ticket);

            Assert.True(test.IsExpired);
            Assert.Null(test.Expires);
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Security.Session.Name"/> property.
        /// </summary>
        [Fact]
        public void Name()
        {
            SDK.Security.Ticket ticket = new SDK.Security.Ticket(new ClaimsIdentity());
            ticket.Identity.AddClaim(new Claim(ClaimTypes.Name, "name"));

            SDK.Security.Session test = new SDK.Security.Session(User, ticket);

            Assert.Equal("name", test.GetClaim(ClaimTypes.Name));
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Security.Session.Name"/> property with a Ticket missing the Name claim.
        /// </summary>
        [Fact]
        public void NameNoClaim()
        {
            SDK.Security.Ticket ticket = new SDK.Security.Ticket(new ClaimsIdentity());

            SDK.Security.Session test = new SDK.Security.Session(User, ticket);

            Assert.Equal(null, test.GetClaim(ClaimTypes.Name));
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Security.Session.Role"/> property.
        /// </summary>
        [Fact]
        public void Role()
        {
            SDK.Security.Ticket ticket = new SDK.Security.Ticket(new ClaimsIdentity());
            ticket.Identity.AddClaim(new Claim(ClaimTypes.Role, SDK.Security.Role.Reader.ToString()));

            SDK.Security.Session test = new SDK.Security.Session(User, ticket);

            Assert.Equal(SDK.Security.Role.Reader, Enum.Parse(typeof(SDK.Security.Role), test.GetClaim(ClaimTypes.Role)));
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Security.Session.Role"/> property with a ticket missing the Role claim.
        /// </summary>
        [Fact]
        public void RoleNoClaim()
        {
            SDK.Security.Ticket ticket = new SDK.Security.Ticket(new ClaimsIdentity());

            SDK.Security.Session test = new SDK.Security.Session(User, ticket);

            Assert.Null(test.GetClaim(ClaimTypes.Role));
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Security.Session.Ticket"/> property.
        /// </summary>
        [Fact]
        public void Ticket()
        {
            SDK.Security.Ticket ticket = new SDK.Security.Ticket(new ClaimsIdentity());

            SDK.Security.Session test = new SDK.Security.Session(User, ticket);

            Assert.Equal(ticket, test.Ticket);
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Security.Session.Ticket"/> property with a null ticket.
        /// </summary>
        [Fact]
        public void TicketNull()
        {
            SDK.Security.Session test = new SDK.Security.Session(User, null);

            Assert.Equal(null, test.Ticket);
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Security.Session.Token"/> property.
        /// </summary>
        [Fact]
        public void Token()
        {
            SDK.Security.Ticket ticket = new SDK.Security.Ticket(new ClaimsIdentity());
            ticket.Identity.AddClaim(new Claim(ClaimTypes.Hash, "token"));

            SDK.Security.Session test = new SDK.Security.Session(User, ticket);

            Assert.Equal("token", test.Token);
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Security.Session.Token"/> property with a ticket missing the Hash claim..
        /// </summary>
        [Fact]
        public void TokenNoClaim()
        {
            SDK.Security.Ticket ticket = new SDK.Security.Ticket(new ClaimsIdentity());

            SDK.Security.Session test = new SDK.Security.Session(User, ticket);

            Assert.Equal(string.Empty, test.Token);
        }

        #endregion Public Methods
    }
}