using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using OpenIIoT.SDK.Package;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenIIoT.Core.Package.WebAPI
{
    public class InstallationOptions
    {
        #region Public Properties

        [EnumDataType(typeof(PackageInstallOptions))]
        [JsonConverter(typeof(StringEnumConverter))]
        public PackageInstallOptions Options { get; set; }

        public string PublicKey { get; set; }

        #endregion Public Properties
    }
}