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

using System.Collections.Generic;
using System.Threading.Tasks;
using Utility.OperationResult;

namespace Symbiote.SDK
{
    /// <summary>
    ///     The abstract base class from which ItemProviders may derive.
    /// </summary>
    public abstract class ItemProvider : IItemProvider
    {
        #region Public Properties

        /// <summary>
        ///     Gets the Item Provider name.
        /// </summary>
        public string ItemProviderName { get; private set; }

        #endregion Public Properties

        #region Protected Properties

        /// <summary>
        ///     Gets or sets the root node of the <see cref="Item"/> tree.
        /// </summary>
        protected Item ItemRoot { get; set; }

        #endregion Protected Properties

        #region Public Methods

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
        public virtual List<Item> Browse(Item root)
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
        public virtual async Task<List<Item>> BrowseAsync(Item root)
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
        /// <returns>A Result containing the result of the operation and the current value of the Item.</returns>
        public abstract Result<object> Read(Item item);

        /// <summary>
        ///     Asynchronously reads and returns the current value of the specified <see cref="Item"/>
        /// </summary>
        /// <param name="item">The Item to read.</param>
        /// <returns>A Result containing the result of the operation and the current value of the Item.</returns>
        public abstract Task<Result<object>> ReadAsync(Item item);

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