/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █   ███    █▄
      █   ███    ███
      █   ███    ███     ██     █   █        █      ██    ▄█   ▄
      █   ███    ███ ▀███████▄ ██  ██       ██  ▀███████▄ ██   █▄
      █   ███    ███     ██  ▀ ██▌ ██       ██▌     ██  ▀ ▀▀▀▀▀██
      █   ███    ███     ██    ██  ██       ██      ██    ▄█   ██
      █   ███    ███     ██    ██  ██▌    ▄ ██      ██    ██   ██
      █   ████████▀     ▄██▀   █   ████▄▄██ █      ▄██▀    █████
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Contains miscellaneous static methods.
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

    using Utility.BigFont;
namespace OpenIIoT.Core
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using OpenIIoT.SDK.Common;

    /// <summary>
    ///     Contains miscellaneous static methods.
    /// </summary>
    public static class Utility
    {
        #region Public Methods

        /// <summary>
        ///     Disables the specified logging level within the LogManager.
        /// </summary>
        /// <param name="level">The level to disable.</param>
        [ExcludeFromCodeCoverage]
        public static void DisableLoggingLevel(NLog.LogLevel level)
        {
            IList<NLog.Config.LoggingRule> rules = NLog.LogManager.Configuration.LoggingRules;

            foreach (var rule in rules)
            {
                rule.DisableLoggingForLevel(level);
            }

            NLog.LogManager.ReconfigExistingLoggers();
        }

        /// <summary>
        ///     Enables the specified logging level within the LogManager.
        /// </summary>
        /// <param name="level">The level to enable.</param>
        [ExcludeFromCodeCoverage]
        public static void EnableLoggingLevel(NLog.LogLevel level)
        {
            IList<NLog.Config.LoggingRule> rules = NLog.LogManager.Configuration.LoggingRules;

            foreach (var rule in rules)
            {
                rule.EnableLoggingForLevel(level);
            }

            NLog.LogManager.ReconfigExistingLoggers();
        }

        /// <summary>
        ///     Installs or uninstalls the application as a Windows Service, depending on the provided action.
        /// </summary>
        /// <param name="action">The action to perform (uninstall or install).</param>
        /// <returns>True if the installation/uninstallation succeeded, false otherwise.</returns>
        [ExcludeFromCodeCoverage]
        public static bool ModifyService(string action)
        {
            try
            {
                if (action == "uninstall")
                {
                    System.Configuration.Install.ManagedInstallerClass.InstallHelper(new string[] { "/u", System.Reflection.Assembly.GetExecutingAssembly().Location });
                }
                else
                {
                    System.Configuration.Install.ManagedInstallerClass.InstallHelper(new string[] { System.Reflection.Assembly.GetExecutingAssembly().Location });
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>
        ///     Prints the logo for the application.
        /// </summary>
        /// <param name="logger">The logger to which the logo should be logged.</param>
        public static void PrintLogo(NLog.Logger logger)
        {
            logger.Info(string.Empty);
            logger.Info(@"      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀ ");
            logger.Info(@"      █   ");

            foreach (string s in BigFontGenerator.GenerateCaseSensitive("OpenIIoT", Font.Graffiti, FontSize.Large))
            {
                logger.Info(@"      █  " + s);
            }

            logger.Info(@"      █");
            logger.Info(@" ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄ ");
            logger.Info(@" █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █ ");
            logger.Info(@"      ▄  ");
        }

        /// <summary>
        ///     Prints the logo footer for the application.
        /// </summary>
        /// <param name="logger">The logger to which the logo should be logged.</param>
        public static void PrintLogoFooter(NLog.Logger logger)
        {
            logger.Info(@"      █  ");
            logger.Info(@"      ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀  ▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀██ ");
            logger.Info(@"                                                                                                   ██ ");
            logger.Info(@"                                                                                               ▀█▄ ██ ▄█▀ ");
            logger.Info(@"                                                                                                 ▀████▀   ");
            logger.Info(@"                                                                                                   ▀▀ ");
            logger.Info(string.Empty);
        }

        /// <summary>
        ///     Recursively prints the application Model to the specified logger.
        /// </summary>
        /// <param name="logger">The logger to which the Model should be printed.</param>
        /// <param name="root">The root Item from which the print should begin.</param>
        /// <param name="indent">The current level of indent to apply.</param>
        /// <param name="levels">The list of indentation levels.</param>
        /// <param name="last">True if the specified element is the last in the current chain.</param>
        public static void PrintModel(NLog.Logger logger, Item root, int indent, System.Collections.Generic.List<bool> levels = null, bool last = false)
        {
            // if indent is zero we are starting with the root. initialize the list and add the first level.
            if (indent == 0)
            {
                levels = new System.Collections.Generic.List<bool>();
            }

            // if indent is greater than the count of items in levels, the tree is deeper than it has been before. add a new level
            // to the list and initialize it to true.
            if (indent >= levels.Count)
            {
                levels.Add(true);
            }

            // set the value of the current level according to whether this element is the last in the current chain
            levels[indent] = !last;

            // build the prefix
            string prefix = string.Empty;
            for (int l = 0; l < indent; l++)
            {
                prefix += levels[l] ? " │  " : "    ";
            }

            logger.Info(@"      █" + prefix + (last ? (indent == 0 ? "  ■ " : " └─╴") : " ├─╴") + root.FQN + " (" + root.SourceFQN + ")");

            // print each of the children of this Item
            for (int i = 0; i < root.Children.Count; i++)
            {
                Item item = root.Children[i];
                PrintModel(logger, item, indent + 1, levels, i == root.Children.Count - 1);
            }
        }

        /// <summary>
        ///     Sets the logging level of the LogManager to the specified level, disabling all lower logging levels.
        /// </summary>
        /// <param name="level">The desired logging level.</param>
        /// <exception cref="Exception">Thrown when the specified string is not a valid logging level.</exception>
        [ExcludeFromCodeCoverage]
        public static void SetLoggingLevel(string level)
        {
            try
            {
                // i'm pretty sure this is the first legitimate use case i've seen for a select case with fallthrough.
                switch (level.ToLower())
                {
                    case "fatal":
                        DisableLoggingLevel(NLog.LogLevel.Error);
                        goto case "error";
                    case "error":
                        DisableLoggingLevel(NLog.LogLevel.Warn);
                        goto case "warn";
                    case "warn":
                        DisableLoggingLevel(NLog.LogLevel.Info);
                        goto case "info";
                    case "info":
                        DisableLoggingLevel(NLog.LogLevel.Debug);
                        goto case "debug";
                    case "debug":
                        DisableLoggingLevel(NLog.LogLevel.Trace);
                        goto case "trace";
                    case "trace":
                        break;

                    default:
                        throw new ArgumentException();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Exception thrown while setting log level: " + ex, ex);
            }
        }

        #endregion Public Methods
    }
}