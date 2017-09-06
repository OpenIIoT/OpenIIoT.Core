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

using System;
using System.Collections.Generic;
using System.Reflection;
using Moq;
using OpenIIoT.Core.Platform;
using OpenIIoT.SDK;
using OpenIIoT.SDK.Common;
using OpenIIoT.SDK.Common.Exceptions;
using OpenIIoT.SDK.Configuration;
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
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ConfigurationManager"/> class.
        /// </summary>
        public ConfigurationManager()
        {
            SetupMocks();

            Core.Configuration.ConfigurationManager.Terminate();

            Manager = Core.Configuration.ConfigurationManager.Instantiate(ApplicationManager.Object, PlatformManager.Object);
        }

        #endregion Public Constructors

        #region Private Properties

        /// <summary>
        ///     Gets or sets the <see cref="IApplicationManager"/> mockup for the class.
        /// </summary>
        private Mock<IApplicationManager> ApplicationManager { get; set; }

        /// <summary>
        ///     Gets or sets the <see cref="IConfigurationManager"/> instance under test.
        /// </summary>
        private SDK.Configuration.IConfigurationManager Manager { get; set; }

        /// <summary>
        ///     Gets or sets the <see cref="IPlatformManager"/> mockup for the class.
        /// </summary>
        private Mock<IPlatformManager> PlatformManager { get; set; }

        /// <summary>
        ///     Gets or sets the <see cref="Core.Platform.PlatformSettings"/> mockup for the class.
        /// </summary>
        private Mock<PlatformSettings> PlatformSettings { get; set; }

        #endregion Private Properties

        #region Public Methods

        /// <summary>
        ///     Tests the constructor.
        /// </summary>
        [Fact]
        public void Constructor()
        {
            Assert.IsType<Core.Configuration.ConfigurationManager>(Manager);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Configuration.ConfigurationManager.Instantiate(IApplicationManager, IPlatformManager)"/> method.
        /// </summary>
        [Fact]
        public void Instantiate()
        {
            SetupMocks();

            Core.Configuration.ConfigurationManager.Terminate();

            Manager = Core.Configuration.ConfigurationManager.Instantiate(ApplicationManager.Object, PlatformManager.Object);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Configuration.ConfigurationManager.Setup"/> method using reflection.
        /// </summary>
        [Fact]
        public void Setup()
        {
            MethodInfo setup = typeof(Core.Configuration.ConfigurationManager).GetMethod("Setup", BindingFlags.NonPublic | BindingFlags.Instance);
            setup.Invoke(Manager, new object[] { });
        }

        /// <summary>
        ///     Tests the <see cref="Core.Configuration.ConfigurationManager.Startup()"/> method via
        ///     <see cref="Core.Common.Manager.Start()"/> .
        /// </summary>
        [Fact]
        public void Start()
        {
            IResult result = Manager.Start();

            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.Equal(State.Running, Manager.State);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Configuration.ConfigurationManager.Startup()"/> method with conditions which should force
        ///     an exception.
        /// </summary>
        [Fact]
        public void StartFailure()
        {
            Core.Configuration.ConfigurationManager.Terminate();

            Mock<IPlatform> platform = new Mock<IPlatform>();
            platform.Setup(p => p.FileExists(It.IsAny<string>())).Returns(false);
            platform.Setup(p => p.WriteFileText(It.IsAny<string>(), It.IsAny<string>())).Returns(new Result<string>().AddError(string.Empty));

            PlatformManager.Setup(p => p.Platform).Returns(platform.Object);

            Manager = Core.Configuration.ConfigurationManager.Instantiate(ApplicationManager.Object, PlatformManager.Object);

            Exception ex = Assert.Throws<ManagerStartException>(() => Manager.Start());

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
            platform.Setup(p => p.WriteFileText(It.IsAny<string>(), It.IsAny<string>())).Returns(new Result<string>());

            // inject the platform mockup into the platform manager mockup
            PlatformManager.Setup(p => p.Platform).Returns(platform.Object);

            // re-instantiate the manager with the mocked platform manager and platform
            Manager = Core.Configuration.ConfigurationManager.Instantiate(ApplicationManager.Object, PlatformManager.Object);

            IResult result = Manager.Start();

            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.Equal(State.Running, Manager.State);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Configuration.ConfigurationManager.Shutdown(StopType)"/> method via
        ///     <see cref="Core.Common.Manager.Stop(StopType)"/> .
        /// </summary>
        [Fact]
        public void Stop()
        {
            Manager.Start();

            Assert.Equal(State.Running, Manager.State);

            IResult result = Manager.Stop();

            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.Equal(State.Stopped, Manager.State);
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

        #region Private Methods

        /// <summary>
        ///     Configures the mockups for the unit tests.
        /// </summary>
        private void SetupMocks()
        {
            ApplicationManager = new Mock<IApplicationManager>();
            ApplicationManager.Setup(a => a.State).Returns(State.Running);
            ApplicationManager.Setup(a => a.IsInState(State.Starting, State.Running)).Returns(true);
            ApplicationManager.Setup(a => a.Managers).Returns(new List<IManager>());

            PlatformSettings = new Mock<PlatformSettings>();
            PlatformSettings.Setup(s => s.DirectoryData).Returns("Data");
            PlatformSettings.Setup(s => s.DirectoryLogs).Returns("Logs");
            PlatformSettings.Setup(s => s.DirectoryPackages).Returns("Packages");
            PlatformSettings.Setup(s => s.DirectoryPersistence).Returns("Persistence");
            PlatformSettings.Setup(s => s.DirectoryPlugins).Returns("Plugins");
            PlatformSettings.Setup(s => s.DirectoryTemp).Returns("Temp");
            PlatformSettings.Setup(s => s.DirectoryWeb).Returns("Web");

            PlatformManager = new Mock<IPlatformManager>();
            PlatformManager.Setup(p => p.State).Returns(State.Running);
            PlatformManager.Setup(p => p.IsInState(State.Starting, State.Running)).Returns(true);
            PlatformManager.Setup(p => p.Platform).Returns(new Core.Platform.Windows.WindowsPlatform());
        }

        #endregion Private Methods
    }
}