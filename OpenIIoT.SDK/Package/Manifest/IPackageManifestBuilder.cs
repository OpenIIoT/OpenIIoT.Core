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

        PackageManifestBuilder AddFile(IPackageManifestFile file);

        PackageManifestBuilder Copyright(string copyright);

        PackageManifestBuilder Description(string description);

        PackageManifestBuilder Files(List<IPackageManifestFile> files);

        PackageManifestBuilder License(string license);

        PackageManifestBuilder Namespace(string ns);

        PackageManifestBuilder Publisher(string publisher);

        PackageManifestBuilder Signature(IPackageManifestSignature signature);

        PackageManifestBuilder Title(string title);

        PackageManifestBuilder Url(string url);

        PackageManifestBuilder Version(string version);

        PackageManifestBuilder BuildDefault(IList<IPackageManifestFile> files);

        PackageManifestBuilder ClearFiles();

        PackageManifestBuilder RemoveFile(IPackageManifestFile file);

        #endregion Public Methods
    }
}