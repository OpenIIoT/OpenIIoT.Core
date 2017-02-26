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

using System;
using System.Collections.Generic;
using System.Reflection;
using Moq;
using OpenIIoT.SDK;
using OpenIIoT.SDK.Common;
using OpenIIoT.SDK.Common.Exceptions;
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
            applicationManager.Setup(a => a.Managers).Returns(new List<IManager>());

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
        ///     Tests the <see cref="Core.Configuration.ConfigurationManager.Setup"/> method using reflection.
        /// </summary>
        [Fact]
        public void Setup()
        {
            MethodInfo setup = typeof(Core.Configuration.ConfigurationManager).GetMethod("Setup", BindingFlags.NonPublic | BindingFlags.Instance);
            setup.Invoke(manager, new object[] { });
        }

        /// <summary>
        ///     Tests the <see cref="Core.Configuration.ConfigurationManager.Startup()"/> method via
        ///     <see cref="SDK.Common.Manager.Start()"/> .
        /// </summary>
        [Fact]
        public void Start()
        {
            // terminate and re-instantiate the manager instance in case it has been started by another test
            Core.Configuration.ConfigurationManager.Terminate();
            manager = Core.Configuration.ConfigurationManager.Instantiate(applicationManager.Object, platformManager.Object);

            IResult result = manager.Start();

            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.Equal(State.Running, manager.State);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Configuration.ConfigurationManager.Startup()"/> method with conditions which should force
        ///     an exception.
        /// </summary>
        [Fact]
        public void StartFailure()
        {
            Core.Configuration.ConfigurationManager.Terminate();

            // prepare a platform mockup which returns false for any call to FileExists() and a bad result for WriteFile(). these
            // two return values should force a ConfigurationLoadException
            Mock<IPlatform> platform = new Mock<IPlatform>();
            platform.Setup(p => p.FileExists(It.IsAny<string>())).Returns(false);
            platform.Setup(p => p.WriteFile(It.IsAny<string>(), It.IsAny<string>())).Returns(new Result<string>().AddError(string.Empty));

            // inject the platform mockup into the platform manager mockup
            platformManager.Setup(p => p.Platform).Returns(platform.Object);

            // re-instantiate the manager with the mocked platform manager and platform
            manager = Core.Configuration.ConfigurationManager.Instantiate(applicationManager.Object, platformManager.Object);

            Exception ex = Assert.Throws<ManagerStartException>(() => manager.Start());

            Assert.NotNull(ex);
            Assert.Equal(typeof(ConfigurationLoadException), ex.InnerException.GetType());
        }

        /// <summary>
        ///     Tests the <see cref="Core.Configuration.ConfigurationManager.Startup()"/> method with conditions which should force
        ///     a rebuild of the configuration.
        /// </summary>
        [Fact]
        public void StartRebuildConfiguration()
        {
            Core.Configuration.ConfigurationManager.Terminate();

            // prepare a platform mockup which returns false for any call to FileExists() and a good result for WriteFile(). these
            // two return values should force a rebuild of the config.
            Mock<IPlatform> platform = new Mock<IPlatform>();
            platform.Setup(p => p.FileExists(It.IsAny<string>())).Returns(false);
            platform.Setup(p => p.WriteFile(It.IsAny<string>(), It.IsAny<string>())).Returns(new Result<string>());

            // inject the platform mockup into the platform manager mockup
            platformManager.Setup(p => p.Platform).Returns(platform.Object);

            // re-instantiate the manager with the mocked platform manager and platform
            manager = Core.Configuration.ConfigurationManager.Instantiate(applicationManager.Object, platformManager.Object);

            IResult result = manager.Start();

            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.Equal(State.Running, manager.State);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Configuration.ConfigurationManager.Shutdown(StopType)"/> method via
        ///     <see cref="SDK.Common.Manager.Stop(StopType)"/> .
        /// </summary>
        [Fact]
        public void Stop()
        {
            manager.Start();
            IResult result = manager.Stop();

            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.Equal(State.Stopped, manager.State);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Configuration.ConfigurationManager.Terminate()"/> method.
        /// </summary>
        [Fact]
        public void Terminate()
        {
            Core.Configuration.ConfigurationManager.Terminate();
        }

        #endregion Public Methods
    }
}