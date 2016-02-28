using NLog;
using Symbiote.Core.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core
{
    class AddressResolver
    {
        private static ProgramManager manager = ProgramManager.Instance();
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static Item Resolve(string lookupFQN)
        {
            Item retVal = default(Item);

            logger.Trace("Attempting to resolve FQN '" + lookupFQN + "'...");
            string itemOrigin = lookupFQN.Split('.')[0];
            logger.Trace("FQN origin parsed as '" + itemOrigin + "'");

            if (itemOrigin == "")
            {
                logger.Trace("Item origin is null; returning default Item.");
                retVal = default(Item);
            }
            else if (itemOrigin == manager.ProductName)
            {
                logger.Trace("Item origin matches the Product Name; returning a Model lookup of the FQN.");
                retVal = manager.ModelManager.FindItem(lookupFQN);

                if (retVal != default(Item))
                    logger.Trace("Resolved Item: " + retVal.ToJson());
                else
                    logger.Trace("Failed to resolve item.");
            }
            else
            {
                logger.Trace("Item originates in a Plugin, searching for instance...");
                retVal = manager.PluginManager.FindPluginItem(lookupFQN);
            }

            logger.Trace("Resolved Item: " + retVal.ToJson());
            return retVal;
        }
    }
}
