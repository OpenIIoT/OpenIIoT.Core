using System.Collections.Generic;
using Utility.OperationResult;

namespace OpenIIoT.SDK.Package
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
    public interface IPackageLoadResult : IResult
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the list of invalid Plugin Packages and the reason they failed validation.
        /// </summary>
        IList<IInvalidPackage> InvalidPackages { get; set; }

        /// <summary>
        ///     Gets or sets the list of valid Plugin Packages discovered during the load.
        /// </summary>
        IList<IPackage> ValidPackages { get; set; }

        #endregion Public Properties
    }
}