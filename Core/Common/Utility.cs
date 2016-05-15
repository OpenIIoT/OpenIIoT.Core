/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀ 
      █
      █   ███    █▄      ███      ▄█   ▄█        ▄█      ███     ▄██   ▄    
      █   ███    ███ ▀█████████▄ ███  ███       ███  ▀█████████▄ ███   ██▄  
      █   ███    ███    ▀███▀▀██ ███▌ ███       ███▌    ▀███▀▀██ ███▄▄▄███  
      █   ███    ███     ███   ▀ ███▌ ███       ███▌     ███   ▀ ▀▀▀▀▀▀███  
      █   ███    ███     ███     ███▌ ███       ███▌     ███     ▄██   ███  
      █   ███    ███     ███     ███  ███       ███      ███     ███   ███  
      █   ███    ███     ███     ███  ███▌    ▄ ███      ███     ███   ███  
      █   ████████▀     ▄████▀   █▀   █████▄▄██ █▀      ▄████▀    ▀█████▀   
      █
 ▄ ▄▄ █ ▄▄▄▄▄▄▄▄▄  ▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄ 
 █ ██ █ █████████  ████ ██████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █ 
      █ 
      █  Contains miscellaneous static methods.
      █ 
      ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀  ▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀██ 
                                                                                                   ██   
                                                                                               ▀█▄ ██ ▄█▀                       
                                                                                                 ▀████▀   
                                                                                                   ▀▀                            */
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Symbiote.Core
{
    /// <summary>
    /// Contains miscellaneous static methods.
    /// </summary>
    static class Utility
    {
        #region Extensions

        /// <summary>
        /// Returns a clone of the supplied list.
        /// </summary>
        /// <typeparam name="T">The list type to clone.</typeparam>
        /// <param name="listToClone">The list from which the clone should be created.</param>
        /// <returns>A clone of the supplied list.</returns>
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
        /// <returns>A subset of the supplied array.</returns>
        internal static T[] SubArray<T>(this T[] data, int index, int length)
        {
            T[] result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }
        
        /// <summary>
        /// Returns the last N elements of the supplied IEnumerable.
        /// </summary>
        /// <typeparam name="T">The type of the IEnumerable.</typeparam>
        /// <param name="source">The IEnumerable.</param>
        /// <param name="N">The number of elements to take from the end of the collection.</param>
        /// <returns>An IEnumerable containing the last N elements of the supplied IEnumerable.</returns>
        public static IEnumerable<T> TakeLast<T>(this IEnumerable<T> source, int N)
        {
            return source.Skip(Math.Max(0, source.Count() - N));
        }
        

        /// <summary>
        /// Returns the specified assembly attribute of the specified assembly.
        /// </summary>
        /// <typeparam name="T">The assembly attribute to return.</typeparam>
        /// <param name="ass">The assembly from which to retrieve the attribute.</param>
        /// <returns>The retrieved attribute.</returns>
        internal static T GetAssemblyAttribute<T>(this System.Reflection.Assembly ass) where T : Attribute
        {
            object[] attributes = ass.GetCustomAttributes(typeof(T), false);
            if (attributes == null || attributes.Length == 0)
                return null;
            return attributes.OfType<T>().SingleOrDefault();
        }

        #endregion

        /// <summary>
        /// Sets the logging level of the LogManager to the specified level, disabling all lower logging levels.
        /// </summary>
        /// <param name="level">The desired logging level.</param>
        public static void SetLoggingLevel(string level)
        {
            try
            {
                // i'm pretty sure this is the first legitimate use case i've seen for a select case with fallthrough.
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

        /// <summary>
        /// Disables the specified logging level witin the LogManager.
        /// </summary>
        /// <param name="level">The level to disable.</param>
        public static void DisableLoggingLevel(LogLevel level)
        {
            foreach (var rule in LogManager.Configuration.LoggingRules)
                rule.DisableLoggingForLevel(level);

            LogManager.ReconfigExistingLoggers();
        }

        /// <summary>
        /// Recursively prints the application Model to the specified logger.
        /// </summary>
        /// <param name="logger">The logger to which the Model should be printed.</param>
        /// <param name="root">The root Item from which the print should begin.</param>
        /// <param name="indent">The current level of indent to apply.</param>
        internal static void PrintModel(Logger logger, Item root, int indent)
        {
            string source = (root.SourceItem == null ? "" : root.SourceItem.FQN);
            logger.Info(new string('\t', indent) + root.FQN + " [" + source + "] children: " + root.Children.Count());

            foreach (Item i in root.Children)
            {
                PrintModel(logger, i, indent + 1);
            }
        }

        /// <summary>
        /// Converts the specified wildcard pattern to a regular expression.
        /// </summary>
        /// <param name="pattern">The wildcard pattern to convert.</param>
        /// <returns>The regular expression resulting from the conversion.</returns>
        internal static string WildcardToRegex(string pattern = "")
        {
            return "^" + System.Text.RegularExpressions.Regex.Escape(pattern)
                              .Replace(@"\*", ".*")
                              .Replace(@"\?", ".")
                       + "$";
        }

        /// <summary>
        /// Returns a truncated GUID.
        /// </summary>
        /// <returns>A truncated GUID.</returns>
        internal static string ShortGuid()
        {
            return Guid.NewGuid().ToString().Split('-')[0];
        }

        /// <summary>
        /// Retrieves the setting corresponding to the specified setting from the app.exe.config file.
        /// </summary>
        /// <param name="key">The setting to retrieve.</param>
        /// <returns>The string value of the retrieved setting.</returns>
        internal static string GetSetting(string key)
        {
            return System.Configuration.ConfigurationManager.AppSettings[key];
        }

        /// <summary>
        /// Retrieves the setting corresponding to the specified setting from the app.exe.config file.
        /// If the setting isn't found, returns the provided defaultSetting and logs a warning.
        /// </summary>
        /// <param name="key">The setting to retrieve.</param>
        /// <param name="defaultSetting">The default setting to return if the setting can't be retrieved.</param>
        /// <returns>The string value of the retrieved setting.</returns>
        internal static string GetSetting(string key, string defaultSetting)
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
        /// Updates the setting corresponding to the specified setting within the app.exe.config file with the specified value.
        /// </summary>
        /// <param name="key">The setting to update.</param>
        /// <param name="value">The value to which the setting should be set.</param>
        internal static void UpdateSetting(string key, string value)
        {
            System.Configuration.Configuration configuration = System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None);
            configuration.AppSettings.Settings[key].Value = value;
            configuration.Save();

            System.Configuration.ConfigurationManager.RefreshSection("appSettings");
        }

        /// <summary>
        /// Prints the logo for the application.
        /// </summary>
        /// <param name="logger">The logger to which the logo should be logged.</param>
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

        /// <summary>
        /// Installs or uninstalls the application as a Windows Service, depending on the provided action.
        /// </summary>
        /// <returns>True if the installation/uninstallation succeeded, false otherwise.</returns>
        public static bool ModifyService(string action)
        {
            try
            {
                if (action == "uninstall")
                    System.Configuration.Install.ManagedInstallerClass.InstallHelper(new string[] { "/u", System.Reflection.Assembly.GetExecutingAssembly().Location });
                else
                    System.Configuration.Install.ManagedInstallerClass.InstallHelper(new string[] { System.Reflection.Assembly.GetExecutingAssembly().Location });
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Computes a cryptographic hash of the provided text using the provided salt.
        /// </summary>
        /// <param name="text">The text to hash.</param>
        /// <param name="salt">The salt with which to seed the hash function.</param>
        /// <returns>The computed hash.</returns>
        public static string ComputeHash(string text, string salt = "")
        {
            byte[] binText = System.Text.Encoding.ASCII.GetBytes(text);
            byte[] binSalt = System.Text.Encoding.ASCII.GetBytes(salt);
            byte[] binSaltedText;

            if (binSalt.Length > 0)
            {
                binSaltedText = new byte[binText.Length + binSalt.Length];

                for (int i = 0; i < binText.Length; i++)
                    binSaltedText[i] = binText[i];

                for (int i = 0; i < binSalt.Length; i++)
                    binSaltedText[binText.Length + i] = binSalt[i];
            }
            else binSaltedText = binText;

            byte[] checksum = System.Security.Cryptography.SHA256.Create().ComputeHash(binSaltedText);

            System.Text.StringBuilder builtString = new System.Text.StringBuilder();
            foreach (byte b in checksum)
            {
                builtString.Append(b.ToString("x2"));
            }
            return builtString.ToString();
        }
    }
}
