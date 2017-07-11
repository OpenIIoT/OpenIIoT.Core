using System;
using OpenIIoT.SDK.Common;
using OpenIIoT.SDK.Packaging.Manifest;
using OpenIIoT.SDK.Plugin;

namespace OpenIIoT.Core.Plugin
{
    public class Package : PackageManifest, IPackage
    {
        #region Public Constructors

        public Package(string fileName, DateTime modifiedOn, PackageManifest manifest)
        {
            this.MapFrom(manifest);

            FileName = fileName;
            ModifiedOn = modifiedOn;
        }

        #endregion Public Constructors

        #region Public Properties

        public string FileName { get; }
        public string FQN => Namespace + "." + Title;
        public bool IsSigned => Signature?.Digest != default(string);
        public bool IsTrusted => Signature?.Trust != default(string);
        public DateTime ModifiedOn { get; }

        #endregion Public Properties
    }
}