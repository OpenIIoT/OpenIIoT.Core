/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █    ▄█     ▄████████
      █   ███    ███    ███
      █   ███▌   ███    █▀  ██   █  ▀██████▄    ▄█████  ▄██████    █████  █  ▀██████▄    ▄█████  ▀██████▄   █          ▄█████
      █   ███▌   ███        ██   ██   ██   ██   ██  ▀  ██    ██   ██  ██ ██    ██   ██   ██   ██   ██   ██ ██         ██   █
      █   ███▌ ▀███████████ ██   ██  ▄██▄▄█▀    ██     ██    ▀   ▄██▄▄█▀ ██▌  ▄██▄▄█▀    ██   ██  ▄██▄▄█▀  ██        ▄██▄▄
      █   ███           ███ ██   ██ ▀▀██▀▀█▄  ▀███████ ██    ▄  ▀███████ ██  ▀▀██▀▀█▄  ▀████████ ▀▀██▀▀█▄  ██       ▀▀██▀▀
      █   ███     ▄█    ███ ██   ██   ██   ██    ▄  ██ ██    ██   ██  ██ ██    ██   ██   ██   ██   ██   ██ ██▌    ▄   ██   █
      █   █▀    ▄████████▀  ██████  ▄██████▀   ▄████▀  ██████▀    ██  ██ █   ▄██████▀    ██   █▀ ▄██████▀  ████▄▄██   ███████
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █
      █
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀ ▀ ▀▀▀     ▀▀               ▀
      █  The GNU Affero General Public License (GNU AGPL)
      █
      █  Copyright (C) 2016-2017 JP Dillingham (jp@dillingham.ws)
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

using OpenIIoT.SDK.Common;
using System;
using System.Collections.Generic;
using Utility.OperationResult;

namespace OpenIIoT.SDK.Common.Provider.ItemProvider
{
    /// <summary>
    ///     Defines the interface for Connector Plugins which are capable of producing unsolicited value updates to configured Items.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Each <see cref="IConnector"/> implementing ISubscribable must implement a <see cref="Dictionary{TKey, TValue}"/>
    ///         property named <see cref="Subscriptions"/> keyed on <see cref="Item"/> and with value <see cref="int"/>. Each entry
    ///         in the Dictionary represents an Item with at least one active subscriber.
    ///     </para>
    ///     <para>
    ///         Subscriptions are added via the <see cref="Subscribe(Item)"/> method. If the specified ConnectorItem does not exist
    ///         in the Dictionary at the time of the method call, the method must add an entry to the Dictionary with value 1. If
    ///         the specified ConnectorItem exists in the Dictionary, the value must be incremented by 1. The Subscribe() method
    ///         must return an <see cref="Result"/> containing the result of the operation as well as any informational, warning or
    ///         error messages that were generated.
    ///     </para>
    ///     <para>
    ///         Subscription are removed via the <see cref="UnSubscribe(Item)"/> method. Assuming the specified ConnectorItem
    ///         exists in the Dictionary at the time of the method call, the value for the entry must be decremented by 1. If,
    ///         after the decrement, the value is zero or less, the item must be removed from the Dictionary completely. The
    ///         UnSubscribe() method must return an Result containing the result of the operation as well as any informational,
    ///         warning or error messages that were generated.
    ///     </para>
    /// </remarks>
    public interface ISubscribable
    {
        /// <summary>
        ///     The <see cref="Dictionary{TKey, TValue}"/> keyed on subscribed Item and containing a <see cref="List{T}"/> of the
        ///     <see cref="Action{T}"/> delegates used to update the subscribers.
        /// </summary>
        Dictionary<Item, List<Action<object>>> Subscriptions { get; }

        /// <summary>
        ///     Creates a subscription to the specified Item.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         Upon the addition of the initial subscriber, an entry is added to the <see cref="Subscriptions"/> Dictionary
        ///         keyed with the specified Item with a new <see cref="List{T}"/> of type <see cref="Action{T}"/> containing one
        ///         entry corresponding to the specified callback delegate.
        ///     </para>
        ///     <para>
        ///         Successive additions add each of the specified callback delegates to the <see cref="Subscriptions"/> dictionary.
        ///     </para>
        /// </remarks>
        /// <param name="item">The <see cref="Item"/> to which the subscription should be added.</param>
        /// <param name="callback">The callback delegate to be invoked upon change of the subscribed Item.</param>
        /// <returns>A value indicating whether the operation succeeded.</returns>
        bool Subscribe(Item item, Action<object> callback);

        /// <summary>
        ///     Removes a subscription from the specified ConnectorItem.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         Upon the removal of a subscriber the specified callback delegate is removed from the corresponding Dictionary
        ///         entry for the specified <see cref="Item"/>.
        ///     </para>
        ///     Upon removal of the final subscriber, the Dictionary key corresponding to the specified <see cref="Item"/> is
        ///     completely removed.
        /// </remarks>
        /// <param name="item">The <see cref="Item"/> for which the subscription should be removed.</param>
        /// <param name="callback">The callback delegate to be invoked upon change of the subscribed Item.</param>
        /// <returns>A value indicating whether the operation succeeded.</returns>
        bool UnSubscribe(Item item, Action<object> callback);
    }
}