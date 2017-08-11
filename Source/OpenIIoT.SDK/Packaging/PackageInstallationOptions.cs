using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using OpenIIoT.SDK.Package;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenIIoT.SDK.Packaging
{
    public class PackageInstallationOptions
    {
        #region Public Properties

        public bool Overwrite { get; set; }

        public string PublicKey { get; set; }
        public bool SkipVerification { get; set; }

        #endregion Public Properties
    }
}