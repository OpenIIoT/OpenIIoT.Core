using OpenIIoT.Core.Plugin.Package;
using OpenIIoT.SDK.Plugin.Package;
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
    public class PluginPackageLoadResult : Result, IPluginPackageLoadResult
    {
        /// <summary>
        ///     The list of valid Plugin Packages discovered during the load.
        /// </summary>
        public IList<IPluginPackage> ValidPackages { get; set; }

        /// <summary>
        ///     The list of invalid Plugin Packages and the reason they failed validation.
        /// </summary>
        public IList<IInvalidPluginPackage> InvalidPackages { get; set; }

        /// <summary>
        ///     The default constructor.
        /// </summary>
        public PluginPackageLoadResult() : base()
        {
            ValidPackages = new List<IPluginPackage>();
            InvalidPackages = new List<IInvalidPluginPackage>();
        }
    }
}