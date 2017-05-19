/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █    ▄█     ▄▄▄▄███▄▄▄▄                                           ▄▄▄▄███▄▄▄▄
      █   ███   ▄██▀▀▀███▀▀▀██▄                                       ▄██▀▀▀███▀▀▀██▄
      █   ███▌  ███   ███   ███  ██████  ██████▄     ▄█████  █        ███   ███   ███   ▄█████  ██▄▄▄▄    ▄█████     ▄████▄     ▄█████    █████
      █   ███▌  ███   ███   ███ ██    ██ ██   ▀██   ██   █  ██        ███   ███   ███   ██   ██ ██▀▀▀█▄   ██   ██   ██    ▀    ██   █    ██  ██
      █   ███▌  ███   ███   ███ ██    ██ ██    ██  ▄██▄▄    ██        ███   ███   ███   ██   ██ ██   ██   ██   ██  ▄██        ▄██▄▄     ▄██▄▄█▀
      █   ███   ███   ███   ███ ██    ██ ██    ██ ▀▀██▀▀    ██        ███   ███   ███ ▀████████ ██   ██ ▀████████ ▀▀██ ███▄  ▀▀██▀▀    ▀███████
      █   ███   ███   ███   ███ ██    ██ ██   ▄██   ██   █  ██▌    ▄  ███   ███   ███   ██   ██ ██   ██   ██   ██   ██    ██   ██   █    ██  ██
      █   █▀     ▀█   ███   █▀   ██████  ██████▀    ███████ ████▄▄██   ▀█   ███   █▀    ██   █▀  █   █    ██   █▀   ██████▀    ███████   ██  ██
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Defines the interface for the Model Manager.
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

using System.Collections.Generic;
using OpenIIoT.SDK.Common;
using OpenIIoT.SDK.Common.Provider.ItemProvider;
using Utility.OperationResult;

namespace OpenIIoT.SDK.Model
{
    /// <summary>
    ///     Defines the interface for the Model Manager.
    /// </summary>
    public interface IModelManager : IManager
    {
        #region Public Properties

        /// <summary>
        ///     Gets a dictionary containing the Fully Qualified Names and references to all of the Items in the model.
        /// </summary>
        Dictionary<string, Item> Dictionary { get; }

        /// <summary>
        ///     Gets the list of configured Item Providers.
        /// </summary>
        List<IItemProvider> ItemProviders { get; }

        /// <summary>
        ///     Gets the root Item for the model.
        /// </summary>
        Item Model { get; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        ///     Adds an Item to the ModelManager's instance of Model and Dictionary.
        /// </summary>
        /// <param name="item">The Item to add.</param>
        /// <returns>A Result containing the added Item.</returns>
        Result<Item> AddItem(Item item);

        /// <summary>
        ///     Attaches the provided Item to the supplied Item. This method should be used only to attach plugin Items to the
        ///     application model. When adding Items directly, use AddItem.
        /// </summary>
        /// <param name="item">The Item to attach to the Model.</param>
        /// <param name="parentItem">The Item to which the new Item should be attached.</param>
        /// <returns>A Result containing the result of the operation and the attached Item.</returns>
        Result<Item> AttachItem(Item item, Item parentItem);

        /// <summary>
        ///     Creates a copy of the specified Item and stores it at the specified FQN within the default Model and Dictionary.
        /// </summary>
        /// <param name="item">The Item to copy.</param>
        /// <param name="fqn">The Fully Qualified Name of the destination Item.</param>
        /// <returns>A Result containing the result of the operation and the newly created Item.</returns>
        Result<Item> CopyItem(Item item, string fqn);

        /// <summary>
        ///     Removes the specified <see cref="IItemProvider"/> from the list of providers stored in the
        ///     <see cref="ItemProviders"/> property.
        /// </summary>
        /// <param name="provider">The Item Provider to remove.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        Result DeRegisterItemProvider(IItemProvider provider);

        IList<IItemProvider> DiscoverItemProviders();

        /// <summary>
        ///     Returns the ModelItem from the Dictionary belonging to the ModelManager instance matching the supplied key.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the desired ModelItem.</param>
        /// <returns>The ModelItem from the Model corresponding to the supplied key.</returns>
        /// <remarks>Retrieves items from the Dictionary instance belonging to the ModelManager instance.</remarks>
        Item FindItem(string fqn);

        /// <summary>
        ///     Moves the supplied Item from one place in the ModelManager's instances of Model and Dictionary to another based on
        ///     the supplied FQN.
        /// </summary>
        /// <param name="item">The Item to move.</param>
        /// <param name="fqn">The Fully Qualified Name representing the new location for the item.</param>
        /// <returns>A Result containing the moved Item.</returns>
        Result<Item> MoveItem(Item item, string fqn);

        /// <summary>
        ///     Adds the specified <see cref="IItemProvider"/> to the list of providers stored in the <see cref="ItemProviders"/> property.
        /// </summary>
        /// <param name="provider">The Item Provider to add.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        Result RegisterItemProvider(IItemProvider provider);

        /// <summary>
        ///     Removes an Item from the ModelManager's Dictionary and from its parent Item.
        /// </summary>
        /// <param name="item">The Item to remove.</param>
        /// <returns>A Result containing the removed Item.</returns>
        Result<Item> RemoveItem(Item item);

        /// <summary>
        ///     Updates the supplied Item with the supplied Source Item.
        /// </summary>
        /// <param name="item">The Item to update.</param>
        /// <param name="sourceItem">The SourceItem with which to update the Item.</param>
        /// <returns>A Result containing the result of the operation and the updated Item.</returns>
        Result<Item> UpdateItem(Item item, Item sourceItem);

        #endregion Public Methods
    }
}