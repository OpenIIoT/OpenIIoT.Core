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

        internal static string WildcardToRegex(string pattern = "")
        {
            return "^" + Regex.Escape(pattern)
                              .Replace(@"\*", ".*")
                              .Replace(@"\?", ".")
                       + "$";
        }

        internal static string ShortGuid()
        {
            return Guid.NewGuid().ToString().Split('-')[0];
        }

        internal static string GetSetting(string key)
        {
            return System.Configuration.ConfigurationManager.AppSettings[key];
        }

        internal static void UpdateSetting(string key, string value)
        {
            System.Configuration.Configuration configuration = System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None);
            configuration.AppSettings.Settings[key].Value = value;
            configuration.Save();

            System.Configuration.ConfigurationManager.RefreshSection("appSettings");
        }

        internal static void PrintLogo4(Logger logger)
        {
            logger.Info(@"----------  -------- -     -   - - -------  - - --   -      --");
            logger.Info(@"");
            logger.Info(@"    .▄▄ ·  ▄· ▄▌• ▌ ▄ ·. ▄▄▄▄· ▪        ▄▄▄▄▄▄▄▄ .");
            logger.Info(@"    ▐█ ▀. ▐█▪██▌·██ ▐███▪▐█ ▀█▪██ ▪     •██  ▀▄.▀·");
            logger.Info(@"    ▄▀▀▀█▄▐█▌▐█▪▐█ ▌▐▌▐█·▐█▀▀█▄▐█· ▄█▀▄  ▐█.▪▐▀▀▪▄");
            logger.Info(@"    ▐█▄▪▐█ ▐█▀·.██ ██▌▐█▌██▄▪▐█▐█▌▐█▌.▐▌ ▐█▌·▐█▄▄▌");
            logger.Info(@"     ▀▀▀▀   ▀ • ▀▀  █▪▀▀▀·▀▀▀▀ ▀▀▀ ▀█▄▀▪ ▀▀▀  ▀▀▀ ");
            logger.Info(@"");
            logger.Info(@"---------- ---------------------- -    ---- ------ - --------- ------  ------ -  - -   -");
        }

        internal static void PrintLogo(Logger logger)
        {
            logger.Info(@"");
            logger.Info(@"------------------- ---------------------- - - --------------- -   -----------  - - -  -     -    - -  -     -");
            logger.Info(@"");
            logger.Info(@"   ▄████████ ▄██   ▄     ▄▄▄▄███▄▄▄▄   ▀█████████▄   ▄█   ▄██████▄      ███        ▄████████ ");
            logger.Info(@"  ███    ███ ███   ██▄ ▄██▀▀▀███▀▀▀██▄   ███    ███ ███  ███    ███ ▀█████████▄   ███    ███ ");
            logger.Info(@"  ███    █▀  ███▄▄▄███ ███   ███   ███   ███    ███ ███▌ ███    ███    ▀███▀▀██   ███    █▀  ");
            logger.Info(@"  ███        ▀▀▀▀▀▀███ ███   ███   ███  ▄███▄▄▄██▀  ███▌ ███    ███     ███   ▀  ▄███▄▄▄     ");
            logger.Info(@"▀███████████ ▄██   ███ ███   ███   ███ ▀▀███▀▀▀██▄  ███▌ ███    ███     ███     ▀▀███▀▀▀     ");
            logger.Info(@"         ███ ███   ███ ███   ███   ███   ███    ██▄ ███  ███    ███     ███       ███    █▄  ");
            logger.Info(@"   ▄█    ███ ███   ███ ███   ███   ███   ███    ███ ███  ███    ███     ███       ███    ███ ");
            logger.Info(@" ▄████████▀   ▀█████▀   ▀█   ███   █▀  ▄█████████▀  █▀    ▀██████▀     ▄████▀     ██████████ ");
            logger.Info(@"");
            logger.Info(@"-------------- - --------- - -           -  -- - - --------------------- - - ----------------  - -  --");
            logger.Info(@"");
        }
    }
}
