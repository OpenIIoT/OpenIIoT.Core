/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄███████▄                                                                         ▄▄▄▄███▄▄▄▄
      █     ███    ███                                                                       ▄██▀▀▀███▀▀▀██▄
      █     ███    ███  █         ▄█████      ██       ▄█████  ██████     █████    ▄▄██▄▄▄   ███   ███   ███   ▄█████  ██▄▄▄▄    ▄█████     ▄████▄     ▄█████    █████
      █     ███    ███ ██         ██   ██ ▀███████▄   ██   ▀█ ██    ██   ██  ██  ▄█▀▀██▀▀█▄  ███   ███   ███   ██   ██ ██▀▀▀█▄   ██   ██   ██    ▀    ██   █    ██  ██
      █   ▀█████████▀  ██         ██   ██     ██  ▀  ▄██▄▄    ██    ██  ▄██▄▄█▀  ██  ██  ██  ███   ███   ███   ██   ██ ██   ██   ██   ██  ▄██        ▄██▄▄     ▄██▄▄█▀
      █     ███        ██       ▀████████     ██    ▀▀██▀▀    ██    ██ ▀███████  ██  ██  ██  ███   ███   ███ ▀████████ ██   ██ ▀████████ ▀▀██ ███▄  ▀▀██▀▀    ▀███████
      █     ███        ██▌    ▄   ██   ██     ██      ██      ██    ██   ██  ██  ██  ██  ██  ███   ███   ███   ██   ██ ██   ██   ██   ██   ██    ██   ██   █    ██  ██
      █    ▄████▀      ████▄▄██   ██   █▀    ▄██▀     ██       ██████    ██  ██   █  ██  █    ▀█   ███   █▀    ██   █▀  █   █    ██   █▀   ██████▀    ███████   ██  ██
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
      █
      █  Unit tests for the PlatformManager class.
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

using System.Reflection;
using Moq;
using OpenIIoT.SDK;
using OpenIIoT.SDK.Common;
using OpenIIoT.SDK.Platform;
using Utility.OperationResult;
using Xunit;

namespace OpenIIoT.Core.Tests.Platform
{
    /// <summary>
    ///     Unit tests for the <see cref="Core.Platform.PlatformManager"/> class.
    /// </summary>
    [Collection("PlatformManager")]
    public class PlatformManager
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="PlatformManager"/> class.
        /// </summary>
        public PlatformManager()
        {
            SetupMocks();

            Core.Platform.PlatformManager.Terminate();

            Manager = Core.Platform.PlatformManager.Instantiate(ApplicationManager.Object);
        }

        #endregion Public Constructors

        #region Private Properties

        /// <summary>
        ///     Gets or sets the <see cref="IApplicationManager"/> mockup for the unit tests.
        /// </summary>
        private Mock<IApplicationManager> ApplicationManager { get; set; }

        /// <summary>
        ///     Gets or sets the <see cref="IPlatformManager"/> instance under test.
        /// </summary>
        private IPlatformManager Manager { get; set; }

        #endregion Private Properties

        #region Public Methods

        /// <summary>
        ///     Tests the constructor.
        /// </summary>
        [Fact]
        public void Constructor()
        {
            Assert.IsType<Core.Platform.PlatformManager>(Manager);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Platform.PlatformManager.Instantiate(IApplicationManager)"/> method.
        /// </summary>
        [Fact]
        public void Instantiate()
        {
            SetupMocks();

            Core.Platform.PlatformManager.Terminate();

            Manager = Core.Platform.PlatformManager.Instantiate(ApplicationManager.Object);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Platform.PlatformManager.Instantiate(IApplicationManager)"/> method.
        /// </summary>
        [Fact]
        public void InstantiateTwice()
        {
            ApplicationManager = new Mock<IApplicationManager>();
            ApplicationManager.Setup(a => a.State).Returns(State.Running);
            ApplicationManager.Setup(a => a.IsInState(State.Starting, State.Running)).Returns(true);
            ApplicationManager.Setup(a => a.Settings).Returns(new Core.ApplicationSettings());

            Core.Platform.PlatformManager.Terminate();

            Manager = Core.Platform.PlatformManager.Instantiate(ApplicationManager.Object);

            IPlatformManager manager2 = Core.Platform.PlatformManager.Instantiate(ApplicationManager.Object);

            Assert.Equal(Manager, manager2);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Platform.PlatformManager.Setup"/> method using reflection.
        /// </summary>
        [Fact]
        public void Setup()
        {
            MethodInfo setup = typeof(Core.Platform.PlatformManager).GetMethod("Setup", BindingFlags.NonPublic | BindingFlags.Instance);
            setup.Invoke(Manager, new object[] { });
        }

        /// <summary>
        ///     Tests the <see cref="Core.Platform.PlatformManager.Startup()"/> method via
        ///     <see cref="Core.Common.Manager.Start()"/> .
        /// </summary>
        [Fact]
        public void Start()
        {
            IResult result = Manager.Start();

            Assert.NotEqual(ResultCode.Failure, result.ResultCode);
            Assert.Equal(State.Running, Manager.State);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Platform.PlatformManager.Shutdown(StopType)"/> method via
        ///     <see cref="Core.Common.Manager.Stop(StopType)"/> .
        /// </summary>
        [Fact]
        public void Stop()
        {
            Manager.Start();
            IResult result = Manager.Stop();

            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.Equal(State.Stopped, Manager.State);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Platform.PlatformManager.Terminate()"/> method.
        /// </summary>
        [Fact]
        public void Terminate()
        {
            Core.Platform.PlatformManager.Terminate();
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
            ApplicationManager.Setup(a => a.Settings).Returns(new Core.ApplicationSettings());
        }

        #endregion Private Methods
    }
}