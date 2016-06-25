using System.Collections.Generic;
using System.Reflection;
using System;
using Newtonsoft.Json;
using Symbiote.Core.OperationResult;

namespace Symbiote.Core.Platform
{
    /// <summary>
    /// The ProgramDirectories class encapsulates the filesystem directories needed to run the application.
    /// </summary>
    public class PlatformDirectories
    {
        #region Properties

        /// <summary>
        /// The root directory; the directory from which the main executable is running.
        /// </summary>
        public string Root { get; private set; }

        /// <summary>
        /// The data directory
        /// </summary>
        public string Data { get; private set; }

        /// <summary>
        /// The archive directory
        /// </summary>
        public string Archives { get; private set; }

        /// <summary>
        /// The plugin directory
        /// </summary>
        public string Plugins { get; private set; }

        /// <summary>
        /// The temporary directory
        /// </summary>
        public string Temp { get; private set; }

        /// <summary>
        /// The persistence directory
        /// </summary>
        public string Persistence { get; private set; }

        /// <summary>
        /// The web directory
        /// </summary>
        /// <remarks>Web content is served from this directory; anything placed here will be exposed.</remarks>
        public string Web { get; private set; }

        /// <summary>
        /// The log directory
        /// </summary>
        public string Logs { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates an instance of ProgramDirectories using the provided dictionary
        /// </summary>
        /// <param name="directories">A dictionary containing the name and directory for each of the program directores.</param>
        public PlatformDirectories(Dictionary<string, string> directories)
        {
            try
            {
                Root = System.IO.Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
                Data = System.IO.Path.Combine(Root, directories["Data"]);
                Archives = System.IO.Path.Combine(Root, directories["Archives"]);
                Plugins = System.IO.Path.Combine(Root, directories["Plugins"]);
                Temp = System.IO.Path.Combine(Root, directories["Temp"]);
                Persistence = System.IO.Path.Combine(Root, directories["Persistence"]);
                Web = System.IO.Path.Combine(Root, directories["Web"]);
                Logs = System.IO.Path.Combine(Root, directories["Logs"]);
            }
            catch (KeyNotFoundException ex)
            {
                // TODO: implement safe mode fallback
                throw new Exception("The directory configuration is missing one or more directories.", ex);
            }

        }

        #endregion

        #region Instance Methods

        /// <summary>
        /// Check each of the directories in the internal directory list and ensures that they exist.  
        /// </summary>
        /// <returns>An Result containing the result of the operation.</returns>
        public Result CheckDirectories()
        {
            Result retVal = new Result();
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
        /// Deserializes the provided string to a dictionary containing the program directory names and paths, then creates
        /// an instance of ProgramDirectories with it.
        /// </summary>
        /// <param name="directories">A serialized dictionary containing the program directories and their paths.</param>
        /// <returns>An Result containing the result of the operation along with a ProgramDirectories instance containing the directories.</returns>
        public static Result<PlatformDirectories> LoadDirectories(string directories)
        {
            Result<PlatformDirectories> retVal = new Result<PlatformDirectories>();

            if (directories == "")
                retVal.AddError("The supplied list of directories is empty.");
            else
            {
                try
                {
                    // hapazardly try to set all of the directories from the deserialized config json.  if anything goes wrong
                    // an exception will be thrown and we'll handle it.
                    retVal.ReturnValue = new PlatformDirectories(JsonConvert.DeserializeObject<Dictionary<string, string>>(directories));
                }
                catch (Exception ex)
                {
                    retVal.AddError("Exception thrown while deserializing the list of directories from the configuration file: " + ex);
                }
            }

            return retVal;
        }

        #endregion
    }
}
