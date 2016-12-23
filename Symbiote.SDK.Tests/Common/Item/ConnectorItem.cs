/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █   ▄████████                                                                           ▄█
      █   ███    ███                                                                         ███
      █   ███    █▀   ██████  ██▄▄▄▄  ██▄▄▄▄     ▄█████  ▄██████     ██     ██████     █████ ███▌     ██       ▄█████    ▄▄██▄▄▄
      █   ███        ██    ██ ██▀▀▀█▄ ██▀▀▀█▄   ██   █  ██    ██ ▀███████▄ ██    ██   ██  ██ ███▌ ▀███████▄   ██   █   ▄█▀▀██▀▀█▄
      █   ███        ██    ██ ██   ██ ██   ██  ▄██▄▄    ██    ▀      ██  ▀ ██    ██  ▄██▄▄█▀ ███▌     ██  ▀  ▄██▄▄     ██  ██  ██
      █   ███    █▄  ██    ██ ██   ██ ██   ██ ▀▀██▀▀    ██    ▄      ██    ██    ██ ▀███████ ███      ██    ▀▀██▀▀     ██  ██  ██
      █   ███    ███ ██    ██ ██   ██ ██   ██   ██   █  ██    ██     ██    ██    ██   ██  ██ ███      ██      ██   █   ██  ██  ██
      █   ████████▀   ██████   █   █   █   █    ███████ ██████▀     ▄██▀    ██████    ██  ██ █▀      ▄██▀     ███████   █  ██  █
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
      █  Unit tests for the ConnectorItem class.
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
using Xunit;
using Symbiote.SDK.Plugin.Connector;

namespace Symbiote.SDK.Tests
{
    /// <summary>
    ///     Unit tests for the ConnectorItem class.
    /// </summary>
    public class ConnectorItem
    {
        /// <summary>
        ///     The shared IConnector mockup.
        /// </summary>
        private Mock<IConnector> connectorMock;

        /// <summary>
        ///     The shared IConnector mockup which implements IReadable.
        /// </summary>
        private Mock<IConnector> readableConnectorMock;

        /// <summary>
        ///     The shared IConnector mockup which implements IWriteable.
        /// </summary>
        private Mock<IConnector> writeableConnectorMock;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ConnectorItem"/> class.
        /// </summary>
        public ConnectorItem()
        {
            connectorMock = new Mock<IConnector>();

            readableConnectorMock = new Mock<IConnector>();
            readableConnectorMock.As<IReadable>();

            writeableConnectorMock = new Mock<IConnector>();
            writeableConnectorMock.As<IWriteable>();
        }

        /// <summary>
        ///     Tests all constructor overloads.
        /// </summary>
        [Fact]
        public void Constructor()
        {
            SDK.ConnectorItem item;

            item = new SDK.ConnectorItem(connectorMock.Object, string.Empty, false);
            Assert.IsType<SDK.ConnectorItem>(item);

            item = new SDK.ConnectorItem(connectorMock.Object, string.Empty, string.Empty);
            Assert.IsType<SDK.ConnectorItem>(item);

            item = new SDK.ConnectorItem(connectorMock.Object, string.Empty, string.Empty, false);
            Assert.IsType<SDK.ConnectorItem>(item);
        }

        /// <summary>
        ///     Tests all properties.
        /// </summary>
        [Fact]
        public void Properties()
        {
            SDK.ConnectorItem item = new SDK.ConnectorItem(connectorMock.Object, "Root.Child.Name", "Source");

            Assert.Equal(connectorMock.Object, item.Connector);
        }

        /// <summary>
        ///     Tests the functionality of the <see cref="SDK.ConnectorItem.AddChild(SDK.ConnectorItem)"/> method.
        /// </summary>
        [Fact]
        public void ItemAdoption()
        {
            SDK.ConnectorItem root = new SDK.ConnectorItem(connectorMock.Object, "Root");
            SDK.ConnectorItem child = new SDK.ConnectorItem(connectorMock.Object, "Orphaned.Item");

            Assert.Equal(true, child.IsOrphaned);
            Assert.Equal("Orphaned.Item", child.FQN);
            Assert.Equal("Orphaned", child.Path);

            root.AddChild(child);

            Assert.Equal(false, child.IsOrphaned);
            Assert.Equal("Root.Item", child.FQN);
            Assert.Equal("Root", child.Path);
        }

        /// <summary>
        ///     Tests the <see cref="Item.Write(object)"/> and <see cref="Item.WriteAsync(object)"/> methods.
        /// </summary>
        [Fact]
        public async void Write()
        {
            SDK.ConnectorItem item = new SDK.ConnectorItem(connectorMock.Object, "Root.Item");

            item.Write("test");
            Assert.Equal("test", item.Value);

            await item.WriteAsync("test two");
            Assert.Equal("test two", item.Value);
        }

        /// <summary>
        ///     Tests the <see cref="SDK.ConnectorItem.Read"/> and <see cref="SDK.ConnectorItem.ReadAsync"/> methods.
        /// </summary>
        [Fact]
        public async void Read()
        {
            // test the method with a connector which implements IReadable start by creating a new ConnectorItem instance
            SDK.ConnectorItem readableItem = new SDK.ConnectorItem(readableConnectorMock.Object, "Root.Item.Readable");

            // create a Result to simulate the return from a Connector read
            Result<object> result = new Result<object>();
            result.ReturnValue = "readable value";

            // set up the readable mock to return the result when we perform the read
            readableConnectorMock.As<IReadable>().Setup(m => m.Read(readableItem)).Returns(result);

            // invoke the methods and do assertions
            Assert.Equal("readable value", readableItem.Read());

            object value = await readableItem.ReadAsync();

            Assert.Equal("readable value", value);
        }

        /// <summary>
        ///     Tests the <see cref="SDK.ConnectorItem.ReadFromSource"/> and <see cref="SDK.ConnectorItem.ReadFromSourceAsync"/> methods.
        /// </summary>
        [Fact]
        public async void ReadFromSource()
        {
            // test the method with a connector which doesn't implement IReadable
            SDK.ConnectorItem item = new SDK.ConnectorItem(connectorMock.Object, "Root.Item");
            item.Write("value");

            object value = item.ReadFromSource();
            Assert.Equal(null, value);

            // invoke the method asynchronously
            object newValue = await item.ReadFromSourceAsync();
            Assert.Equal(null, newValue);

            // test the method with a connector which implements IReadable start by creating a new ConnectorItem instance
            SDK.ConnectorItem readableItem = new SDK.ConnectorItem(readableConnectorMock.Object, "Root.Item.Readable");

            // create a Result to simulate the return from a Connector read
            Result<object> result = new Result<object>();
            result.ReturnValue = "readable value";

            // set up the readable mock to return the result when we perform the read
            readableConnectorMock.As<IReadable>().Setup(m => m.Read(readableItem)).Returns(result);

            // invoke the read and assert that the values match
            object readableValue = readableItem.ReadFromSource();
            Assert.Equal("readable value", readableValue);
        }

        /// <summary>
        ///     Tests the <see cref="Item.Write(object)"/> and <see cref="Item.WriteToSourceAsync(object)"/>
        /// </summary>
        [Fact]
        public async void WriteToSource()
        {
            // test the method with an item from a connector that doesn't implement IWriteable
            SDK.ConnectorItem nonWriteableItem = new SDK.ConnectorItem(connectorMock.Object, "Root.NonWriteable");
            Assert.NotEqual(ResultCode.Success, nonWriteableItem.WriteToSource("test").ResultCode);

            // test the method with an item from a connector that implements IWriteable create the item
            SDK.ConnectorItem item = new SDK.ConnectorItem(writeableConnectorMock.Object, "Root.Item");

            // set up the mock connector
            writeableConnectorMock.As<IWriteable>().Setup(m => m.Write(item, "write test")).Returns(new Result());
            writeableConnectorMock.As<IWriteable>().Setup(m => m.Write(item, "write test two")).Returns(new Result());

            // perform the write and assert that it succeeded and assert the changed value
            Assert.Equal(ResultCode.Success, item.WriteToSource("write test").ResultCode);
            Assert.Equal("write test", item.Value);

            // invoke the method and await the result
            Result result = await item.WriteToSourceAsync("write test two");

            // assert
            Assert.Equal(ResultCode.Success, result.ResultCode);
            Assert.Equal("write test two", item.Value);
        }

        ///// <summary>
        /////     Tests the <see cref="Item.AddChild(Item)"/> and <see cref="Item.RemoveChild(Item)"/> methods.
        ///// </summary>
        //[Fact]
        //public void AddRemoveChildren()
        //{
        //    Item item = new Item("Root");
        //    Item child = new Item("Root.Child");
        //    Item childsChild = new Item("Root.Child.Child");
        //    child.AddChild(childsChild);

        // // add the child and ensure the operation was successful and that it returns the child item Result<Item> addResult = item.AddChild(child);

        // Assert.Equal(ResultCode.Success, addResult.ResultCode); Assert.Equal(child, addResult.ReturnValue);

        // // remove the child and ensure it was successful and that it returns the child item Result<Item> removeResult = item.RemoveChild(child);

        // Assert.Equal(ResultCode.Success, removeResult.ResultCode); Assert.Equal(child, removeResult.ReturnValue);

        // // attempt to remove a non-existent child and ensure that the operation fails Result<Item> badRemoveResult =
        // item.RemoveChild(new Item("Root.New"));

        //    Assert.Equal(ResultCode.Failure, badRemoveResult.ResultCode);
        //}

        ///// <summary>
        /////     Tests the <see cref="Item.SubscribeToSource"/> and <see cref="Item.UnsubscribeFromSource"/> methods.
        ///// </summary>
        //[Fact]
        //public void Subscription()
        //{
        //    Item sourceItem = new Item("Root.SourceItem");
        //    sourceItem.Write("initial value");

        // Item item = new Item("Root.Item", sourceItem);

        // // subscribe the item to it's source item and assert that it succeeded Result subscribeResult =
        // item.SubscribeToSource(); Assert.Equal(ResultCode.Success, subscribeResult.ResultCode);

        // // write a value to the source item and assert that the item's value updates. sourceItem.Write("new value");
        // Assert.Equal("new value", sourceItem.Value); Assert.Equal("new value", item.Value);

        // // unsubscribe the item from it's source item and assert that it succeeded Result unsubscribeResult =
        // item.UnsubscribeFromSource(); Assert.Equal(ResultCode.Success, unsubscribeResult.ResultCode);

        // // write a value to the source item and assert that the item's value doesn't update. sourceItem.Write("final value");
        // Assert.Equal("final value", sourceItem.Value); Assert.NotEqual("final value", item.Value);

        // // test the subscribe/unsubscribe methods with an item for which the source item has not been set Item lastItem = new Item("Root.LastItem");

        // Result lastItemSub = lastItem.SubscribeToSource(); Assert.Equal(ResultCode.Failure, lastItemSub.ResultCode);

        //    Result lastItemUnSub = lastItem.UnsubscribeFromSource();
        //    Assert.Equal(ResultCode.Failure, lastItemUnSub.ResultCode);
        //}
    }
}