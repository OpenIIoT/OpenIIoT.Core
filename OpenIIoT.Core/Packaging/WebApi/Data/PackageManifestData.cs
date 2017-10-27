namespace OpenIIoT.Core.Packaging.WebApi.Data
{
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using OpenIIoT.SDK.Common;
    using OpenIIoT.SDK.Packaging.Manifest;

    [DataContract]
    public class PackageManifestData
    {
        #region Public Constructors

        public PackageManifestData(IPackageManifest packageManifest)
        {
            this.CopyPropertyValuesFrom(packageManifest);

            Signature = new PackageManifestSignatureData(packageManifest.Signature);
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        ///     Gets or sets the Package copyright.
        /// </summary>
        [JsonProperty(Order = 6)]
        [DataMember(Order = 6)]
        public string Copyright { get; set; }

        /// <summary>
        ///     Gets or sets the Package description.
        /// </summary>
        [JsonProperty(Order = 4)]
        [DataMember(Order = 4)]
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets the Package license.
        /// </summary>
        [JsonProperty(Order = 7)]
        [DataMember(Order = 7)]
        public string License { get; set; }

        /// <summary>
        ///     Gets or sets the Package namespace.
        /// </summary>
        [JsonProperty(Order = 3)]
        [DataMember(Order = 3)]
        public string Namespace { get; set; }

        /// <summary>
        ///     Gets or sets the Package publisher.
        /// </summary>
        [JsonProperty(Order = 5)]
        [DataMember(Order = 5)]
        public string Publisher { get; set; }

        /// <summary>
        ///     Gets or sets the Package <see cref="PackageManifestSignatureData"/>.
        /// </summary>
        [JsonProperty(Order = 9)]
        [DataMember(Order = 9)]
        public PackageManifestSignatureData Signature { get; set; }

        /// <summary>
        ///     Gets or sets the Package title.
        /// </summary>
        [JsonProperty(Order = 1)]
        [DataMember(Order = 1)]
        public string Title { get; set; }

        /// <summary>
        ///     Gets or sets the Package url.
        /// </summary>
        [JsonProperty(Order = 8)]
        [DataMember(Order = 8)]
        public string Url { get; set; }

        /// <summary>
        ///     Gets or sets the Package version.
        /// </summary>
        [JsonProperty(Order = 2)]
        [DataMember(Order = 2)]
        public string Version { get; set; }

        #endregion Public Properties
    }
}