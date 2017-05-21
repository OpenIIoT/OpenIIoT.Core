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

using System;
using System.Collections.Generic;
using OpenIIoT.SDK.Common;
using Utility.BigFont;

namespace OpenIIoT.Core
{
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
        public static void DisableLoggingLevel(NLog.LogLevel level)
        {
            IList<NLog.Config.LoggingRule> rules = NLog.LogManager.Configuration.LoggingRules;

            foreach (var rule in rules)
            {
                rule.DisableLoggingForLevel(level);
            }

            ReconfigLoggers();
        }

        /// <summary>
        ///     Enables the specified logging level within the LogManager.
        /// </summary>
        /// <param name="level">The level to enable.</param>
        public static void EnableLoggingLevel(NLog.LogLevel level)
        {
            IList<NLog.Config.LoggingRule> rules = NLog.LogManager.Configuration.LoggingRules;

            foreach (var rule in rules)
            {
                rule.EnableLoggingForLevel(level);
            }

            ReconfigLoggers();
        }

        /// <summary>
        ///     Retrieves the setting corresponding to the specified setting from the app.exe.config file.
        /// </summary>
        /// <param name="key">The setting to retrieve.</param>
        /// <returns>The string value of the retrieved setting.</returns>
        public static string GetSetting(string key)
        {
            return System.Configuration.ConfigurationManager.AppSettings[key];
        }

        /// <summary>
        ///     Retrieves the setting corresponding to the specified setting from the app.exe.config file. If the setting isn't
        ///     found, returns the provided defaultSetting and logs a warning.
        /// </summary>
        /// <param name="key">The setting to retrieve.</param>
        /// <param name="defaultSetting">The default setting to return if the setting can't be retrieved.</param>
        /// <returns>The string value of the retrieved setting.</returns>
        public static string GetSetting(string key, string defaultSetting)
        {
            string retVal = GetSetting(key);
            if (retVal == default(string))
            {
                NLog.LogManager.GetCurrentClassLogger().Warn("Failed to retrieve the setting '" + key + "'.  Defaulting to '" + defaultSetting + "'.");
                retVal = defaultSetting;
            }

            return retVal;
        }

        /// <summary>
        ///     Installs or uninstalls the application as a Windows Service, depending on the provided action.
        /// </summary>
        /// <param name="action">The action to perform (uninstall or install).</param>
        /// <returns>True if the installation/uninstallation succeeded, false otherwise.</returns>
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
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

        /// <summary>
        ///     Updates the setting corresponding to the specified setting within the app.exe.config file with the specified value.
        /// </summary>
        /// <param name="key">The setting to update.</param>
        /// <param name="value">The value to which the setting should be set.</param>
        /// <exception cref="ArgumentException">Thrown when the specified key can not be found in the configuration.</exception>
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public static void UpdateSetting(string key, string value)
        {
            try
            {
                System.Configuration.Configuration configuration = System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None);
                configuration.AppSettings.Settings[key].Value = value;
                configuration.Save();

                System.Configuration.ConfigurationManager.RefreshSection("appSettings");
            }
            catch (NullReferenceException)
            {
                throw new ArgumentException("The specified key could not be found in the configuration.");
            }
        }

        /// <summary>
        ///     Reconfigures all loggers.
        /// </summary>
        /// <remarks>
        ///     This method is necessary to solve an issue with NLog 4.2x and mono;
        ///     <see cref="NLog.LogManager.ReconfigExistingLoggers"/> intermittently fails with a "collection changed" exception.
        /// </remarks>
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        private static void ReconfigLoggers()
        {
            int retries = 5;

            while (retries > 0)
            {
                try
                {
                    NLog.LogManager.ReconfigExistingLoggers();
                    break;
                }
                catch
                {
                    retries--;
                }
            }

            if (retries == 0)
            {
                throw new Exception("ReconfigLoggers() ultimately failed after 5 retries.");
            }
        }

        #endregion Public Methods
    }
}