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
using Utility.OperationResult;
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
        ///     Tests the <see cref="Item.Clone"/> method.
        /// </summary>
        [Fact]
        public void Clone()
        {
            Item original = new Item("Root.Item");
            Item clone = (Item)original.Clone();

            Assert.Equal(original.FQN, clone.FQN);
        }

        /// <summary>
        ///     Tests the <see cref="Item.Write(object)"/> and <see cref="Item.WriteAsync(object)"/> methods.
        /// </summary>
        [Fact]
        public async void Write()
        {
            Item item = new Item("Root.Item");

            Assert.Equal(true, item.Writeable);

            item.Write("test");

            Assert.Equal("test", item.Value);

            await item.WriteAsync("test two");

            Assert.Equal("test two", item.Value);

            item.Writeable = false;
            Assert.Equal(false, item.Writeable);

            Result writeResult = item.Write("new value");

            Assert.Equal(ResultCode.Failure, writeResult.ResultCode);
            Assert.Equal("test two", item.Value);
        }

        /// <summary>
        ///     Tests the <see cref="Item.Read"/> and <see cref="Item.ReadAsync"/> methods.
        /// </summary>
        [Fact]
        public async void Read()
        {
            Item item = new Item("Root.Item");
            item.Write("Value!");

            Assert.Equal("Value!", item.Value);
            Assert.Equal("Value!", item.Read());

            object value = await item.ReadAsync();

            Assert.Equal("Value!", value);
        }

        /// <summary>
        ///     Tests the <see cref="Item.ToString"/> method.
        /// </summary>
        [Fact]
        public void ToString()
        {
            Item item = new Item("Root.Node.Child");
            Assert.Equal("Root.Node.Child", item.ToString());
        }
    }
}