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

using System.Diagnostics.CodeAnalysis;
using System.Threading;
using Moq;
using Utility.OperationResult;
using Xunit;

namespace Symbiote.SDK.Tests.Common
{
    /// <summary>
    ///     Unit tests for the Manager class.
    /// </summary>
    [Collection("Manager")]
    public class Manager
    {
        #region Private Fields

        /// <summary>
        ///     The shared ApplicationManager mockup.
        /// </summary>
        private Mock<IApplicationManager> applicationManagerMock;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Manager"/> class.
        /// </summary>
        public Manager()
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
        /// <remarks>Depends upon the <see cref="ManagerMock"/> class to simulate the behavior under test.</remarks>
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
        /// <remarks>
        ///     Depends upon the <see cref="ManagerMockTwo"/> and <see cref="ManagerMockWithDependency"/> classes to simulate the
        ///     behavior under test.
        /// </remarks>
        [Fact]
        public void DependencyFault()
        {
            ManagerMockTwo o = ManagerMockTwo.Instantiate(applicationManagerMock.Object);
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
        /// <remarks>
        ///     Depends upon the <see cref="ManagerMockTwo"/> and <see cref="ManagerMockWithDependency"/> classes to simulate the
        ///     behavior under test.
        /// </remarks>
        [Fact]
        public void DependencyStop()
        {
            ManagerMockTwo o = ManagerMockTwo.Instantiate(applicationManagerMock.Object);
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
        ///     Tests <see cref="Core.Manager.Restart(StopType)"/>.
        /// </summary>
        /// <remarks>Depends upon the <see cref="ManagerMock"/> class to simulate the behavior under test.</remarks>
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
        ///     Tests <see cref="Core.Manager.Restart(StopType)"/> with the manager in the stopped State.
        /// </summary>
        [Fact]
        public void RestartNotRunning()
        {
            Mock<SDK.Manager> mock = new Mock<SDK.Manager>();
            mock.CallBase = true;

            Result restart = mock.Object.Restart();
            Assert.Equal(ResultCode.Failure, restart.ResultCode);
        }

        /// <summary>
        ///     Tests <see cref="Core.Manager.Start"/>.
        /// </summary>
        /// <remarks>Depends upon the <see cref="ManagerMock"/> class to simulate the behavior under test.</remarks>
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
        ///     Tests <see cref="Core.Manager.Start"/> with a dependency in the stopped State.
        /// </summary>
        /// <remarks>Depends upon the <see cref="ManagerMock"/> class to simulate the behavior under test.</remarks>
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
        ///     Tests <see cref="Core.Manager.Stop(StopType)"/>.
        /// </summary>
        /// <remarks>Depends upon the <see cref="ManagerMock"/> class to simulate the behavior under test.</remarks>
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

    /// <summary>
    ///     Mocks a Manager.
    /// </summary>
    /// <remarks>
    ///     It is not feasible to use a mocking framework for this mockup due to the implementation of the Singleton pattern.
    /// </remarks>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    public class ManagerMock : SDK.Manager
    {
        #region Private Fields

        /// <summary>
        ///     The Singleton instance of this class.
        /// </summary>
        private static ManagerMock instance;

        #endregion Private Fields

        #region Private Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ManagerMock"/> class.
        /// </summary>
        /// <param name="manager">The ApplicationManager dependency.</param>
        private ManagerMock(IApplicationManager manager)
        {
            ManagerName = "Mock Manager";
            RegisterDependency<IApplicationManager>(manager);

            ChangeState(State.Initialized);
        }

        #endregion Private Constructors

        #region Public Methods

        /// <summary>
        ///     Instantiates and returns the Manager.
        /// </summary>
        /// <param name="manager">The ApplicationManager dependency.</param>
        /// <returns>The instantiated Manager.</returns>
        public static ManagerMock Instantiate(IApplicationManager manager)
        {
            // remove the code that makes this a singleton so that test runners can get a fresh instance each time.
            instance = new ManagerMock(manager);
            return instance;
        }

        /// <summary>
        ///     Simulates the check of an unregistered dependency.
        /// </summary>
        /// <returns>A value indicating whether the unregistered dependency was found.</returns>
        public bool CheckBadDependency()
        {
            return Dependency<IManager>() != null;
        }

        /// <summary>
        ///     Simulates the check of a registered dependency.
        /// </summary>
        /// <returns>A value indicating whether the registered dependency was found.</returns>
        public bool CheckDependency()
        {
            return Dependency<IApplicationManager>() != null;
        }

        #endregion Public Methods
    }

    /// <summary>
    ///     Mocks a Manager.
    /// </summary>
    /// <remarks>
    ///     It is not feasible to use a mocking framework for this mockup due to the implementation of the Singleton pattern.
    /// </remarks>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    public class ManagerMockTwo : SDK.Manager
    {
        #region Private Fields

        /// <summary>
        ///     The Singleton instance of this class.
        /// </summary>
        private static ManagerMockTwo instance;

        #endregion Private Fields

        #region Private Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ManagerMockTwo"/> class.
        /// </summary>
        /// <param name="manager">The ApplicationManager dependency.</param>
        private ManagerMockTwo(IApplicationManager manager)
        {
            ManagerName = "Mock Manager";
            RegisterDependency<IApplicationManager>(manager);

            ChangeState(State.Initialized);
        }

        #endregion Private Constructors

        #region Public Methods

        /// <summary>
        ///     Instantiates the Manager.
        /// </summary>
        /// <param name="manager">The ApplicationManager dependency.</param>
        /// <returns>The Instantiated Manager.</returns>
        public static ManagerMockTwo Instantiate(IApplicationManager manager)
        {
            // remove the code that makes this a singleton so that test runners can get a fresh instance each time.
            instance = new ManagerMockTwo(manager);
            return instance;
        }

        /// <summary>
        ///     Simulates a fault of the Manager.
        /// </summary>
        public void Fault()
        {
            ChangeState(State.Faulted, StopType.Stop | StopType.Restart);
        }

        #endregion Public Methods
    }

    /// <summary>
    ///     Mocks a Manager with one dependency in addition to the ApplicationManager.
    /// </summary>
    /// <remarks>
    ///     It is not feasible to use a mocking framework for this mockup due to the implementation of the Singleton pattern.
    /// </remarks>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    public class ManagerMockWithDependency : SDK.Manager
    {
        #region Private Fields

        /// <summary>
        ///     The Singleton instance of this class.
        /// </summary>
        private static ManagerMockWithDependency instance;

        #endregion Private Fields

        #region Private Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ManagerMockWithDependency"/> class.
        /// </summary>
        /// <param name="manager">The ApplicationManager dependency.</param>
        /// <param name="otherManager">A second Manager dependency.</param>
        private ManagerMockWithDependency(IApplicationManager manager, IManager otherManager)
        {
            ManagerName = "Mock Manager";
            RegisterDependency<IApplicationManager>(manager);
            RegisterDependency<IManager>(otherManager);

            ChangeState(State.Initialized);
        }

        #endregion Private Constructors

        #region Public Methods

        /// <summary>
        ///     Instantiates the Manager.
        /// </summary>
        /// <param name="manager">The ApplicationManager dependency.</param>
        /// <param name="otherManager">A second Manager dependency.</param>
        /// <returns>The instantiated Manager.</returns>
        public static ManagerMockWithDependency Instantiate(IApplicationManager manager, IManager otherManager)
        {
            // remove the code that makes this a singleton so that test runners can get a fresh instance each time.
            instance = new ManagerMockWithDependency(manager, otherManager);
            return instance;
        }

        #endregion Public Methods
    }
}