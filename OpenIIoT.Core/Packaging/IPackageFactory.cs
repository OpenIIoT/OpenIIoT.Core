namespace OpenIIoT.Core.Packaging
{
    using OpenIIoT.SDK.Common.OperationResult;
    using OpenIIoT.SDK.Packaging;

    public interface IPackageFactory
    {
        #region Public Methods

        IResult<IPackage> GetPackage(string directoryName);

        IResult<IPackageArchive> GetPackageArchive(string fileName);

        #endregion Public Methods
    }
}