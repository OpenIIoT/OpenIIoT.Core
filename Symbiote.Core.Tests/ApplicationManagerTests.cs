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
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using Symbiote.Core.SDK;
using Symbiote.Core.SDK.Exceptions;
using Symbiote.Core.Tests.Mockups;
using Utility.OperationResult;
using Xunit;

namespace Symbiote.Core.Tests
{
    /// <summary>
    ///     Tests <see cref="ApplicationManager.Instantiate(Type[])"/> with a Manager with a known bad dependency.
    /// </summary>
    /// <remarks>Presented in a distinct class to enforce execution order.</remarks>
    [Collection("ApplicationManager")]
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    public class ApplicationManagerBadDependency : IDisposable
    {
        #region Public Methods

        /// <summary>
        ///     Disposes the ApplicationManager.
        /// </summary>
        public void Dispose()
        {
            ApplicationManager.Terminate();
        }

        /// <summary>
        ///     Tests <see cref="ApplicationManager.Instantiate(Type[])"/> with a Manager with a known bad dependency.
        /// </summary>
        [Fact]
        public void ManagerWithBadDepdency()
        {
            Assert.Throws<ManagerInstantiationException>(() => ApplicationManager.Instantiate(new Type[] { typeof(MockManagerBadDependency) }));
        }

        #endregion Public Methods
    }

    /// <summary>
    ///     Tests <see cref="ApplicationManager.Instantiate(Type[])"/> with a Manager with no Instantiate() method.
    /// </summary>
    /// <remarks>Presented in a distinct class to enforce execution order.</remarks>
    [Collection("ApplicationManager")]
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    public class ApplicationManagerBadInstantiate : IDisposable
    {
        #region Public Methods

        /// <summary>
        ///     Disposes the ApplicationManager.
        /// </summary>
        public void Dispose()
        {
            ApplicationManager.Terminate();
        }

        /// <summary>
        ///     Tests <see cref="ApplicationManager.Instantiate(Type[])"/> with a Manager with no Instantiate() method.
        /// </summary>
        [Fact]
        public void ManagerWithBadInstantiate()
        {
            ApplicationManager.Terminate();
            Assert.Throws<ManagerInstantiationException>(() => ApplicationManager.Instantiate(new Type[] { typeof(MockManagerBadInstantiate) }));
        }

        #endregion Public Methods
    }

    /// <summary>
    ///     Tests <see cref="ApplicationManager.Instantiate(Type[])"/> with a Type array containing a Type not implementing IManager.
    /// </summary>
    /// <remarks>Presented in a distinct class to enforce execution order.</remarks>
    [Collection("ApplicationManager")]
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    public class ApplicationManagerBadType : IDisposable
    {
        #region Public Methods

        /// <summary>
        ///     Disposes the ApplicationManager.
        /// </summary>
        public void Dispose()
        {
            ApplicationManager.Terminate();
        }

        /// <summary>
        ///     Tests <see cref="ApplicationManager.Instantiate(Type[])"/> with a Type array containing a Type not implementing IManager.
        /// </summary>
        [Fact]
        public void InstantiateWithNonIManager()
        {
            Assert.Throws<ManagerTypeListException>(() => ApplicationManager.Instantiate(new Type[] { typeof(int) }));
        }

        #endregion Public Methods
    }

    /// <summary>
    ///     Tests invocation of <see cref="ApplicationManager.Instantiate(Type[])"/> with a Manager with a broken
    ///     <see cref="Manager.Setup"/> method.
    /// </summary>
    /// <remarks>Presented in a distinct class to enforce execution order.</remarks>
    [Collection("ApplicationManager")]
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    public class ApplicationManagerBrokenTest : IDisposable
    {
        #region Public Methods

        /// <summary>
        ///     Disposes the ApplicationManager.
        /// </summary>
        public void Dispose()
        {
            ApplicationManager.Terminate();
        }

        /// <summary>
        ///     Tests <see cref="ApplicationManager.Instantiate(Type[])"/> with a Type array containing an instance of IManager
        ///     with the Setup() method returning a null Result.
        /// </summary>
        [Fact]
        public void InstantiateWithBrokenSetupMethod()
        {
            Assert.Throws<ManagerSetupException>(() => ApplicationManager.Instantiate(new Type[] { typeof(MockManagerBroken) }));
        }

        #endregion Public Methods
    }

    /// <summary>
    ///     Tests <see cref="ApplicationManager.Instantiate(Type[])"/> with a manager that doesn't implement IManager.
    /// </summary>
    /// <remarks>Presented in a distinct class to enforce execution order.</remarks>
    [Collection("ApplicationManager")]
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    public class ApplicationManagerDoesntImplementIManager : IDisposable
    {
        #region Public Methods

        /// <summary>
        ///     Disposes the ApplicationManager.
        /// </summary>
        public void Dispose()
        {
            ApplicationManager.Terminate();
        }

        /// <summary>
        ///     Tests <see cref="ApplicationManager.Instantiate(Type[])"/> with a Manager with no Instantiate() method.
        /// </summary>
        [Fact]
        public void ManagerDoesntImplementIManager()
        {
            Assert.Throws<ManagerTypeListException>(() => ApplicationManager.Instantiate(new Type[] { typeof(MockManagerDoesntImplementIManager) }));
        }

        #endregion Public Methods
    }

    /// <summary>
    ///     Test <see cref="ApplicationManager.Instantiate(Type[])"/> with a Type defined twice in the constructor Type list.
    /// </summary>
    /// <remarks>Presented in a distinct class to enforce execution order.</remarks>
    [Collection("ApplicationManager")]
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    public class ApplicationManagerDoubleManagers : IDisposable
    {
        #region Public Methods

        /// <summary>
        ///     Disposes the ApplicationManager.
        /// </summary>
        public void Dispose()
        {
            ApplicationManager.Terminate();
        }

        /// <summary>
        ///     Test <see cref="ApplicationManager.Instantiate(Type[])"/> with a Type defined twice in the constructor Type list.
        /// </summary>
        [Fact]
        public void DoubleManagers()
        {
            Assert.Throws<ManagerInstantiationException>(() => ApplicationManager.Instantiate(new Type[] { typeof(MockManager), typeof(MockManager) }));
        }

        #endregion Public Methods
    }

    /// <summary>
    ///     Tests <see cref="ApplicationManager.Instantiate(Type[])"/> with an empty Type array.
    /// </summary>
    /// <remarks>Presented in a distinct class to enforce execution order.</remarks>
    [Collection("ApplicationManager")]
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    public class ApplicationManagerEmptyArray : IDisposable
    {
        #region Public Methods

        /// <summary>
        ///     Disposes the ApplicationManager.
        /// </summary>
        public void Dispose()
        {
            ApplicationManager.Terminate();
        }

        /// <summary>
        ///     Tests <see cref="ApplicationManager.Instantiate(Type[])"/> with an empty Type array.
        /// </summary>
        [Fact]
        public void InstantiateWithEmpty()
        {
            Assert.Throws<ManagerTypeListException>(() => ApplicationManager.Instantiate(new Type[] { }));
        }

        #endregion Public Methods
    }

    /// <summary>
    ///     Tests <see cref="ApplicationManager.GetInstance"/> prior to invocation of <see cref="ApplicationManager.Instantiate(Type[])"/>.
    /// </summary>
    /// <remarks>Presented in a distinct class to enforce execution order.</remarks>
    [Collection("ApplicationManager")]
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    public class ApplicationManagerGetInstanceBeforeInstantiation : IDisposable
    {
        #region Public Methods

        /// <summary>
        ///     Disposes the ApplicationManager.
        /// </summary>
        public void Dispose()
        {
            ApplicationManager.Terminate();
        }

        /// <summary>
        ///     Tests <see cref="ApplicationManager.GetInstance"/> prior to invocation of <see cref="ApplicationManager.Instantiate(Type[])"/>.
        /// </summary>
        [Fact]
        public void GetInstanceBeforeInstantiation()
        {
            Assert.Throws<ManagerNotInitializedException>(() => ApplicationManager.GetInstance());
        }

        #endregion Public Methods
    }

    /// <summary>
    ///     Tests <see cref="ApplicationManager.GetInstance()"/> after first invoking <see cref="ApplicationManager.Instantiate(Type[])"/>.
    /// </summary>
    /// <remarks>Presented in a distinct class to enforce execution order.</remarks>
    [Collection("ApplicationManager")]
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    public class ApplicationManagerInstantiateAndGetInstanceTest : IDisposable
    {
        #region Public Methods

        /// <summary>
        ///     Disposes the ApplicationManager.
        /// </summary>
        public void Dispose()
        {
            ApplicationManager.Terminate();
        }

        /// <summary>
        ///     Tests <see cref="ApplicationManager.GetInstance()"/> after first invoking <see cref="ApplicationManager.Instantiate(Type[])"/>.
        /// </summary>
        [Fact]
        public void InstantiateAndGetInstance()
        {
            ApplicationManager manager1 = ApplicationManager.Instantiate(new Type[] { typeof(MockManager) });
            ApplicationManager manager2 = ApplicationManager.GetInstance();
        }

        #endregion Public Methods
    }

    /// <summary>
    ///     Tests successive invocations of <see cref="ApplicationManager.Instantiate(Type[])"/>.
    /// </summary>
    /// <remarks>Presented in a distinct class to enforce execution order.</remarks>
    [Collection("ApplicationManager")]
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    public class ApplicationManagerInstantiateTwiceTest : IDisposable
    {
        #region Public Methods

        /// <summary>
        ///     Disposes the ApplicationManager.
        /// </summary>
        public void Dispose()
        {
            ApplicationManager.Terminate();
        }

        /// <summary>
        ///     Tests successive invocations of <see cref="ApplicationManager.Instantiate(Type[])"/>.
        /// </summary>
        [Fact]
        public void InstantiateTwice()
        {
            ApplicationManager manager1 = ApplicationManager.Instantiate(new Type[] { typeof(MockManager) });
            ApplicationManager manager2 = ApplicationManager.Instantiate(new Type[] { typeof(MockManager) });
        }

        #endregion Public Methods
    }

    /// <summary>
    ///     Tests <see cref="ApplicationManager.Instantiate(Type[])"/> with a Manager with no dependencies defined.
    /// </summary>
    /// <remarks>Presented in a distinct class to enforce execution order.</remarks>
    [Collection("ApplicationManager")]
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    public class ApplicationManagerNoDependencies : IDisposable
    {
        #region Public Methods

        /// <summary>
        ///     Disposes the ApplicationManager.
        /// </summary>
        public void Dispose()
        {
            ApplicationManager.Terminate();
        }

        /// <summary>
        ///     Tests <see cref="ApplicationManager.Instantiate(Type[])"/> with a Manager with no dependencies defined.
        /// </summary>
        [Fact]
        public void ManagerWithNoDependencies()
        {
            Assert.Throws<ManagerInstantiationException>(() => ApplicationManager.Instantiate(new Type[] { typeof(MockManagerNoDependencies) }));
        }

        #endregion Public Methods
    }

    /// <summary>
    ///     Tests <see cref="ApplicationManager.Instantiate(Type[])"/> with a Manager with no Instantiate() method.
    /// </summary>
    /// <remarks>Presented in a distinct class to enforce execution order.</remarks>
    [Collection("ApplicationManager")]
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    public class ApplicationManagerNoInstantiate : IDisposable
    {
        #region Public Methods

        /// <summary>
        ///     Disposes the ApplicationManager.
        /// </summary>
        public void Dispose()
        {
            ApplicationManager.Terminate();
        }

        /// <summary>
        ///     Tests <see cref="ApplicationManager.Instantiate(Type[])"/> with a Manager with no Instantiate() method.
        /// </summary>
        [Fact]
        public void ManagerWithNoInstantiate()
        {
            Assert.Throws<ManagerInstantiationException>(() => ApplicationManager.Instantiate(new Type[] { typeof(MockManagerNoInstantiate) }));
        }

        #endregion Public Methods
    }

    /// <summary>
    ///     Tests <see cref="ApplicationManager.Instantiate(Type[])"/> with a null Type array.
    /// </summary>
    /// <remarks>Presented in a distinct class to enforce execution order.</remarks>
    [Collection("ApplicationManager")]
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    public class ApplicationManagerNullInstantiation : IDisposable
    {
        #region Public Methods

        /// <summary>
        ///     Disposes the ApplicationManager.
        /// </summary>
        public void Dispose()
        {
            ApplicationManager.Terminate();
        }

        /// <summary>
        ///     Tests <see cref="ApplicationManager.Instantiate(Type[])"/> with a null Type array.
        /// </summary>
        [Fact]
        public void InstantiateWithNull()
        {
            Assert.Throws<ManagerTypeListException>(() => ApplicationManager.Instantiate(null));
        }

        #endregion Public Methods
    }

    /// <summary>
    ///     Tests <see cref="Manager.Start()"/> and <see cref="Manager.Stop()"/>
    /// </summary>
    [Collection("ApplicationManager")]
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    public class ApplicationManagerStartStop
    {
        #region Public Methods

        /// <summary>
        ///     Tests <see cref="Manager.Start()"/> with a Manager known to return a failed Result from startup.
        /// </summary>
        [Fact]
        public void StartBadReturn()
        {
            ApplicationManager.Terminate();

            ApplicationManager manager = ApplicationManager.Instantiate(new Type[] { typeof(MockManagerStartBadReturn) });

            Assert.Throws<ManagerStartException>(() => manager.Start());
        }

        /// <summary>
        ///     Tests <see cref="Manager.Start()"/> with a Manager known to throw an exception during startup.
        /// </summary>
        [Fact]
        public void StartFail()
        {
            ApplicationManager.Terminate();

            ApplicationManager manager = ApplicationManager.Instantiate(new Type[] { typeof(MockManagerStartFail) });

            Assert.Throws<ManagerStartException>(() => manager.Start());
        }

        /// <summary>
        ///     Tests <see cref="Manager.Start()"/> and <see cref="Manager.Stop()"/>
        /// </summary>
        [Fact]
        public void StartStop()
        {
            ApplicationManager.Terminate();

            ApplicationManager manager = ApplicationManager.Instantiate(new Type[] { typeof(MockManager) });

            Result startResult = manager.Start();

            Assert.NotEqual(ResultCode.Failure, startResult.ResultCode);
            Assert.Equal(State.Running, manager.State);

            Result stopResult = manager.Stop();

            Assert.NotEqual(ResultCode.Failure, stopResult.ResultCode);
            Assert.Equal(State.Stopped, manager.State);
        }

        /// <summary>
        ///     Tests <see cref="Manager.Stop()"/> with a Manager known to return a failed Result from shutdown.
        /// </summary>
        [Fact]
        public void StopBadReturn()
        {
            ApplicationManager.Terminate();

            ApplicationManager manager = ApplicationManager.Instantiate(new Type[] { typeof(MockManagerStopBadReturn) });

            Result startResult = manager.Start();

            Assert.NotEqual(ResultCode.Failure, startResult.ResultCode);
            Assert.Equal(State.Running, manager.State);

            Assert.Throws<ManagerStopException>(() => manager.Stop());
        }

        /// <summary>
        ///     Tests <see cref="Manager.Stop()"/> with a Manager known to throw an exception during shutdown.
        /// </summary>
        [Fact]
        public void StopFail()
        {
            ApplicationManager.Terminate();

            ApplicationManager manager = ApplicationManager.Instantiate(new Type[] { typeof(MockManagerStopFail) });

            Result startResult = manager.Start();

            Assert.NotEqual(ResultCode.Failure, startResult.ResultCode);
            Assert.Equal(State.Running, manager.State);

            Assert.Throws<ManagerStopException>(() => manager.Stop());
        }

        #endregion Public Methods
    }

    /// <summary>
    ///     Unit tests for the ApplicationManager class.
    /// </summary>
    /// <remarks>Presented in a distinct class to enforce execution order.</remarks>
    [Collection("ApplicationManager")]
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]
    public class ApplicationManagerTests
    {
        #region Public Methods

        /// <summary>
        ///     Tests <see cref="ApplicationManager.Instantiate(Type[])"/> with a Type array containing a valid, functioning
        ///     IManager instance.
        /// </summary>
        [Fact]
        public void InstantiateWithValidIManager()
        {
            ApplicationManager.Terminate();

            ApplicationManager manager = ApplicationManager.Instantiate(new Type[] { typeof(MockManager) });

            Assert.IsType<ApplicationManager>(manager);
            Assert.NotNull(manager);

            ImmutableList<IManager> managers = manager.GetManagers();

            Assert.Equal(managers.Count, 2);

            Assert.NotNull(manager.ProductName);
            Assert.NotNull(manager.ProductVersion);
            Assert.Equal(manager.InstanceName, ApplicationManager.GetInstanceName());
        }

        #endregion Public Methods
    }
}