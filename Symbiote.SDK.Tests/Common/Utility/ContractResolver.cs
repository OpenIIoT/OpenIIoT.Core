/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █   ▄████████                                                                      ▄████████
      █   ███    ███                                                                    ███    ███
      █   ███    █▀   ██████  ██▄▄▄▄      ██       █████   ▄█████   ▄██████     ██     ▄███▄▄▄▄██▀    ▄█████   ▄█████  ██████   █        █    █     ▄█████    █████
      █   ███        ██    ██ ██▀▀▀█▄ ▀███████▄   ██  ██   ██   ██ ██    ██ ▀███████▄ ▀▀███▀▀▀▀▀     ██   █    ██  ▀  ██    ██ ██       ██    ██   ██   █    ██  ██
      █   ███        ██    ██ ██   ██     ██  ▀  ▄██▄▄█▀   ██   ██ ██    ▀      ██  ▀ ▀███████████  ▄██▄▄      ██     ██    ██ ██       ██    ██  ▄██▄▄     ▄██▄▄█▀
      █   ███    █▄  ██    ██ ██   ██     ██    ▀███████ ▀████████ ██    ▄      ██      ███    ███ ▀▀██▀▀    ▀███████ ██    ██ ██       ██    ██ ▀▀██▀▀    ▀███████
      █   ███    ███ ██    ██ ██   ██     ██      ██  ██   ██   ██ ██    ██     ██      ███    ███   ██   █     ▄  ██ ██    ██ ██▌    ▄  █▄  ▄█    ██   █    ██  ██
      █   ████████▀   ██████   █   █     ▄██▀     ██  ██   ██   █▀ ██████▀     ▄██▀     ███    ███   ███████  ▄████▀   ██████  ████▄▄██   ▀██▀     ███████   ██  ██
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
      █  Unit tests for the ContractResolver class.
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
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Symbiote.SDK.Tests
{
    /// <summary>
    ///     Unit tests for the ContractResolver class.
    /// </summary>
    public class ContractResolver
    {
        /// <summary>
        ///     The shared mockup object to be used for the serialization tests.
        /// </summary>
        private ContractResolverTestObject mockup;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ContractResolver"/> class.
        /// </summary>
        public ContractResolver()
        {
            mockup = new ContractResolverTestObject();
        }

        /// <summary>
        ///     Tests all constructor overloads.
        /// </summary>
        [Fact]
        public void Constructor()
        {
            SDK.ContractResolver resolver;

            resolver = new SDK.ContractResolver();
            Assert.IsType<SDK.ContractResolver>(resolver);

            resolver = new SDK.ContractResolver(new List<string>(new string[] { }));
            Assert.IsType<SDK.ContractResolver>(resolver);

            resolver = new SDK.ContractResolver(new List<string>(new string[] { }), ContractResolverType.OptIn);
            Assert.IsType<SDK.ContractResolver>(resolver);
        }

        [Fact]
        public void OptIn()
        {
        }

        [Fact]
        public void OptOut()
        {
        }

        [Fact]
        public void SecondaryTypes()
        {
        }
    }

    /// <summary>
    ///     Represents a test object used for the <see cref="ContractResolver"/> unit tests.
    /// </summary>
    /// <remarks>
    ///     It is not feasible to use a mocking framework for this mockup due to the complexity in creating a new type.
    /// </remarks>
    public class ContractResolverTestObject
    {
        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the number.
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        ///     Gets or sets a value representing a boolean.
        /// </summary>
        public bool TrueFalse { get; set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ContractResolverTestObject"/> class.
        /// </summary>
        public ContractResolverTestObject()
        {
            Name = "Test Object";
            Number = 42;
            TrueFalse = true;
        }
    }
}