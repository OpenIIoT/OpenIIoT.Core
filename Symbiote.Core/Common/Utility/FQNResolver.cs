/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄████████ ████████▄   ███▄▄▄▄      ▄████████
      █     ███    ███ ███    ███  ███▀▀▀██▄   ███    ███
      █     ███    █▀  ███    ███  ███   ███  ▄███▄▄▄▄██▀    ▄█████   ▄█████  ██████   █        █    █     ▄█████    █████
      █    ▄███▄▄▄     ███    ███  ███   ███ ▀▀███▀▀▀▀▀     ██   █    ██  ▀  ██    ██ ██       ██    ██   ██   █    ██  ██
      █   ▀▀███▀▀▀     ███    ███  ███   ███ ▀███████████  ▄██▄▄      ██     ██    ██ ██       ██    ██  ▄██▄▄     ▄██▄▄█▀
      █     ███        ███    ███  ███   ███   ███    ███ ▀▀██▀▀    ▀███████ ██    ██ ██       ██    ██ ▀▀██▀▀    ▀███████
      █     ███        ███  ▀ ███  ███   ███   ███    ███   ██   █     ▄  ██ ██    ██ ██▌    ▄  █▄  ▄█    ██   █    ██  ██
      █     ███         ▀██████▀▄█  ▀█   █▀    ███    ███   ███████  ▄████▀   ██████  ████▄▄██   ▀██▀     ███████   ██  ██
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Given an FQN, the AddressResolver locates and returns the corresponding Item.
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

using Symbiote.Core.Plugin;
using Symbiote.SDK;
using Symbiote.SDK.Model;

namespace Symbiote.Core
{
    /// <summary>
    ///     Given an FQN, the AddressResolver locates and returns the corresponding Item.
    /// </summary>
    /// <remarks>
    ///     Examines the first tuple of the provided FQN and if it matches the configured product name (e.g. Symbiote), performs a
    ///     lookup of the item using the ModelManager. If the first tuple is something other than the product name, performs a
    ///     lookup of the item using the PluginManager.
    /// </remarks>
    public class FQNResolver
    {
        #region Private Fields

        /// <summary>
        ///     The ApplicationManager for the application.
        /// </summary>
        private static ApplicationManager manager = ApplicationManager.GetInstance();

        #endregion Private Fields

        #region Public Enums

        /// <summary>
        ///     Indicates the source of the Item.
        /// </summary>
        public enum ItemSource
        {
            /// <summary>
            ///     The default source.
            /// </summary>
            Unknown,

            /// <summary>
            ///     The Item originated from a Connector Plugin.
            /// </summary>
            Plugin,

            /// <summary>
            ///     The Item originated from the application Model.
            /// </summary>
            Model
        }

        #endregion Public Enums

        #region Public Methods

        /// <summary>
        ///     Determines the source of the Item by examining the first tuple of the FQN.
        /// </summary>
        /// <param name="lookupFQN">The Fully Qualified Name of the Item for which the source is to be determined.</param>
        /// <returns>The enumeration representing the source of the Item.</returns>
        public static ItemSource GetSource(string lookupFQN)
        {
            ItemSource retVal = default(ItemSource);

            string itemOrigin = lookupFQN.Split('.')[0];

            if (itemOrigin == string.Empty)
            {
                retVal = ItemSource.Unknown;
            }
            else if (itemOrigin == manager.InstanceName)
            {
                retVal = ItemSource.Model;
            }
            else
            {
                retVal = ItemSource.Plugin;
            }

            System.Console.WriteLine("Item source: " + retVal.ToString());
            return retVal;
        }

        /// <summary>
        ///     Locates the Item corresponding to the supplied FQN and returns it.
        /// </summary>
        /// <param name="lookupFQN">The Fully Qualified Name of the Item to locate.</param>
        /// <returns>The located item.</returns>
        public static Item Resolve(string lookupFQN)
        {
            Item retVal = default(Item);

            ItemSource source = GetSource(lookupFQN);

            // if the origin is null, a malformed FQN was provided. return null.
            if (source == ItemSource.Unknown)
            {
                retVal = default(Item);
            }
            else if (source == ItemSource.Model)
            {
                // if the origin is the product, the FQN belongs to a Model item. use the ModelManager to look it up.
                retVal = manager.GetManager<IModelManager>().FindItem(lookupFQN);
            }
            else
            {
                // if the origin is something other than the product, the FQN belongs to a plugin item. use the PluginManager to
                // look it up.
                retVal = manager.GetManager<IPluginManager>().FindPluginItem(lookupFQN);
            }

            return retVal;
        }

        #endregion Public Methods
    }
}