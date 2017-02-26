using OpenIIoT.SDK.Plugin.Archive;
using System.Collections.Generic;
using Utility.OperationResult;

namespace OpenIIoT.SDK.Plugin.Archive
{
    /// <summary>
    ///     The PluginArchiveLoadResult extends the Result class and adds a list of type PluginArchive and a Dictionary with key
    ///     and value types of string.
    ///
    ///     The ValidArchives PluginArchive list contains the list of valid plugin archives discovered during the load.
    ///
    ///     The InvalidArchive dictionary contains the list of archives that did not pass validation, along with the reason
    ///     validation failed.
    /// </summary>
    public class PluginArchiveLoadResult : Result, IPluginArchiveLoadResult
    {
        /// <summary>
        ///     The list of valid Plugin Archives discovered during the load.
        /// </summary>
        public IList<IPluginArchive> ValidArchives { get; set; }

        /// <summary>
        ///     The list of invalid Plugin Archives and the reason they failed validation.
        /// </summary>
        public IList<IInvalidPluginArchive> InvalidArchives { get; set; }

        /// <summary>
        ///     The default constructor.
        /// </summary>
        public PluginArchiveLoadResult() : base()
        {
            ValidArchives = new List<IPluginArchive>();
            InvalidArchives = new List<IInvalidPluginArchive>();
        }
    }
}