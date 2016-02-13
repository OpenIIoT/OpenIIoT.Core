using NLog;
using Symbiote.Core.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Symbiote.Core
{
    class Utility
    {
        internal static void PrintConnectorPluginItemChildren(Logger logger, IConnector connector)
        {
            logger.Info(connector.Browse().FQN);
            PrintConnectorPluginItemChildren(logger, connector, connector.Browse(), 1);
        }

        internal static void PrintConnectorPluginItemChildren(Logger logger, IConnector connector, Item root, int indent)
        {
            foreach (Item i in connector.Browse(root))
            {
                if (i.HasChildren() == false)
                    logger.Info(new string('\t', indent) + i.FQN + " Value: " + connector.Read(i.FQN).ToString());
                else
                    logger.Info(new string('\t', indent) + i.FQN);
                PrintConnectorPluginItemChildren(logger, connector, i, indent + 1);
            }
        }

        internal static void PrintItemChildren(Logger logger, Item root, int indent)
        {
            string source = (root.SourceItem == null ? "" : root.SourceItem.FQN);
            logger.Info(new string('\t', indent) + root.FQN + " [" + source + "] children: " + root.Children.Count());

            foreach (Item i in root.Children)
            {
                PrintItemChildren(logger, i, indent + 1);
            }
        }

        internal static string WildcardToRegex(string pattern)
        {
            return "^" + Regex.Escape(pattern)
                              .Replace(@"\*", ".*")
                              .Replace(@"\?", ".")
                       + "$";
        }

        internal static void PrintLogo(Logger logger)
        {
            logger.Info("--------------------------------------------------------- - ------- ------------------- - -- --  -  -- - ----- - -  - - ---");
            logger.Info(@"      ___                       ___                                     ___                         ___     ");
            logger.Info(@"     /\__\                     /\  \         _____                     /\  \                       /\__\    ");
            logger.Info(@"    /:/ _/_         ___       |::\  \       /::\  \       ___         /::\  \         ___         /:/ _/_   ");
            logger.Info(@"   /:/ /\  \       /|  |      |:|:\  \     /:/\:\  \     /\__\       /:/\:\  \       /\__\       /:/ /\__\  ");
            logger.Info(@"  /:/ /::\  \     |:|  |    __|:|\:\  \   /:/ /::\__\   /:/__/      /:/  \:\  \     /:/  /      /:/ /:/ _/_ ");
            logger.Info(@" /:/_/:/\:\__\    |:|  |   /::::|_\:\__\ /:/_/:/\:|__| /::\  \     /:/__/ \:\__\   /:/__/      /:/_/:/ /\__\");
            logger.Info(@" \:\/:/ /:/  /  __|:|__|   \:\~~\  \/__/ \:\/:/ /:/  / \/\:\  \__  \:\  \ /:/  /  /::\  \      \:\/:/ /:/  /");
            logger.Info(@"  \::/ /:/  /  /::::\  \    \:\  \        \::/_/:/  /   ~~\:\/\__\  \:\  /:/  /  /:/\:\  \      \::/_/:/  / ");
            logger.Info(@"   \/_/:/  /   ~~~~\:\  \    \:\  \        \:\/:/  /       \::/  /   \:\/:/  /   \/__\:\  \      \:\/:/  /  ");
            logger.Info(@"     /:/  /         \:\__\    \:\__\        \::/  /        /:/  /     \::/  /         \:\__\      \::/  /   ");
            logger.Info(@"     \/__/           \/__/     \/__/         \/__/         \/__/       \/__/           \/__/       \/__/    ");
            logger.Info("--------- - -------------------------------------- - -----------------------  - -   -------         -----------  - -   -  - -    - - -");
        }
    }
}
