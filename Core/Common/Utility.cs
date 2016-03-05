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
    static class Utility
    {
        #region Extensions

        internal static List<T> Clone<T>(this IList<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }

        /// <summary>
        /// Returns a subset of the supplied array.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="data">The array.</param>
        /// <param name="index">The index at which the subarray should start.</param>
        /// <param name="length">The length of the desired subarray; the number of elements to select.</param>
        /// <returns></returns>
        internal static T[] SubArray<T>(this T[] data, int index, int length)
        {
            T[] result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }

        internal static T GetAssemblyAttribute<T>(this System.Reflection.Assembly ass) where T : Attribute
        {
            object[] attributes = ass.GetCustomAttributes(typeof(T), false);
            if (attributes == null || attributes.Length == 0)
                return null;
            return attributes.OfType<T>().SingleOrDefault();
        }

        #endregion

        public static void SetLoggingLevel(string level)
        {
            try
            {
                switch (level.ToLower())
                {
                    case "fatal":
                        DisableLoggingLevel(LogLevel.Error);
                        goto case "error";
                    case "error":
                        DisableLoggingLevel(LogLevel.Warn);
                        goto case "warn";
                    case "warn":
                        DisableLoggingLevel(LogLevel.Info);
                        goto case "info";
                    case "info":
                        DisableLoggingLevel(LogLevel.Debug);
                        goto case "debug";
                    case "debug":
                        DisableLoggingLevel(LogLevel.Trace);
                        goto case "trace";
                    case "trace":
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Exception thrown while setting log level: " + ex, ex);
            }

        }

        public static void DisableLoggingLevel(LogLevel level)
        {
            foreach (var rule in LogManager.Configuration.LoggingRules)
                rule.DisableLoggingForLevel(level);

            LogManager.ReconfigExistingLoggers();
        }

        internal static void PrintModel(Logger logger, Item root, int indent)
        {
            string source = (root.SourceItem == null ? "" : root.SourceItem.FQN);
            logger.Info(new string('\t', indent) + root.FQN + " [" + source + "] children: " + root.Children.Count());

            foreach (Item i in root.Children)
            {
                PrintModel(logger, i, indent + 1);
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

        internal static void PrintLogo(Logger logger)
        {
            logger.Info(@"");
            logger.Info(@"+--------------- -- - ---- --------------- - -        -  --    -   -----------  - - -- ------ ------+");
            logger.Info(@"|''' '  '                                                                                           |");
            logger.Info(@"|''    ▄████████ ▄██   ▄     ▄▄▄▄███▄▄▄▄   ▀█████████▄   ▄█   ▄██████▄      ███        ▄████████    |");
            logger.Info(@"|`    ███    ███ ███   ██▄ ▄██▀▀▀███▀▀▀██▄   ███    ███ ███  ███    ███ ▀█████████▄   ███    ███    |");
            logger.Info(@"|     ███    █▀  ███▄▄▄███ ███   ███   ███   ███    ███ ███▌ ███    ███    ▀███▀▀██   ███    █▀     |");
            logger.Info(@"|     ███        ▀▀▀▀▀▀███ ███   ███   ███  ▄███▄▄▄██▀  ███▌ ███    ███     ███   ▀  ▄███▄▄▄        |");
            logger.Info(@"|   ▀███████████ ▄██   ███ ███   ███   ███ ▀▀███▀▀▀██▄  ███▌ ███    ███     ███     ▀▀███▀▀▀        |");
            logger.Info(@"|            ███ ███   ███ ███   ███   ███   ███    ██▄ ███  ███    ███     ███       ███    █▄     |");
            logger.Info(@"|      ▄█    ███ ███   ███ ███   ███   ███   ███    ███ ███  ███    ███     ███       ███    ███    |");
            logger.Info(@"|    ▄████████▀   ▀█████▀   ▀█   ███   █▀  ▄█████████▀  █▀    ▀██████▀     ▄████▀     ██████████   .|");
            logger.Info(@"|                                                                                           . .  ...|");
            logger.Info(@"+-------------- - --------- - -           -  -- - - --------------------- - - ----------------  - --+");
            logger.Info(@"");
        }
    }
}
