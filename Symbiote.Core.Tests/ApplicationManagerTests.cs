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

namespace Symbiote.Core.Tests
{
    /// <summary>
    ///     Tests <see cref="ApplicationManager.GetInstance()"/> after first invoking <see cref="ApplicationManager.Instantiate(Type[])"/>.
    /// </summary>
    /// <remarks>
    ///     Presented in a distinct class to enforce execution order.
    /// </remarks>
    public class ApplicationManagerInstantiateAndGetInstanceTest
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
    }

    /// <summary>
    ///     Tests <see cref="ApplicationManager.Instantiate(Type[])"/> with a Manager with a known bad dependency.
    /// </summary>
    /// <remarks>
    ///     Presented in a distinct class to enforce execution order.
    /// </remarks>
    public class ApplicationManagerBadDependency
    {
        /// <summary>
        ///     Tests <see cref="ApplicationManager.Instantiate(Type[])"/> with a Manager with a known bad dependency.
        /// </summary>
        [Fact]
        public void TestManagerWithBadDepdency()
        {
            Assert.Throws<ManagerInstantiationException>((() => ApplicationManager.Instantiate(new Type[] { typeof(MockManagerBadDependency) })));
        }
    }

    /// <summary>
    ///     Tests <see cref="ApplicationManager.Instantiate(Type[])"/> with a Manager with no Instantiate() method.
    /// </summary>
    /// <remarks>
    ///     Presented in a distinct class to enforce execution order.
    /// </remarks>
    public class ApplicationManagerBadInstantiate
    {
        /// <summary>
        ///     Tests <see cref="ApplicationManager.Instantiate(Type[])"/> with a Manager with no Instantiate() method.
        /// </summary>
        [Fact]
        public void TestManagerWithBadInstantiate()
        {
            Assert.Throws<ManagerInstantiationException>((() => ApplicationManager.Instantiate(new Type[] { typeof(MockManagerBadInstantiate) })));
        }
    }

    /// <summary>
    ///     Tests <see cref="ApplicationManager.Instantiate(Type[])"/> with a manager that doesn't implement IManager.
    /// </summary>
    /// <remarks>
    ///     Presented in a distinct class to enforce execution order.
    /// </remarks>
    public class ApplicationManagerDoesntImplementIManager
    {
        /// <summary>
        ///     Tests <see cref="ApplicationManager.Instantiate(Type[])"/> with a Manager with no Instantiate() method.
        /// </summary>
        [Fact]
        public void TestManagerDoesntImplementIManager()
        {
            Assert.Throws<ManagerTypeListException>((() => ApplicationManager.Instantiate(new Type[] { typeof(MockManagerDoesntImplementIManager) })));
        }
    }

    /// <summary>
    ///     Tests successive invocations of <see cref="ApplicationManager.Instantiate(Type[])"/>.
    /// </summary>
    /// <remarks>
    ///     Presented in a distinct class to enforce execution order.
    /// </remarks>
    public class ApplicationManagerInstantiateTwiceTest
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
    }

    public class NoInstantiate
    {
        /// <summary>
        ///     Tests <see cref="ApplicationManager.Instantiate(Type[])"/> with a Manager with no Instantiate() method.
        /// </summary>
        [Fact]
        public void TestManagerWithNoInstantiate()
        {
            Assert.Throws<ManagerInstantiationException>((() => ApplicationManager.Instantiate(new Type[] { typeof(MockManagerNoInstantiate) })));
        }
    }

    /// <summary>
    ///     Tests invocation of <see cref="ApplicationManager.Instantiate(Type[])"/> with a Manager with a broken <see cref="Manager.Setup"/> method.
    /// </summary>
    /// <remarks>
    ///     Presented in a distinct class to enforce execution order.
    /// </remarks>
    public class ApplicationManagerBrokenTest
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
    }

    /// <summary>
    ///     Tests <see cref="ApplicationManager.Instantiate(Type[])"/> with a Manager with no dependencies defined.
    /// </summary>
    public class ApplicationManagerNoDependencies
    {
        /// <summary>
        ///     Tests <see cref="ApplicationManager.Instantiate(Type[])"/> with a Manager with no dependencies defined.
        /// </summary>
        [Fact]
        public void TestManagerWithNoDependencies()
        {
            Assert.Throws<ManagerInstantiationException>(() => ApplicationManager.Instantiate(new Type[] { typeof(MockManagerNoDependencies) }));
        }
    }

    /// <summary>
    ///     Test <see cref="ApplicationManager.Instantiate(Type[])"/> with a Type defined twice in the constructor Type list. 
    /// </summary>
    public class ApplicationManagerDoubleManagers
    {
        /// <summary>
        ///     Test <see cref="ApplicationManager.Instantiate(Type[])"/> with a Type defined twice in the constructor Type list. 
        /// </summary>
        [Fact]
        public void TestDoubleManagers()
        {
            Assert.Throws<ManagerInstantiationException>(() => ApplicationManager.Instantiate(new Type[] { typeof(MockManager), typeof(MockManager) }));
        }
    }

    /// <summary>
    ///     Tests <see cref="ApplicationManager.GetInstance"/> prior to invocation of <see cref="ApplicationManager.Instantiate(Type[])"/>.  
    /// </summary>
    public class ApplicationManagerGetInstanceBeforeInstantiation
    {
        /// <summary>
        ///     Tests <see cref="ApplicationManager.GetInstance"/> prior to invocation of <see cref="ApplicationManager.Instantiate(Type[])"/>.  
        /// </summary>
        [Fact]
        public void TestGetInstanceBeforeInstantiation()
        {
            Assert.Throws<ManagerNotInitializedException>(() => ApplicationManager.GetInstance());
        }
    }

    /// <summary>
    ///     Tests <see cref="ApplicationManager.Instantiate(Type[])"/> with a null Type array.
    /// </summary>
    public class ApplicationManagerNullInstantiation
    {
        /// <summary>
        ///     Tests <see cref="ApplicationManager.Instantiate(Type[])"/> with a null Type array.
        /// </summary>
        [Fact]
        public void TestInstantiateWithNull()
        {
            Assert.Throws<ManagerTypeListException>(() => ApplicationManager.Instantiate(null));
        }
    }

    /// <summary>
    /// Tests <see cref="ApplicationManager.Instantiate(Type[])"/> with an empty Type array.
    /// </summary>
    public class ApplicationManagerEmptyArray
    {
        /// <summary>
        /// Tests <see cref="ApplicationManager.Instantiate(Type[])"/> with an empty Type array.
        /// </summary>
        [Fact]
        public void TestInstantiateWithEmpty()
        {
            Assert.Throws<ManagerTypeListException>(() => ApplicationManager.Instantiate(new Type[] { }));
        }
    }

    /// <summary>
    ///     Tests <see cref="ApplicationManager.Instantiate(Type[])"/> with a Type array containing a Type not implementing IManager.
    /// </summary>
    public class ApplicationManagerBadType
    {
        /// <summary>
        ///     Tests <see cref="ApplicationManager.Instantiate(Type[])"/> with a Type array containing a Type not implementing IManager.
        /// </summary>
        [Fact]
        public void TestInstantiateWithNonIManager()
        {
            Assert.Throws<ManagerTypeListException>(() => ApplicationManager.Instantiate(new Type[] { typeof(int) }));
        }
    }

    /// <summary>
    ///     Unit tests for the ApplicationManager class.
    /// </summary>
    public class ApplicationManagerTests
    {
        /// <summary>
        ///     Tests <see cref="ApplicationManager.Instantiate(Type[])"/> with a Type array containing a valid, functioning IManager instance.
        /// </summary>
        [Fact]
        public void TestInstantiateWithValidIManager()
        {
            ApplicationManager manager = ApplicationManager.Instantiate(new Type[] { typeof(MockManager) });

            Assert.IsType<ApplicationManager>(manager);
            Assert.NotNull(manager);

            ImmutableList<IManager> managers = manager.GetManagers();
        
            Assert.Equal(managers.Count, 2);

            Assert.NotNull(manager.ProductName);
            Assert.NotNull(manager.ProductVersion);
            Assert.Equal(manager.InstanceName, ApplicationManager.GetInstanceName());

            ApplicationManager.GetInstance().Start();
            ApplicationManager.GetInstance().Stop();
        }
    }
}
