using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Symbiote.Core.Platform;

namespace Symbiote.Core.Platform
{
    /// <summary>
    /// The ProgramDirectories class encapsulates the filesystem directories needed to run the application.
    /// </summary>
    public class PlatformDirectories
    {
        /// <summary>
        /// The root directory; the directory from which the main executable is running.
        /// </summary>
        public string Root { get; private set; }

        /// <summary>
        /// The data directory
        /// </summary>
        public string Data { get; private set; }

        /// <summary>
        /// The app directory
        /// </summary>
        public string Apps { get; private set; }

        /// <summary>
        /// The plugin directory
        /// </summary>
        public string Plugins { get; private set; }

        /// <summary>
        /// The temporary directory
        /// </summary>
        public string Temp { get; private set; }

        /// <summary>
        /// The web directory
        /// </summary>
        /// <remarks>Web content is served from this directory; anything placed here will be exposed.</remarks>
        public string Web { get; private set; }

        /// <summary>
        /// The log directory
        /// </summary>
        public string Logs { get; private set; }


        /// <summary>
        /// Creates an instance of ProgramDirectories using the provided dictionary
        /// </summary>
        /// <param name="directories">A dictionary containing the name and directory for each of the program directores.</param>
        public PlatformDirectories(Dictionary<string, string> directories)
        {
            Root = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            Data = Path.Combine(Root, directories["Data"]);
            Apps = Path.Combine(Root, directories["Apps"]);
            Plugins = Path.Combine(Root, directories["Plugins"]);
            Temp = Path.Combine(Root, directories["Temp"]);
            Web = Path.Combine(Root, directories["Web"]);
            Logs = Path.Combine(Root, directories["Logs"]);
        }

        #region Instance Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public OperationResult CheckDirectories()
        {
            OperationResult retVal = new OperationResult();
            IPlatform platform = ProgramManager.Instance().PlatformManager.Platform;
            Dictionary<string, string> directories = ToDictionary();

            foreach (string directory in directories.Keys)
            {
                if (!platform.DirectoryExists(directories[directory]))
                {
                    platform.CreateDirectory(directories[directory]);
                    retVal.AddWarning("The directory '" + directories[directory] + "' was missing and was recreated.");
                }
            }
            return retVal;
        }

        /// <summary>
        /// Returns a dictionary containing all of the program directories keyed by name.
        /// </summary>
        /// <returns>A dictionary containing all of the program directories keyed by name.</returns>
        public Dictionary<string, string> ToDictionary()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            foreach (PropertyInfo p in this.GetType().GetProperties())
            {
                dictionary.Add(p.Name, (string)p.GetValue(this));
            }
            return dictionary;
        }

        #endregion

        #region Static Methods

        /// <summary>
        /// Removes the supplied root from the supplied subdirectory to return the path to the subdirectory
        /// relative to the root.
        /// </summary>
        /// <param name="root">The root path.</param>
        /// <param name="subDirectory">The subdirectory relative to the root.</param>
        /// <returns>A string containing the subDirectory with the root path removed.</returns>
        public static string GetRelativePath(string root, string subDirectory)
        {
            return subDirectory.Replace(root, "");
        }

        #endregion
    }
}
