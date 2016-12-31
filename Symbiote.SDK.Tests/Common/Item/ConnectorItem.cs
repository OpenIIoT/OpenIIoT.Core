///*
// █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀ ▀ ▀ ▀▀ █ █
// ▄████████ ▄█ █ ███ ███ ███ █ ███ █▀ ██████ ██▄▄▄▄ ██▄▄▄▄ ▄█████ ▄██████ ██ ██████ █████ ███▌ ██ ▄█████ ▄▄██▄▄▄ █ ███ ██ ██
// ██▀▀▀█▄ ██▀▀▀█▄ ██ █ ██ ██ ▀███████▄ ██ ██ ██ ██ ███▌ ▀███████▄ ██ █ ▄█▀▀██▀▀█▄ █ ███ ██ ██ ██ ██ ██ ██ ▄██▄▄ ██ ▀ ██ ▀ ██ ██
// ▄██▄▄█▀ ███▌ ██ ▀ ▄██▄▄ ██ ██ ██ █ ███ █▄ ██ ██ ██ ██ ██ ██ ▀▀██▀▀ ██ ▄ ██ ██ ██ ▀███████ ███ ██ ▀▀██▀▀ ██ ██ ██ █ ███ ███ ██ ██
// ██ ██ ██ ██ ██ █ ██ ██ ██ ██ ██ ██ ██ ███ ██ ██ █ ██ ██ ██ █ ████████▀ ██████ █ █ █ █ ███████ ██████▀ ▄██▀ ██████ ██ ██ █▀ ▄██▀
// ███████ █ ██ █ █ █ ███ █ ▀█████████▄ █ ▀███▀▀██ ▄█████ ▄█████ ██ ▄█████ █ ███ ▀ ██ █ ██ ▀ ▀███████▄ ██ ▀ █ ███ ▄██▄▄ ██ ██ ▀ ██
// █ ███ ▀▀██▀▀ ▀███████ ██ ▀███████ █ ███ ██ █ ▄ ██ ██ ▄ ██ █ ▄████▀ ███████ ▄████▀ ▄██▀ ▄████▀ █
// ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄ ▄▄ ▄▄ ▄▄▄▄ ▄▄ ▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
// █████████████████████████████████████████████████████████████ ███████████████ ██ ██ ██ ████ ██ ██ ████████████████ █ █ ▄ █ Unit
// tests for the ConnectorItem class. █ █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀ ▀ ▀▀▀ ▀▀ ▀ █ The GNU Affero General
// Public License (GNU AGPL) █ █ Copyright (C) 2016 JP Dillingham (jp@dillingham.ws) █ █ This program is free software: you can
// redistribute it and/or modify █ it under the terms of the GNU Affero General Public License as published by █ the Free Software
// Foundation, either version 3 of the License, or █ (at your option) any later version. █ █ This program is distributed in the
// hope that it will be useful, █ but WITHOUT ANY WARRANTY; without even the implied warranty of █ MERCHANTABILITY or FITNESS FOR A
// PARTICULAR PURPOSE. See the █ GNU Affero General Public License for more details. █ █ You should have received a copy of the GNU
// Affero General Public License █ along with this program. If not, see <http://www.gnu.org/licenses/>. █ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀
// ▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀██ ██ ▀█▄ ██ ▄█▀ ▀████▀ ▀▀ */

//using System.Diagnostics.CodeAnalysis;
//using Moq;
//using Symbiote.SDK.Plugin.Connector;
//using Utility.OperationResult;
//using Xunit;

//namespace Symbiote.SDK.Tests
//{
//    /// <summary>
//    ///     Unit tests for the <see cref="SDK.ConnectorItem"/> class.
//    /// </summary>
//    [Collection("ConnectorItem")]
//    public class ConnectorItem
//    {
//        #region Private Fields

// /// <summary> /// The shared IConnector mockup. /// </summary> private Mock<IConnector> connectorMock;

// /// <summary> /// The shared IConnector mockup which implements IReadable. /// </summary> private Mock<IConnector> readableConnectorMock;

// /// <summary> /// The shared IConnector mockup which implements ISubscribable. /// </summary> private Mock<IConnector> subscribableConnectorMock;

// /// <summary> /// The shared IConnector mockup which implements IWriteable. /// </summary> private Mock<IConnector> writeableConnectorMock;

// #endregion Private Fields

// #region Public Constructors

// /// <summary> /// Initializes a new instance of the <see cref="ConnectorItem"/> class. /// </summary> public ConnectorItem() {
// connectorMock = new Mock<IConnector>();

// readableConnectorMock = new Mock<IConnector>();

// writeableConnectorMock = new Mock<IConnector>(); writeableConnectorMock.As<IWriteable>();

// subscribableConnectorMock = new Mock<IConnector>(); subscribableConnectorMock.As<ISubscribable>(); }

// #endregion Public Constructors

// #region Public Methods

// ///
// <summary>
//     /// Tests the <see cref="SDK.ConnectorItem.AddChild(SDK.ConnectorItem)"/> and ///
//     <see cref="SDK.ConnectorItem.RemoveChild(SDK.ConnectorItem)"/> methods. ///
// </summary>
// [Fact] public void AddRemoveChildren() { SDK.ConnectorItem item = new SDK.ConnectorItem(connectorMock.Object, "Root");
// SDK.ConnectorItem child = new SDK.ConnectorItem(connectorMock.Object, "Root.Child"); SDK.ConnectorItem childsChild = new
// SDK.ConnectorItem(connectorMock.Object, "Root.Child.Child"); child.AddChild(childsChild);

// // add the child and ensure the operation was successful and that it returns the child item Result<SDK.ConnectorItem> addResult
// = item.AddChild(child);

// Assert.Equal(ResultCode.Success, addResult.ResultCode); Assert.Equal(child, addResult.ReturnValue);

// // remove the child and ensure it was successful and that it returns the child item Result<SDK.ConnectorItem> removeResult = item.RemoveChild(child);

// Assert.Equal(ResultCode.Success, removeResult.ResultCode); Assert.Equal(child, removeResult.ReturnValue);

// // attempt to remove a non-existent child and ensure that the operation fails Result<SDK.ConnectorItem> badRemoveResult =
// item.RemoveChild(new SDK.ConnectorItem(connectorMock.Object, "Root.New"));

// Assert.Equal(ResultCode.Failure, badRemoveResult.ResultCode); }

// ///
// <summary>
//     /// Tests the <see cref="SDK.ConnectorItem.Changed"/> event. ///
// </summary>
// [SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1008:OpeningParenthesisMustBeSpacedCorrectly", Justification = "Reviewed.")]
// [Fact] public void Changed() { // prepare an item and write an initial value SDK.ConnectorItem item = new
// SDK.ConnectorItem(connectorMock.Object, "Root.Item"); item.Write("initial");

// // prepare event args and bind a handler to the changed event SDK.ItemChangedEventArgs args = default(SDK.ItemChangedEventArgs);
// item.Changed += delegate (object sender, SDK.ItemChangedEventArgs e) { args = e; };

// // invoke the write method to fire the event item.Write("test");

// // assert that the previousvalue and value members of the event args are as expected. Assert.Equal("initial",
// args.PreviousValue); Assert.Equal("test", args.Value); }

// ///
// <summary>
//     /// Tests all constructor overloads. ///
// </summary>
// [Fact] public void Constructor() { SDK.ConnectorItem item;

// item = new SDK.ConnectorItem(connectorMock.Object, string.Empty); Assert.IsType<SDK.ConnectorItem>(item);

// item = new SDK.ConnectorItem(connectorMock.Object, string.Empty, string.Empty); Assert.IsType<SDK.ConnectorItem>(item); }

// ///
// <summary>
//     /// Tests the functionality of the <see cref="SDK.ConnectorItem.AddChild(SDK.ConnectorItem)"/> method. ///
// </summary>
// [Fact] public void ItemAdoption() { SDK.ConnectorItem root = new SDK.ConnectorItem(connectorMock.Object, "Root");
// SDK.ConnectorItem child = new SDK.ConnectorItem(connectorMock.Object, "Orphaned.Item");

// Assert.Equal(true, child.IsOrphaned); Assert.Equal("Orphaned.Item", child.FQN); Assert.Equal("Orphaned", child.Path);

// root.AddChild(child);

// Assert.Equal(false, child.IsOrphaned); Assert.Equal("Root.Item", child.FQN); Assert.Equal("Root", child.Path); }

// ///
// <summary>
//     /// Tests all properties. ///
// </summary>
// [Fact] public void Properties() { SDK.ConnectorItem item = new SDK.ConnectorItem(connectorMock.Object, "Root.Child.Name", "Source");

// Assert.Equal(connectorMock.Object, item.Connector); }

// ///
// <summary>
//     /// Tests the <see cref="SDK.ConnectorItem.Read"/> and <see cref="SDK.ConnectorItem.ReadAsync"/> methods. ///
// </summary>
// [Fact] public async void Read() { // test the method with a connector which implements IReadable start by creating a new
// ConnectorItem instance SDK.ConnectorItem readableItem = new SDK.ConnectorItem(readableConnectorMock.Object, "Root.Item.Readable");

// // create a Result to simulate the return from a Connector read Result<object> result = new Result<object>(); result.ReturnValue
// = "readable value";

// // set up the readable mock to return the result when we perform the read readableConnectorMock.Setup(m => m.Read(readableItem)).Returns(result);

// // invoke the methods and do assertions Assert.Equal("readable value", readableItem.Read());

// object value = await readableItem.ReadAsync();

// Assert.Equal("readable value", value); }

// ///
// <summary>
//     /// Tests the <see cref="SDK.ConnectorItem.ReadFromSource"/> and <see cref="SDK.ConnectorItem.ReadFromSourceAsync"/>
//     methods. ///
// </summary>
// [Fact] public async void ReadFromSource() { // test the method with a connector which doesn't implement IReadable
// SDK.ConnectorItem item = new SDK.ConnectorItem(connectorMock.Object, "Root.Item"); item.Write("value");

// object value = item.ReadFromSource(); Assert.Equal(null, value);

// // invoke the method asynchronously object newValue = await item.ReadFromSourceAsync(); Assert.Equal(null, newValue);

// // test the method with a connector which implements IReadable start by creating a new ConnectorItem instance SDK.ConnectorItem
// readableItem = new SDK.ConnectorItem(readableConnectorMock.Object, "Root.Item.Readable");

// // create a Result to simulate the return from a Connector read Result<object> result = new Result<object>(); result.ReturnValue
// = "readable value";

// // set up the readable mock to return the result when we perform the read readableConnectorMock.Setup(m => m.Read(readableItem)).Returns(result);

// // invoke the read and assert that the values match object readableValue = readableItem.ReadFromSource(); Assert.Equal("readable
// value", readableValue); }

// ///
// <summary>
//     /// Tests the <see cref="Item.SubscribeToSource"/> and <see cref="Item.UnsubscribeFromSource"/> methods. ///
// </summary>
// [Fact] public void Subscription() { // prepare an item with a source connector which does not implement ISubscribable
// SDK.ConnectorItem item = new SDK.ConnectorItem(connectorMock.Object, "Root.Item");

// // assert that subscribe/unsubscribe methods result in a failure Assert.Equal(ResultCode.Failure,
// item.SubscribeToSource().ResultCode); Assert.Equal(ResultCode.Failure, item.UnsubscribeFromSource().ResultCode);

// // prepare an item with a source connector which implements ISubscribable SDK.ConnectorItem subItem = new
// SDK.ConnectorItem(subscribableConnectorMock.Object, "Root.SubItem");

// // prepare the connector mockup Result result = new Result(); subscribableConnectorMock.As<ISubscribable>().Setup(m =>
// m.Subscribe(subItem)).Returns(result); subscribableConnectorMock.As<ISubscribable>().Setup(m => m.UnSubscribe(subItem)).Returns(result);

// Assert.Equal(ResultCode.Success, subItem.SubscribeToSource().ResultCode); Assert.Equal(ResultCode.Success,
// subItem.UnsubscribeFromSource().ResultCode); }

// ///
// <summary>
//     /// Tests the <see cref="SDK.ConnectorItem.SubscriptionsChanged()"/> method. ///
// </summary>
// [Fact] [SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1008:OpeningParenthesisMustBeSpacedCorrectly", Justification =
// "Reviewed.")] public void SubscriptionsChanged() { // prepare an item SDK.ConnectorItem item = new
// SDK.ConnectorItem(connectorMock.Object, "Root.Item");

// // invoke the method. no handlers are attached, so item should unsubscribe itself from the source connector. item.SubscriptionsChanged();

// // attach an event handler to the changed event item.Changed += delegate (object sender, SDK.ItemChangedEventArgs e) { };

// // invoke the method again. handler is attached, so item should subscribe itself to the source connector.
// item.SubscriptionsChanged(); }

// ///
// <summary>
//     /// Tests the <see cref="Item.Write(object)"/> and <see cref="Item.WriteAsync(object)"/> methods. ///
// </summary>
// [Fact] public async void Write() { SDK.ConnectorItem item = new SDK.ConnectorItem(connectorMock.Object, "Root.Item");

// item.Write("test"); Assert.Equal("test", item.Value);

// await item.WriteAsync("test two"); Assert.Equal("test two", item.Value); }

// ///
// <summary>
//     /// Tests the <see cref="SDK.ConnectorItem.Write(object)"/> and <see cref="SDK.ConnectorItem.WriteToSourceAsync(object)"/> ///
// </summary>
// [Fact] public async void WriteToSource() { // test the method with an item from a connector that doesn't implement IWriteable
// SDK.ConnectorItem nonWriteableItem = new SDK.ConnectorItem(connectorMock.Object, "Root.NonWriteable");
// Assert.NotEqual(ResultCode.Success, nonWriteableItem.WriteToSource("test").ResultCode);

// // test the method with an item from a connector that implements IWriteable create the item SDK.ConnectorItem item = new
// SDK.ConnectorItem(writeableConnectorMock.Object, "Root.Item");

// // set up the mock connector writeableConnectorMock.As<IWriteable>().Setup(m => m.Write(item, "write test")).Returns(new
// Result()); writeableConnectorMock.As<IWriteable>().Setup(m => m.Write(item, "write test two")).Returns(new Result());

// // perform the write and assert that it succeeded and assert the changed value Assert.Equal(ResultCode.Success,
// item.WriteToSource("write test").ResultCode); Assert.Equal("write test", item.Value);

// // invoke the method and await the result Result result = await item.WriteToSourceAsync("write test two");

// // assert Assert.Equal(ResultCode.Success, result.ResultCode); Assert.Equal("write test two", item.Value); }

//        #endregion Public Methods
//    }
//}