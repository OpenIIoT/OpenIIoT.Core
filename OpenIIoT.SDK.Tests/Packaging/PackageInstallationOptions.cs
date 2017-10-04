/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄███████▄                                                               ▄█                                                                                                   ▄██████▄
      █     ███    ███                                                              ███                                                                                                  ███    ███
      █     ███    ███   ▄█████   ▄██████    █  █▄     ▄█████     ▄████▄     ▄█████ ███▌ ██▄▄▄▄    ▄█████     ██      ▄█████   █        █         ▄█████      ██     █   ██████  ██▄▄▄▄  ███    ███    █████▄     ██     █   ██████  ██▄▄▄▄    ▄█████
      █     ███    ███   ██   ██ ██    ██   ██ ▄██▀    ██   ██   ██    ▀    ██   █  ███▌ ██▀▀▀█▄   ██  ▀  ▀███████▄   ██   ██ ██       ██         ██   ██ ▀███████▄ ██  ██    ██ ██▀▀▀█▄ ███    ███   ██   ██ ▀███████▄ ██  ██    ██ ██▀▀▀█▄   ██  ▀
      █   ▀█████████▀    ██   ██ ██    ▀    ██▐█▀      ██   ██  ▄██        ▄██▄▄    ███▌ ██   ██   ██         ██  ▀   ██   ██ ██       ██         ██   ██     ██  ▀ ██▌ ██    ██ ██   ██ ███    ███   ██   ██     ██  ▀ ██▌ ██    ██ ██   ██   ██
      █     ███        ▀████████ ██    ▄  ▀▀████     ▀████████ ▀▀██ ███▄  ▀▀██▀▀    ███  ██   ██ ▀███████     ██    ▀████████ ██       ██       ▀████████     ██    ██  ██    ██ ██   ██ ███    ███ ▀██████▀      ██    ██  ██    ██ ██   ██ ▀███████
      █     ███          ██   ██ ██    ██   ██ ▀██▄    ██   ██   ██    ██   ██   █  ███  ██   ██    ▄  ██     ██      ██   ██ ██▌    ▄ ██▌    ▄   ██   ██     ██    ██  ██    ██ ██   ██ ███    ███   ██          ██    ██  ██    ██ ██   ██    ▄  ██
      █    ▄████▀        ██   █▀ ██████▀    ▀█   ▀█▀   ██   █▀   ██████▀    ███████ █▀    █   █   ▄████▀     ▄██▀     ██   █▀ ████▄▄██ ████▄▄██   ██   █▀    ▄██▀   █    ██████   █   █   ▀██████▀   ▄███▀       ▄██▀   █    ██████   █   █   ▄████▀
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
      █  Unit tests for the PackageInstallationOptions class.
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

namespace OpenIIoT.SDK.Tests.Packaging
{
    using Xunit;

    /// <summary>
    ///     Unit tests for the <see cref="SDK.Packaging.PackageInstallationOptions"/> class.
    /// </summary>
    public class PackageInstallationOptions
    {
        #region Public Methods

        /// <summary>
        ///     Tests the constructor and all properties.
        /// </summary>
        [Fact]
        public void Constructor()
        {
            SDK.Packaging.PackageInstallationOptions test = new SDK.Packaging.PackageInstallationOptions()
            {
                Overwrite = false,
                PublicKey = string.Empty,
                SkipVerification = false,
            };

            Assert.IsType<SDK.Packaging.PackageInstallationOptions>(test);
            Assert.False(test.Overwrite);
            Assert.Equal(string.Empty, test.PublicKey);
            Assert.False(test.SkipVerification);
        }

        #endregion Public Methods
    }
}