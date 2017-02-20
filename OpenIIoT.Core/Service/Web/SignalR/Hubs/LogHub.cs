using System.Collections.Generic;
using Microsoft.AspNet.SignalR;
using NLog;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System;
using System.Linq;
using NLog.RealtimeLogger;
using OpenIIoT.SDK;

namespace OpenIIoT.Core.Service.Web.SignalR
{
    /// <summary>
    ///     The LogHub provides realtime read access to logs.
    /// </summary>
    public class LogHub : Hub, IHub
    {
        #region Variables

        /// <summary>
        ///     The ApplicationManager for the application.
        /// </summary>
        private IApplicationManager manager = ApplicationManager.GetInstance();

        /// <summary>
        ///     The Logger for this class.
        /// </summary>
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        ///     The HubManager managing this hub.
        /// </summary>
        private static HubHelper hubManager;

        #endregion Variables

        #region Constructors

        /// <summary>
        ///     Constructs a new instance of the hub with the supplied ApplicationManager.
        /// </summary>
        public LogHub()
        {
            // if hubManager is null, create a new instance. this ensures that there is only one copy for the hub regardless of the
            // number of instances.
            if (hubManager == default(HubHelper))
            {
                hubManager = new HubHelper(manager, this);
                RealtimeLogger.LogAppended += hubManager.OnChange;
            }
        }

        #endregion Constructors

        #region Instance Methods

        /// <summary>
        ///     Event called when a new client connects to the hub.
        /// </summary>
        /// <returns>A Task used for asynchronous calls.</returns>
        public override Task OnConnected()
        {
            logger.Info(GetLogPrefix() + "connected.");
            return base.OnConnected();
        }

        /// <summary>
        ///     Called when a client disconnects from the hub.
        /// </summary>
        /// <param name="stopCalled">True if the connection was intentionally stopped with Stop(), false otherwise.</param>
        /// <returns>A Task used for asynchronous calls.</returns>
        public override Task OnDisconnected(bool stopCalled)
        {
            logger.Info(GetLogPrefix() + "disconnected.");
            Unsubscribe(new object());
            return base.OnDisconnected(stopCalled);
        }

        /// <summary>
        ///     Called when a client reconnects to the hub after having previously disconnected.
        /// </summary>
        /// <returns>A Task used for asynchronous calls.</returns>
        public override Task OnReconnected()
        {
            logger.Info(GetLogPrefix() + "reconnected.");
            Subscribe(new object());
            return base.OnReconnected();
        }

        /// <summary>
        ///     Called from the HubManager event proxy; called when a new message is added to the Logger.
        /// </summary>
        /// <param name="sender">The object that raised the original Changed event.</param>
        /// <param name="e">The event arguments.</param>
        public void Read(object sender, EventArgs e)
        {
            RealtimeLoggerEventArgs args = (RealtimeLoggerEventArgs)e;

            string levelJson = JsonConvert.SerializeObject(args.Level);
            string messageJson = JsonConvert.SerializeObject(args.Message);

            Clients.Group("Logger").read(levelJson, messageJson);
        }

        /// <summary>
        ///     Invoked by clients to update the value of an Item.
        /// </summary>
        /// <remarks>
        ///     Invokes the writeSuccess() and writeError() methods on the calling client depending on the outcome of the call.
        /// </remarks>
        /// <param name="args">
        ///     An object array containing the Fully Qualified Name of the Item to update in the first index and an object
        ///     containing the new value in the second.
        /// </param>
        public void Write(object[] args)
        {
            Clients.Caller.writeError("Logger", new object[] { "Not implemented." });
        }

        /// <summary>
        ///     Invoked by clients to update the value of the SourceItem(s) for an Item. Recursively writes the value all the way
        ///     down to the origin.
        /// </summary>
        /// <remarks>
        ///     Invokes the writeSuccess() and writeError() methods on the calling client depending on the outcome of the call.
        /// </remarks>
        /// <param name="args">
        ///     An object array containing the Fully Qualified Name of the Item to update in the first index and an object
        ///     containing the new value in the second.
        /// </param>
        public void WriteToSource(object[] args)
        {
            Clients.Caller.writeToSourceError("Logger", new object[] { "Not implemented." });
        }

        /// <summary>
        ///     Subscribes the calling client to the logger.
        /// </summary>
        /// <remarks>
        ///     Registers an event handler to the Changed event for the item, adds the client to the SignalR group for the item's
        ///     FQN, Subscribes the client to the item within the HubManager and calls the subscribeSuccess() method on the calling client.
        /// </remarks>
        /// <param name="arg">The Fully Qualified name of the Item to which to subscribe.</param>
        public void Subscribe(object arg)
        {
            Groups.Add(Context.ConnectionId, "Logger");
            hubManager.Subscribe("Logger", Context.ConnectionId);
            Clients.Caller.subscribeSuccess("Logger");

            logger.Info(GetLogPrefix() + "subscribed to the Logger.");

            logger.Info("SignalR Logger now has " + hubManager.GetSubscriptions("Logger").Count + " subscriber(s).");
        }

        /// <summary>
        ///     Unsubscribes the calling client from the logger.
        /// </summary>
        /// <remarks>
        ///     Unregisters the event handler for the item, removes the client to the SignalR group for the item's FQN,
        ///     unsubscribes the client from the item within the HubManager and calls the unsubscribeSuccess() method on the
        ///     calling client.
        /// </remarks>
        public void Unsubscribe(object arg)
        {
            Groups.Remove(Context.ConnectionId, "Logger");
            hubManager.Unsubscribe("Logger", Context.ConnectionId);
            Clients.Caller.unsubscribeSuccess("Logger");

            logger.Info(GetLogPrefix() + "unsubscribed from the Logger.");

            logger.Info("SignalR Logger now has " + hubManager.GetSubscriptions("Logger").Count + " subscriber(s).");
        }

        private string GetLogPrefix()
        {
            return "SignalR Connection [" + this.GetType().Name + "/ID: " + Context.ConnectionId + "] ";
        }

        #endregion Instance Methods
    }
}