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

using System.Reflection;
using Moq;
using OpenIIoT.SDK;
using OpenIIoT.SDK.Common;
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
        #region Private Fields

        /// <summary>
        ///     The <see cref="IApplicationManager"/> mockup to be used as the dependency for the <see cref="Core.Platform.PlatformManager"/>.
        /// </summary>
        private Mock<IApplicationManager> applicationManager;

        /// <summary>
        ///     The <see cref="SDK.Platform.IPlatformManager"/> instance under test.
        /// </summary>
        private SDK.Platform.IPlatformManager manager;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="PlatformManager"/> class.
        /// </summary>
        public PlatformManager()
        {
            applicationManager = new Mock<IApplicationManager>();
            applicationManager.Setup(a => a.State).Returns(State.Running);
            applicationManager.Setup(a => a.IsInState(State.Starting, State.Running)).Returns(true);

            manager = Core.Platform.PlatformManager.Instantiate(applicationManager.Object);
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///     Tests the constructor.
        /// </summary>
        [Fact]
        public void Constructor()
        {
            Assert.IsType<Core.Platform.PlatformManager>(manager);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Platform.PlatformManager.Setup"/> method using reflection.
        /// </summary>
        [Fact]
        public void Setup()
        {
            MethodInfo setup = typeof(Core.Platform.PlatformManager).GetMethod("Setup", BindingFlags.NonPublic | BindingFlags.Instance);
            setup.Invoke(manager, new object[] { });
        }

        /// <summary>
        ///     Tests the <see cref="Core.Platform.PlatformManager.Startup()"/> method via <see cref="SDK.Common.Manager.Start()"/> .
        /// </summary>
        [Fact]
        public void Start()
        {
            IResult result = manager.Start();

            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.Equal(State.Running, manager.State);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Platform.PlatformManager.Startup()"/> method with a bad instance of PlatformDirectories
        ///     via <see cref="SDK.Common.Manager.Start()"/> .
        /// </summary>
        [Fact]
        public void StartBadDirectories()
        {
            manager.Platform.SetDirectories(new Core.Platform.PlatformDirectories());

            IResult result = manager.Start();

            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Platform.PlatformManager.Shutdown(StopType)"/> method via
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
        ///     Tests the <see cref="Core.Platform.PlatformManager.Terminate()"/> method.
        /// </summary>
        [Fact]
        public void Terminate()
        {
            Core.Platform.PlatformManager.Terminate();
        }

        #endregion Public Methods
    }
}