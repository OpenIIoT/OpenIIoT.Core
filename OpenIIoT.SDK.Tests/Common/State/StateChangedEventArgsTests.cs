/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄████████                                         ▄████████
      █     ███    ███                                         ███    ███
      █     ███    █▀      ██      ▄█████      ██       ▄█████ ███    █▀    ██   █      ▄█████  ██▄▄▄▄     ▄████▄     ▄█████ ██████▄
      █     ███        ▀███████▄   ██   ██ ▀███████▄   ██   █  ███          ██   ██     ██   ██ ██▀▀▀█▄   ██    ▀    ██   █  ██   ▀██
      █   ▀███████████     ██  ▀   ██   ██     ██  ▀  ▄██▄▄    ███         ▄██▄▄▄██▄▄   ██   ██ ██   ██  ▄██        ▄██▄▄    ██    ██
      █            ███     ██    ▀████████     ██    ▀▀██▀▀    ███    █▄  ▀▀██▀▀▀██▀  ▀████████ ██   ██ ▀▀██ ███▄  ▀▀██▀▀    ██    ██
      █      ▄█    ███     ██      ██   ██     ██      ██   █  ███    ███   ██   ██     ██   ██ ██   ██   ██    ██   ██   █  ██   ▄██
      █    ▄████████▀     ▄██▀     ██   █▀    ▄██▀     ███████ ████████▀    ██   ██     ██   █▀  █   █    ██████▀    ███████ ██████▀
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
      █  Unit tests for the StateChangedEventArgs class.
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
    ///     Unit tests for the <see cref="StateChangedEventArgs"/> class.
    /// </summary>
    public class StateChangedEventArgsTests
    {
        #region Public Methods

        /// <summary>
        ///     Tests all constructor overloads.
        /// </summary>
        [Fact]
        public void Constructor()
        {
            StateChangedEventArgs args;

            args = new StateChangedEventArgs(State.Initialized, State.Undefined);
            Assert.IsType<StateChangedEventArgs>(args);

            args = new StateChangedEventArgs(State.Initialized, State.Undefined, "message");
            Assert.IsType<StateChangedEventArgs>(args);

            args = new StateChangedEventArgs(State.Initialized, State.Undefined, "message", StopType.Shutdown);
            Assert.IsType<StateChangedEventArgs>(args);
        }

        /// <summary>
        ///     Tests all properties.
        /// </summary>
        [Fact]
        public void Properties()
        {
            StateChangedEventArgs args = new StateChangedEventArgs(State.Initialized, State.Undefined, "message", StopType.Shutdown);

            Assert.Equal(State.Initialized, args.State);
            Assert.Equal(State.Undefined, args.PreviousState);
        }

        #endregion Public Methods
    }
}