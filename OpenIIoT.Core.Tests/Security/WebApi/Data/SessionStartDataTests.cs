/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄████████                                                     ▄████████                                        ████████▄
      █     ███    ███                                                    ███    ███                                        ███   ▀███
      █     ███    █▀     ▄█████   ▄█████   ▄█████  █   ██████  ██▄▄▄▄    ███    █▀      ██      ▄█████     █████     ██    ███    ███   ▄█████      ██      ▄█████
      █     ███          ██   █    ██  ▀    ██  ▀  ██  ██    ██ ██▀▀▀█▄   ███        ▀███████▄   ██   ██   ██  ██ ▀███████▄ ███    ███   ██   ██ ▀███████▄   ██   ██
      █   ▀███████████  ▄██▄▄      ██       ██     ██▌ ██    ██ ██   ██ ▀███████████     ██  ▀   ██   ██  ▄██▄▄█▀     ██  ▀ ███    ███   ██   ██     ██  ▀   ██   ██
      █            ███ ▀▀██▀▀    ▀███████ ▀███████ ██  ██    ██ ██   ██          ███     ██    ▀████████ ▀███████     ██    ███    ███ ▀████████     ██    ▀████████
      █      ▄█    ███   ██   █     ▄  ██    ▄  ██ ██  ██    ██ ██   ██    ▄█    ███     ██      ██   ██   ██  ██     ██    ███   ▄███   ██   ██     ██      ██   ██
      █    ▄████████▀    ███████  ▄████▀   ▄████▀  █    ██████   █   █   ▄████████▀     ▄██▀     ██   █▀   ██  ██    ▄██▀   ████████▀    ██   █▀    ▄██▀     ██   █▀
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
      █  Unit tests for the SessionStartData class.
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
    using Xunit;

    /// <summary>
    ///     Unit tests for the <see cref="SessionStartData"/> class.
    /// </summary>
    public class SessionStartDataTests
    {
        #region Public Methods

        /// <summary>
        ///     Tests the constructor and all properties.
        /// </summary>
        [Fact]
        public void Constructor()
        {
            SessionStartData test = new SessionStartData() { Name = "name", Password = "password" };

            Assert.IsType<SessionStartData>(test);
            Assert.Equal("name", test.Name);
            Assert.Equal("password", test.Password);

            Assert.True(test.DataAnnotationIsValid());
        }

        /// <summary>
        ///     Tests data annotation validation with an empty <see cref="SessionStartData.Name"/>.
        /// </summary>
        [Fact]
        public void NameEmpty()
        {
            SessionStartData test = new SessionStartData() { Name = string.Empty, Password = "password" };

            Assert.False(test.DataAnnotationIsValid());
        }

        /// <summary>
        ///     Tests data annotation validation with a null <see cref="SessionStartData.Name"/>.
        /// </summary>
        [Fact]
        public void NameNull()
        {
            SessionStartData test = new SessionStartData() { Password = "password" };

            Assert.False(test.DataAnnotationIsValid());
        }

        /// <summary>
        ///     Tests data annotation validation with a <see cref="SessionStartData.Name"/> exceeding the length limit.
        /// </summary>
        [Fact]
        public void NameTooLong()
        {
            SessionStartData test = new SessionStartData() { Name = new string('a', 129) };

            Assert.False(test.DataAnnotationIsValid());
        }

        /// <summary>
        ///     Tests data annotation validation with an empty <see cref="SessionStartData.Password"/>.
        /// </summary>
        [Fact]
        public void PasswordEmpty()
        {
            SessionStartData test = new SessionStartData() { Name = "name", Password = string.Empty };

            Assert.False(test.DataAnnotationIsValid());
        }

        /// <summary>
        ///     Tests data annotation validation with a null <see cref="SessionStartData.Password"/>.
        /// </summary>
        [Fact]
        public void PasswordNull()
        {
            SessionStartData test = new SessionStartData() { Name = "name" };

            Assert.False(test.DataAnnotationIsValid());
        }

        /// <summary>
        ///     Tests data annotation validation with a <see cref="SessionStartData.Password"/> exceeding the length limit.
        /// </summary>
        [Fact]
        public void PasswordTooLong()
        {
            SessionStartData test = new SessionStartData() { Name = new string('a', 513) };

            Assert.False(test.DataAnnotationIsValid());
        }

        #endregion Public Methods
    }
}