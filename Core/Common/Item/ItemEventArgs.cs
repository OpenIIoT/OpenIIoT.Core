using System;

namespace Symbiote.Core
{
    /// <summary>
    /// The ItemEventArgs contain the event arguments for Item Changed events.
    /// </summary>
    public class ItemEventArgs : EventArgs
    {
        /// <summary>
        /// The new value of the Item.
        /// </summary>
        public object Value { get; private set; }

        /// <summary>
        /// The default constructor.
        /// </summary>
        /// <param name="value">The new value of the Item.</param>
        public ItemEventArgs(object value) : base()
        {
            Value = value;
        }
    }
}
