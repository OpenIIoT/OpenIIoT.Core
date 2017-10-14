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

[module: System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed.")]

namespace OpenIIoT.SDK.Tests.Common
{
    using Newtonsoft.Json;
    using OpenIIoT.SDK.Common;
    using Xunit;

    /// <summary>
    ///     Represents a test object used for the <see cref="ContractResolverTests"/> unit tests.
    /// </summary>
    /// <remarks>
    ///     It is not feasible to use a mocking framework for this mockup due to the complexity in creating a new type.
    /// </remarks>
    public class ContractResolverTestObject
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ContractResolverTestObject"/> class.
        /// </summary>
        public ContractResolverTestObject()
        {
            Name = "Test Object";
            Number = 42;
            TrueFalse = true;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the number.
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether the TrueFalse property is true.
        /// </summary>
        public bool TrueFalse { get; set; }

        #endregion Public Properties
    }

    /// <summary>
    ///     Unit tests for the <see cref="ContractResolver"/> class.
    /// </summary>
    public class ContractResolverTests
    {
        #region Private Fields

        /// <summary>
        ///     The shared mockup object to be used for the serialization tests.
        /// </summary>
        private ContractResolverTestObject mockup;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ContractResolverTests"/> class.
        /// </summary>
        public ContractResolverTests()
        {
            mockup = new ContractResolverTestObject();
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///     Tests all constructor overloads.
        /// </summary>
        [Fact]
        public void Constructor()
        {
            ContractResolver resolver;

            resolver = new ContractResolver();
            Assert.IsType<ContractResolver>(resolver);

            resolver = new ContractResolver();
            Assert.IsType<ContractResolver>(resolver);

            resolver = new ContractResolver(ContractResolverType.OptIn);
            Assert.IsType<ContractResolver>(resolver);
        }

        /// <summary>
        ///     Tests the resolver with the <see cref="ContractResolverType.OptIn"/> resolver type.
        /// </summary>
        [Fact]
        public void OptIn()
        {
            ContractResolver resolver = new ContractResolver(ContractResolverType.OptIn, "Name");

            string json = JsonConvert.SerializeObject(mockup, new JsonSerializerSettings() { ContractResolver = resolver });

            Assert.Equal("{\"Name\":\"Test Object\"}", json);
        }

        /// <summary>
        ///     Tests the resolver with the <see cref="ContractResolverType.OptOut"/> resolver type.
        /// </summary>
        [Fact]
        public void OptOut()
        {
            ContractResolver resolver = new ContractResolver(ContractResolverType.OptOut, "Number", "TrueFalse");

            string json = JsonConvert.SerializeObject(mockup, new JsonSerializerSettings() { ContractResolver = resolver });

            Assert.Equal("{\"Name\":\"Test Object\"}", json);
        }

        /// <summary>
        ///     Tests resolver.
        /// </summary>
        [Fact]
        public void Resolve()
        {
            ContractResolver resolver = new ContractResolver(ContractResolverType.OptOut);

            string json = JsonConvert.SerializeObject(mockup, new JsonSerializerSettings() { ContractResolver = resolver });

            Assert.Equal("{\"Name\":\"Test Object\",\"Number\":42,\"TrueFalse\":true}", json);
        }

        #endregion Public Methods
    }
}