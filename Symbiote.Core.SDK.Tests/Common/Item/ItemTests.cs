/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █    ▄█
      █   ███
      █   ███▌     ██       ▄█████    ▄▄██▄▄▄
      █   ███▌ ▀███████▄   ██   █   ▄█▀▀██▀▀█▄
      █   ███▌     ██  ▀  ▄██▄▄     ██  ██  ██
      █   ███      ██    ▀▀██▀▀     ██  ██  ██
      █   ███      ██      ██   █   ██  ██  ██
      █   █▀      ▄██▀     ███████   █  ██  █
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
      █  Unit tests for the Item class.
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
using Xunit;

namespace Symbiote.Core.SDK.Tests
{
    /// <summary>
    ///     Unit tests for the Item class.
    /// </summary>
    public class ItemTests
    {
        /// <summary>
        ///     Tests all constructor overloads.
        /// </summary>
        [Fact]
        public void Constructor()
        {
            Item item = new Item();
            Assert.IsType<Item>(item);

            item = new Item(string.Empty);
            Assert.IsType<Item>(item);

            item = new Item(string.Empty, false);
            Assert.IsType<Item>(item);

            item = new Item(string.Empty, string.Empty);
            Assert.IsType<Item>(item);

            item = new Item(string.Empty, string.Empty, false);
            Assert.IsType<Item>(item);
        }

        /// <summary>
        ///     Tests all properties.
        /// </summary>
        [Fact]
        public void Properties()
        {
            Item item = new Item("Root.Child.Name", "Source");

            Assert.Equal(new List<Item>(), item.Children);
            Assert.Equal("Root.Child.Name", item.FQN);
            Assert.Equal(new Guid().ToString().Length, item.Guid.ToString().Length);
            Assert.Equal(false, item.HasChildren);
            Assert.Equal(true, item.IsOrphaned);
            Assert.Equal("Name", item.Name);
            Assert.Equal(default(Item), item.Parent);
            Assert.Equal("Root.Child", item.Path);
            Assert.Equal("Source", item.SourceFQN);

            Assert.Equal(default(Item), item.SourceItem);

            Item newItem = new Item("Source.Item");
            item.SourceItem = newItem;
            Assert.Equal(newItem, item.SourceItem);

            Assert.Equal(default(object), item.Value);
            Assert.Equal(true, item.Writeable);
        }

        /// <summary>
        ///     Tests the functionality of the <see cref="Item.AddChild(Item)"/> method.
        /// </summary>
        [Fact]
        public void ItemAdoption()
        {
            Item root = new Item("Root");
            Item child = new Item("Orphaned.Item");

            Assert.Equal(true, child.IsOrphaned);
            Assert.Equal("Orphaned.Item", child.FQN);
            Assert.Equal("Orphaned", child.Path);

            root.AddChild(child);

            Assert.Equal(false, child.IsOrphaned);
            Assert.Equal("Root.Item", child.FQN);
            Assert.Equal("Root", child.Path);
        }

        /// <summary>
        ///     Tests the <see cref="Clone"/> method.
        /// </summary>
        [Fact]
        public void Clone()
        {
            Item original = new Item("Root.Item");
            Item clone = (Item)original.Clone();

            Assert.True(original.Equals(clone));
        }

        /// <summary>
        ///     Tests the <see cref="Equals"/> method.
        /// </summary>
        [Fact]
        public void Equals()
        {
            Item left = new Item("Root.Left");
            Item right = new Item("Root.Right");
            Item left2 = new Item("Root.Left");
            string notItem = "not item";

            Assert.False(left.Equals(notItem));
            Assert.False(left.Equals(right));
            Assert.True(left.Equals(left2));
        }
    }
}