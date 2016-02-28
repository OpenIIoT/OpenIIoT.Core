using NLog;
using Symbiote.Core.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core
{
    /// <summary>
    /// Given an FQN, the AddressResolver locates and returns the corresponding Item.
    /// </summary>
    class AddressResolver
    {
        #region Variables

        /// <summary>
        /// The ProgramManager for the application.
        /// </summary>
        private static ProgramManager manager = ProgramManager.Instance();

        /// <summary>
        /// The logger for this class.
        /// </summary>
        private static Logger logger = LogManager.GetCurrentClassLogger();

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

            string itemOrigin = lookupFQN.Split('.')[0];

            if (itemOrigin == "")
            {
                retVal = default(Item);
            }
            else if (itemOrigin == manager.ProductName)
            {
                retVal = manager.ModelManager.FindItem(lookupFQN);
            }
            else
            {
                retVal = manager.PluginManager.FindPluginItem(lookupFQN);
            }

            if (retVal != default(Item))
                logger.Trace("Resolved Item: " + retVal.ToJson());
            else
                logger.Trace("Failed to resolve item.");

            return retVal;
        }

        #endregion
    }
}
