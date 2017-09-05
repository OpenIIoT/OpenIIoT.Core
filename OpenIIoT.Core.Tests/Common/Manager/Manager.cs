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
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using Moq;
using OpenIIoT.SDK;
using OpenIIoT.SDK.Common;
using OpenIIoT.SDK.Common.Exceptions;
using Utility.OperationResult;
using Xunit;

namespace OpenIIoT.Core.Tests.Common
{
    /// <summary>
    ///     Unit tests for the <see cref="Core.Common.Manager"/> class.
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
        ///     Tests the <see cref="Core.Common.Manager.AutomaticRestartPending"/> property.
        /// </summary>
        /// <remarks>Depends upon the <see cref="ManagerMock"/> class to simulate the behavior under test.</remarks>
        [Fact]
        public void AutomaticRestartPending()
        {
            ManagerMock test = ManagerMock.Instantiate(applicationManagerMock.Object);

            Assert.Equal(false, test.AutomaticRestartPending);
        }

        /// <summary>
        ///     Tests the class constructor and property accessors.
        /// </summary>
        /// <remarks>Depends upon the <see cref="ManagerMock"/> class to simulate the behavior under test.</remarks>
        [Fact]
        public void Constructor()
        {
            ManagerMock test = ManagerMock.Instantiate(applicationManagerMock.Object);

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
            IResult start = test.Start();
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
            Thread.Sleep(1500);

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
            IResult start = test.Start();
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
        ///     Tests the <see cref="Core.Common.Manager.EventProviderName"/> property.
        /// </summary>
        /// <remarks>Depends upon the <see cref="ManagerMock"/> class to simulate the behavior under test.</remarks>
        [Fact]
        public void EventProviderName()
        {
            ManagerMock test = ManagerMock.Instantiate(applicationManagerMock.Object);

            Assert.Equal(test.GetType().Name, test.EventProviderName);
        }

        /// <summary>
        ///     Tests the fault handling of the Manager.
        /// </summary>
        [Fact]
        public void Fault()
        {
            ManagerMockTwo test = ManagerMockTwo.Instantiate(applicationManagerMock.Object);

            test.Start();
            Assert.Equal(State.Running, test.State);

            test.Fault();
            Assert.Equal(State.Faulted, test.State);

            test.Start();
            Assert.Equal(State.Running, test.State);

            test.FaultWithRestart();
            Assert.Equal(State.Faulted, test.State);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Common.Manager.ManagerName"/> property.
        /// </summary>
        /// <remarks>Depends upon the <see cref="ManagerMock"/> class to simulate the behavior under test.</remarks>
        [Fact]
        public void ManagerName()
        {
            ManagerMock test = ManagerMock.Instantiate(applicationManagerMock.Object);

            Assert.Equal("Mock Manager", test.ManagerName);
        }

        /// <summary>
        ///     Tests <see cref="Core.Common.Manager.Restart(StopType)"/>.
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
            IResult restart = test.Restart();
            Assert.Equal(ResultCode.Success, restart.ResultCode);
            Assert.Equal(State.Running, test.State);
        }

        /// <summary>
        ///     Tests <see cref="Core.Common.Manager.Restart(StopType)"/> with the manager in the stopped State.
        /// </summary>
        [Fact]
        public void RestartNotRunning()
        {
            Mock<Core.Common.Manager> mock = new Mock<Core.Common.Manager>();
            mock.CallBase = true;

            IResult restart = mock.Object.Restart();
            Assert.Equal(ResultCode.Failure, restart.ResultCode);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Common.Manager.Shutdown(StopType)"/> method.
        /// </summary>
        [Fact]
        public void Shutdown()
        {
            ManagerMockBadShutdown bad = ManagerMockBadShutdown.Instantiate(applicationManagerMock.Object);

            bad.Start();
            Assert.Equal(State.Running, bad.State);

            Assert.Throws<ManagerStopException>(() => bad.Stop());

            ManagerMockFailingShutdown fail = ManagerMockFailingShutdown.Instantiate(applicationManagerMock.Object);

            fail.Start();
            Assert.Equal(State.Running, fail.State);

            IResult result = fail.Stop();

            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        /// <summary>
        ///     Tests <see cref="Core.Common.Manager.Start"/>.
        /// </summary>
        /// <remarks>Depends upon the <see cref="ManagerMock"/> class to simulate the behavior under test.</remarks>
        [Fact]
        public void Start()
        {
            ManagerMock test = ManagerMock.Instantiate(applicationManagerMock.Object);

            // start the manager and assert that it is running
            IResult start = test.Start();
            Assert.Equal(State.Running, test.State);

            // try to start again and assert that the operation fails
            IResult startAgain = test.Start();
            Assert.Equal(ResultCode.Failure, startAgain.ResultCode);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Common.Manager.Startup"/> method.
        /// </summary>
        [Fact]
        public void Startup()
        {
            ManagerMockBadStartup bad = ManagerMockBadStartup.Instantiate(applicationManagerMock.Object);

            Assert.Throws<ManagerStartException>(() => bad.Start());

            ManagerMockFailingStartup fail = ManagerMockFailingStartup.Instantiate(applicationManagerMock.Object);

            IResult result = fail.Start();
            Assert.Equal(ResultCode.Failure, result.ResultCode);
            Assert.Equal(fail.State, State.Faulted);
        }

        /// <summary>
        ///     Tests <see cref="Core.Common.Manager.Start"/> with a dependency in the stopped State.
        /// </summary>
        /// <remarks>Depends upon the <see cref="ManagerMock"/> class to simulate the behavior under test.</remarks>
        [Fact]
        public void StartWithStoppedDependency()
        {
            Mock<IApplicationManager> a = new Mock<IApplicationManager>();
            a.Setup(m => m.State).Returns(State.Stopped);

            ManagerMock test = ManagerMock.Instantiate(a.Object);

            // start the manager and assert that it is running
            IResult start = test.Start();
            Assert.Equal(ResultCode.Failure, start.ResultCode);
        }

        /// <summary>
        ///     Tests the <see cref="Core.Common.Manager.State"/> property.
        /// </summary>
        /// <remarks>Depends upon the <see cref="ManagerMock"/> class to simulate the behavior under test.</remarks>
        [Fact]
        public void StateProperty()
        {
            ManagerMock test = ManagerMock.Instantiate(applicationManagerMock.Object);

            Assert.Equal(State.Initialized, test.State);
        }

        /// <summary>
        ///     Tests <see cref="Core.Common.Manager.Stop(StopType)"/>.
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
            IResult stop = test.Stop();
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
    public class ManagerMock : Core.Common.Manager
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
            EventProviderName = GetType().Name;

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
    ///     Mocks a Manager which throws an exception in the <see cref="Core.Common.Manager.Shutdown(StopType)"/> method.
    /// </summary>
    /// <remarks>
    ///     It is not feasible to use a mocking framework for this mockup due to the access level of the Shutdown() method.
    /// </remarks>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    public class ManagerMockBadShutdown : Core.Common.Manager
    {
        #region Private Fields

        /// <summary>
        ///     The Singleton instance of this class.
        /// </summary>
        private static ManagerMockBadShutdown instance;

        #endregion Private Fields

        #region Private Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ManagerMockBadShutdown"/> class.
        /// </summary>
        /// <param name="manager">The ApplicationManager dependency.</param>
        private ManagerMockBadShutdown(IApplicationManager manager)
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
        /// <returns>The instantiated Manager.</returns>
        public static ManagerMockBadShutdown Instantiate(IApplicationManager manager)
        {
            // remove the code that makes this a singleton so that test runners can get a fresh instance each time.
            instance = new ManagerMockBadShutdown(manager);
            return instance;
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        ///     Simulates an exception in the shutdown routine.
        /// </summary>
        /// <param name="stopType">The nature of the stoppage.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        protected override IResult Shutdown(StopType stopType = StopType.Stop)
        {
            throw new Exception("exception");
        }

        #endregion Protected Methods
    }

    /// <summary>
    ///     Mocks a Manager which throws an exception in the <see cref="Core.Common.Manager.Startup"/> method.
    /// </summary>
    /// <remarks>
    ///     It is not feasible to use a mocking framework for this mockup due to the access level of the Startup() method.
    /// </remarks>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    public class ManagerMockBadStartup : Core.Common.Manager
    {
        #region Private Fields

        /// <summary>
        ///     The Singleton instance of this class.
        /// </summary>
        private static ManagerMockBadStartup instance;

        #endregion Private Fields

        #region Private Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ManagerMockBadStartup"/> class.
        /// </summary>
        /// <param name="manager">The ApplicationManager dependency.</param>
        private ManagerMockBadStartup(IApplicationManager manager)
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
        /// <returns>The instantiated Manager.</returns>
        public static ManagerMockBadStartup Instantiate(IApplicationManager manager)
        {
            // remove the code that makes this a singleton so that test runners can get a fresh instance each time.
            instance = new ManagerMockBadStartup(manager);
            return instance;
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        ///     Simulates an exception in the startup routine.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        protected override IResult Startup()
        {
            throw new Exception("exception");
        }

        #endregion Protected Methods
    }

    /// <summary>
    ///     Mocks a Manager which returns a failing Result from the <see cref="Core.Common.Manager.Shutdown(StopType)"/> method.
    /// </summary>
    /// <remarks>
    ///     It is not feasible to use a mocking framework for this mockup due to the access level of the Shutdown() method.
    /// </remarks>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    public class ManagerMockFailingShutdown : Core.Common.Manager
    {
        #region Private Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ManagerMockFailingShutdown"/> class.
        /// </summary>
        /// <param name="manager">The ApplicationManager dependency.</param>
        private ManagerMockFailingShutdown(IApplicationManager manager)
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
        /// <returns>The instantiated Manager.</returns>
        public static ManagerMockFailingShutdown Instantiate(IApplicationManager manager)
        {
            // remove the code that makes this a singleton so that test runners can get a fresh instance each time.
            return new ManagerMockFailingShutdown(manager);
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        ///     Simulates an exception in the shutdown routine.
        /// </summary>
        /// <param name="stopType">The nature of the stoppage.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        protected override IResult Shutdown(StopType stopType = StopType.Stop)
        {
            return new Result(ResultCode.Failure);
        }

        #endregion Protected Methods
    }

    /// <summary>
    ///     Mocks a Manager which returns a failing Result from the <see cref="Core.Common.Manager.Startup"/> method.
    /// </summary>
    /// <remarks>
    ///     It is not feasible to use a mocking framework for this mockup due to the access level of the Startup() method.
    /// </remarks>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    public class ManagerMockFailingStartup : Core.Common.Manager
    {
        #region Private Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ManagerMockFailingStartup"/> class.
        /// </summary>
        /// <param name="manager">The ApplicationManager dependency.</param>
        private ManagerMockFailingStartup(IApplicationManager manager)
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
        /// <returns>The instantiated Manager.</returns>
        public static ManagerMockFailingStartup Instantiate(IApplicationManager manager)
        {
            // remove the code that makes this a singleton so that test runners can get a fresh instance each time.
            return new ManagerMockFailingStartup(manager);
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        ///     Simulates a failing startup routine.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        protected override IResult Startup()
        {
            return new Result(ResultCode.Failure);
        }

        #endregion Protected Methods
    }

    /// <summary>
    ///     Mocks a Manager.
    /// </summary>
    /// <remarks>
    ///     It is not feasible to use a mocking framework for this mockup due to the implementation of the Singleton pattern.
    /// </remarks>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    public class ManagerMockTwo : Core.Common.Manager
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
            ChangeState(State.Faulted);
        }

        /// <summary>
        ///     Simulates a fault of the Manager with a pending restart.
        /// </summary>
        public void FaultWithRestart()
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
    public class ManagerMockWithDependency : Core.Common.Manager
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