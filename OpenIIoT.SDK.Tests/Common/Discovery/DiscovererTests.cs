/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █   ████████▄
      █   ███   ▀███
      █   ███    ███  █    ▄█████  ▄██████  ██████   █    █     ▄█████    █████    ▄█████    █████
      █   ███    ███ ██    ██  ▀  ██    ██ ██    ██ ██    ██   ██   █    ██  ██   ██   █    ██  ██
      █   ███    ███ ██▌   ██     ██    ▀  ██    ██ ██    ██  ▄██▄▄     ▄██▄▄█▀  ▄██▄▄     ▄██▄▄█▀
      █   ███    ███ ██  ▀███████ ██    ▄  ██    ██ ██    ██ ▀▀██▀▀    ▀███████ ▀▀██▀▀    ▀███████
      █   ███   ▄███ ██     ▄  ██ ██    ██ ██    ██  █▄  ▄█    ██   █    ██  ██   ██   █    ██  ██
      █   ████████▀  █    ▄████▀  ██████▀   ██████    ▀██▀     ███████   ██  ██   ███████   ██  ██
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
      █  Unit tests for the Discoverer class.
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

namespace OpenIIoT.SDK.Tests.Common.Discovery
{
    using System.Collections.Generic;
    using OpenIIoT.SDK.Common.Discovery;
    using Xunit;

    /// <summary>
    ///     Defines the interface used for the DiscoverableChild class.
    /// </summary>
    public interface IDiscoverableChild
    {
    }

    /// <summary>
    ///     Defines the interface used for the DiscoverableParent class.
    /// </summary>
    public interface IDiscoverableParent
    {
    }

    /// <summary>
    ///     Mocks a class implementing a discoverable interface.
    /// </summary>
    [Discoverable]
    public class DiscoverableChild : IDiscoverableChild
    {
    }

    /// <summary>
    ///     Mocks a class containing discoverable properties.
    /// </summary>
    /// <remarks>
    ///     It is not feasible to use a mocking framework due to the difficulty in appending attributes at run time.
    /// </remarks>
    [Discoverable]
    public class DiscoverableParent : IDiscoverableParent
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="DiscoverableParent"/> class.
        /// </summary>
        public DiscoverableParent()
        {
            Child = new DiscoverableChild();

            Children = new List<DiscoverableChild>();
            Children.Add(new DiscoverableChild());
            Children.Add(new DiscoverableChild());
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        ///     Gets or sets an atomic discoverable property.
        /// </summary>
        [Discoverable]
        public DiscoverableChild Child { get; set; }

        /// <summary>
        ///     Gets or sets an IEnumerable discoverable property.
        /// </summary>
        [Discoverable]
        public List<DiscoverableChild> Children { get; set; }

        /// <summary>
        ///     Gets or sets the parent.
        /// </summary>
        [Discoverable]
        public DiscoverableParent Parent { get; set; }

        #endregion Public Properties
    }

    /// <summary>
    ///     Unit tests for the <see cref="Discoverer"/> class.
    /// </summary>
    public class DiscovererTests
    {
        #region Public Methods

        /// <summary>
        ///     Tests the <see cref="Discoverer.Discover{T}(object)"/> method.
        /// </summary>
        [Fact]
        public void Discover()
        {
            DiscoverableParent parent = new DiscoverableParent();

            IList<IDiscoverableChild> list = Discoverer.Discover<IDiscoverableChild>(parent);

            Assert.Equal(3, list.Count);
        }

        /// <summary>
        ///     Tests the <see cref=".Discoverer.Discover{T}(object)"/> method with an object which does not include the
        ///     <see cref="DiscoverableAttribute"/> attribute.
        /// </summary>
        [Fact]
        public void DiscoverNotDiscoverable()
        {
            string astring = string.Empty;

            IList<string> list = Discoverer.Discover<string>(astring);

            Assert.Empty(list);
        }

        /// <summary>
        ///     Tests the <see cref="Discoverer.Discover{T}(object)"/> method with a self-referencing object.
        /// </summary>
        [Fact]
        public void DiscoverSelfReferential()
        {
            DiscoverableParent parent = new DiscoverableParent();

            parent.Parent = new DiscoverableParent();

            IList<IDiscoverableParent> list = Discoverer.Discover<IDiscoverableParent>(parent);

            Assert.Equal(2, list.Count);

            parent.Parent = parent;

            list = Discoverer.Discover<IDiscoverableParent>(parent);

            Assert.Equal(1, list.Count);
        }

        #endregion Public Methods
    }
}