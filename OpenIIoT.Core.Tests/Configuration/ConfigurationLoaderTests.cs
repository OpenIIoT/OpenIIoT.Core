/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █   ▄████████                                                                                                       ▄█
      █   ███    ███                                                                                                     ███
      █   ███    █▀   ██████  ██▄▄▄▄     ▄█████  █     ▄████▄  ██   █     █████   ▄█████      ██     █   ██████  ██▄▄▄▄  ███        ██████    ▄█████  ██████▄     ▄█████    █████
      █   ███        ██    ██ ██▀▀▀█▄   ██   ▀█ ██    ██    ▀  ██   ██   ██  ██   ██   ██ ▀███████▄ ██  ██    ██ ██▀▀▀█▄ ███       ██    ██   ██   ██ ██   ▀██   ██   █    ██  ██
      █   ███        ██    ██ ██   ██  ▄██▄▄    ██▌  ▄██       ██   ██  ▄██▄▄█▀   ██   ██     ██  ▀ ██▌ ██    ██ ██   ██ ███       ██    ██   ██   ██ ██    ██  ▄██▄▄     ▄██▄▄█▀
      █   ███    █▄  ██    ██ ██   ██ ▀▀██▀▀    ██  ▀▀██ ███▄  ██   ██ ▀███████ ▀████████     ██    ██  ██    ██ ██   ██ ███       ██    ██ ▀████████ ██    ██ ▀▀██▀▀    ▀███████
      █   ███    ███ ██    ██ ██   ██   ██      ██    ██    ██ ██   ██   ██  ██   ██   ██     ██    ██  ██    ██ ██   ██ ███▌    ▄ ██    ██   ██   ██ ██   ▄██   ██   █    ██  ██
      █   ████████▀   ██████   █   █    ██      █     ██████▀  ██████    ██  ██   ██   █▀    ▄██▀   █    ██████   █   █  █████▄▄██  ██████    ██   █▀ ██████▀    ███████   ██  ██
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
      █  Unit tests for the ConfigurationLoader class.
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

namespace OpenIIoT.Core.Tests.Configuration
{
    using System;
    using System.Collections.Generic;
    using Moq;
    using OpenIIoT.Core.Configuration;
    using OpenIIoT.SDK.Common.Exceptions;
    using OpenIIoT.SDK.Common.OperationResult;
    using OpenIIoT.SDK.Platform;
    using Xunit;

    /// <summary>
    ///     Unit tests for the <see cref="ConfigurationLoader"/> class.
    /// </summary>
    public class ConfigurationLoaderTests
    {
        #region Public Methods

        /// <summary>
        ///     Tests the <see cref="ConfigurationLoader.BuildNew"/> method.
        /// </summary>
        [Fact]
        public void BuildNew()
        {
            Mock<IPlatform> platform = new Mock<IPlatform>();

            ConfigurationLoader loader = new ConfigurationLoader(platform.Object);

            IResult<IDictionary<string, IDictionary<string, object>>> result = loader.BuildNew();

            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.NotNull(result.ReturnValue);
            Assert.IsAssignableFrom<IDictionary<string, IDictionary<string, object>>>(result.ReturnValue);
        }

        /// <summary>
        ///     Tests the constructor.
        /// </summary>
        [Fact]
        public void Constructor()
        {
            Mock<IPlatform> platform = new Mock<IPlatform>();

            ConfigurationLoader loader = new ConfigurationLoader(platform.Object);

            Assert.IsType<ConfigurationLoader>(loader);
        }

        /// <summary>
        ///     Tests the <see cref="ConfigurationLoader.Load(string)"/> method.
        /// </summary>
        [Fact]
        public void Load()
        {
            Mock<IPlatform> platform = new Mock<IPlatform>();
            platform.Setup(p => p.WriteFileText(It.IsAny<string>(), It.IsAny<string>())).Returns(new Result<string>());
            platform.Setup(p => p.FileExists(It.IsAny<string>())).Returns(true);
            platform.Setup(p => p.ReadFileText(It.IsAny<string>())).Returns(new Result<string>().SetReturnValue("{}"));

            ConfigurationLoader loader = new ConfigurationLoader(platform.Object);

            IResult result = loader.Load("file.ext");

            Assert.Equal(ResultCode.Success, result.ResultCode);
        }

        /// <summary>
        ///     Tests the <see cref="ConfigurationLoader.Load(string)"/> method with a mockup which indicates the specified file
        ///     could not be found.
        /// </summary>
        [Fact]
        public void LoadFileNotFound()
        {
            Mock<IPlatform> platform = new Mock<IPlatform>();
            platform.Setup(p => p.WriteFileText(It.IsAny<string>(), It.IsAny<string>())).Returns(new Result<string>());
            platform.Setup(p => p.FileExists(It.IsAny<string>())).Returns(false);

            ConfigurationLoader loader = new ConfigurationLoader(platform.Object);

            IResult result = loader.Load("file.ext");

            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        /// <summary>
        ///     Tests the <see cref="ConfigurationLoader.Load(string)"/> method with a mockup which simulates a failure to read the
        ///     specified file.
        /// </summary>
        [Fact]
        public void LoadReadFailure()
        {
            Mock<IPlatform> platform = new Mock<IPlatform>();
            platform.Setup(p => p.WriteFileText(It.IsAny<string>(), It.IsAny<string>())).Returns(new Result<string>());
            platform.Setup(p => p.FileExists(It.IsAny<string>())).Returns(true);
            platform.Setup(p => p.ReadFileText(It.IsAny<string>())).Returns(new Result<string>().SetResultCode(ResultCode.Failure));

            ConfigurationLoader loader = new ConfigurationLoader(platform.Object);

            Exception ex = Record.Exception(() => loader.Load("file.ext"));

            Assert.NotNull(ex);
            Assert.IsType<ConfigurationLoadException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="ConfigurationLoader.Save(IDictionary{string, IDictionary{string, object}}, string)"/> method.
        /// </summary>
        [Fact]
        public void Save()
        {
            Mock<IPlatform> platform = new Mock<IPlatform>();
            platform.Setup(p => p.WriteFileText(It.IsAny<string>(), It.IsAny<string>())).Returns(new Result<string>());

            ConfigurationLoader loader = new ConfigurationLoader(platform.Object);

            IDictionary<string, IDictionary<string, object>> configuration = new Dictionary<string, IDictionary<string, object>>();

            IResult result = loader.Save(configuration, "file.ext");

            Assert.Equal(ResultCode.Success, result.ResultCode);
        }

        #endregion Public Methods
    }
}