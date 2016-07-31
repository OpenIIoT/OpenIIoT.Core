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
      █  Unit tests for the ProgramManager class.
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
    /// Tests <see cref="ProgramManager.GetInstance()"/> without having first instantiated the Manager.
    /// </summary>
    /// <remarks>
    /// Presented in a distinct class to enforce execution order.
    /// </remarks>
    public class ProgramManagerGetInstanceTest
    {
        [Fact]
        public void TestGetInstance()
        {
            Assert.Throws<ManagerNotInitializedException>(() => ProgramManager.GetInstance());
        }
    }

    /// <summary>
    /// Tests <see cref="ProgramManager.GetInstance()"/> after first invoking <see cref="ProgramManager.Instantiate(Type[])"/>.
    /// </summary>
    /// <remarks>
    /// Presented in a distinct class to enforce execution order.
    /// </remarks>
    public class ProgramManagerInstantiateAndGetInstanceTest
    {
        [Fact]
        public void TestInstantiateAndGetInstance()
        {
            ProgramManager manager1 = ProgramManager.Instantiate(new Type[] { typeof(MockManager) });
            ProgramManager manager2 = ProgramManager.GetInstance();

            Assert.Equal(manager1, manager2);
        }
    }

    /// <summary>
    /// Tests successive invocations of <see cref="ProgramManager.Instantiate(Type[])"/>.
    /// </summary>
    /// <remarks>
    /// Presented in a distinct class to enforce execution order.
    /// </remarks>
    public class ProgramManagerInstantiateTwiceTest
    {
        [Fact]
        public void TestInstantiateTwice()
        {
            ProgramManager manager1 = ProgramManager.Instantiate(new Type[] { typeof(MockManager) });
            ProgramManager manager2 = ProgramManager.Instantiate(new Type[] { typeof(MockManager) });

            Assert.Equal(manager1, manager2);
        }
    }

    /// <summary>
    /// Unit tests for the ProgramManager class.
    /// </summary>
    public class ProgramManagerTests
    {
        [Fact]
        public void TestGetInstanceBeforeInstantiation()
        {
            Assert.Throws<ManagerNotInitializedException>(() => ProgramManager.GetInstance());
        }

        /// <summary>
        /// Tests instantiation of the ProgramManager with a null Type array.
        /// </summary>
        [Fact]
        public void TestInstantiateWithNull()
        {
            Assert.Throws<ManagerTypeListException>(() => ProgramManager.Instantiate(null));
        }

        /// <summary>
        /// Tests instantiation of the ProgramManager with an empty Type array.
        /// </summary>
        [Fact]
        public void TestInstantiateWithEmpty()
        {
            Assert.Throws<ManagerTypeListException>(() => ProgramManager.Instantiate(new Type[] { }));
        }

        /// <summary>
        /// Tests instantiation of the ProgramManager with a Type array containing a Type not implementing IManager.
        /// </summary>
        [Fact]
        public void TestInstantiateWithNonIManager()
        {
            Assert.Throws<ManagerTypeListException>(() => ProgramManager.Instantiate(new Type[] { typeof(int) }));
        }

        /// <summary>
        ///     Tests instantiation of the ProgramManager with a Type array containing an instance of IManager with the 
        ///     Setup() method returning a null Result/
        /// </summary>
        [Fact]
        public void TestInstantiateWithBrokenSetupMethod()
        {
            Assert.Throws<ManagerSetupException>(() => ProgramManager.Instantiate(new Type[] { typeof(MockManagerBroken) }));
        }

        /// <summary>
        /// Tests instantiation of the ProgramManager with a Type array containing a valid, functioning IManager instance.
        /// </summary>
        [Fact]
        public void TestInstantiateWithValidIManager()
        {
            ProgramManager manager = ProgramManager.Instantiate(new Type[] { typeof(MockManager) });

            Assert.IsType<ProgramManager>(manager);
            Assert.NotNull(manager);
        }
    }
}
