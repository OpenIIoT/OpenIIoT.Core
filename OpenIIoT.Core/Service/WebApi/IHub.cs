namespace OpenIIoT.Core.Service.WebApi
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    ///     The IHub interface defines characteristics of a Hub.
    /// </summary>
    public interface IHub
    {
        // TODO: reevaluate the use case beyond Item read/writes. Do other hub implementations require the same methods?

        #region Public Methods

        /// <summary>
        ///     Called from the HubManager event proxy; called when a subscribed Item's value changes.
        /// </summary>
        /// <param name="sender">The Item that raised the original Changed event.</param>
        /// <param name="e">The event arguments.</param>
        void Read(object sender, EventArgs e);

        /// <summary>
        ///     Subscribes the calling client to the item matching the provided FQN.
        /// </summary>
        /// <param name="obj">The Fully Qualified Name of the item to which the client is to be subscribed.</param>
        void Subscribe(object obj);

        /// <summary>
        ///     Unsubscribes the calling client from the item matching the provided FQN.
        /// </summary>
        /// <param name="obj">The Fully Qualified Name of the item to which the client is to be unsubscribed.</param>
        void Unsubscribe(object obj);

        /// <summary>
        ///     Invoked by clients to update the value of an Item.
        /// </summary>
        /// <param name="args">
        ///     An object array containing the Fully Qualified Name of the Item to update in the first index and an object
        ///     containing the new value in the second.
        /// </param>
        void Write(object[] args);

        #endregion Public Methods
    }
}