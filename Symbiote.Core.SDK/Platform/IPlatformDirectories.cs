using System.Collections.Generic;
using Utility.OperationResult;

namespace Symbiote.Core.SDK.Platform
{
    /// <summary>
    /// The ProgramDirectories class encapsulates the filesystem directories needed to run the application.
    /// </summary>
    public interface IPlatformDirectories
    {
        #region Properties

        /// <summary>
        /// The root directory; the directory from which the main executable is running.
        /// </summary>
        string Root { get; }

        /// <summary>
        /// The data directory
        /// </summary>
        string Data { get; }

        /// <summary>
        /// The archive directory
        /// </summary>
        string Archives { get; }

        /// <summary>
        /// The plugin directory
        /// </summary>
        string Plugins { get; }

        /// <summary>
        /// The temporary directory
        /// </summary>
        string Temp { get; }

        /// <summary>
        /// The persistence directory
        /// </summary>
        string Persistence { get; }

        /// <summary>
        /// The web directory
        /// </summary>
        /// <remarks>Web content is served from this directory; anything placed here will be exposed.</remarks>
        string Web { get; }

        /// <summary>
        /// The log directory
        /// </summary>
        string Logs { get; }

        #endregion

        #region Instance Methods

        /// <summary>
        /// Check each of the directories in the internal directory list and ensures that they exist.  
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        Result CheckDirectories();

        /// <summary>
        /// Returns a dictionary containing all of the program directories keyed by name.
        /// </summary>
        /// <returns>A dictionary containing all of the program directories keyed by name.</returns>
        Dictionary<string, string> ToDictionary();

        #endregion
    }
}
