/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █   ███    █▄                              ███    █▄                                                   ████████▄
      █   ███    ███                             ███    ███                                                  ███   ▀███
      █   ███    ███   ▄█████    ▄█████    █████ ███    ███    █████▄ ██████▄    ▄█████      ██       ▄█████ ███    ███   ▄█████      ██      ▄█████
      █   ███    ███   ██  ▀    ██   █    ██  ██ ███    ███   ██   ██ ██   ▀██   ██   ██ ▀███████▄   ██   █  ███    ███   ██   ██ ▀███████▄   ██   ██
      █   ███    ███   ██      ▄██▄▄     ▄██▄▄█▀ ███    ███   ██   ██ ██    ██   ██   ██     ██  ▀  ▄██▄▄    ███    ███   ██   ██     ██  ▀   ██   ██
      █   ███    ███ ▀███████ ▀▀██▀▀    ▀███████ ███    ███ ▀██████▀  ██    ██ ▀████████     ██    ▀▀██▀▀    ███    ███ ▀████████     ██    ▀████████
      █   ███    ███    ▄  ██   ██   █    ██  ██ ███    ███   ██      ██   ▄██   ██   ██     ██      ██   █  ███   ▄███   ██   ██     ██      ██   ██
      █   ████████▀   ▄████▀    ███████   ██  ██ ████████▀   ▄███▀    ██████▀    ██   █▀    ▄██▀     ███████ ████████▀    ██   █▀    ▄██▀     ██   █▀
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
      █  Unit tests for the UserUpdateData class.
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
    using OpenIIoT.Core.Security.WebApi.Data;
    using OpenIIoT.SDK.Security;
    using Xunit;

    /// <summary>
    ///     Unit tests for the <see cref="UserUpdateData"/> class.
    /// </summary>
    public class UserUpdateDataTests
    {
        #region Public Methods

        /// <summary>
        ///     Tests the constructor and all properties.
        /// </summary>
        [Fact]
        public void Constructor()
        {
            UserUpdateData test = new UserUpdateData()
            {
                DisplayName = "display name",
                Email = "email@email.com",
                Password = "password",
                Role = Role.Reader,
            };

            Assert.IsType<UserUpdateData>(test);
            Assert.Equal("display name", test.DisplayName);
            Assert.Equal("email@email.com", test.Email);
            Assert.Equal("password", test.Password);
            Assert.Equal(Role.Reader, test.Role);

            Assert.True(test.DataAnnotationIsValid());
        }

        /// <summary>
        ///     Tests data annotation validation with a <see cref="UserUpdateData.DisplayName"/> exceeding the length limit.
        /// </summary>
        [Fact]
        public void DisplayNameTooLong()
        {
            UserUpdateData test = new UserUpdateData()
            {
                DisplayName = new string('a', 129),
            };

            Assert.False(test.DataAnnotationIsValid());
        }

        /// <summary>
        ///     Tests data annotation validation with a <see cref="UserUpdateData.DisplayName"/> of length less than the length minimum.
        /// </summary>
        [Fact]
        public void DisplayNameTooShort()
        {
            UserUpdateData test = new UserUpdateData()
            {
                DisplayName = string.Empty,
            };

            Assert.False(test.DataAnnotationIsValid());
        }

        /// <summary>
        ///     Tests data annotation validation with a <see cref="UserUpdateData.Email"/> which is not a valid email address.
        /// </summary>
        [Fact]
        public void EmailInvalid()
        {
            UserUpdateData test = new UserUpdateData()
            {
                Email = "email",
            };

            Assert.False(test.DataAnnotationIsValid());
        }

        /// <summary>
        ///     Tests data annotation validation with a <see cref="UserUpdateData.Password"/> exceeding the length limit.
        /// </summary>
        [Fact]
        public void PasswordTooLong()
        {
            UserUpdateData test = new UserUpdateData()
            {
                Password = new String('a', 513),
            };

            Assert.False(test.DataAnnotationIsValid());
        }

        /// <summary>
        ///     Tests data annotation validation with a <see cref="UserUpdateData.Password"/> of length less than the length minimum.
        /// </summary>
        [Fact]
        public void PasswordTooShort()
        {
            UserUpdateData test = new UserUpdateData()
            {
                Password = string.Empty,
            };

            Assert.False(test.DataAnnotationIsValid());
        }

        #endregion Public Methods
    }
}