/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀ 
      █   
      █      ▄███████▄                                                                ▄▄▄▄███▄▄▄▄                                                             
      █     ███    ███                                                              ▄██▀▀▀███▀▀▀██▄                                                           
      █     ███    ███    █████  ██████     ▄████▄     █████   ▄█████     ▄▄██▄▄▄   ███   ███   ███   ▄█████  ██▄▄▄▄    ▄█████     ▄████▄     ▄█████    █████ 
      █     ███    ███   ██  ██ ██    ██   ██    ▀    ██  ██   ██   ██  ▄█▀▀██▀▀█▄  ███   ███   ███   ██   ██ ██▀▀▀█▄   ██   ██   ██    ▀    ██   █    ██  ██ 
      █   ▀█████████▀   ▄██▄▄█▀ ██    ██  ▄██        ▄██▄▄█▀   ██   ██  ██  ██  ██  ███   ███   ███   ██   ██ ██   ██   ██   ██  ▄██        ▄██▄▄     ▄██▄▄█▀ 
      █     ███        ▀███████ ██    ██ ▀▀██ ███▄  ▀███████ ▀████████  ██  ██  ██  ███   ███   ███ ▀████████ ██   ██ ▀████████ ▀▀██ ███▄  ▀▀██▀▀    ▀███████ 
      █     ███          ██  ██ ██    ██   ██    ██   ██  ██   ██   ██  ██  ██  ██  ███   ███   ███   ██   ██ ██   ██   ██   ██   ██    ██   ██   █    ██  ██ 
      █    ▄████▀        ██  ██  ██████    ██████▀    ██  ██   ██   █▀   █  ██  █    ▀█   ███   █▀    ██   █▀  █   █    ██   █▀   ██████▀    ███████   ██  ██ 
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
using Symbiote.Core.Test.Mockups;
using System;
using Xunit;

namespace Symbiote.Core.Test
{
    /// <summary>
    /// Tests <see cref="ApplicationManager.GetInstance()"/> without having first instantiated the Manager.
    /// </summary>
    /// <remarks>
    /// Presented in a distinct class to enforce execution order.
    /// </remarks>
    public class ApplicationManagerGetInstanceTest
    {
        [Fact]
        public void TestGetInstance()
        {
            Assert.Throws<ManagerNotInitializedException>(() => ApplicationManager.GetInstance());
        }
    }

    /// <summary>
    /// Tests <see cref="ApplicationManager.GetInstance()"/> after first invoking <see cref="ApplicationManager.Instantiate(Type[])"/>.
    /// </summary>
    /// <remarks>
    /// Presented in a distinct class to enforce execution order.
    /// </remarks>
    public class ApplicationManagerInstantiateAndGetInstanceTest
    {
        [Fact]
        public void TestInstantiateAndGetInstance()
        {
            ApplicationManager manager1 = ApplicationManager.Instantiate(new Type[] { typeof(MockManager) });
            ApplicationManager manager2 = ApplicationManager.GetInstance();

            Assert.Equal(manager1, manager2);
        }
    }

    /// <summary>
    /// Tests successive invocations of <see cref="ApplicationManager.Instantiate(Type[])"/>.
    /// </summary>
    /// <remarks>
    /// Presented in a distinct class to enforce execution order.
    /// </remarks>
    public class ApplicationManagerInstantiateTwiceTest
    {
        [Fact]
        public void TestInstantiateTwice()
        {
            ApplicationManager manager1 = ApplicationManager.Instantiate(new Type[] { typeof(MockManager) });
            ApplicationManager manager2 = ApplicationManager.Instantiate(new Type[] { typeof(MockManager) });

            Assert.Equal(manager1, manager2);
        }
    }

    /// <summary>
    /// Unit tests for the ApplicationManager class.
    /// </summary>
    public class ApplicationManagerTests
    {
        [Fact]
        public void TestGetInstanceBeforeInstantiation()
        {
            Assert.Throws<ManagerNotInitializedException>(() => ApplicationManager.GetInstance());
        }

        /// <summary>
        /// Tests instantiation of the ApplicationManager with a null Type array.
        /// </summary>
        [Fact]
        public void TestInstantiateWithNull()
        {
            Assert.Throws<ManagerTypeListException>(() => ApplicationManager.Instantiate(null));
        }

        /// <summary>
        /// Tests instantiation of the ApplicationManager with an empty Type array.
        /// </summary>
        [Fact]
        public void TestInstantiateWithEmpty()
        {
            Assert.Throws<ManagerTypeListException>(() => ApplicationManager.Instantiate(new Type[] { }));
        }

        /// <summary>
        /// Tests instantiation of the ApplicationManager with a Type array containing a Type not implementing IManager.
        /// </summary>
        [Fact]
        public void TestInstantiateWithNonIManager()
        {
            Assert.Throws<ManagerTypeListException>(() => ApplicationManager.Instantiate(new Type[] { typeof(int) }));
        }

        /// <summary>
        ///     Tests instantiation of the ApplicationManager with a Type array containing an instance of IManager with the 
        ///     Setup() method returning a null Result/
        /// </summary>
        [Fact]
        public void TestInstantiateWithBrokenSetupMethod()
        {
            Assert.Throws<ManagerSetupException>(() => ApplicationManager.Instantiate(new Type[] { typeof(MockManagerBroken) }));
        }

        /// <summary>
        /// Tests instantiation of the ApplicationManager with a Type array containing a valid, functioning IManager instance.
        /// </summary>
        [Fact]
        public void TestInstantiateWithValidIManager()
        {
            ApplicationManager manager = ApplicationManager.Instantiate(new Type[] { typeof(MockManager) });

            Assert.IsType<ApplicationManager>(manager);
            Assert.NotNull(manager);
        }
    }
}
