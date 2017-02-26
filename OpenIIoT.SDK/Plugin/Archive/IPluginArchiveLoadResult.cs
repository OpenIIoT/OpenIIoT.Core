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
    public interface IPluginArchiveLoadResult : IResult
    {
        /// <summary>
        ///     The list of valid Plugin Archives discovered during the load.
        /// </summary>
        IList<IPluginArchive> ValidArchives { get; set; }

        /// <summary>
        ///     The list of invalid Plugin Archives and the reason they failed validation.
        /// </summary>
        IList<IInvalidPluginArchive> InvalidArchives { get; set; }
    }
}