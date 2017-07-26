/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █     ▄████████                                                                                        ▄▄▄▄███▄▄▄▄
      █     ███    ███                                                                                     ▄██▀▀▀███▀▀▀██▄
      █     ███    ███    █████▄    █████▄  █        █   ▄██████   ▄█████      ██     █   ██████  ██▄▄▄▄   ███   ███   ███   ▄█████  ██▄▄▄▄    ▄█████     ▄████▄     ▄█████    █████
      █     ███    ███   ██   ██   ██   ██ ██       ██  ██    ██   ██   ██ ▀███████▄ ██  ██    ██ ██▀▀▀█▄  ███   ███   ███   ██   ██ ██▀▀▀█▄   ██   ██   ██    ▀    ██   █    ██  ██
      █   ▀███████████   ██   ██   ██   ██ ██       ██▌ ██    ▀    ██   ██     ██  ▀ ██▌ ██    ██ ██   ██  ███   ███   ███   ██   ██ ██   ██   ██   ██  ▄██        ▄██▄▄     ▄██▄▄█▀
      █     ███    ███ ▀██████▀  ▀██████▀  ██       ██  ██    ▄  ▀████████     ██    ██  ██    ██ ██   ██  ███   ███   ███ ▀████████ ██   ██ ▀████████ ▀▀██ ███▄  ▀▀██▀▀    ▀███████
      █     ███    ███   ██        ██      ██▌    ▄ ██  ██    ██   ██   ██     ██    ██  ██    ██ ██   ██  ███   ███   ███   ██   ██ ██   ██   ██   ██   ██    ██   ██   █    ██  ██
      █     ███    █▀   ▄███▀     ▄███▀    ████▄▄██ █   ██████▀    ██   █▀    ▄██▀   █    ██████   █   █    ▀█   ███   █▀    ██   █▀  █   █    ██   █▀   ██████▀    ███████   ██  ██
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
      █  Unit tests for the ApplicationManager class.
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
using System.Diagnostics.CodeAnalysis;
using OpenIIoT.SDK;
using OpenIIoT.SDK.Common;
using OpenIIoT.SDK.Common.Exceptions;
using Utility.OperationResult;
using Xunit;

namespace OpenIIoT.Core.Tests
{
    /// <summary>
    ///     Unit tests for the ApplicationManager class.
    /// </summary>
    [Collection("ApplicationManager")]
    public class ApplicationManager
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ApplicationManager"/> class.
        /// </summary>
        /// <remarks>Terminates any previous instantiation of the ApplicationManager prior to each test.</remarks>
        public ApplicationManager()
        {
            Core.ApplicationManager.Terminate();
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///     Test <see cref="Core.ApplicationManager.Instantiate(Type[])"/> with a Type defined twice in the constructor Type list.
        /// </summary>
        /// <remarks>Depends upon the <see cref="MockManager"/> class to simulate the behavior under test.</remarks>
        [Fact]
        public void DoubleManagers()
        {
            Exception ex = Record.Exception(() => Core.ApplicationManager.Instantiate(new Type[] { typeof(MockManager), typeof(MockManager) }));

            Assert.NotNull(ex);
            Assert.IsType<ManagerInstantiationException>(ex);
        }

        /// <summary>
        ///     Tests <see cref="Core.ApplicationManager.GetInstance"/> prior to invocation of <see cref="Core.ApplicationManager.Instantiate(Type[])"/>.
        /// </summary>
        [Fact]
        public void GetInstanceBeforeInstantiation()
        {
            Exception ex = Record.Exception(() => Core.ApplicationManager.GetInstance());

            Assert.NotNull(ex);
            Assert.IsType<ManagerNotInitializedException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="IApplicationManager.InstanceName"/> property.
        /// </summary>
        [Fact]
        public void InstanceName()
        {
            IApplicationManager manager = Core.ApplicationManager.Instantiate(new Type[] { typeof(MockManager) });

            Assert.NotNull(manager.InstanceName);
        }

        /// <summary>
        ///     Tests <see cref="Core.ApplicationManager.GetInstance()"/> after first invoking <see cref="Core.ApplicationManager.Instantiate(Type[])"/>.
        /// </summary>
        /// <remarks>Depends upon the <see cref="MockManager"/> class to simulate the behavior under test.</remarks>
        [Fact]
        public void InstantiateAndGetInstance()
        {
            IApplicationManager manager1 = Core.ApplicationManager.Instantiate(new Type[] { typeof(MockManager) });
            IApplicationManager manager2 = Core.ApplicationManager.GetInstance();

            Assert.Equal(manager1, manager2);
        }

        /// <summary>
        ///     Tests successive invocations of <see cref="Core.ApplicationManager.Instantiate(Type[])"/>.
        /// </summary>
        /// <remarks>Depends upon the <see cref="MockManager"/> class to simulate the behavior under test.</remarks>
        [Fact]
        public void InstantiateTwice()
        {
            IApplicationManager manager1 = Core.ApplicationManager.Instantiate(new Type[] { typeof(MockManager) });
            IApplicationManager manager2 = Core.ApplicationManager.Instantiate(new Type[] { typeof(MockManager) });
        }

        /// <summary>
        ///     Tests <see cref="Core.ApplicationManager.Instantiate(Type[])"/> with a Type array containing an instance of
        ///     IManager with the Setup() method returning a null Result.
        /// </summary>
        /// <remarks>Depends upon the <see cref="MockManagerBroken"/> class to simulate the behavior under test.</remarks>
        [Fact]
        public void InstantiateWithBrokenSetupMethod()
        {
            Exception ex = Record.Exception(() => Core.ApplicationManager.Instantiate(new Type[] { typeof(MockManagerBroken) }));

            Assert.NotNull(ex);
            Assert.IsType<ManagerSetupException>(ex);
        }

        /// <summary>
        ///     Tests <see cref="Core.ApplicationManager.Instantiate(Type[])"/> with an empty Type array.
        /// </summary>
        [Fact]
        public void InstantiateWithEmptyArray()
        {
            Exception ex = Record.Exception(() => Core.ApplicationManager.Instantiate(new Type[] { }));

            Assert.NotNull(ex);
            Assert.IsType<ManagerTypeListException>(ex);
        }

        /// <summary>
        ///     Tests <see cref="Core.ApplicationManager.Instantiate(Type[])"/> with a Type array containing a Type not
        ///     implementing IManager.
        /// </summary>
        [Fact]
        public void InstantiateWithNonIManager()
        {
            Exception ex = Record.Exception(() => Core.ApplicationManager.Instantiate(new Type[] { typeof(int) }));

            Assert.NotNull(ex);
            Assert.IsType<ManagerTypeListException>(ex);
        }

        /// <summary>
        ///     Tests <see cref="Core.ApplicationManager.Instantiate(Type[])"/> with a null Type array.
        /// </summary>
        [Fact]
        public void InstantiateWithNull()
        {
            Exception ex = Record.Exception(() => Core.ApplicationManager.Instantiate(null));

            Assert.NotNull(ex);
            Assert.IsType<ManagerTypeListException>(ex);
        }

        /// <summary>
        ///     Tests <see cref="Core.ApplicationManager.Instantiate(Type[])"/> with a Type array containing a valid, functioning
        ///     IManager instance.
        /// </summary>
        /// <remarks>Depends upon the <see cref="MockManager"/> class to simulate the behavior under test.</remarks>
        [Fact]
        public void InstantiateWithValidIManager()
        {
            IApplicationManager manager = Core.ApplicationManager.Instantiate(new Type[] { typeof(MockManager) });

            Assert.IsType<Core.ApplicationManager>(manager);
            Assert.NotNull(manager);

            IReadOnlyList<IManager> managers = manager.Managers;

            Assert.Equal(managers.Count, 2);

            Assert.NotNull(manager.ProductName);
            Assert.NotNull(manager.ProductVersion);
        }

        /// <summary>
        ///     Tests <see cref="Core.ApplicationManager.Instantiate(Type[])"/> with a Manager with no Instantiate() method.
        /// </summary>
        /// <remarks>
        ///     Depends upon the <see cref="MockManagerDoesntImplementIManager"/> class to simulate the behavior under test.
        /// </remarks>
        [Fact]
        public void ManagerDoesntImplementIManager()
        {
            Exception ex = Record.Exception(() => Core.ApplicationManager.Instantiate(new Type[] { typeof(MockManagerDoesntImplementIManager) }));

            Assert.NotNull(ex);
            Assert.IsType<ManagerTypeListException>(ex);
        }

        /// <summary>
        ///     Tests the <see cref="IApplicationManager.Managers"/> property.
        /// </summary>
        [Fact]
        public void Managers()
        {
            IApplicationManager manager = Core.ApplicationManager.Instantiate(new Type[] { typeof(MockManager) });

            Assert.Equal(2, manager.Managers.Count);
            Assert.Equal(manager.Managers[0].GetType(), typeof(Core.ApplicationManager));
            Assert.Equal(manager.Managers[1].GetType(), typeof(MockManager));
        }

        /// <summary>
        ///     Tests <see cref="Core.ApplicationManager.Instantiate(Type[])"/> with a Manager with a known bad dependency.
        /// </summary>
        /// <remarks>Depends upon the <see cref="MockManagerBadDependency"/> class to simulate the behavior under test.</remarks>
        [Fact]
        public void ManagerWithBadDepdency()
        {
            Exception ex = Record.Exception(() => Core.ApplicationManager.Instantiate(new Type[] { typeof(MockManagerBadDependency) }));

            Assert.NotNull(ex);
            Assert.IsType<ManagerInstantiationException>(ex);
        }

        /// <summary>
        ///     Tests <see cref="Core.ApplicationManager.Instantiate(Type[])"/> with a Manager with no Instantiate() method.
        /// </summary>
        /// <remarks>Depends upon the <see cref="MockManagerBadInstantiate"/> class to simulate the behavior under test.</remarks>
        [Fact]
        public void ManagerWithBadInstantiate()
        {
            Exception ex = Record.Exception(() => Core.ApplicationManager.Instantiate(new Type[] { typeof(MockManagerBadInstantiate) }));

            Assert.NotNull(ex);
            Assert.IsType<ManagerInstantiationException>(ex);
        }

        /// <summary>
        ///     Tests <see cref="Core.ApplicationManager.Instantiate(Type[])"/> with a Manager with no dependencies defined.
        /// </summary>
        /// <remarks>Depends upon the <see cref="MockManagerNoDependencies"/> class to simulate the behavior under test.</remarks>
        [Fact]
        public void ManagerWithNoDependencies()
        {
            Exception ex = Record.Exception(() => Core.ApplicationManager.Instantiate(new Type[] { typeof(MockManagerNoDependencies) }));

            Assert.NotNull(ex);
            Assert.IsType<ManagerInstantiationException>(ex);
        }

        /// <summary>
        ///     Tests <see cref="Manager.Start()"/> with a Manager known to return a failed Result from startup.
        /// </summary>
        /// <remarks>Depends upon the <see cref="MockManagerStartBadReturn"/> class to simulate the behavior under test.</remarks>
        [Fact]
        public void StartBadReturn()
        {
            IApplicationManager manager = Core.ApplicationManager.Instantiate(new Type[] { typeof(MockManagerStartBadReturn) });

            Exception ex = Record.Exception(() => manager.Start());

            Assert.NotNull(ex);
            Assert.IsType<ManagerStartException>(ex);
        }

        /// <summary>
        ///     Tests <see cref="Manager.Start()"/> with a Manager known to throw an exception during startup.
        /// </summary>
        /// <remarks>Depends upon the <see cref="MockManagerStartFail"/> class to simulate the behavior under test.</remarks>
        [Fact]
        public void StartFail()
        {
            IApplicationManager manager = Core.ApplicationManager.Instantiate(new Type[] { typeof(MockManagerStartFail) });

            Exception ex = Record.Exception(() => manager.Start());

            Assert.NotNull(ex);
            Assert.IsType<ManagerStartException>(ex);
        }

        /// <summary>
        ///     Tests <see cref="Manager.Start()"/> and <see cref="Manager.Stop(StopType)"/>
        /// </summary>
        /// <remarks>Depends upon the <see cref="MockManager"/> class to simulate the behavior under test.</remarks>
        [Fact]
        public void StartStop()
        {
            IApplicationManager manager = Core.ApplicationManager.Instantiate(new Type[] { typeof(MockManager) });

            IResult startResult = manager.Start();

            Assert.NotEqual(ResultCode.Failure, startResult.ResultCode);
            Assert.Equal(State.Running, manager.State);

            IResult stopResult = manager.Stop();

            Assert.NotEqual(ResultCode.Failure, stopResult.ResultCode);
            Assert.Equal(State.Stopped, manager.State);
        }

        /// <summary>
        ///     Tests <see cref="Manager.Stop(StopType)"/> with a Manager known to return a failed Result from shutdown.
        /// </summary>
        /// <remarks>Depends upon the <see cref="MockManagerStopBadReturn"/> class to simulate the behavior under test.</remarks>
        [Fact]
        public void StopBadReturn()
        {
            IApplicationManager manager = Core.ApplicationManager.Instantiate(new Type[] { typeof(MockManagerStopBadReturn) });

            IResult startResult = manager.Start();

            Assert.NotEqual(ResultCode.Failure, startResult.ResultCode);
            Assert.Equal(State.Running, manager.State);

            Exception ex = Record.Exception(() => manager.Stop());

            Assert.NotNull(ex);
            Assert.IsType<ManagerStopException>(ex);
        }

        /// <summary>
        ///     Tests <see cref="Manager.Stop(StopType)"/> with a Manager known to throw an exception during shutdown.
        /// </summary>
        /// <remarks>Depends upon the <see cref="MockManagerStopFail"/> class to simulate the behavior under test.</remarks>
        [Fact]
        public void StopFail()
        {
            IApplicationManager manager = Core.ApplicationManager.Instantiate(new Type[] { typeof(MockManagerStopFail) });

            IResult startResult = manager.Start();

            Assert.NotEqual(ResultCode.Failure, startResult.ResultCode);
            Assert.Equal(State.Running, manager.State);

            Exception ex = Record.Exception(() => manager.Stop());

            Assert.NotNull(ex);
            Assert.IsType<ManagerStopException>(ex);
        }

        #endregion Public Methods
    }

    /// <summary>
    ///     Mocks a Manager.
    /// </summary>
    /// <remarks>
    ///     It is not feasible to use a mocking framework for this mockup due to the Type parameter requirement of the
    ///     ApplicationManager class; this class is instantiated by the ApplicationManager via reflection.
    /// </remarks>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    public class MockManager : Core.Common.Manager
    {
        #region Private Fields

        /// <summary>
        ///     The Singleton instance of this class.
        /// </summary>
        private static MockManager instance;

        #endregion Private Fields

        #region Private Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="MockManager"/> class.
        /// </summary>
        /// <param name="manager">The ApplicationManager dependency.</param>
        /// <returns>The instantiated Manager.</returns>
        private MockManager(IApplicationManager manager)
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
        public static MockManager Instantiate(IApplicationManager manager)
        {
            // remove the code that makes this a singleton so that test runners can get a fresh instance each time.
            instance = new MockManager(manager);
            return instance;
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        ///     Simulates a normal setup routine.
        /// </summary>
        protected override void Setup()
        {
            return;
        }

        /// <summary>
        ///     Simulates a normal shutdown routine.
        /// </summary>
        /// <param name="stopType">The nature of the stoppage.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        protected override IResult Shutdown(StopType stopType = StopType.Stop)
        {
            return new Result();
        }

        /// <summary>
        ///     Simulates a normal startup routine.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        protected override IResult Startup()
        {
            return new Result();
        }

        #endregion Protected Methods
    }

    /// <summary>
    ///     Mocks a Manager which contains an invalid dependency; omitting <see cref="IApplicationManager"/>.
    /// </summary>
    /// <remarks>
    ///     It is not feasible to use a mocking framework for this mockup due to the need to modify the constructor and
    ///     <see cref="Instantiate(MockManager)"/> method.
    /// </remarks>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    public class MockManagerBadDependency : Core.Common.Manager
    {
        #region Private Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="MockManagerBadDependency"/> class.
        /// </summary>
        /// <param name="manager">The ApplicationManager dependency.</param>
        private MockManagerBadDependency(MockManager manager)
        {
            ManagerName = "Mock Manager with Bad Dependency";
            ChangeState(State.Initialized);
        }

        #endregion Private Constructors

        #region Public Methods

        /// <summary>
        ///     Instantiates the Manager.
        /// </summary>
        /// <param name="manager">The ApplicationManager dependency.</param>
        /// <returns>The instantiated Manager.</returns>
        public static MockManagerBadDependency Instantiate(MockManager manager)
        {
            return new MockManagerBadDependency(manager);
        }

        #endregion Public Methods
    }

    /// <summary>
    ///     Mocks a Manager that is missing the implementation not inherited from the base <see cref="Manager"/> class.
    /// </summary>
    /// <remarks>
    ///     It is not feasible to use a mocking framework for this mockup due to the need to remove the Instantiate() method to
    ///     simulate the behavior under test.
    /// </remarks>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    public class MockManagerBadInstantiate : Core.Common.Manager
    {
    }

    /// <summary>
    ///     Mocks a Manager that throws an exception within the <see cref="Manager.Setup()"/> method.
    /// </summary>
    /// <remarks>
    ///     It is not feasible to use a mocking framework for this mockup due to the <see langword="protected"/> access level of
    ///     the <see cref="Manager.Setup()"/> method.
    /// </remarks>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    public class MockManagerBroken : Core.Common.Manager
    {
        #region Private Fields

        /// <summary>
        ///     The Singleton instance of this class.
        /// </summary>
        private static MockManagerBroken instance;

        #endregion Private Fields

        #region Private Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="MockManagerBroken"/> class.
        /// </summary>
        /// <param name="manager">The ApplicationManager dependency.</param>
        private MockManagerBroken(IApplicationManager manager)
        {
            ManagerName = "Mock Manager Broken";
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
        public static MockManagerBroken Instantiate(IApplicationManager manager)
        {
            if (instance == null)
            {
                instance = new MockManagerBroken(manager);
            }

            return instance;
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        ///     Simulates a failing Setup routine.
        /// </summary>
        /// <exception cref="ManagerSetupException">Thrown when an error is encountered during setup.</exception>
        protected override void Setup()
        {
            // throw an exception to simulate an error
            throw new ManagerSetupException(string.Empty);
        }

        #endregion Protected Methods
    }

    /// <summary>
    ///     Mocks a Manager that doesn't implement the <see cref="IManager"/> interface.
    /// </summary>
    /// <remarks>
    ///     It is not feasible to use a mocking framework for this mockup due to the need to change the interface(s) implemented.
    /// </remarks>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    public class MockManagerDoesntImplementIManager
    {
    }

    /// <summary>
    ///     Mocks a Manager with no dependencies.
    /// </summary>
    /// <remarks>
    ///     It is not feasible to use a mocking framework for this mockup due to the need to change the dependencies specified by
    ///     the <see cref="Instantiate"/> method and constructor.
    /// </remarks>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1642:ConstructorSummaryDocumentationMustBeginWithStandardText", Justification = "Reviewed.")]
    public class MockManagerNoDependencies : Core.Common.Manager
    {
        #region Private Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="MockManagerNoDependencies"/> class.
        /// </summary>
        private MockManagerNoDependencies()
        {
            return;
        }

        #endregion Private Constructors

        #region Public Methods

        /// <summary>
        ///     Instantiates the Manager.
        /// </summary>
        /// <returns>The instantiated Manager.</returns>
        public static MockManagerNoDependencies Instantiate()
        {
            return new MockManagerNoDependencies();
        }

        #endregion Public Methods
    }

    /// <summary>
    ///     Mocks a Manager in the <see cref="State.Running"/> state.
    /// </summary>
    /// <remarks>
    ///     It is not feasible to use a mocking framework for this mockup due to the Type parameter requirement of the
    ///     ApplicationManager class; this class is instantiated by the ApplicationManager via reflection.
    /// </remarks>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    public class MockManagerRunning : Core.Common.Manager
    {
        #region Private Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="MockManagerRunning"/> class.
        /// </summary>
        /// <param name="manager">The ApplicationManager dependency.</param>
        private MockManagerRunning(IApplicationManager manager)
        {
            ManagerName = "Mock Manager";
            RegisterDependency<IApplicationManager>(manager);

            ChangeState(State.Running);
        }

        #endregion Private Constructors

        #region Public Methods

        /// <summary>
        ///     Instantiates the Manager.
        /// </summary>
        /// <param name="manager">The ApplicationManager dependency.</param>
        /// <returns>The instantiated Manager.</returns>
        public static MockManagerRunning Instantiate(IApplicationManager manager)
        {
            return new MockManagerRunning(manager);
        }

        #endregion Public Methods
    }

    /// <summary>
    ///     Mocks a Manager with a <see cref="Startup"/> method returning a failing Result.
    /// </summary>
    /// <remarks>
    ///     It is not feasible to use a mocking framework for this mockup due to the Type parameter requirement of the
    ///     ApplicationManager class; this class is instantiated by the ApplicationManager via reflection.
    /// </remarks>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    public class MockManagerStartBadReturn : Core.Common.Manager
    {
        #region Private Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="MockManagerStartBadReturn"/> class.
        /// </summary>
        /// <param name="manager">The ApplicationManager dependency.</param>
        private MockManagerStartBadReturn(IApplicationManager manager)
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
        public static MockManagerStartBadReturn Instantiate(IApplicationManager manager)
        {
            return new MockManagerStartBadReturn(manager);
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        ///     Simulates a Startup routine returning a failing Result.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        protected override IResult Startup()
        {
            return new Result().AddError(string.Empty);
        }

        #endregion Protected Methods
    }

    /// <summary>
    ///     Mocks a Manager with a failing <see cref="Startup"/> method.
    /// </summary>
    /// <remarks>
    ///     It is not feasible to use a mocking framework for this mockup due to the Type parameter requirement of the
    ///     ApplicationManager class; this class is instantiated by the ApplicationManager via reflection.
    /// </remarks>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    public class MockManagerStartFail : Core.Common.Manager
    {
        #region Private Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="MockManagerStartFail"/> class.
        /// </summary>
        /// <param name="manager">The ApplicationManager dependency.</param>
        private MockManagerStartFail(IApplicationManager manager)
        {
            ManagerName = "Mock Manager";
            RegisterDependency<IApplicationManager>(manager);

            ChangeState(State.Running);
        }

        #endregion Private Constructors

        #region Public Methods

        /// <summary>
        ///     Instantiates the Manager.
        /// </summary>
        /// <param name="manager">The ApplicationManager dependency.</param>
        /// <returns>The instantiated Manager.</returns>
        public static MockManagerStartFail Instantiate(IApplicationManager manager)
        {
            return new MockManagerStartFail(manager);
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        ///     Simulates a failing Startup routine.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        protected override IResult Startup()
        {
            throw new Exception(string.Empty);
        }

        #endregion Protected Methods
    }

    /// <summary>
    ///     Mocks a Manager with a <see cref="Shutdown(StopType)"/> method returning a failing Result.
    /// </summary>
    /// <remarks>
    ///     It is not feasible to use a mocking framework for this mockup due to the Type parameter requirement of the
    ///     ApplicationManager class; this class is instantiated by the ApplicationManager via reflection.
    /// </remarks>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    public class MockManagerStopBadReturn : Core.Common.Manager
    {
        #region Private Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="MockManagerStopBadReturn"/> class.
        /// </summary>
        /// <param name="manager">The ApplicationManager dependency.</param>
        private MockManagerStopBadReturn(IApplicationManager manager)
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
        public static MockManagerStopBadReturn Instantiate(IApplicationManager manager)
        {
            return new MockManagerStopBadReturn(manager);
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        ///     Simulates a Shutdown routine returning a failing Result.
        /// </summary>
        /// <param name="stopType">The nature of the shutdown.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        protected override IResult Shutdown(StopType stopType = StopType.Stop)
        {
            return new Result().AddError(string.Empty);
        }

        #endregion Protected Methods
    }

    /// <summary>
    ///     Mocks a Manager with a failing <see cref="Shutdown(StopType)"/> method.
    /// </summary>
    /// <remarks>
    ///     It is not feasible to use a mocking framework for this mockup due to the Type parameter requirement of the
    ///     ApplicationManager class; this class is instantiated by the ApplicationManager via reflection.
    /// </remarks>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    public class MockManagerStopFail : Core.Common.Manager
    {
        #region Private Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="MockManagerStopFail"/> class.
        /// </summary>
        /// <param name="manager">The ApplicationManager dependency.</param>
        private MockManagerStopFail(IApplicationManager manager)
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
        public static MockManagerStopFail Instantiate(IApplicationManager manager)
        {
            return new MockManagerStopFail(manager);
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        ///     Simulates a failing Shutdown routine.
        /// </summary>
        /// <param name="stopType">The nature of the shutdown.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        protected override IResult Shutdown(StopType stopType = StopType.Stop)
        {
            throw new Exception(string.Empty);
        }

        #endregion Protected Methods
    }
}