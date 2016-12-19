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
using Symbiote.Core.Tests.Mockups;
using Symbiote.SDK;
using Moq;
using Utility.OperationResult;
using Xunit;

namespace Symbiote.Core.Tests
{
    [Collection("ApplicationManager")]
    public class ApplicationManager
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ApplicationManager"/> class.
        /// </summary>
        /// <remarks>Terminates any previous instantiation of the ApplicationManager prior to each test.</remarks>
        public ApplicationManager()
        {
            Core.ApplicationManager.Terminate();
        }

        /// <summary>
        ///     Tests <see cref="Core.ApplicationManager.Instantiate(Type[])"/> with a Manager with a known bad dependency.
        /// </summary>
        [Fact]
        public void ManagerWithBadDepdency()
        {
            Assert.Throws<ManagerInstantiationException>(() => Core.ApplicationManager.Instantiate(new Type[] { typeof(MockManagerBadDependency) }));
        }

        /// <summary>
        ///     Tests <see cref="ApplicationManager.Instantiate(Type[])"/> with a Manager with no Instantiate() method.
        /// </summary>
        [Fact]
        public void ManagerWithBadInstantiate()
        {
            Assert.Throws<ManagerInstantiationException>(() => Core.ApplicationManager.Instantiate(new Type[] { typeof(MockManagerBadInstantiate) }));
        }

        /// <summary>
        ///     Tests <see cref="ApplicationManager.Instantiate(Type[])"/> with a Type array containing a Type not implementing IManager.
        /// </summary>
        [Fact]
        public void InstantiateWithNonIManager()
        {
            Assert.Throws<ManagerTypeListException>(() => Core.ApplicationManager.Instantiate(new Type[] { typeof(int) }));
        }

        /// <summary>
        ///     Tests <see cref="ApplicationManager.Instantiate(Type[])"/> with a Type array containing an instance of IManager
        ///     with the Setup() method returning a null Result.
        /// </summary>
        [Fact]
        public void InstantiateWithBrokenSetupMethod()
        {
            Assert.Throws<ManagerSetupException>(() => Core.ApplicationManager.Instantiate(new Type[] { typeof(MockManagerBroken) }));
        }

        /// <summary>
        ///     Tests <see cref="ApplicationManager.Instantiate(Type[])"/> with a Manager with no Instantiate() method.
        /// </summary>
        [Fact]
        public void ManagerDoesntImplementIManager()
        {
            Assert.Throws<ManagerTypeListException>(() => Core.ApplicationManager.Instantiate(new Type[] { typeof(MockManagerDoesntImplementIManager) }));
        }

        /// <summary>
        ///     Test <see cref="ApplicationManager.Instantiate(Type[])"/> with a Type defined twice in the constructor Type list.
        /// </summary>
        [Fact]
        public void DoubleManagers()
        {
            Assert.Throws<ManagerInstantiationException>(() => Core.ApplicationManager.Instantiate(new Type[] { typeof(MockManager), typeof(MockManager) }));
        }

        /// <summary>
        ///     Tests <see cref="ApplicationManager.Instantiate(Type[])"/> with an empty Type array.
        /// </summary>
        [Fact]
        public void InstantiateWithEmptyArray()
        {
            Assert.Throws<ManagerTypeListException>(() => Core.ApplicationManager.Instantiate(new Type[] { }));
        }

        /// <summary>
        ///     Tests <see cref="ApplicationManager.GetInstance"/> prior to invocation of <see cref="ApplicationManager.Instantiate(Type[])"/>.
        /// </summary>
        [Fact]
        public void GetInstanceBeforeInstantiation()
        {
            Assert.Throws<ManagerNotInitializedException>(() => Core.ApplicationManager.GetInstance());
        }

        /// <summary>
        ///     Tests <see cref="ApplicationManager.GetInstance()"/> after first invoking <see cref="ApplicationManager.Instantiate(Type[])"/>.
        /// </summary>
        [Fact]
        public void InstantiateAndGetInstance()
        {
            Core.ApplicationManager manager1 = Core.ApplicationManager.Instantiate(new Type[] { typeof(MockManager) });
            Core.ApplicationManager manager2 = Core.ApplicationManager.GetInstance();

            Assert.Equal(manager1, manager2);
        }

        /// <summary>
        ///     Tests successive invocations of <see cref="ApplicationManager.Instantiate(Type[])"/>.
        /// </summary>
        [Fact]
        public void InstantiateTwice()
        {
            Core.ApplicationManager manager1 = Core.ApplicationManager.Instantiate(new Type[] { typeof(MockManager) });
            Core.ApplicationManager manager2 = Core.ApplicationManager.Instantiate(new Type[] { typeof(MockManager) });
        }

        /// <summary>
        ///     Tests <see cref="ApplicationManager.Instantiate(Type[])"/> with a Manager with no dependencies defined.
        /// </summary>
        [Fact]
        public void ManagerWithNoDependencies()
        {
            Assert.Throws<ManagerInstantiationException>(() => Core.ApplicationManager.Instantiate(new Type[] { typeof(MockManagerNoDependencies) }));
        }

        /// <summary>
        ///     Tests <see cref="ApplicationManager.Instantiate(Type[])"/> with a Manager with no Instantiate() method.
        /// </summary>
        [Fact]
        public void ManagerWithNoInstantiate()
        {
            Assert.Throws<ManagerInstantiationException>(() => Core.ApplicationManager.Instantiate(new Type[] { typeof(MockManagerNoInstantiate) }));
        }

        /// <summary>
        ///     Tests <see cref="ApplicationManager.Instantiate(Type[])"/> with a null Type array.
        /// </summary>
        [Fact]
        public void InstantiateWithNull()
        {
            Assert.Throws<ManagerTypeListException>(() => Core.ApplicationManager.Instantiate(null));
        }

        /// <summary>
        ///     Tests <see cref="Manager.Start()"/> with a Manager known to return a failed Result from startup.
        /// </summary>
        [Fact]
        public void StartBadReturn()
        {
            Core.ApplicationManager manager = Core.ApplicationManager.Instantiate(new Type[] { typeof(MockManagerStartBadReturn) });

            Assert.Throws<ManagerStartException>(() => manager.Start());
        }

        /// <summary>
        ///     Tests <see cref="Manager.Start()"/> with a Manager known to throw an exception during startup.
        /// </summary>
        [Fact]
        public void StartFail()
        {
            Core.ApplicationManager manager = Core.ApplicationManager.Instantiate(new Type[] { typeof(MockManagerStartFail) });

            Assert.Throws<ManagerStartException>(() => manager.Start());
        }

        /// <summary>
        ///     Tests <see cref="Manager.Start()"/> and <see cref="Manager.Stop()"/>
        /// </summary>
        [Fact]
        public void StartStop()
        {
            Core.ApplicationManager manager = Core.ApplicationManager.Instantiate(new Type[] { typeof(MockManager) });

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
            Core.ApplicationManager manager = Core.ApplicationManager.Instantiate(new Type[] { typeof(MockManagerStopBadReturn) });

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
            Core.ApplicationManager manager = Core.ApplicationManager.Instantiate(new Type[] { typeof(MockManagerStopFail) });

            Result startResult = manager.Start();

            Assert.NotEqual(ResultCode.Failure, startResult.ResultCode);
            Assert.Equal(State.Running, manager.State);

            Assert.Throws<ManagerStopException>(() => manager.Stop());
        }

        /// <summary>
        ///     Tests <see cref="ApplicationManager.Instantiate(Type[])"/> with a Type array containing a valid, functioning
        ///     IManager instance.
        /// </summary>
        [Fact]
        public void InstantiateWithValidIManager()
        {
            Core.ApplicationManager manager = Core.ApplicationManager.Instantiate(new Type[] { typeof(MockManager) });

            Assert.IsType<Core.ApplicationManager>(manager);
            Assert.NotNull(manager);

            ImmutableList<IManager> managers = manager.GetManagers();

            Assert.Equal(managers.Count, 2);

            Assert.NotNull(manager.ProductName);
            Assert.NotNull(manager.ProductVersion);
            Assert.Equal(manager.InstanceName, Core.ApplicationManager.GetInstanceName());
        }
    }
}