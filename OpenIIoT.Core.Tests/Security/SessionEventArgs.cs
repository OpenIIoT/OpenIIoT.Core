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
      █  Unit tests for the SessionEventArgs class.
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

using System.Security.Claims;
using Microsoft.Owin.Security;
using Xunit;

namespace OpenIIoT.Core.Tests.Security
{
    /// <summary>
    ///     Unit tests for the <see cref="Core.Security.SessionEventArgs"/> class.
    /// </summary>
    public class SessionEventArgs
    {
        #region Public Methods

        /// <summary>
        ///     Test the constructor and all properties.
        /// </summary>
        [Fact]
        public void Constructor()
        {
            Core.Security.Session session = new Core.Security.Session("key", new AuthenticationTicket(new ClaimsIdentity(), new AuthenticationProperties()));
            Core.Security.SessionEventArgs test = new Core.Security.SessionEventArgs(session);

            Assert.IsType<Core.Security.SessionEventArgs>(test);
            Assert.Equal(session, test.Session);
        }

        #endregion Public Methods
    }
}