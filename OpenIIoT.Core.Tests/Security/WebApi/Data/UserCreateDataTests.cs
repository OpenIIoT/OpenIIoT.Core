/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █   ███    █▄                              ▄████████                                                   ████████▄
      █   ███    ███                             ███    ███                                                  ███   ▀███
      █   ███    ███   ▄█████    ▄█████    █████ ███    █▀     █████    ▄█████   ▄█████      ██       ▄█████ ███    ███   ▄█████      ██      ▄█████
      █   ███    ███   ██  ▀    ██   █    ██  ██ ███          ██  ██   ██   █    ██   ██ ▀███████▄   ██   █  ███    ███   ██   ██ ▀███████▄   ██   ██
      █   ███    ███   ██      ▄██▄▄     ▄██▄▄█▀ ███         ▄██▄▄█▀  ▄██▄▄      ██   ██     ██  ▀  ▄██▄▄    ███    ███   ██   ██     ██  ▀   ██   ██
      █   ███    ███ ▀███████ ▀▀██▀▀    ▀███████ ███    █▄  ▀███████ ▀▀██▀▀    ▀████████     ██    ▀▀██▀▀    ███    ███ ▀████████     ██    ▀████████
      █   ███    ███    ▄  ██   ██   █    ██  ██ ███    ███   ██  ██   ██   █    ██   ██     ██      ██   █  ███   ▄███   ██   ██     ██      ██   ██
      █   ████████▀   ▄████▀    ███████   ██  ██ ████████▀    ██  ██   ███████   ██   █▀    ▄██▀     ███████ ████████▀    ██   █▀    ▄██▀     ██   █▀
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
      █  Unit tests for the UserCreateData class.
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
    using OpenIIoT.Core.Security.WebApi.Data;
    using OpenIIoT.SDK.Security;
    using Xunit;

    /// <summary>
    ///     Unit tests for the <see cref="UserCreateData"/> class.
    /// </summary>
    public class UserCreateDataTests
    {
        #region Public Methods

        /// <summary>
        ///     Tests the constructor and all properties.
        /// </summary>
        [Fact]
        public void Constructor()
        {
            UserCreateData test = new UserCreateData()
            {
                Name = "name",
                DisplayName = "display name",
                Email = "email@email.com",
                Password = "password",
                Role = Role.Reader,
            };

            Assert.IsType<UserCreateData>(test);
            Assert.Equal("name", test.Name);
            Assert.Equal("display name", test.DisplayName);
            Assert.Equal("email@email.com", test.Email);
            Assert.Equal("password", test.Password);
            Assert.Equal(Role.Reader, test.Role);

            Assert.True(test.DataAnnotationIsValid());
        }

        /// <summary>
        ///     Tests data annotation validation with a null <see cref="UserCreateData.DisplayName"/>.
        /// </summary>
        [Fact]
        public void DisplayNameNull()
        {
            UserCreateData test = new UserCreateData()
            {
                DisplayName = null,
            };

            Assert.False(test.DataAnnotationIsValid());
        }

        /// <summary>
        ///     Tests data annotation validation with a <see cref="UserCreateData.DisplayName"/> exceeding the length limit.
        /// </summary>
        [Fact]
        public void DisplayNameTooLong()
        {
            UserCreateData test = new UserCreateData()
            {
                DisplayName = new string('a', 129),
            };

            Assert.False(test.DataAnnotationIsValid());
        }

        /// <summary>
        ///     Tests data annotation validation with a <see cref="UserCreateData.DisplayName"/> of length less than the length minimum.
        /// </summary>
        [Fact]
        public void DisplayNameTooShort()
        {
            UserCreateData test = new UserCreateData()
            {
                DisplayName = string.Empty,
            };

            Assert.False(test.DataAnnotationIsValid());
        }

        /// <summary>
        ///     Tests data annotation validation with a <see cref="UserCreateData.Email"/> which is not a valid email address.
        /// </summary>
        [Fact]
        public void EmailInvalid()
        {
            UserCreateData test = new UserCreateData()
            {
                Email = "email",
            };

            Assert.False(test.DataAnnotationIsValid());
        }

        /// <summary>
        ///     Tests data annotation validation with a null <see cref="UserCreateData.Email"/>.
        /// </summary>
        [Fact]
        public void EmailNull()
        {
            UserCreateData test = new UserCreateData()
            {
                Email = null,
            };

            Assert.False(test.DataAnnotationIsValid());
        }

        /// <summary>
        ///     Tests data annotation validation with a null <see cref="UserCreateData.Name"/>.
        /// </summary>
        [Fact]
        public void NameNull()
        {
            UserCreateData test = new UserCreateData()
            {
                DisplayName = "display name",
                Email = "email@email.com",
                Password = "password",
                Role = Role.Reader,
            };

            Assert.False(test.DataAnnotationIsValid());
        }

        /// <summary>
        ///     Tests data annotation validation with a <see cref="UserCreateData.Name"/> exceeding the length limit.
        /// </summary>
        [Fact]
        public void NameTooLong()
        {
            UserCreateData test = new UserCreateData()
            {
                Name = new string('a', 129),
            };

            Assert.False(test.DataAnnotationIsValid());
        }

        /// <summary>
        ///     Tests data annotation validation with a <see cref="UserCreateData.Name"/> of length less than the length minimum.
        /// </summary>
        [Fact]
        public void NameTooShort()
        {
            UserCreateData test = new UserCreateData()
            {
                Name = string.Empty,
            };

            Assert.False(test.DataAnnotationIsValid());
        }

        /// <summary>
        ///     Tests data annotation validation with a null <see cref="UserCreateData.Password"/>.
        /// </summary>
        [Fact]
        public void PasswordNull()
        {
            UserCreateData test = new UserCreateData()
            {
                Password = null,
            };

            Assert.False(test.DataAnnotationIsValid());
        }

        /// <summary>
        ///     Tests data annotation validation with a <see cref="UserCreateData.Password"/> exceeding the length limit.
        /// </summary>
        [Fact]
        public void PasswordTooLong()
        {
            UserCreateData test = new UserCreateData()
            {
                Password = new string('a', 513),
            };

            Assert.False(test.DataAnnotationIsValid());
        }

        /// <summary>
        ///     Tests data annotation validation with a <see cref="UserCreateData.Password"/> of length less than the length minimum.
        /// </summary>
        [Fact]
        public void PasswordTooShort()
        {
            UserCreateData test = new UserCreateData()
            {
                Password = string.Empty,
            };

            Assert.False(test.DataAnnotationIsValid());
        }

        #endregion Public Methods
    }
}