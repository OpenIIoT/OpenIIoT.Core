using OpenIIoT.Core.Extensibility.Package;
using OpenIIoT.SDK.Extensibility.Package;
using OpenIIoT.SDK.Plugin.Package;
using System.Collections.Generic;
using Utility.OperationResult;

namespace OpenIIoT.SDK.Plugin.Package
{
    /// <summary>
    ///     The PackageLoadResult extends the Result class and adds a list of type Package and a Dictionary with key and value
    ///     types of string.
    ///
    ///     The ValidPackages Package list contains the list of valid plugin archives discovered during the load.
    ///
    ///     The InvalidPackage dictionary contains the list of archives that did not pass validation, along with the reason
    ///     validation failed.
    /// </summary>
    public class PackageLoadResult : Result, IPackageLoadResult
    {
        /// <summary>
        ///     The list of valid Plugin Packages discovered during the load.
        /// </summary>
        public IList<IPackage> ValidPackages { get; set; }

        /// <summary>
        ///     The list of invalid Plugin Packages and the reason they failed validation.
        /// </summary>
        public IList<IInvalidPackage> InvalidPackages { get; set; }

        /// <summary>
        ///     The default constructor.
        /// </summary>
        public PackageLoadResult() : base()
        {
            ValidPackages = new List<IPackage>();
            InvalidPackages = new List<IInvalidPackage>();
        }
    }
}