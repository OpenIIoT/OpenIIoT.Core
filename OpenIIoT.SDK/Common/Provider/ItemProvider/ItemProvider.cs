/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █    ▄█                                     ▄███████▄
      █   ███                                    ███    ███
      █   ███▌     ██       ▄█████    ▄▄██▄▄▄    ███    ███    █████  ██████   █    █   █  ██████▄     ▄█████    █████
      █   ███▌ ▀███████▄   ██   █   ▄█▀▀██▀▀█▄   ███    ███   ██  ██ ██    ██ ██    ██ ██  ██   ▀██   ██   █    ██  ██
      █   ███▌     ██  ▀  ▄██▄▄     ██  ██  ██ ▀█████████▀   ▄██▄▄█▀ ██    ██ ██    ██ ██▌ ██    ██  ▄██▄▄     ▄██▄▄█▀
      █   ███      ██    ▀▀██▀▀     ██  ██  ██   ███        ▀███████ ██    ██ ██    ██ ██  ██    ██ ▀▀██▀▀    ▀███████
      █   ███      ██      ██   █   ██  ██  ██   ███          ██  ██ ██    ██  █▄  ▄█  ██  ██   ▄██   ██   █    ██  ██
      █   █▀      ▄██▀     ███████   █  ██  █   ▄████▀        ██  ██  ██████    ▀██▀   █   ██████▀    ███████   ██  ██
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  The abstract base class from which ItemProviders may derive.
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
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using NLog.xLogger;
using System.Linq;

namespace OpenIIoT.SDK.Common.Provider.ItemProvider
{
    /// <summary>
    ///     The abstract base class from which ItemProviders may derive.
    /// </summary>
    public abstract class ItemProvider : IItemProvider, ISubscribable
    {
        /// <summary>
        ///     The Logger for this class.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Allows GetCurrentClassLogger() in extension classes.")]
        protected xLogger logger = xLogManager.GetCurrentClassxLogger();

        /// <summary>
        ///     Initializes a new instance of the <see cref="ItemProvider"/> class.
        /// </summary>
        /// <param name="providerName">The name of the provider.</param>
        public ItemProvider(string providerName)
        {
            ItemProviderName = providerName;
            logger.Debug("Initializing Item Provider '" + ItemProviderName + "'...");

            Subscriptions = new Dictionary<Item, List<Action<object>>>();
        }

        #region Public Properties

        /// <summary>
        ///     Gets or sets the Item Provider name.
        /// </summary>
        public string ItemProviderName { get; protected set; }

        /// <summary>
        ///     Gets or sets the <see cref="Dictionary{TKey, TValue}"/> keyed on subscribed Item and containing a
        ///     <see cref="List{T}"/> of the <see cref="Action{T}"/> delegates used to update the subscribers.
        /// </summary>
        public Dictionary<Item, List<Action<object>>> Subscriptions { get; protected set; }

        #endregion Public Properties

        #region Protected Properties

        /// <summary>
        ///     Gets or sets the root node of the <see cref="Item"/> tree.
        /// </summary>
        protected Item ItemRoot { get; set; }

        #endregion Protected Properties

        #region Public Methods

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
        public bool Subscribe(Item item, Action<object> callback)
        {
            logger.EnterMethod(xLogger.Params(item, callback));
            logger.Debug("Subscribing to Item '" + item.FQN + "' on Provider '" + ItemProviderName + "'...");

            bool retVal = false;

            if (!Subscriptions.ContainsKey(item))
            {
                logger.Debug("The Item '" + item.FQN + "' has been added to the Subscriptions list.");
                Subscriptions.Add(item, new List<Action<object>>());
            }

            List<Action<object>> callbackList = Subscriptions[item];
            bool containsCallback = callbackList.Contains(callback);

            if (!containsCallback)
            {
                int count = Subscriptions[item].Count;

                Subscriptions[item].Add(callback);

                logger.Debug("Subscriptions to Item '" + item.FQN + "' on Provider '" + ItemProviderName + "' changed from " + count + " to " + Subscriptions[item].Count + ".");

                retVal = true;
            }
            else
            {
                logger.Debug("The specified item '" + item.FQN + "' and callback '" + callback.Target.ToString() + "' has already been subscribed.");
            }

            logger.ExitMethod(retVal);
            return retVal;
        }

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
        public bool UnSubscribe(Item item, Action<object> callback)
        {
            logger.EnterMethod(xLogger.Params(item, callback));
            logger.Debug("UnSubscribing from Item '" + item.FQN + "' on Provider '" + ItemProviderName + "'...");

            bool retVal = false;

            if (Subscriptions.ContainsKey(item))
            {
                int count = Subscriptions[item].Count;

                Subscriptions[item].Remove(callback);

                logger.Debug("Subscriptions to Item '" + item.FQN + "' on Provider '" + ItemProviderName + "' changed from " + count + " to " + Subscriptions[item].Count + ".");

                if (Subscriptions[item].Count == 0)
                {
                    Subscriptions.Remove(item);

                    logger.Debug("Item '" + item.FQN + "' has no further subscribers and has been removed from the Subscriptions list.");
                }

                retVal = true;
            }
            else
            {
                logger.Debug("Subscription for Item '" + item.FQN + "' on Provider '" + ItemProviderName + "' not found.");
            }

            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        ///     Returns the root node of the <see cref="Item"/> tree.
        /// </summary>
        /// <returns>The root node of the Item tree.</returns>
        public virtual Item Browse()
        {
            return ItemRoot;
        }

        /// <summary>
        ///     Returns a list of the children <see cref="Item"/> instances for the specified Item within the Item tree.
        /// </summary>
        /// <param name="root">The Item for which the children are to be returned.</param>
        /// <returns>A List of type Item containing all of the specified Item's children.</returns>
        public virtual IList<Item> Browse(Item root)
        {
            return root == null ? ItemRoot.Children : root.Children;
        }

        /// <summary>
        ///     Asynchronously returns the root node of the <see cref="Item"/> tree.
        /// </summary>
        /// <returns>The root node of the Item tree.</returns>
        public virtual async Task<Item> BrowseAsync()
        {
            return await Task.Run(() => Browse());
        }

        /// <summary>
        ///     Asynchronously returns a list of the children <see cref="Item"/> instances for the specified Item within the Item tree.
        /// </summary>
        /// <param name="root">The Item for which the children are to be returned.</param>
        /// <returns>A List of type Item containing all of the specified Item's children.</returns>
        public virtual async Task<IList<Item>> BrowseAsync(Item root)
        {
            return await Task.Run(() => Browse(root));
        }

        /// <summary>
        ///     Finds and returns the <see cref="Item"/> matching the specified Fully Qualified Name.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Item to return.</param>
        /// <returns>The found Item, or the default(Item) if not found.</returns>
        public virtual Item Find(string fqn)
        {
            return Find(ItemRoot, fqn);
        }

        /// <summary>
        ///     Asynchronously finds and returns the <see cref="Item"/> matching the specified Fully Qualified Name.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Item to return.</param>
        /// <returns>The found Item, or the default(Item) if not found.</returns>
        public virtual async Task<Item> FindAsync(string fqn)
        {
            return await Task.Run(() => Find(fqn));
        }

        /// <summary>
        ///     Reads and returns the current value of the specified <see cref="Item"/>.
        /// </summary>
        /// <param name="item">The Item to read.</param>
        /// <returns>The value of the specified Item.</returns>
        public abstract object Read(Item item);

        /// <summary>
        ///     Asynchronously reads and returns the current value of the specified <see cref="Item"/>
        /// </summary>
        /// <param name="item">The Item to read.</param>
        /// <returns>The value of the specified Item.</returns>
        public abstract Task<object> ReadAsync(Item item);

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        ///     Recursively search the <see cref="Item"/> tree for the Item with a Fully Qualified Name matching the specified
        ///     Fully Qualified Name.
        /// </summary>
        /// <param name="root">The root Item from which to base the search.</param>
        /// <param name="fqn">The Fully Qualified Name of the Item to return.</param>
        /// <returns>The found Item, or the default(Item) if not found.</returns>
        private Item Find(Item root, string fqn)
        {
            // if the specified item's FQN matches the searched FQN, return it.
            if (root.FQN == fqn)
            {
                return root;
            }

            Item found = default(Item);

            // iterate over each child in the list of the root's children, recursively calling the Find() method
            foreach (Item child in root.Children)
            {
                found = Find(child, fqn);

                // if the found item isn't default, it was found within the recursive call, so we don't need to search anymore.
                if (found != default(Item))
                {
                    break;
                }
            }

            return found;
        }

        #endregion Private Methods
    }
}