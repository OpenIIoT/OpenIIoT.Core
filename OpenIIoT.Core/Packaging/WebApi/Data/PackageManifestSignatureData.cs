namespace OpenIIoT.Core.Packaging.WebApi.Data
{
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using OpenIIoT.SDK.Common;
    using OpenIIoT.SDK.Packaging.Manifest;

    [DataContract]
    public class PackageManifestSignatureData
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="PackageManifestSignatureData"/> class from the specified <paramref name="packageManifestSignature"/>.
        /// </summary>
        /// <param name="packageManifestSignature">
        ///     The <see cref="PackageManifestSignature"/> instance from which to copy values.
        /// </param>
        public PackageManifestSignatureData(PackageManifestSignature packageManifestSignature)
        {
            this.CopyPropertyValuesFrom(packageManifestSignature);
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        ///     Gets or sets the issuer of the PGP keys used to create the <see cref="PackageManifestSignature.Digest"/>.
        /// </summary>
        [JsonProperty(Order = 1)]
        [DataMember(Order = 1)]
        public string Issuer { get; set; }

        /// <summary>
        ///     Gets or sets the Keybase.io username associated with the PGP keys used to create the <see cref="PackageManifestSignature.Digest"/>.
        /// </summary>
        [JsonProperty(Order = 2)]
        [DataMember(Order = 2)]
        public string Subject { get; set; }

        #endregion Public Properties
    }
}