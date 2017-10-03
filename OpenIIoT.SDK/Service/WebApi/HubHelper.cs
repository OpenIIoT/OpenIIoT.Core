using System;
using System.Collections.Generic;
using System.Linq;
using NLog;
using OpenIIoT.SDK;
using OpenIIoT.SDK.Common.OperationResult;

namespace OpenIIoT.SDK.Service.WebApi
{
    /// <summary>
    ///     The HubHelper acts as a static subscription and event manager for SignalR hubs.
    /// </summary>
    /// <remarks>SignalR hubs are unable to persist data across instances because a new instance is created for each invocation.</remarks>
    public class HubHelper
    {
        // TODO: evaluate whether this makes sense to non-core hubs. Would a plugin based hub use this?

        #region Private Fields

        /// <summary>
        ///     The Logger for this class.
        /// </summary>
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        ///     The ApplicationManager for the application.
        /// </summary>
        private IApplicationManager manager;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="HubHelper"/> class with the supplied ApplicationManager.
        /// </summary>
        /// <param name="manager">The ApplicationManager for the application.</param>
        /// <param name="hub">The hub to be managed by the HubManager.</param>
        public HubHelper(IApplicationManager manager, IHub hub)
        {
            this.manager = manager;
            Hub = hub;
            Subscriptions = new Dictionary<object, List<string>>();
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        ///     Gets the hub being managed by the HubManager.
        /// </summary>
        public IHub Hub { get; private set; }

        /// <summary>
        ///     Gets a dictionary containing all of the subscribed objects along with a list of clients subscribed to each object.
        /// </summary>
        public Dictionary<object, List<string>> Subscriptions { get; private set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        ///     Returns a list of subscribed items for the supplied client using the default dictionary.
        /// </summary>
        /// <param name="client">The client for which to return the list of subscriptions.</param>
        /// <returns>A list containing all of the items to which the client is subscribed.</returns>
        public List<string> GetClientSubscriptions(string client)
        {
            return GetClientSubscriptions(client, Subscriptions);
        }

        /// <summary>
        ///     Returns a list of subscribed items for the supplied client using the supplied dictionary.
        /// </summary>
        /// <param name="client">The client for which to return the list of subscriptions.</param>
        /// <param name="dictionary">The dictionary from which to retrieve the list of subscriptions.</param>
        /// <returns>A list containing all of the items to which the client is subscribed.</returns>
        public List<string> GetClientSubscriptions(string client, Dictionary<object, List<string>> dictionary)
        {
            List<string> retVal = new List<string>();
            List<object> keyList = new List<object>(dictionary.Keys);

            // iterate over all subscribed items
            foreach (string key in keyList)
            {
                if (dictionary[key].Where(v => v.Equals(client)).Count() > 0)
                {
                    retVal.Add(key);
                }
            }

            return retVal;
        }

        /// <summary>
        ///     Returns the list of clients subscribed to the supplied object in the default dictionary.
        /// </summary>
        /// <param name="key">The object from which the list of clients should be retrieved.</param>
        /// <returns>A list containing the clients subscribed to the supplied object.</returns>
        public List<string> GetSubscriptions(object key)
        {
            return GetSubscriptions(key, Subscriptions);
        }

        /// <summary>
        ///     Returns the list of clients subscribed to the supplied object in the supplied dictionary.
        /// </summary>
        /// <param name="key">The object from which the list of clients should be retrieved.</param>
        /// <param name="dictionary">The dictionary from which to retrieve the list of clients.</param>
        /// <returns>A list containing the clients subscribed to the supplied object.</returns>
        public List<string> GetSubscriptions(object key, Dictionary<object, List<string>> dictionary)
        {
            List<string> subs;
            dictionary.TryGetValue(key, out subs);
            return subs;
        }

        /// <summary>
        ///     An event proxy for the change event for items monitored by the hub.
        /// </summary>
        /// <remarks>
        ///     This is necessary so that the event handler for an item can be removed when the client unsubscribes or disconnects.
        ///     An event handler within the hub itself is unable to be unregistered due to the way the hub is instantiated by SignalR.
        /// </remarks>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event arguments.</param>
        public void OnChange(object sender, EventArgs e)
        {
            Hub.Read(sender, e);
        }

        /// <summary>
        ///     Adds the supplied client to the default dictionary entry for the supplied key
        /// </summary>
        /// <param name="key">The object to which the client is subscribing.</param>
        /// <param name="client">The client subscribing to the object.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public Result Subscribe(object key, string client)
        {
            return Subscribe(key, client, Subscriptions);
        }

        /// <summary>
        ///     Adds the supplied client to the supplied dictionary entry for the supplied key
        /// </summary>
        /// <param name="key">The object to which the client is subscribing.</param>
        /// <param name="client">The client subscribing to the object.</param>
        /// <param name="dictionary">The dictionary to which to add the entry.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public Result Subscribe(object key, string client, Dictionary<object, List<string>> dictionary)
        {
            Result retVal = new Result();

            try
            {
                List<string> subs;
                dictionary.TryGetValue(key, out subs);

                if (subs == default(List<string>))
                {
                    subs = new List<string>();
                }

                subs.Add(client);

                dictionary[key] = subs;
            }
            catch (Exception ex)
            {
                retVal.AddError("Exception thrown adding the subscription to the dictionary: " + ex.Message);
            }

            return retVal;
        }

        /// <summary>
        ///     Removes the supplied client from the default dictionary entry for the supplied key.
        /// </summary>
        /// <param name="key">The object to which the client is unsubscribing.</param>
        /// <param name="client">The client unsubscribing from the object.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public Result Unsubscribe(object key, string client)
        {
            return Unsubscribe(key, client, Subscriptions);
        }

        /// <summary>
        ///     Removes the supplied client from the supplied dictionary entry for the supplied key.
        /// </summary>
        /// <param name="key">The object from which the client is unsubscribing.</param>
        /// <param name="client">The client unsubscribing from the object.</param>
        /// <param name="dictionary">The dictionary from which to remove the entry.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public Result Unsubscribe(object key, string client, Dictionary<object, List<string>> dictionary)
        {
            Result retVal = new Result();

            try
            {
                List<string> subs;
                dictionary.TryGetValue(key, out subs);

                if (subs != default(List<string>))
                {
                    subs.Remove(client);
                }
            }
            catch (Exception ex)
            {
                retVal.AddError("Exception thrown adding the subscription to the dictionary: " + ex.Message);
            }

            return retVal;
        }

        #endregion Public Methods
    }
}