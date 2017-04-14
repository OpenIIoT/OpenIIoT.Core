using Newtonsoft.Json;

namespace OpenIIoT.SDK.Package.Manifest
{
    public class PackageManifestFile : IPackageManifestFile
    {
        #region Private Properties

        [JsonProperty(Order = 3)]
        public string Hash { get; set; }

        [JsonProperty(Order = 1)]
        public string Source { get; set; }

        [JsonProperty(Order = 2)]
        public PackageManifestFileType Type { get; set; }

        #endregion Private Properties
    }
}