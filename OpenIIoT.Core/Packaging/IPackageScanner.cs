namespace OpenIIoT.Core.Packaging
{
    using System.Collections.Generic;
    using OpenIIoT.SDK.Common.OperationResult;
    using OpenIIoT.SDK.Packaging;

    public interface IPackageScanner
    {
        #region Public Methods

        IResult<IList<IPackageArchive>> ScanPackageArchives();

        IResult<IList<IPackage>> ScanPackages();

        #endregion Public Methods
    }
}