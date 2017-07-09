using System;
using OpenIIoT.SDK.Packaging.Manifest;

namespace OpenIIoT.SDK.Plugin
{
    public interface IPackage : IPackageManifest
    {
        #region Public Properties

        string FileName { get; }

        string FQN { get; }
        bool IsSigned { get; }
        bool IsTrusted { get; }
        DateTime ModifiedOn { get; }

        #endregion Public Properties
    }
}