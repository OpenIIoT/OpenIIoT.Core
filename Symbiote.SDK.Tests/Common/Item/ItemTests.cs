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

namespace Symbiote.SDK.Tests
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

            item = new Item(string.Empty, default(Item), string.Empty, false);
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

            Item rootItem = new Item("Root");
            Assert.Equal("Root", rootItem.FQN);

            // not technically properties but we are testing them here anyway
            Assert.Equal("Root.Child.Name", item.ToString());
            Assert.NotNull(item.ToJson());
            Assert.NotNull(item.ToJson(new ContractResolver()));
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
        ///     Tests the <see cref="Item.ReadFromSource"/> and <see cref="Item.ReadFromSourceAsync"/> methods.
        /// </summary>
        [Fact]
        public async void ReadFromSource()
        {
            Item sourceItem = new Item("Root.SourceItem");
            sourceItem.Write("source value");

            Item item = new Item("Root.Item", sourceItem);
            item.Write("value");

            Item child = new Item("Root.Item.Child");
            item.AddChild(child);

            // invoke the ReadFromSource method on the item. the method should return the source item's value, and should set the
            // item's value to the same value.
            object value = item.ReadFromSource();

            // ensure the correct value is returned and set as the item's value
            Assert.Equal("source value", value);
            Assert.Equal("source value", item.Value);

            // change the source item's value so we can read again
            sourceItem.Write("new value");

            // invoke the method asynchronously
            object newValue = await item.ReadFromSourceAsync();

            // ensure the proper value is returned and set
            Assert.Equal("new value", newValue);
            Assert.Equal("new value", item.Value);
        }

        /// <summary>
        ///     Tests the <see cref="Item.Write(object)"/> and <see cref="Item.WriteToSourceAsync(object)"/>
        /// </summary>
        [Fact]
        public async void WriteToSource()
        {
            Item sourceItem1 = new Item("Root.SourceItem1");
            sourceItem1.Write("source value 1");

            Item sourceItem2 = new Item("Root.SourceItem2");
            sourceItem2.Write("source value 2");
            sourceItem2.Writeable = false;

            Item item = new Item("Root.Item");

            // try a write with an unbound source item
            Result badWriteResult = item.WriteToSource("value");

            Assert.Equal(ResultCode.Success, badWriteResult.ResultCode);
            Assert.Equal("value", item.Value);

            // try a write with an unwriteable source item
            item.SourceItem = sourceItem2;
            Result badWriteResult2 = item.WriteToSource("value");

            Assert.Equal(ResultCode.Failure, badWriteResult2.ResultCode);

            // write a good value
            item.SourceItem = sourceItem1;
            Result writeResult = item.WriteToSource("value 1");

            Assert.Equal(ResultCode.Success, writeResult.ResultCode);
            Assert.Equal("value 1", item.SourceItem.Value);

            // write a good value asynchronously
            Result writeResult2 = await item.WriteToSourceAsync("value 2");

            Assert.Equal(ResultCode.Success, writeResult.ResultCode);
            Assert.Equal("value 2", item.SourceItem.Value);
        }

        /// <summary>
        ///     Tests the <see cref="Item.AddChild(Item)"/> and <see cref="Item.RemoveChild(Item)"/> methods.
        /// </summary>
        [Fact]
        public void AddRemoveChildren()
        {
            Item item = new Item("Root");
            Item child = new Item("Root.Child");
            Item childsChild = new Item("Root.Child.Child");
            child.AddChild(childsChild);

            // add the child and ensure the operation was successful and that it returns the child item
            Result<Item> addResult = item.AddChild(child);

            Assert.Equal(ResultCode.Success, addResult.ResultCode);
            Assert.Equal(child, addResult.ReturnValue);

            // remove the child and ensure it was successful and that it returns the child item
            Result<Item> removeResult = item.RemoveChild(child);

            Assert.Equal(ResultCode.Success, removeResult.ResultCode);
            Assert.Equal(child, removeResult.ReturnValue);

            // attempt to remove a non-existent child and ensure that the operation fails
            Result<Item> badRemoveResult = item.RemoveChild(new Item("Root.New"));

            Assert.Equal(ResultCode.Failure, badRemoveResult.ResultCode);
        }

        /// <summary>
        ///     Tests the <see cref="Item.SubscribeToSource"/> and <see cref="Item.UnsubscribeFromSource"/> methods.
        /// </summary>
        [Fact]
        public void Subscription()
        {
            Item sourceItem = new Item("Root.SourceItem");
            sourceItem.Write("initial value");

            Item item = new Item("Root.Item", sourceItem);

            // subscribe the item to it's source item and assert that it succeeded
            Result subscribeResult = item.SubscribeToSource();
            Assert.Equal(ResultCode.Success, subscribeResult.ResultCode);

            // write a value to the source item and assert that the item's value updates.
            sourceItem.Write("new value");
            Assert.Equal("new value", sourceItem.Value);
            Assert.Equal("new value", item.Value);

            // unsubscribe the item from it's source item and assert that it succeeded
            Result unsubscribeResult = item.UnsubscribeFromSource();
            Assert.Equal(ResultCode.Success, unsubscribeResult.ResultCode);

            // write a value to the source item and assert that the item's value doesn't update.
            sourceItem.Write("final value");
            Assert.Equal("final value", sourceItem.Value);
            Assert.NotEqual("final value", item.Value);

            // test the subscribe/unsubscribe methods with an item for which the source item has not been set
            Item lastItem = new Item("Root.LastItem");

            Result lastItemSub = lastItem.SubscribeToSource();
            Assert.Equal(ResultCode.Failure, lastItemSub.ResultCode);

            Result lastItemUnSub = lastItem.UnsubscribeFromSource();
            Assert.Equal(ResultCode.Failure, lastItemUnSub.ResultCode);
        }
    }
}