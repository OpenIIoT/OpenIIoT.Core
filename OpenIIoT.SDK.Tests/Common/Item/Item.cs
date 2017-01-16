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
using Moq;
using Utility.OperationResult;
using OpenIIoT.SDK.Common;
using Xunit;
using OpenIIoT.SDK.Common.Provider.ItemProvider;

namespace OpenIIoT.SDK.Tests
{
    /// <summary>
    ///     Unit tests for the <see cref="SDK.Common.Item"/> class.
    /// </summary>
    [Collection("Item")]
    public class Item
    {
        #region Public Methods

        /// <summary>
        ///     Tests the <see cref="SDK.Common.Item.AddChild(SDK.Common.Item)"/> method.
        /// </summary>
        [Fact]
        public void AddChild()
        {
            SDK.Common.Item item = new SDK.Common.Item("Root");
            SDK.Common.Item child = new SDK.Common.Item("Root.Child");

            Result<SDK.Common.Item> result = item.AddChild(child);

            // assert that the add succeeded and that it returned the item we specified
            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.Same(child, result.ReturnValue);

            // assert that the parent of the item we added is now equal to the item to which it was added
            Assert.Same(item, child.Parent);

            // assert that the parent item's children count is 1 and that the only child is the same as the one we added
            Assert.Equal(1, item.Children.Count);
            Assert.Same(child, item.Children[0]);
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Common.Item.AddChild(SDK.Common.Item)"/> method to ensure that circular references can't
        ///     be introduced.
        /// </summary>
        [Fact]
        public void AddChildCircular()
        {
            SDK.Common.Item rootItem = new SDK.Common.Item("Root");
            SDK.Common.Item child = new SDK.Common.Item("Root.Child");
            SDK.Common.Item childsChild = new SDK.Common.Item("Root.Child.Child");
            rootItem.AddChild(child);
            child.AddChild(childsChild);

            // attempt to create a circular reference
            Result result = childsChild.AddChild(rootItem);

            Assert.Equal(ResultCode.Failure, result.ResultCode);
            Assert.True(result.GetLastError().Contains("circular reference"));
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Common.Item.AddChild(SDK.Common.Item)"/> method by attempting to add a null child to an Item.
        /// </summary>
        [Fact]
        public void AddChildNull()
        {
            SDK.Common.Item item = new SDK.Common.Item("Root");

            Result result = item.AddChild(null);

            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Common.Item.AddChild(SDK.Common.Item)"/> method by attempting to add a child Item to itself.
        /// </summary>
        [Fact]
        public void AddChildSelf()
        {
            SDK.Common.Item item = new SDK.Common.Item("Root");

            Result result = item.AddChild(item);

            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Common.Item.Clone"/> method.
        /// </summary>
        [Fact]
        public void Clone()
        {
            SDK.Common.Item original = new SDK.Common.Item("Root.Item");
            SDK.Common.Item clone = (SDK.Common.Item)original.Clone();

            Assert.Equal(original.FQN, clone.FQN);
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Common.Item.CloneAs(string)"/> method.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the mutated Item from which this Item is cloned.</param>
        [Theory]
        [InlineData("Root.Item.New")]
        [InlineData("Root")]
        [InlineData("")]
        public void CloneAs(string fqn)
        {
            SDK.Common.Item original = new SDK.Common.Item("Root.Item");
            SDK.Common.Item clone = (SDK.Common.Item)original.CloneAs(fqn);

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

            SDK.Common.Item item = new SDK.Common.Item();
            Assert.IsType<SDK.Common.Item>(item);

            item = new SDK.Common.Item(string.Empty);
            Assert.IsType<SDK.Common.Item>(item);

            item = new SDK.Common.Item(string.Empty, ItemAccessMode.ReadWrite);
            Assert.IsType<SDK.Common.Item>(item);

            item = new SDK.Common.Item(string.Empty, ItemAccessMode.ReadWrite, mockProvider.Object);
            Assert.IsType<SDK.Common.Item>(item);

            item = new SDK.Common.Item(string.Empty, mockProvider.Object);
            Assert.IsType<SDK.Common.Item>(item);

            item = new SDK.Common.Item(string.Empty, string.Empty);
            Assert.IsType<SDK.Common.Item>(item);

            item = new SDK.Common.Item(string.Empty, new SDK.Common.Item());
            Assert.IsType<SDK.Common.Item>(item);

            item = new SDK.Common.Item(string.Empty, new SDK.Common.Item(), mockProvider.Object);
            Assert.IsType<SDK.Common.Item>(item);

            item = new SDK.Common.Item(string.Empty, string.Empty, mockProvider.Object);
            Assert.IsType<SDK.Common.Item>(item);
        }

        /// <summary>
        ///     Tests the functionality of the <see cref="SDK.Common.Item.AddChild(SDK.Common.Item)"/> method.
        /// </summary>
        [Fact]
        public void ItemAdoption()
        {
            SDK.Common.Item root = new SDK.Common.Item("Root");
            SDK.Common.Item child = new SDK.Common.Item("Orphaned.Item");

            Assert.Equal(true, child.IsOrphaned);
            Assert.Equal("Orphaned.Item", child.FQN);
            Assert.Equal("Orphaned", child.Path);

            root.AddChild(child);

            Assert.Equal(false, child.IsOrphaned);
            Assert.Equal("Root.Item", child.FQN);
            Assert.Equal("Root", child.Path);

            // try to add a null/default Item to the test item. it should fail.
            Result result = root.AddChild(default(SDK.Common.Item));
            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        /// <summary>
        ///     Tests all properties.
        /// </summary>
        [Fact]
        public void Properties()
        {
            SDK.Common.Item item = new SDK.Common.Item("Root.Child.Name", "Source");

            Assert.Equal(new List<SDK.Common.Item>(), item.Children);
            Assert.Equal("Root.Child.Name", item.FQN);
            Assert.Equal(new Guid().ToString().Length, item.Guid.ToString().Length);
            Assert.Equal(false, item.HasChildren);
            Assert.Equal(true, item.IsOrphaned);
            Assert.Equal(false, item.IsSubscribedToSource);
            Assert.Equal("Name", item.Name);
            Assert.Equal(default(SDK.Common.Item), item.Parent);
            Assert.Equal("Root.Child", item.Path);
            Assert.Equal("Source", item.SourceFQN);
            Assert.Equal(default(SDK.Common.Item), item.SourceItem);

            Assert.IsType<System.Threading.ReaderWriterLockSlim>(item.Lock);

            SDK.Common.Item newItem = new SDK.Common.Item("Source.Item");
            item.SourceItem = newItem;
            Assert.Equal(newItem, item.SourceItem);

            Assert.Equal(default(object), item.Read());

            SDK.Common.Item rootItem = new SDK.Common.Item("Root");
            Assert.Equal("Root", rootItem.FQN);

            // not technically properties but we are testing them here anyway
            Assert.Equal("Root.Child.Name", item.ToString());
            Assert.NotNull(item.ToJson());
            Assert.NotNull(item.ToJson(new SDK.Common.ContractResolver()));
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Common.Item.Read"/> and <see cref="SDK.Common.Item.ReadAsync"/> methods.
        /// </summary>
        [Fact]
        public async void Read()
        {
            SDK.Common.Item item = new SDK.Common.Item("Root.Item");
            item.Write("Value!");

            Assert.Equal("Value!", item.Read());

            object value = await item.ReadAsync();

            Assert.Equal("Value!", value);
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Common.Item.ReadFromSourceAsync"/> method.
        /// </summary>
        [Fact]
        public async void ReadFromSourceAsync()
        {
            SDK.Common.Item sourceItem = new SDK.Common.Item("Root.SourceItem");
            sourceItem.Write("source value");

            SDK.Common.Item item = new SDK.Common.Item("Root.Item", sourceItem);
            item.Write("value");

            SDK.Common.Item child = new SDK.Common.Item("Root.Item.Child");
            item.AddChild(child);

            object value = await item.ReadFromSourceAsync();

            Assert.Equal("source value", value);
            Assert.Equal(SDK.Common.ItemQuality.Good, item.Quality);
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Common.Item.ReadFromSource"/> method when the <see cref="SDK.Common.Item.Source"/> is <see cref="SDK.Common.ItemSource.Item"/>.
        /// </summary>
        [Fact]
        public void ReadFromSourceItem()
        {
            SDK.Common.Item sourceItem = new SDK.Common.Item("Root.SourceItem");
            sourceItem.Write("source value");

            SDK.Common.Item item = new SDK.Common.Item("Root.Item", sourceItem);
            item.Write("value");

            SDK.Common.Item child = new SDK.Common.Item("Root.Item.Child");
            item.AddChild(child);

            // invoke the ReadFromSource method on the item. the method should return the source item's value, and should set the
            // item's value to the same value.
            object value = item.ReadFromSource();

            // ensure the correct value is returned and set as the item's value
            Assert.Equal("source value", value);
            Assert.Equal("source value", item.Read());
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Common.Item.ReadFromSource"/> method when the <see cref="SDK.Common.Item.Source"/> is <see cref="SDK.Common.ItemSource.ItemProvider"/>.
        /// </summary>
        [Fact]
        public void ReadFromSourceProvider()
        {
            Mock<IItemProvider> mockProvider = new Mock<IItemProvider>();

            SDK.Common.Item item = new SDK.Common.Item("Root.Item", mockProvider.Object);

            mockProvider.Setup(m => m.Read(item)).Returns("source value");

            // invoke the ReadFromSource method on the item. the method should return the source item's value, and should set the
            // item's value to the same value.
            object value = item.ReadFromSource();

            // ensure the correct value is returned and set as the item's value
            Assert.Equal("source value", value);
            Assert.Equal("source value", item.Read());
            Assert.Equal(ItemQuality.Good, item.Quality);
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Common.Item.ReadFromSource"/> method when the <see cref="SDK.Common.Item.Source"/> is <see cref="SDK.Common.ItemSource.ItemProvider"/>.
        /// </summary>
        [Fact]
        public void ReadFromSourceProviderBad()
        {
            Mock<IItemProvider> mockProvider = new Mock<IItemProvider>();

            SDK.Common.Item item = new SDK.Common.Item("Root.Item", mockProvider.Object);

            mockProvider.Setup(m => m.Read(item)).Throws(new Exception());

            // invoke the ReadFromSource method on the item. the method should return the source item's value, and should set the
            // item's value to the same value.
            object value = item.ReadFromSource();

            // ensure the correct value is returned and set as the item's value
            Assert.Equal(null, value);
            Assert.Equal(null, item.Read());
            Assert.Equal(ItemQuality.Bad, item.Quality);
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Common.Item.ReadFromSource"/> method when the <see cref="SDK.Common.Item.Source"/> is <see cref="SDK.Common.ItemSource.Item"/>.
        /// </summary>
        [Fact]
        public void ReadFromSourceUnresolved()
        {
            SDK.Common.Item sourceItem = new SDK.Common.Item("Root.SourceItem");
            sourceItem.Write("source value");

            // create an "unresolved" Item by specifying the source FQN but not the corresponding Item.
            SDK.Common.Item item = new SDK.Common.Item("Root.Item", "some.fqn");

            // invoke the ReadFromSource method on the item. the method should return the source item's value, and should set the
            // item's value to the same value.
            object value = item.ReadFromSource();

            // ensure the correct value is returned and set as the item's value
            Assert.Equal(null, value);
            Assert.Equal(null, item.Read());
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Common.Item.AddChild(SDK.Common.Item)"/> and
        ///     <see cref="SDK.Common.Item.RemoveChild(SDK.Common.Item)"/> methods.
        /// </summary>
        [Fact]
        public void RemoveChild()
        {
            SDK.Common.Item item = new SDK.Common.Item("Root");
            SDK.Common.Item child = new SDK.Common.Item("Root.Child");
            SDK.Common.Item grandChild = new SDK.Common.Item("Root.Child.Child");

            item.AddChild(child);
            child.AddChild(grandChild);

            // remove the child and ensure it was successful and that it returns the child item
            Result<SDK.Common.Item> removeResult = item.RemoveChild(child);

            Assert.Equal(ResultCode.Success, removeResult.ResultCode);
            Assert.Equal(child, removeResult.ReturnValue);

            // assert that the parent's children count is now zero
            Assert.Equal(0, item.Children.Count);
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Common.Item.RemoveChild(SDK.Common.Item)"/> method with an Item that has not been added to
        ///     the list of children.
        /// </summary>
        [Fact]
        public void RemoveChildDoesntExist()
        {
            SDK.Common.Item item = new SDK.Common.Item("Root");
            SDK.Common.Item child = new SDK.Common.Item("Root.Child");

            Result result = item.RemoveChild(child);

            Assert.Equal(ResultCode.Failure, result.ResultCode);
            Assert.True(result.GetLastError().Contains("Failed to find"));
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Common.Item.RemoveChild(SDK.Common.Item)"/> method by attempting to remove a null child.
        /// </summary>
        [Fact]
        public void RemoveChildNull()
        {
            SDK.Common.Item item = new SDK.Common.Item("Root");

            Result result = item.RemoveChild(null);

            Assert.Equal(ResultCode.Failure, result.ResultCode);
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Common.Item.Source"/> property.
        /// </summary>
        [Fact]
        public void Source()
        {
            Mock<IItemProvider> mockProvider = new Mock<IItemProvider>();

            SDK.Common.Item provider = new SDK.Common.Item(string.Empty, mockProvider.Object);
            Assert.Equal(ItemSource.Provider, provider.Source);

            SDK.Common.Item item = new SDK.Common.Item(string.Empty, new SDK.Common.Item());
            Assert.Equal(ItemSource.Item, item.Source);

            SDK.Common.Item unresolved = new SDK.Common.Item(string.Empty, "source");
            Assert.Equal(ItemSource.Unresolved, unresolved.Source);

            SDK.Common.Item unknown = new SDK.Common.Item();
            Assert.Equal(ItemSource.Unknown, unknown.Source);
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Common.Item.SubscribeToSource"/> method with an Item whose
        ///     <see cref="SDK.Common.Item.Source"/> is <see cref="ItemSource.Item"/>.
        /// </summary>
        [Fact]
        public void SubscribeToSourceItem()
        {
            SDK.Common.Item sourceItem = new SDK.Common.Item("Root.SourceItem");
            SDK.Common.Item item = new SDK.Common.Item("Root.Item", sourceItem);

            Result result = item.SubscribeToSource();

            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.True(item.IsSubscribedToSource);
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Common.Item.SubscribeToSource"/> method with an Item whose
        ///     <see cref="SDK.Common.Item.Source"/> is <see cref="ItemSource.ItemProvider"/>.
        /// </summary>
        [Fact]
        public void SubscribeToSourceProvider()
        {
            // mock an IItemProvider that also implements ISubscribable
            Mock<IItemProvider> mockProvider = new Mock<IItemProvider>();
            mockProvider.As<ISubscribable>();

            SDK.Common.Item sourceItem = new SDK.Common.Item("Root.SourceItem");
            SDK.Common.Item item = new SDK.Common.Item("Root.Item", sourceItem, mockProvider.Object);

            Assert.Equal(ItemSource.Provider, item.Source);

            Result result = item.SubscribeToSource();

            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.True(item.IsSubscribedToSource);
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Common.Item.SubscribeToSource"/> method with an Item whose
        ///     <see cref="SDK.Common.Item.Source"/> is <see cref="ItemSource.ItemProvider"/> and where the
        ///     <see cref="SDK.Common.Item.Provider"/> does not implement <see cref="ISubscribable"/>.
        /// </summary>
        [Fact]
        public void SubscribeToSourceProviderNotSubscribable()
        {
            // mock an IItemProvider that doesn't implement ISubscribable
            Mock<IItemProvider> mockProvider = new Mock<IItemProvider>();

            SDK.Common.Item sourceItem = new SDK.Common.Item("Root.SourceItem");
            SDK.Common.Item item = new SDK.Common.Item("Root.Item", sourceItem, mockProvider.Object);

            Result result = item.SubscribeToSource();

            Assert.Equal(ResultCode.Failure, result.ResultCode);
            Assert.False(item.IsSubscribedToSource);
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Common.Item.SubscribeToSource"/> and <see cref="SDK.Common.Item.UnsubscribeFromSource"/> methods.
        /// </summary>
        [Fact]
        public void Subscription()
        {
            SDK.Common.Item sourceItem = new SDK.Common.Item("Root.SourceItem");
            sourceItem.Write("initial value");

            SDK.Common.Item item = new SDK.Common.Item("Root.Item", sourceItem);

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
            SDK.Common.Item lastItem = new SDK.Common.Item("Root.LastItem");

            Result lastItemSub = lastItem.SubscribeToSource();
            Assert.Equal(ResultCode.Failure, lastItemSub.ResultCode);

            Result lastItemUnSub = lastItem.UnsubscribeFromSource();
            Assert.Equal(ResultCode.Failure, lastItemUnSub.ResultCode);
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Common.Item.SubscriptionsChanged"/> method with no subscribers listening.
        /// </summary>
        [Fact]
        public void SubscriptionsChangedNoSubscribers()
        {
            Mock<IItemProvider> mockItemProvider = new Mock<IItemProvider>();
            mockItemProvider.As<ISubscribable>();

            SDK.Common.Item item = new SDK.Common.Item("Root", mockItemProvider.Object);

            item.SubscriptionsChanged();
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Common.Item.SubscriptionsChanged"/> method with subscribers listening.
        /// </summary>
        [Fact]
        public void SubscriptionsChangedSubscribers()
        {
            Mock<IItemProvider> mockItemProvider = new Mock<IItemProvider>();
            mockItemProvider.As<ISubscribable>();

            SDK.Common.Item item = new SDK.Common.Item("Root", mockItemProvider.Object);

            EventHandler<SDK.Common.ItemChangedEventArgs> handler = (sender, e) => { };

            item.Changed += handler;

            item.SubscriptionsChanged();
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Common.Item.UnsubscribeFromSource"/> method with an Item whose
        ///     <see cref="SDK.Common.Item.Source"/> is <see cref="ItemSource.Item"/>.
        /// </summary>
        [Fact]
        public void UnSubscribeFromSourceItem()
        {
            SDK.Common.Item sourceItem = new SDK.Common.Item("Root.SourceItem");
            SDK.Common.Item item = new SDK.Common.Item("Root.Item", sourceItem);
            item.SubscribeToSource();

            Assert.True(item.IsSubscribedToSource);

            Result result = item.UnsubscribeFromSource();

            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.False(item.IsSubscribedToSource);
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Common.Item.UnsubscribeFromSource"/> method with an Item whose
        ///     <see cref="SDK.Common.Item.Source"/> is <see cref="ItemSource.ItemProvider"/>.
        /// </summary>
        [Fact]
        public void UnSubscribeFromSourceProvider()
        {
            // mock an IItemProvider that also implements ISubscribable
            Mock<IItemProvider> mockProvider = new Mock<IItemProvider>();
            mockProvider.As<ISubscribable>();

            SDK.Common.Item sourceItem = new SDK.Common.Item("Root.SourceItem");
            SDK.Common.Item item = new SDK.Common.Item("Root.Item", sourceItem, mockProvider.Object);
            item.SubscribeToSource();

            Assert.Equal(ItemSource.Provider, item.Source);
            Assert.True(item.IsSubscribedToSource);

            Result result = item.UnsubscribeFromSource();

            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.False(item.IsSubscribedToSource);
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Common.Item.Write(object)"/> method.
        /// </summary>
        [Fact]
        public async void Write()
        {
            SDK.Common.Item writeableItem = new SDK.Common.Item("Root.Item");
            SDK.Common.Item nonWriteableItem = new SDK.Common.Item("Root.Item2", ItemAccessMode.ReadOnly);

            bool result = writeableItem.Write("test");
            Assert.True(result);
            Assert.Equal("test", writeableItem.Read());

            result = await writeableItem.WriteAsync("test two");

            Assert.True(result);
            Assert.Equal("test two", writeableItem.Read());

            result = nonWriteableItem.Write("new value");

            Assert.False(result);
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Common.Item.WriteAsync(object)"/> method.
        /// </summary>
        [Fact]
        public async void WriteAsync()
        {
            SDK.Common.Item writeableItem = new SDK.Common.Item("Root.Item");
            SDK.Common.Item nonWriteableItem = new SDK.Common.Item("Root.Item2", ItemAccessMode.ReadOnly);

            bool result = await writeableItem.WriteAsync("test two");

            Assert.True(result);
            Assert.Equal("test two", writeableItem.Read());

            result = nonWriteableItem.Write("new value");

            Assert.False(result);
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Common.Item.WriteToSource(object)"/> method.
        /// </summary>
        [Fact]
        public void WriteToSource()
        {
            // mock an IWriteable item provider
            Mock<IItemProvider> mockItemProvider = new Mock<IItemProvider>();
            mockItemProvider.CallBase = true;
            mockItemProvider.As<IWriteable>();

            // create an item sourced from an ItemProvider and link a model item
            SDK.Common.Item providerItem = new SDK.Common.Item("Source.Item", mockItemProvider.Object);

            // setup the mock to return a good value for the provider's Write()
            mockItemProvider.As<IWriteable>().Setup(p => p.Write(It.IsAny<SDK.Common.Item>(), It.IsAny<object>())).Returns(true);

            SDK.Common.Item sourceItem = new SDK.Common.Item("Root.Model.Item", providerItem);

            // test a write with an IWriteable provider
            bool result = sourceItem.WriteToSource("source value");

            // assert that the write completed and that the value was written
            Assert.True(result);
            Assert.Equal("source value", sourceItem.Read());
            Assert.Equal("source value", providerItem.Read());
        }

        /// <summary>
        ///     Tests the <see cref="SDK.Common.Item.WriteToSourceAsync(object)"/> method.
        /// </summary>
        [Fact]
        public async void WriteToSourceAsync()
        {
            // mock an IWriteable item provider
            Mock<IItemProvider> mockItemProvider = new Mock<IItemProvider>();
            mockItemProvider.CallBase = true;
            mockItemProvider.As<IWriteable>();

            // create an item sourced from an ItemProvider and link a model item
            SDK.Common.Item providerItem = new SDK.Common.Item("Source.Item", mockItemProvider.Object);

            // setup the mock to return a good value for the provider's Write()
            mockItemProvider.As<IWriteable>().Setup(p => p.Write(It.IsAny<SDK.Common.Item>(), It.IsAny<object>())).Returns(true);

            SDK.Common.Item sourceItem = new SDK.Common.Item("Root.Model.Item", providerItem);

            // test a write with an IWriteable provider
            bool result = await sourceItem.WriteToSourceAsync("source value");

            // assert that the write completed and that the value was written
            Assert.True(result);
            Assert.Equal("source value", sourceItem.Read());
            Assert.Equal("source value", providerItem.Read());
        }

        #endregion Public Methods
    }
}