/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █   ▄████████                                                                                                         ▄▄▄▄███▄▄▄▄
      █   ███    ███                                                                                                      ▄██▀▀▀███▀▀▀██▄
      █   ███    █▀   ██████  ██▄▄▄▄     ▄█████  █     ▄████▄  ██   █     █████   ▄█████      ██     █   ██████  ██▄▄▄▄   ███   ███   ███   ▄█████  ██▄▄▄▄    ▄█████     ▄████▄     ▄█████    █████
      █   ███        ██    ██ ██▀▀▀█▄   ██   ▀█ ██    ██    ▀  ██   ██   ██  ██   ██   ██ ▀███████▄ ██  ██    ██ ██▀▀▀█▄  ███   ███   ███   ██   ██ ██▀▀▀█▄   ██   ██   ██    ▀    ██   █    ██  ██
      █   ███        ██    ██ ██   ██  ▄██▄▄    ██▌  ▄██       ██   ██  ▄██▄▄█▀   ██   ██     ██  ▀ ██▌ ██    ██ ██   ██  ███   ███   ███   ██   ██ ██   ██   ██   ██  ▄██        ▄██▄▄     ▄██▄▄█▀
      █   ███    █▄  ██    ██ ██   ██ ▀▀██▀▀    ██  ▀▀██ ███▄  ██   ██ ▀███████ ▀████████     ██    ██  ██    ██ ██   ██  ███   ███   ███ ▀████████ ██   ██ ▀████████ ▀▀██ ███▄  ▀▀██▀▀    ▀███████
      █   ███    ███ ██    ██ ██   ██   ██      ██    ██    ██ ██   ██   ██  ██   ██   ██     ██    ██  ██    ██ ██   ██  ███   ███   ███   ██   ██ ██   ██   ██   ██   ██    ██   ██   █    ██  ██
      █   ████████▀   ██████   █   █    ██      █     ██████▀  ██████    ██  ██   ██   █▀    ▄██▀   █    ██████   █   █    ▀█   ███   █▀    ██   █▀  █   █    ██   █▀   ██████▀    ███████   ██  ██
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
      █  Unit tests for the ConfigurationManager class.
      █
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀ ▀ ▀▀▀     ▀▀               ▀
      █  The GNU Affero General Public License (GNU AGPL)
      █
      █  Copyright (C) 2016 JP Dillingham (jp@dillingham.ws)
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

using Moq;
using OpenIIoT.SDK;
using OpenIIoT.SDK.Common;
using OpenIIoT.SDK.Platform;
using Utility.OperationResult;
using Xunit;

namespace OpenIIoT.Core.Tests.Configuration
{
    /// <summary>
    ///     Unit tests for the <see cref="Core.Configuration.ConfigurationManager"/> class.
    /// </summary>
    [Collection("ConfigurationManager")]
    public class ConfigurationManager
    {
        #region Private Fields

        /// <summary>
        ///     The <see cref="IApplicationManager"/> mockup to be used as the dependency for the <see cref="Core.Configuration.ConfigurationManager"/>.
        /// </summary>
        private Mock<IApplicationManager> applicationManager;

        /// <summary>
        ///     The <see cref="SDK.Configuration.IConfigurationManager"/> instance under test.
        /// </summary>
        private SDK.Configuration.IConfigurationManager manager;

        /// <summary>
        ///     The <see cref="IPlatformManager"/> mockup to be used as the dependency for the <see cref="Core.Configuration.ConfigurationManager"/>.
        /// </summary>
        private Mock<IPlatformManager> platformManager;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ConfigurationManager"/> class.
        /// </summary>
        public ConfigurationManager()
        {
            applicationManager = new Mock<IApplicationManager>();
            applicationManager.Setup(a => a.State).Returns(State.Running);
            applicationManager.Setup(a => a.IsInState(State.Starting, State.Running)).Returns(true);

            platformManager = new Mock<IPlatformManager>();
            platformManager.Setup(p => p.State).Returns(State.Running);
            platformManager.Setup(p => p.IsInState(State.Starting, State.Running)).Returns(true);
            platformManager.Setup(p => p.Platform).Returns(new Core.Platform.Windows.WindowsPlatform());

            manager = Core.Configuration.ConfigurationManager.Instantiate(applicationManager.Object, platformManager.Object);
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///     Tests the constructor.
        /// </summary>
        [Fact]
        public void Constructor()
        {
            Assert.IsType<Core.Configuration.ConfigurationManager>(manager);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Configuration.ConfigurationManager.Startup()"/> method via
        ///     <see cref="SDK.Common.Manager.Start()"/> .
        /// </summary>
        [Fact]
        public void Start()
        {
            Result result = manager.Start();

            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.Equal(State.Running, manager.State);
        }

        [Fact]
        public void StartFailure()
        {
            // prepare a platform mockup which returns false for any call to FileExists() and a bad result for WriteFile()
            Mock<IPlatform> platform = new Mock<IPlatform>();
            platform.Setup(p => p.FileExists(It.IsAny<string>())).Returns(false);
            platform.Setup(p => p.WriteFile(It.IsAny<string>(), It.IsAny<string>())).Returns(new Result<string>().AddError(string.Empty));

            // inject the platform mockup into the platform manager mockup platformManager.Setup(p => p.Platform).Returns(platform.Object);

            Result result = manager.Start();

            Assert.Equal(ResultCode.Failure, result.ResultCode);
            Assert.Equal(State.Initialized, manager.State);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Configuration.ConfigurationManager.Shutdown(StopType)"/> method via
        ///     <see cref="SDK.Common.Manager.Stop(StopType)"/> .
        /// </summary>
        [Fact]
        public void Stop()
        {
            manager.Start();
            Result result = manager.Stop();

            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.Equal(State.Stopped, manager.State);
        }

        #endregion Public Methods
    }
}