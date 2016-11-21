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
using Symbiote.Core.SDK;
using Symbiote.Core.Tests.Mockups;
using System;
using System.Collections.Immutable;
using Xunit;
using Utility.OperationResult;

namespace Symbiote.Core.Tests
{
    /// <summary>
    ///     Tests <see cref="ApplicationManager.GetInstance()"/> after first invoking <see cref="ApplicationManager.Instantiate(Type[])"/>.
    /// </summary>
    /// <remarks>
    ///     Presented in a distinct class to enforce execution order.
    /// </remarks>
    [Collection("ApplicationManager")]
    public class ApplicationManagerInstantiateAndGetInstanceTest : IDisposable
    {
        /// <summary>
        ///     Tests <see cref="ApplicationManager.GetInstance()"/> after first invoking <see cref="ApplicationManager.Instantiate(Type[])"/>.
        /// </summary>
        [Fact]
        public void TestInstantiateAndGetInstance()
        {
            ApplicationManager manager1 = ApplicationManager.Instantiate(new Type[] { typeof(MockManager) });
            ApplicationManager manager2 = ApplicationManager.GetInstance();
        }

        /// <summary>
        ///     Disposes the ApplicationManager.
        /// </summary>
        public void Dispose()
        {
            ApplicationManager.Dispose();
        }
    }

    /// <summary>
    ///     Tests <see cref="ApplicationManager.Instantiate(Type[])"/> with a Manager with a known bad dependency.
    /// </summary>
    /// <remarks>
    ///     Presented in a distinct class to enforce execution order.
    /// </remarks>
    [Collection("ApplicationManager")]
    public class ApplicationManagerBadDependency : IDisposable
    {
        /// <summary>
        ///     Tests <see cref="ApplicationManager.Instantiate(Type[])"/> with a Manager with a known bad dependency.
        /// </summary>
        [Fact]
        public void TestManagerWithBadDepdency()
        {
            Assert.Throws<ManagerInstantiationException>((() => ApplicationManager.Instantiate(new Type[] { typeof(MockManagerBadDependency) })));
        }

        /// <summary>
        ///     Disposes the ApplicationManager.
        /// </summary>
        public void Dispose()
        {
            ApplicationManager.Dispose();
        }
    }

    /// <summary>
    ///     Tests <see cref="ApplicationManager.Instantiate(Type[])"/> with a Manager with no Instantiate() method.
    /// </summary>
    /// <remarks>
    ///     Presented in a distinct class to enforce execution order.
    /// </remarks>
    [Collection("ApplicationManager")]
    public class ApplicationManagerBadInstantiate : IDisposable
    {
        /// <summary>
        ///     Tests <see cref="ApplicationManager.Instantiate(Type[])"/> with a Manager with no Instantiate() method.
        /// </summary>
        [Fact]
        public void TestManagerWithBadInstantiate()
        {
            Assert.Throws<ManagerInstantiationException>((() => ApplicationManager.Instantiate(new Type[] { typeof(MockManagerBadInstantiate) })));
        }

        /// <summary>
        ///     Disposes the ApplicationManager.
        /// </summary>
        public void Dispose()
        {
            ApplicationManager.Dispose();
        }
    }

    /// <summary>
    ///     Tests <see cref="ApplicationManager.Instantiate(Type[])"/> with a manager that doesn't implement IManager.
    /// </summary>
    /// <remarks>
    ///     Presented in a distinct class to enforce execution order.
    /// </remarks>
    [Collection("ApplicationManager")]
    public class ApplicationManagerDoesntImplementIManager : IDisposable
    {
        /// <summary>
        ///     Tests <see cref="ApplicationManager.Instantiate(Type[])"/> with a Manager with no Instantiate() method.
        /// </summary>
        [Fact]
        public void TestManagerDoesntImplementIManager()
        {
            Assert.Throws<ManagerTypeListException>((() => ApplicationManager.Instantiate(new Type[] { typeof(MockManagerDoesntImplementIManager) })));
        }

        /// <summary>
        ///     Disposes the ApplicationManager.
        /// </summary>
        public void Dispose()
        {
            ApplicationManager.Dispose();
        }
    }

    /// <summary>
    ///     Tests successive invocations of <see cref="ApplicationManager.Instantiate(Type[])"/>.
    /// </summary>
    /// <remarks>
    ///     Presented in a distinct class to enforce execution order.
    /// </remarks>
    [Collection("ApplicationManager")]
    public class ApplicationManagerInstantiateTwiceTest : IDisposable
    {
        /// <summary>
        ///     Tests successive invocations of <see cref="ApplicationManager.Instantiate(Type[])"/>.
        /// </summary>
        [Fact]
        public void TestInstantiateTwice()
        {
            ApplicationManager manager1 = ApplicationManager.Instantiate(new Type[] { typeof(MockManager) });
            ApplicationManager manager2 = ApplicationManager.Instantiate(new Type[] { typeof(MockManager) });
        }

        /// <summary>
        ///     Disposes the ApplicationManager.
        /// </summary>
        public void Dispose()
        {
            ApplicationManager.Dispose();
        }
    }

    /// <summary>
    ///     Tests <see cref="ApplicationManager.Instantiate(Type[])"/> with a Manager with no Instantiate() method.
    /// </summary>
    /// <remarks>
    ///     Presented in a distinct class to enforce execution order.
    /// </remarks>
    [Collection("ApplicationManager")]
    public class ApplicationManagerNoInstantiate : IDisposable
    {
        /// <summary>
        ///     Tests <see cref="ApplicationManager.Instantiate(Type[])"/> with a Manager with no Instantiate() method.
        /// </summary>
        [Fact]
        public void TestManagerWithNoInstantiate()
        {
            Assert.Throws<ManagerInstantiationException>((() => ApplicationManager.Instantiate(new Type[] { typeof(MockManagerNoInstantiate) })));
        }

        /// <summary>
        ///     Disposes the ApplicationManager.
        /// </summary>
        public void Dispose()
        {
            ApplicationManager.Dispose();
        }
    }

    /// <summary>
    ///     Tests invocation of <see cref="ApplicationManager.Instantiate(Type[])"/> with a Manager with a broken <see cref="Manager.Setup"/> method.
    /// </summary>
    /// <remarks>
    ///     Presented in a distinct class to enforce execution order.
    /// </remarks>
    [Collection("ApplicationManager")]
    public class ApplicationManagerBrokenTest : IDisposable
    {
        /// <summary>
        ///     Tests <see cref="ApplicationManager.Instantiate(Type[])"/> with a Type array containing an instance of IManager with the 
        ///     Setup() method returning a null Result.
        /// </summary>
        [Fact]
        public void TestInstantiateWithBrokenSetupMethod()
        {
            Assert.Throws<ManagerSetupException>(() => ApplicationManager.Instantiate(new Type[] { typeof(MockManagerBroken) }));
        }

        /// <summary>
        ///     Disposes the ApplicationManager.
        /// </summary>
        public void Dispose()
        {
            ApplicationManager.Dispose();
        }
    }

    /// <summary>
    ///     Tests <see cref="ApplicationManager.Instantiate(Type[])"/> with a Manager with no dependencies defined.
    /// </summary>
    /// <remarks>
    ///     Presented in a distinct class to enforce execution order.
    /// </remarks>
    [Collection("ApplicationManager")]
    public class ApplicationManagerNoDependencies : IDisposable
    {
        /// <summary>
        ///     Tests <see cref="ApplicationManager.Instantiate(Type[])"/> with a Manager with no dependencies defined.
        /// </summary>
        [Fact]
        public void TestManagerWithNoDependencies()
        {
            Assert.Throws<ManagerInstantiationException>(() => ApplicationManager.Instantiate(new Type[] { typeof(MockManagerNoDependencies) }));
        }

        /// <summary>
        ///     Disposes the ApplicationManager.
        /// </summary>
        public void Dispose()
        {
            ApplicationManager.Dispose();
        }
    }

    /// <summary>
    ///     Test <see cref="ApplicationManager.Instantiate(Type[])"/> with a Type defined twice in the constructor Type list. 
    /// </summary>
    /// <remarks>
    ///     Presented in a distinct class to enforce execution order.
    /// </remarks>
    [Collection("ApplicationManager")]
    public class ApplicationManagerDoubleManagers : IDisposable
    {
        /// <summary>
        ///     Test <see cref="ApplicationManager.Instantiate(Type[])"/> with a Type defined twice in the constructor Type list. 
        /// </summary>
        [Fact]
        public void TestDoubleManagers()
        {
            Assert.Throws<ManagerInstantiationException>(() => ApplicationManager.Instantiate(new Type[] { typeof(MockManager), typeof(MockManager) }));
        }

        /// <summary>
        ///     Disposes the ApplicationManager.
        /// </summary>
        public void Dispose()
        {
            ApplicationManager.Dispose();
        }
    }

    /// <summary>
    ///     Tests <see cref="ApplicationManager.GetInstance"/> prior to invocation of <see cref="ApplicationManager.Instantiate(Type[])"/>.  
    /// </summary>
    /// <remarks>
    ///     Presented in a distinct class to enforce execution order.
    /// </remarks>
    [Collection("ApplicationManager")]
    public class ApplicationManagerGetInstanceBeforeInstantiation : IDisposable
    {
        /// <summary>
        ///     Tests <see cref="ApplicationManager.GetInstance"/> prior to invocation of <see cref="ApplicationManager.Instantiate(Type[])"/>.  
        /// </summary>
        [Fact]
        public void TestGetInstanceBeforeInstantiation()
        {
            Assert.Throws<ManagerNotInitializedException>(() => ApplicationManager.GetInstance());
        }

        /// <summary>
        ///     Disposes the ApplicationManager.
        /// </summary>
        public void Dispose()
        {
            ApplicationManager.Dispose();
        }
    }

    /// <summary>
    ///     Tests <see cref="ApplicationManager.Instantiate(Type[])"/> with a null Type array.
    /// </summary>
    /// <remarks>
    ///     Presented in a distinct class to enforce execution order.
    /// </remarks>
    [Collection("ApplicationManager")]
    public class ApplicationManagerNullInstantiation : IDisposable
    {
        /// <summary>
        ///     Tests <see cref="ApplicationManager.Instantiate(Type[])"/> with a null Type array.
        /// </summary>
        [Fact]
        public void TestInstantiateWithNull()
        {
            Assert.Throws<ManagerTypeListException>(() => ApplicationManager.Instantiate(null));
        }

        /// <summary>
        ///     Disposes the ApplicationManager.
        /// </summary>
        public void Dispose()
        {
            ApplicationManager.Dispose();
        }
    }

    /// <summary>
    ///     Tests <see cref="ApplicationManager.Instantiate(Type[])"/> with an empty Type array.
    /// </summary>
    /// <remarks>
    ///     Presented in a distinct class to enforce execution order.
    /// </remarks>
    [Collection("ApplicationManager")]
    public class ApplicationManagerEmptyArray : IDisposable
    {
        /// <summary>
        ///     Tests <see cref="ApplicationManager.Instantiate(Type[])"/> with an empty Type array.
        /// </summary>
        [Fact]
        public void TestInstantiateWithEmpty()
        {
            Assert.Throws<ManagerTypeListException>(() => ApplicationManager.Instantiate(new Type[] { }));
        }

        /// <summary>
        ///     Disposes the ApplicationManager.
        /// </summary>
        public void Dispose()
        {
            ApplicationManager.Dispose();
        }
    }

    /// <summary>
    ///     Tests <see cref="ApplicationManager.Instantiate(Type[])"/> with a Type array containing a Type not implementing IManager.
    /// </summary>
    /// <remarks>
    ///     Presented in a distinct class to enforce execution order.
    /// </remarks>
    [Collection("ApplicationManager")]
    public class ApplicationManagerBadType : IDisposable
    {
        /// <summary>
        ///     Tests <see cref="ApplicationManager.Instantiate(Type[])"/> with a Type array containing a Type not implementing IManager.
        /// </summary>
        [Fact]
        public void TestInstantiateWithNonIManager()
        {
            Assert.Throws<ManagerTypeListException>(() => ApplicationManager.Instantiate(new Type[] { typeof(int) }));
        }

        /// <summary>
        ///     Disposes the ApplicationManager.
        /// </summary>
        public void Dispose()
        {
            ApplicationManager.Dispose();
        }
    }

    /// <summary>
    ///     Unit tests for the ApplicationManager class.
    /// </summary>
    /// <remarks>
    ///     Presented in a distinct class to enforce execution order.
    /// </remarks>
    [Collection("ApplicationManager")]
    public class ApplicationManagerTests
    {
        /// <summary>
        ///     Tests <see cref="ApplicationManager.Instantiate(Type[])"/> with a Type array containing a valid, functioning IManager instance.
        /// </summary>
        [Fact]
        public void TestInstantiateWithValidIManager()
        {
            ApplicationManager.Dispose();

            ApplicationManager manager = ApplicationManager.Instantiate(new Type[] { typeof(MockManager) });

            Assert.IsType<ApplicationManager>(manager);
            Assert.NotNull(manager);

            ImmutableList<IManager> managers = manager.GetManagers();
        
            Assert.Equal(managers.Count, 2);

            Assert.NotNull(manager.ProductName);
            Assert.NotNull(manager.ProductVersion);
            Assert.Equal(manager.InstanceName, ApplicationManager.GetInstanceName());
        }
    }

    /// <summary>
    ///     Tests <see cref="Manager.Start()"/> and <see cref="Manager.Stop()"/> 
    /// </summary>
    [Collection("ApplicationManager")]
    public class ApplicationManagerStartStop
    {
        /// <summary>
        ///     Tests <see cref="Manager.Start()"/> and <see cref="Manager.Stop()"/> 
        /// </summary>
        [Fact]
        public void TestStartStop()
        {
            ApplicationManager.Dispose();

            ApplicationManager manager = ApplicationManager.Instantiate(new Type[] { typeof(MockManager) });

            Result startResult = manager.Start();

            Assert.NotEqual(ResultCode.Failure, startResult.ResultCode);
            Assert.Equal(State.Running, manager.State);

            Result stopResult = manager.Stop();

            Assert.NotEqual(ResultCode.Failure, stopResult.ResultCode);
            Assert.Equal(State.Stopped, manager.State);
        }

        /// <summary>
        ///     Tests <see cref="Manager.Start()"/> with a Manager known to throw an exception during startup. 
        /// </summary>
        [Fact]
        public void TestStartFail()
        {
            ApplicationManager.Dispose();

            ApplicationManager manager = ApplicationManager.Instantiate(new Type[] { typeof(MockManagerStartFail) });

            Assert.Throws<ManagerStartException>(() => manager.Start());
        }

        /// <summary>
        ///     Tests <see cref="Manager.Start()"/> with a Manager known to return a failed Result from startup. 
        /// </summary>
        [Fact]
        public void TestStartBadReturn()
        {
            ApplicationManager.Dispose();

            ApplicationManager manager = ApplicationManager.Instantiate(new Type[] { typeof(MockManagerStartBadReturn) });

            Assert.Throws<ManagerStartException>(() => manager.Start());
        }

        /// <summary>
        ///     Tests <see cref="Manager.Stop()"/> with a Manager known to throw an exception during shutdown.
        /// </summary>
        [Fact]
        public void TestStopFail()
        {
            ApplicationManager.Dispose();

            ApplicationManager manager = ApplicationManager.Instantiate(new Type[] { typeof(MockManagerStopFail) });

            Result startResult = manager.Start();

            Assert.NotEqual(ResultCode.Failure, startResult.ResultCode);
            Assert.Equal(State.Running, manager.State);

            Assert.Throws<ManagerStopException>(() => manager.Stop());
        }

        /// <summary>
        ///     Tests <see cref="Manager.Stop()"/> with a Manager known to return a failed Result from shutdown. 
        /// </summary>
        [Fact]
        public void TestStopBadReturn()
        {
            ApplicationManager.Dispose();

            ApplicationManager manager = ApplicationManager.Instantiate(new Type[] { typeof(MockManagerStopBadReturn) });

            Result startResult = manager.Start();

            Assert.NotEqual(ResultCode.Failure, startResult.ResultCode);
            Assert.Equal(State.Running, manager.State);

            Assert.Throws<ManagerStopException>(() => manager.Stop());
        }
    }
}
