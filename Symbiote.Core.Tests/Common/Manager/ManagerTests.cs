/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄▄▄▄███▄▄▄▄
      █    ▄██▀▀▀███▀▀▀██▄
      █    ███   ███   ███   ▄█████  ██▄▄▄▄    ▄█████     ▄████▄     ▄█████    █████
      █    ███   ███   ███   ██   ██ ██▀▀▀█▄   ██   ██   ██    ▀    ██   █    ██  ██
      █    ███   ███   ███   ██   ██ ██   ██   ██   ██  ▄██        ▄██▄▄     ▄██▄▄█▀
      █    ███   ███   ███ ▀████████ ██   ██ ▀████████ ▀▀██ ███▄  ▀▀██▀▀    ▀███████
      █    ███   ███   ███   ██   ██ ██   ██   ██   ██   ██    ██   ██   █    ██  ██
      █     ▀█   ███   █▀    ██   █▀  █   █    ██   █▀   ██████▀    ███████   ██  ██
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
      █  Unit tests for the Manager class.
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

using Symbiote.SDK;
using Symbiote.Core.Tests.Common.Mockups;
using System.Threading;
using Utility.OperationResult;
using Xunit;
using Moq;

namespace Symbiote.Core.Tests.Common
{
    /// <summary>
    ///     Unit tests for the Manager class.
    /// </summary>
    [Collection("Manager")]
    public class ManagerTests
    {
        #region Private Fields

        private Mock<IApplicationManager> applicationManagerMock;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ManagerTests"/> class.
        /// </summary>
        public ManagerTests()
        {
            applicationManagerMock = new Mock<IApplicationManager>();
            applicationManagerMock.Setup(m => m.State).Returns(State.Running);
            applicationManagerMock.Setup(m => m.IsInState(new State[] { State.Starting, State.Running })).Returns(true);
            applicationManagerMock.Setup(m => m.IsInState(new State[] { State.Running })).Returns(true);
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///     Tests the class constructor and property accessors.
        /// </summary>
        [Fact]
        public void Constructor()
        {
            ManagerMock test = ManagerMock.Instantiate(applicationManagerMock.Object);

            Assert.Equal("Mock Manager", test.ManagerName);
            Assert.Equal(test.GetType().Name, test.EventProviderName);

            Assert.Equal(true, test.CheckDependency());
            Assert.Throws<DependencyNotResolvedException>(() => test.CheckBadDependency());

            test.Dispose();
        }

        /// <summary>
        ///     Tests the behavior of the Manager when a dependency faults.
        /// </summary>
        [Fact]
        public void DependencyFault()
        {
            OtherManagerMock o = OtherManagerMock.Instantiate(applicationManagerMock.Object);
            o.Start();

            ManagerMockWithDependency test = ManagerMockWithDependency.Instantiate(applicationManagerMock.Object, o);

            // start the manager and assert that it is running
            Result start = test.Start();
            Assert.Equal(State.Running, test.State);

            // fault the manager upon which the test manager is dependent ensure that this manager stops.start the other manager
            // and ensure that this manager remains stopped.
            o.Fault();
            Assert.Equal(State.Faulted, o.State);
            Assert.Equal(State.Stopped, test.State);
            Assert.Equal(true, test.AutomaticRestartPending);

            o.Start();
            Assert.Equal(State.Running, o.State);

            // wait 1500ms for the manager to restart (the restart timer is set for 500ms)
            Thread.Sleep(1000);

            // assert that the manager has restarted.
            Assert.Equal(State.Running, test.State);
        }

        /// <summary>
        ///     Tests the behavior of the Manager when a dependency stops.
        /// </summary>
        [Fact]
        public void DependencyStop()
        {
            OtherManagerMock o = OtherManagerMock.Instantiate(applicationManagerMock.Object);
            o.Start();

            ManagerMockWithDependency test = ManagerMockWithDependency.Instantiate(applicationManagerMock.Object, o);

            // start the manager and assert that it is running
            Result start = test.Start();
            Assert.Equal(State.Running, test.State);

            // stop the other manager (the manager upon which this test manager is dependent) ensure that this manager stops.
            // restart the other manager and ensure that this manager remains stopped.
            o.Stop();
            Assert.Equal(State.Stopped, o.State);
            Assert.Equal(State.Stopped, test.State);
            Assert.Equal(false, test.AutomaticRestartPending);

            o.Start();
            Assert.Equal(State.Running, o.State);
            Assert.Equal(State.Stopped, test.State);

            // restart this manager in preparation for the next
            test.Start();
            Assert.Equal(State.Running, test.State);

            // stop the other manager with the restart flag
            o.Stop(StopType.Restart);
            Assert.Equal(State.Stopped, o.State);
            Assert.Equal(State.Stopped, test.State);
            Assert.Equal(true, test.AutomaticRestartPending);

            o.Start();
            Assert.Equal(State.Running, o.State);

            // wait 1500ms for the manager to restart (the restart timer is set for 500ms)
            Thread.Sleep(1000);

            // assert that the manager has restarted.
            Assert.Equal(State.Running, test.State);
        }

        /// <summary>
        ///     Tests <see cref="Manager.Restart(StopType)"/>.
        /// </summary>
        [Fact]
        public void Restart()
        {
            ManagerMock test = ManagerMock.Instantiate(applicationManagerMock.Object);

            // start the manager and assert that it is running
            test.Start();
            Assert.Equal(State.Running, test.State);

            // restart the manager and assert that the operation succeeded
            Result restart = test.Restart();
            Assert.Equal(ResultCode.Success, restart.ResultCode);
            Assert.Equal(State.Running, test.State);
        }

        /// <summary>
        ///     Tests <see cref="Manager.Restart(StopType)"/> with the manager in the stopped State.
        /// </summary>
        [Fact]
        public void RestartNotRunning()
        {
            ManagerMock test = ManagerMock.Instantiate(applicationManagerMock.Object);

            Result restart = test.Restart();
            Assert.Equal(ResultCode.Failure, restart.ResultCode);
        }

        /// <summary>
        ///     Tests <see cref="Manager.Start"/>.
        /// </summary>
        [Fact]
        public void Start()
        {
            ManagerMock test = ManagerMock.Instantiate(applicationManagerMock.Object);

            // start the manager and assert that it is running
            Result start = test.Start();
            Assert.Equal(State.Running, test.State);

            // try to start again and assert that the operation fails
            Result startAgain = test.Start();
            Assert.Equal(ResultCode.Failure, startAgain.ResultCode);
        }

        /// <summary>
        ///     Tests <see cref="Manager.Start"/> with a dependency in the stopped State.
        /// </summary>
        [Fact]
        public void StartWithStoppedDependency()
        {
            Mock<IApplicationManager> a = new Mock<IApplicationManager>();
            a.Setup(m => m.State).Returns(State.Stopped);

            ManagerMock test = ManagerMock.Instantiate(a.Object);

            // start the manager and assert that it is running
            Result start = test.Start();
            Assert.Equal(ResultCode.Failure, start.ResultCode);
        }

        /// <summary>
        ///     Tests <see cref="Manager.Stop(StopType)"/>.
        /// </summary>
        [Fact]
        public void Stop()
        {
            ManagerMock test = ManagerMock.Instantiate(applicationManagerMock.Object);

            // start the manager and assert that it is running
            test.Start();
            Assert.Equal(State.Running, test.State);

            // stop the manager and assert that it is stopped
            test.Stop();
            Assert.Equal(State.Stopped, test.State);

            // try to stop again and assert that the operation fails
            Result stop = test.Stop();
            Assert.Equal(ResultCode.Failure, stop.ResultCode);
        }

        #endregion Public Methods
    }
}