using System.Collections.Generic;
using Utility.OperationResult;

namespace OpenIIoT.SDK.Plugin.Package
{
    /// <summary>
    ///     The PluginPackageLoadResult extends the Result class and adds a list of type PluginPackage and a Dictionary with key
    ///     and value types of string.
    ///
    ///     The ValidPackages PluginPackage list contains the list of valid plugin archives discovered during the load.
    ///
    ///     The InvalidPackage dictionary contains the list of archives that did not pass validation, along with the reason
    ///     validation failed.
    /// </summary>
    public interface IPluginPackageLoadResult : IResult
    {
        /// <summary>
        ///     The list of valid Plugin Packages discovered during the load.
        /// </summary>
        IList<IPluginPackage> ValidPackages { get; set; }

        /// <summary>
        ///     The list of invalid Plugin Packages and the reason they failed validation.
        /// </summary>
        IList<IInvalidPluginPackage> InvalidPackages { get; set; }
    }
}