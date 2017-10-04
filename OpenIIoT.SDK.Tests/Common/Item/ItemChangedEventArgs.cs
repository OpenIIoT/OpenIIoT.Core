/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █    ▄█                                  ▄████████
      █   ███                                  ███    ███
      █   ███▌     ██       ▄█████    ▄▄██▄▄▄  ███    █▀    ██   █      ▄█████  ██▄▄▄▄     ▄████▄     ▄█████ ██████▄
      █   ███▌ ▀███████▄   ██   █   ▄█▀▀██▀▀█▄ ███          ██   ██     ██   ██ ██▀▀▀█▄   ██    ▀    ██   █  ██   ▀██
      █   ███▌     ██  ▀  ▄██▄▄     ██  ██  ██ ███         ▄██▄▄▄██▄▄   ██   ██ ██   ██  ▄██        ▄██▄▄    ██    ██
      █   ███      ██    ▀▀██▀▀     ██  ██  ██ ███    █▄  ▀▀██▀▀▀██▀  ▀████████ ██   ██ ▀▀██ ███▄  ▀▀██▀▀    ██    ██
      █   ███      ██      ██   █   ██  ██  ██ ███    ███   ██   ██     ██   ██ ██   ██   ██    ██   ██   █  ██   ▄██
      █   █▀      ▄██▀     ███████   █  ██  █  ████████▀    ██   ██     ██   █▀  █   █    ██████▀    ███████ ██████▀
      █
      █      ▄████████                                        ▄████████
      █     ███    ███                                        ███    ███
      █     ███    █▀   █    █     ▄█████ ██▄▄▄▄      ██      ███    ███    █████    ▄████▄    ▄█████
      █    ▄███▄▄▄     ██    ██   ██   █  ██▀▀▀█▄ ▀███████▄   ███    ███   ██  ██   ██    ▀    ██  ▀
      █   ▀▀███▀▀▀     ██    ██  ▄██▄▄    ██   ██     ██  ▀ ▀███████████  ▄██▄▄█▀  ▄██         ██
      █     ███    █▄  ██    ██ ▀▀██▀▀    ██   ██     ██      ███    ███ ▀███████ ▀▀██ ███▄  ▀███████
      █     ███    ███  █▄  ▄█    ██   █  ██   ██     ██      ███    ███   ██  ██   ██    ██    ▄  ██
      █     ██████████   ▀██▀     ███████  █   █     ▄██▀     ███    █▀    ██  ██   ██████▀   ▄████▀
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
      █  Unit tests for the ItemChangedEventArgs class.
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

namespace OpenIIoT.SDK.Tests.Common
{
    using OpenIIoT.SDK.Common;
    using Xunit;

    /// <summary>
    ///     Unit tests for the <see cref="SDK.Common.ItemChangedEventArgs"/> class.
    /// </summary>
    [Collection("ItemChangedEventArgs")]
    public class ItemChangedEventArgs
    {
        #region Public Methods

        /// <summary>
        ///     Tests all constructor overloads.
        /// </summary>
        [Fact]
        public void Constructor()
        {
            SDK.Common.ItemChangedEventArgs args;

            args = new SDK.Common.ItemChangedEventArgs("new", "previous", ItemQuality.Good, ItemQuality.Good);

            Assert.IsType<SDK.Common.ItemChangedEventArgs>(args);
        }

        /// <summary>
        ///     Tests all properties.
        /// </summary>
        [Fact]
        public void Properties()
        {
            SDK.Common.ItemChangedEventArgs args = new SDK.Common.ItemChangedEventArgs("new", "previous", ItemQuality.Good, ItemQuality.Good);

            Assert.Equal("previous", args.PreviousValue);
            Assert.Equal("new", args.Value);
            Assert.Equal(false, args.QualityChanged);
        }

        #endregion Public Methods
    }
}