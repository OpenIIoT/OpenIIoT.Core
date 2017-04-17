using System;
using System.Collections.Generic;

namespace OpenIIoT.SDK.Package.Manifest
{
    public interface IPackageManifestBuilder
    {
        #region Public Properties

        PackageManifest Manifest { get; }

        #endregion Public Properties

        #region Public Methods

        PackageManifestBuilder AddFile(PackageManifestFileType type, IPackageManifestFile file);

        PackageManifestBuilder BuildDefault();

        PackageManifestBuilder ClearFiles();

        PackageManifestBuilder Copyright(string copyright);

        PackageManifestBuilder Description(string description);

        PackageManifestBuilder Files(IDictionary<PackageManifestFileType, IList<IPackageManifestFile>> files);

        PackageManifestBuilder License(string license);

        PackageManifestBuilder Namespace(string ns);

        PackageManifestBuilder Publisher(string publisher);

        PackageManifestBuilder RemoveFile(PackageManifestFileType type, IPackageManifestFile file);

        PackageManifestBuilder Signature(IPackageManifestSignature signature);

        PackageManifestBuilder Title(string title);

        PackageManifestBuilder Url(string url);

        PackageManifestBuilder Version(string version);

        #endregion Public Methods
    }
}