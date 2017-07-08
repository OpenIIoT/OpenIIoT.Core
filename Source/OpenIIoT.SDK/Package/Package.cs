using OpenIIoT.SDK.Packaging.Manifest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenIIoT.SDK.Common;

namespace OpenIIoT.SDK.Package
{
    public class Package : PackageManifest
    {
        #region Public Constructors

        public Package()
        {
        }

        public Package(PackageManifest manifest)
        {
            this.MapFrom(manifest);
        }

        #endregion Public Constructors

        #region Public Properties

        public string FQN => Namespace + "." + Title;

        public bool IsSigned => Signature?.Digest != default(string);

        public bool IsTrusted => Signature?.Trust != default(string);

        #endregion Public Properties
    }
}