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
            logger.Trace("Attempting to resolve FQN '" + lookupFQN + "'...");
            
            string itemOrigin = lookupFQN.Split('.')[0];

            logger.Trace("FQN origin parsed as '" + itemOrigin + "'");

            if (itemOrigin == "")
            {
                logger.Trace("Item origin is null; returning default Item.");
                return default(Item);
            }
            else if (itemOrigin == manager.ProductName)
            {
                logger.Trace("Item origin matches the Product Name; returning a Model lookup of the FQN.");
                Item retVal = manager.ModelManager.FindItem(lookupFQN);
                logger.Trace("Resolved Item: " + retVal.ToJson());
                return retVal;
            }
            else
            {
                logger.Trace("Item originates in a Plugin, searching for instance...");
                IConnector originPlugin = (IConnector)manager.PluginManager.FindPluginInstance(itemOrigin);

                if (originPlugin != default(IConnector))
                {
                    logger.Trace("Origin Plugin is '" + originPlugin.ToString() + "'.  Passing FQN to plugin FindItem() method...");

                    Item retVal = originPlugin.FindItem(lookupFQN);
                    logger.Trace("Resolved Item: " + retVal.ToJson());
                    return retVal;
                }
                else
                {
                    logger.Trace("Origin Plugin not found; returning default Item.");
                }
            }
            return default(Item);
        }
    }
}
