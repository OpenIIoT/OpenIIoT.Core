/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄▄▄▄███▄▄▄▄
      █    ▄██▀▀▀███▀▀▀██▄
      █    ███   ███   ███    ▄█████   ▄█████   ▄█████   ▄█████     ▄████▄     ▄█████
      █    ███   ███   ███   ██   █    ██  ▀    ██  ▀    ██   ██   ██    ▀    ██   █
      █    ███   ███   ███  ▄██▄▄      ██       ██       ██   ██  ▄██        ▄██▄▄
      █    ███   ███   ███ ▀▀██▀▀    ▀███████ ▀███████ ▀████████ ▀▀██ ███▄  ▀▀██▀▀
      █    ███   ███   ███   ██   █     ▄  ██    ▄  ██   ██   ██   ██    ██   ██   █
      █     ▀█   ███   █▀    ███████  ▄████▀   ▄████▀    ██   █▀   ██████▀    ███████
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
      █  Unit tests for the Message class.
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

namespace OpenIIoT.SDK.Tests.Common.OperationResult
{
    using OpenIIoT.SDK.Common.OperationResult;
    using Xunit;

    /// <summary>
    ///     Unit tests for the <see cref="Message"/> class.
    /// </summary>
    public class MessageTests
    {
        #region Public Methods

        /// <summary>
        ///     Tests the constructor of <see cref="Message"/>.
        /// </summary>
        [Fact]
        public void Constructor()
        {
            Message testblank = new Message();

            Assert.Equal(MessageType.Info, testblank.Type);
            Assert.Equal(string.Empty, testblank.Text);

            Message testtype = new Message(MessageType.Warning);

            Assert.Equal(MessageType.Warning, testtype.Type);
            Assert.Equal(string.Empty, testtype.Text);

            Message test = new Message(MessageType.Error, "test!");

            Assert.Equal(MessageType.Error, test.Type);
            Assert.Equal("test!", test.Text);
        }

        /// <summary>
        ///     Tests <see cref="Message.ToString"/>.
        /// </summary>
        [Fact]
        public void ToStringTest()
        {
            Message test = new Message(MessageType.Info, "Test");

            Assert.Equal("[INFO] Test", test.ToString());
        }

        #endregion Public Methods
    }
}