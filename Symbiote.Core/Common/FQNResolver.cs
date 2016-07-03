using Symbiote.Core.Model;

namespace Symbiote.Core
{
    /// <summary>
    /// Given an FQN, the AddressResolver locates and returns the corresponding Item.
    /// Examines the first tuple of the provided FQN and if it matches the configured product name (e.g. Symbiote),
    /// performs a lookup of the item using the ModelManager.  If the first tuple is something other than the product name,
    /// performs a lookup of the item using the PluginManager.
    /// </summary>
    class FQNResolver
    {
        #region Enumerations

        /// <summary>
        /// Indicates the source of the Item.
        /// </summary>
        public enum ItemSource
        {
            /// <summary>
            /// The default source.
            /// </summary>
            Unknown,
            /// <summary>
            /// The Item originated from a Connector Plugin.
            /// </summary>
            Plugin,
            /// <summary>
            /// The Item originated from the application Model.
            /// </summary>
            Model
        }

        #endregion

        #region Variables

        /// <summary>
        /// The ProgramManager for the application.
        /// </summary>
        private static ProgramManager manager = ProgramManager.Instance();

        #endregion

        #region Static Methods

        /// <summary>
        /// Locates the Item corresponding to the supplied FQN and returns it.
        /// </summary>
        /// <param name="lookupFQN">The Fully Qualified Name of the Item to locate.</param>
        /// <returns>The located item.</returns>
        public static Item Resolve(string lookupFQN)
        {
            Item retVal = default(Item);

            ItemSource source = GetSource(lookupFQN);

            // if the origin is null, a malformed FQN was provided.  return null.
            if (source == ItemSource.Unknown)
                retVal = default(Item);
            // if the origin is the product, the FQN belongs to a Model item. 
            // use the ModelManager to look it up.
            else if (source == ItemSource.Model)
                retVal = manager.ModelManager.FindItem(lookupFQN);
            // if the origin is something other than the product, the FQN belongs to a plugin item.
            // use the PluginManager to look it up.
            else
                retVal = manager.PluginManager.FindPluginItem(lookupFQN);

            return retVal;
        }

        /// <summary>
        /// Determines the source of the Item by examining the first tuple of the FQN.
        /// </summary>
        /// <param name="lookupFQN">The Fully Qualified Name of the Item for which the source is to be determined.</param>
        /// <returns>The enumeration representing the source of the Item.</returns>
        public static ItemSource GetSource(string lookupFQN)
        {
            ItemSource retVal = default(ItemSource);

            string itemOrigin = lookupFQN.Split('.')[0];

            if (itemOrigin == "")
                retVal = ItemSource.Unknown;
            else if (itemOrigin == manager.InstanceName)
                retVal = ItemSource.Model;
            else
                retVal = ItemSource.Plugin;

            return retVal;
        }

        #endregion
    }
}
