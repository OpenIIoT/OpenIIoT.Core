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
    ///     Unit tests for the <see cref="SDK.Item"/> class.
    /// </summary>
    [Collection("Item")]
    public class Item
    {
        #region Public Methods

        /// <summary>
        ///     Tests the <see cref="SDK.Item.AddChild(SDK.Item)"/> and <see cref="SDK.Item.RemoveChild(SDK.Item)"/> methods.
        /// </summary>
        [Fact]
        public void AddRemoveChildren()
        {
            SDK.Item item = new SDK.Item("Root");
            SDK.Item child = new SDK.Item("Root.Child");
            SDK.Item childsChild = new SDK.Item("Root.Child.Child");
            child.AddChild(childsChild);

            // add the child and ensure the operation was successful and that it returns the child item
            Result<SDK.Item> addResult = item.AddChild(child);

            Assert.Equal(ResultCode.Success, addResult.ResultCode);
            Assert.Equal(child, addResult.ReturnValue);

            // remove the child and ensure it was successful and that it returns the child item
            Result<SDK.Item> removeResult = item.RemoveChild(child);

            Assert.Equal(ResultCode.Success, removeResult.ResultCode);
            Assert.Equal(child, removeResult.ReturnValue);

            // attempt to remove a non-existent child and ensure that the operation fails
            Result<SDK.Item> badRemoveResult = item.RemoveChild(new SDK.Item("Root.New"));

            Assert.Equal(ResultCode.Failure, badRemoveResult.ResultCode);
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Item.Clone"/> method.
        /// </summary>
        [Fact]
        public void Clone()
        {
            SDK.Item original = new SDK.Item("Root.Item");
            SDK.Item clone = (SDK.Item)original.Clone();

            Assert.Equal(original.FQN, clone.FQN);
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Item.CloneAs(string)"/> method.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the mutated Item from which this Item is cloned.</param>
        [Theory]
        [InlineData("Root.Item.New")]
        [InlineData("Root")]
        [InlineData("")]
        public void CloneAs(string fqn)
        {
            SDK.Item original = new SDK.Item("Root.Item");
            SDK.Item clone = (SDK.Item)original.CloneAs(fqn);

            Assert.Equal(fqn, clone.FQN);
            Assert.NotNull(clone.Name);
            Assert.NotNull(clone.Path);
        }

        /// <summary>
        ///     Tests all constructor overloads.
        /// </summary>
        [Fact]
        public void Constructor()
        {
            SDK.Item item = new SDK.Item();
            Assert.IsType<SDK.Item>(item);

            item = new SDK.Item(string.Empty);
            Assert.IsType<SDK.Item>(item);

            item = new SDK.Item(string.Empty, false);
            Assert.IsType<SDK.Item>(item);

            item = new SDK.Item(string.Empty, string.Empty);
            Assert.IsType<SDK.Item>(item);

            item = new SDK.Item(string.Empty, new SDK.Item());
            Assert.IsType<SDK.Item>(item);

            item = new SDK.Item(string.Empty, default(SDK.Item), string.Empty, false);
            Assert.IsType<SDK.Item>(item);
        }

        /// <summary>
        ///     Tests the functionality of the <see cref="SDK.Item.AddChild(SDK.Item)"/> method.
        /// </summary>
        [Fact]
        public void ItemAdoption()
        {
            SDK.Item root = new SDK.Item("Root");
            SDK.Item child = new SDK.Item("Orphaned.Item");

            Assert.Equal(true, child.IsOrphaned);
            Assert.Equal("Orphaned.Item", child.FQN);
            Assert.Equal("Orphaned", child.Path);

            root.AddChild(child);

            Assert.Equal(false, child.IsOrphaned);
            Assert.Equal("Root.Item", child.FQN);
            Assert.Equal("Root", child.Path);

            // try to add a null/default Item to the test item. it should fail.
            Result result = root.AddChild(default(SDK.Item));
            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        /// <summary>
        ///     Tests all properties.
        /// </summary>
        [Fact]
        public void Properties()
        {
            SDK.Item item = new SDK.Item("Root.Child.Name", "Source");

            Assert.Equal(new List<SDK.Item>(), item.Children);
            Assert.Equal("Root.Child.Name", item.FQN);
            Assert.Equal(new Guid().ToString().Length, item.Guid.ToString().Length);
            Assert.Equal(false, item.HasChildren);
            Assert.Equal(true, item.IsOrphaned);
            Assert.Equal("Name", item.Name);
            Assert.Equal(default(SDK.Item), item.Parent);
            Assert.Equal("Root.Child", item.Path);
            Assert.Equal("Source", item.SourceFQN);
            Assert.Equal(default(SDK.Item), item.SourceItem);

            SDK.Item newItem = new SDK.Item("Source.Item");
            item.SourceItem = newItem;
            Assert.Equal(newItem, item.SourceItem);

            Assert.Equal(default(object), item.Value);
            Assert.Equal(true, item.Writeable);

            SDK.Item rootItem = new SDK.Item("Root");
            Assert.Equal("Root", rootItem.FQN);

            // not technically properties but we are testing them here anyway
            Assert.Equal("Root.Child.Name", item.ToString());
            Assert.NotNull(item.ToJson());
            Assert.NotNull(item.ToJson(new SDK.ContractResolver()));
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Item.Read"/> and <see cref="SDK.Item.ReadAsync"/> methods.
        /// </summary>
        [Fact]
        public async void Read()
        {
            SDK.Item item = new SDK.Item("Root.Item");
            item.Write("Value!");

            Assert.Equal("Value!", item.Value);
            Assert.Equal("Value!", item.Read());

            object value = await item.ReadAsync();

            Assert.Equal("Value!", value);
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Item.ReadFromSource"/> and <see cref="SDK.Item.ReadFromSourceAsync"/> methods.
        /// </summary>
        [Fact]
        public async void ReadFromSource()
        {
            SDK.Item sourceItem = new SDK.Item("Root.SourceItem");
            sourceItem.Write("source value");

            SDK.Item item = new SDK.Item("Root.Item", sourceItem);
            item.Write("value");

            SDK.Item child = new SDK.Item("Root.Item.Child");
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
        ///     Tests the <see cref="SDK.Item.SubscribeToSource"/> and <see cref="SDK.Item.UnsubscribeFromSource"/> methods.
        /// </summary>
        [Fact]
        public void Subscription()
        {
            SDK.Item sourceItem = new SDK.Item("Root.SourceItem");
            sourceItem.Write("initial value");

            SDK.Item item = new SDK.Item("Root.Item", sourceItem);

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
            SDK.Item lastItem = new SDK.Item("Root.LastItem");

            Result lastItemSub = lastItem.SubscribeToSource();
            Assert.Equal(ResultCode.Failure, lastItemSub.ResultCode);

            Result lastItemUnSub = lastItem.UnsubscribeFromSource();
            Assert.Equal(ResultCode.Failure, lastItemUnSub.ResultCode);
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Item.Write(object)"/> and <see cref="SDK.Item.WriteAsync(object)"/> methods.
        /// </summary>
        [Fact]
        public async void Write()
        {
            SDK.Item item = new SDK.Item("Root.Item");

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
        ///     Tests the <see cref="SDK.Item.Write(object)"/> and <see cref="SDK.Item.WriteToSourceAsync(object)"/>
        /// </summary>
        [Fact]
        public async void WriteToSource()
        {
            SDK.Item sourceItem1 = new SDK.Item("Root.SourceItem1");
            sourceItem1.Write("source value 1");

            SDK.Item sourceItem2 = new SDK.Item("Root.SourceItem2");
            sourceItem2.Write("source value 2");
            sourceItem2.Writeable = false;

            SDK.Item item = new SDK.Item("Root.Item");

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

        #endregion Public Methods
    }
}