namespace OpenIIoT.Core.Packaging.WebApi.Data
{
    using System;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using OpenIIoT.SDK.Common;
    using OpenIIoT.SDK.Packaging;

    [DataContract]
    public class PackageArchiveSummaryData
    {
        #region Public Constructors

        public PackageArchiveSummaryData(IPackageArchive packageArchive)
        {
            this.CopyPropertyValuesFrom(packageArchive);

            Manifest = new PackageManifestData(packageArchive.Manifest);
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        ///     Gets the time at which the archive was created, in Utc.
        /// </summary>
        [JsonProperty(Order = 5)]
        [DataMember(Order = 5)]
        public DateTime CreatedOn { get; set; }

        /// <summary>
        ///     Gets the fully qualified filename of the archive file.
        /// </summary>
        [JsonProperty(Order = 2)]
        [DataMember(Order = 2)]
        public string FileName { get; set; }

        /// <summary>
        ///     Gets the Fully Qualified Name of the Package.
        /// </summary>
        [JsonProperty(Order = 1)]
        [DataMember(Order = 1)]
        public string FQN { get; set; }

        /// <summary>
        ///     Gets a value indicating whether the archive signature contains a trust.
        /// </summary>
        [JsonProperty(Order = 3)]
        [DataMember(Order = 3)]
        public bool HasTrust { get; set; }

        /// <summary>
        ///     Gets a value indicating whether the archive is signed.
        /// </summary>
        [JsonProperty(Order = 4)]
        [DataMember(Order = 4)]
        public bool IsSigned { get; set; }

        /// <summary>
        ///     Gets the <see cref="IPackageManifest"/> for the Package.
        /// </summary>
        [JsonProperty(Order = 7)]
        [DataMember(Order = 7)]
        public PackageManifestData Manifest { get; set; }

        /// <summary>
        ///     Gets the time at which the archive was last modified, in Utc.
        /// </summary>
        [JsonProperty(Order = 6)]
        [DataMember(Order = 6)]
        public DateTime ModifiedOn { get; set; }

        #endregion Public Properties
    }
}