/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄███████▄                                                                ▄████████
      █     ███    ███                                                                ███    ███
      █     ███    ███   ▄█████   ▄██████    █  █▄     ▄█████     ▄████▄     ▄█████   ███    ███    █████  ▄██████   ██   █     █   █    █     ▄█████
      █     ███    ███   ██   ██ ██    ██   ██ ▄██▀    ██   ██   ██    ▀    ██   █    ███    ███   ██  ██ ██    ██   ██   ██   ██  ██    ██   ██   █
      █   ▀█████████▀    ██   ██ ██    ▀    ██▐█▀      ██   ██  ▄██        ▄██▄▄    ▀███████████  ▄██▄▄█▀ ██    ▀   ▄██▄▄▄██▄▄ ██▌ ██    ██  ▄██▄▄
      █     ███        ▀████████ ██    ▄  ▀▀████     ▀████████ ▀▀██ ███▄  ▀▀██▀▀      ███    ███ ▀███████ ██    ▄  ▀▀██▀▀▀██▀  ██  ██    ██ ▀▀██▀▀
      █     ███          ██   ██ ██    ██   ██ ▀██▄    ██   ██   ██    ██   ██   █    ███    ███   ██  ██ ██    ██   ██   ██   ██   █▄  ▄█    ██   █
      █    ▄████▀        ██   █▀ ██████▀    ▀█   ▀█▀   ██   █▀   ██████▀    ███████   ███    █▀    ██  ██ ██████▀    ██   ██   █     ▀██▀     ███████
      █
      █    ▄█    █▄                                                                                         ████████▄
      █   ███    ███                                                                                        ███   ▀███
      █   ███    ███    ▄█████    █████  █     ▄█████  █   ▄██████   ▄█████      ██     █   ██████  ██▄▄▄▄  ███    ███   ▄█████      ██      ▄█████
      █   ███    ███   ██   █    ██  ██ ██    ██   ▀█ ██  ██    ██   ██   ██ ▀███████▄ ██  ██    ██ ██▀▀▀█▄ ███    ███   ██   ██ ▀███████▄   ██   ██
      █   ███    ███  ▄██▄▄     ▄██▄▄█▀ ██▌  ▄██▄▄    ██▌ ██    ▀    ██   ██     ██  ▀ ██▌ ██    ██ ██   ██ ███    ███   ██   ██     ██  ▀   ██   ██
      █   ███    ███ ▀▀██▀▀    ▀███████ ██  ▀▀██▀▀    ██  ██    ▄  ▀████████     ██    ██  ██    ██ ██   ██ ███    ███ ▀████████     ██    ▀████████
      █    ██▄  ▄██    ██   █    ██  ██ ██    ██      ██  ██    ██   ██   ██     ██    ██  ██    ██ ██   ██ ███   ▄███   ██   ██     ██      ██   ██
      █     ▀████▀     ███████   ██  ██ █     ██      █   ██████▀    ██   █▀    ▄██▀   █    ██████   █   █  ████████▀    ██   █▀    ▄██▀     ██   █▀
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
      █  Unit tests for the PackageArchiveVerificationData class.
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

namespace OpenIIoT.Core.Tests.Packaging.WebApi.Data
{
    using OpenIIoT.Core.Packaging.WebApi.Data;
    using OpenIIoT.SDK.Common.OperationResult;
    using OpenIIoT.SDK.Packaging;
    using Xunit;

    /// <summary>
    ///     Unit tests for the <see cref="PackageArchiveVerificationData"/> class.
    /// </summary>
    public class PackageArchiveVerificationDataTests
    {
        #region Public Methods

        /// <summary>
        ///     Tests the constructor with a failing Result.
        /// </summary>
        [Fact]
        public void ConstructorBadResult()
        {
            PackageArchiveVerificationData test = new PackageArchiveVerificationData(
                    new Result<bool>()
                        .SetReturnValue(false)
                        .AddError("failed"));

            Assert.Equal(PackageVerification.Refuted, test.Verification);
            Assert.Equal(1, test.Messages.Count);
        }

        /// <summary>
        ///     Tests the constructor with a suceeding Result.
        /// </summary>
        [Fact]
        public void ConstructorGoodResult()
        {
            PackageArchiveVerificationData test = new PackageArchiveVerificationData(
                new Result<bool>()
                    .SetReturnValue(true));

            Assert.Equal(PackageVerification.Verified, test.Verification);
        }

        #endregion Public Methods
    }
}