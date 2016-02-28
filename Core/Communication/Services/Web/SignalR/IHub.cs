using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core.Communication.Services.Web.SignalR
{
    /// <summary>
    /// The IHub interface defines characteristics of a Hub.
    /// </summary>
    public interface IHub
    {
        /// <summary>
        /// Called from the HubManager event proxy; called when a subscribed Item's value changes.
        /// </summary>
        /// <param name="sender">The Item that raised the original Changed event.</param>
        /// <param name="e">The event arguments.</param>
        void Read(object sender, EventArgs e);
        /// <summary>
        /// Invoked by clients to update the value of an Item.
        /// </summary>
        /// <param name="args">An object array containing the Fully Qualified Name of the Item to update in the first index and an object containing the new value in the second.</param>
        void Write(object[] args);
        /// <summary>
        /// Invoked by clients to update the value of the SourceItem(s) for an Item.  Recursively writes the value all the way down to the origin.
        /// </summary>
        /// <param name="args">An object array containing the Fully Qualified Name of the Item to update in the first index and an object containing the new value in the second.</param>
        void WriteToSource(object[] args);
        /// <summary>
        /// Subscribes the calling client to the item matching the provided FQN.
        /// </summary>
        /// <param name="obj"></param>
        void Subscribe(object obj);
        /// <summary>
        /// Unsubscribes the calling client from the item matching the provided FQN.
        /// </summary>
        /// <param name="obj">the Fully Qualified Name of the item to which the client is to be unsubscribed.</param>
        void Unsubscribe(object obj);
    }
}
