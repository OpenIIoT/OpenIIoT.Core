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

using Moq;
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
            // create mockups
            Mock<IItemProvider> mockProvider = new Mock<IItemProvider>();

            SDK.Item item = new SDK.Item();
            Assert.IsType<SDK.Item>(item);

            item = new SDK.Item(string.Empty);
            Assert.IsType<SDK.Item>(item);

            item = new SDK.Item(string.Empty, string.Empty);
            Assert.IsType<SDK.Item>(item);

            item = new SDK.Item(string.Empty, new SDK.Item());
            Assert.IsType<SDK.Item>(item);

            item = new SDK.Item(string.Empty, new SDK.Item(), mockProvider.Object);
            Assert.IsType<SDK.Item>(item);

            item = new SDK.Item(string.Empty, string.Empty, mockProvider.Object);
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

            Assert.Equal(default(object), item.Read());

            SDK.Item rootItem = new SDK.Item("Root");
            Assert.Equal("Root", rootItem.FQN);

            // not technically properties but we are testing them here anyway
            Assert.Equal("Root.Child.Name", item.ToString());
            Assert.NotNull(item.ToJson());
            Assert.NotNull(item.ToJson(new SDK.ContractResolver()));
        }

        [Fact]
        public void Source()
        {
            Mock<IItemProvider> mockProvider = new Mock<IItemProvider>();

            SDK.Item provider = new SDK.Item(string.Empty, mockProvider.Object);
            Assert.Equal(ItemSource.ItemProvider, provider.Source);

            SDK.Item item = new SDK.Item(string.Empty, new SDK.Item());
            Assert.Equal(ItemSource.Item, item.Source);

            SDK.Item unresolved = new SDK.Item(string.Empty, "source");
            Assert.Equal(ItemSource.Unresolved, unresolved.Source);

            SDK.Item unknown = new SDK.Item();
            Assert.Equal(ItemSource.Unknown, unknown.Source);
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Item.Read"/> and <see cref="SDK.Item.ReadAsync"/> methods.
        /// </summary>
        [Fact]
        public async void Read()
        {
            SDK.Item item = new SDK.Item("Root.Item");
            item.Write("Value!");

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
            Assert.Equal("source value", item.Read());

            // change the source item's value so we can read again
            sourceItem.Write("new value");

            // invoke the method asynchronously
            object newValue = await item.ReadFromSourceAsync();

            // ensure the proper value is returned and set
            Assert.Equal("new value", newValue);
            Assert.Equal("new value", item.Read());
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
            Assert.Equal("new value", sourceItem.Read());
            Assert.Equal("new value", item.Read());

            // unsubscribe the item from it's source item and assert that it succeeded
            Result unsubscribeResult = item.UnsubscribeFromSource();
            Assert.Equal(ResultCode.Success, unsubscribeResult.ResultCode);

            // write a value to the source item and assert that the item's value doesn't update.
            sourceItem.Write("final value");
            Assert.Equal("final value", sourceItem.Read());
            Assert.NotEqual("final value", item.Read());

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
            SDK.Item writeableItem = new SDK.Item("Root.Item");
            SDK.Item nonWriteableItem = new SDK.Item("Root.Item2", ItemAccessMode.ReadOnly);

            bool result = writeableItem.Write("test");
            Assert.True(result);
            Assert.Equal("test", writeableItem.Read());

            result = await writeableItem.WriteAsync("test two");

            Assert.True(result);
            Assert.Equal("test two", writeableItem.Read());

            result = nonWriteableItem.Write("new value");

            Assert.False(result);
        }

        [Fact]
        public async void WriteToSourceAsync()
        {
            // mock an IWriteable item provider
            Mock<IItemProvider> mockItemProvider = new Mock<IItemProvider>();
            mockItemProvider.CallBase = true;
            mockItemProvider.As<IWriteable>();

            // create an item sourced from an ItemProvider and link a model item
            SDK.Item providerItem = new SDK.Item("Source.Item", mockItemProvider.Object);

            // setup the mock to return a good value for the provider's Write()
            mockItemProvider.As<IWriteable>().Setup(p => p.Write(It.IsAny<SDK.Item>(), It.IsAny<object>())).Returns(true);

            SDK.Item sourceItem = new SDK.Item("Root.Model.Item", providerItem);

            // test a write with an IWriteable provider
            bool result = await sourceItem.WriteToSourceAsync("source value");

            // assert that the write completed and that the value was written
            Assert.True(result);
            Assert.Equal("source value", sourceItem.Read());
            Assert.Equal("source value", providerItem.Read());
        }

        [Fact]
        public async void WriteToSource()
        {
            // mock an IWriteable item provider
            Mock<IItemProvider> mockItemProvider = new Mock<IItemProvider>();
            mockItemProvider.CallBase = true;
            mockItemProvider.As<IWriteable>();

            // create an item sourced from an ItemProvider and link a model item
            SDK.Item providerItem = new SDK.Item("Source.Item", mockItemProvider.Object);

            // setup the mock to return a good value for the provider's Write()
            mockItemProvider.As<IWriteable>().Setup(p => p.Write(It.IsAny<SDK.Item>(), It.IsAny<object>())).Returns(true);

            SDK.Item sourceItem = new SDK.Item("Root.Model.Item", providerItem);

            // test a write with an IWriteable provider
            bool result = sourceItem.WriteToSource("source value");

            // assert that the write completed and that the value was written
            Assert.True(result);
            Assert.Equal("source value", sourceItem.Read());
            Assert.Equal("source value", providerItem.Read());
        }

        #endregion Public Methods
    }
}