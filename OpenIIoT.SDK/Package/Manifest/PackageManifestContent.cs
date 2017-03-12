using Newtonsoft.Json;

namespace OpenIIoT.SDK.Package.Manifest
{
    internal class PackageManifestContent
    {
        [JsonProperty(Order = 2)]
        private PackageManifestContentItem[] Plugins { get; set; }

        [JsonProperty(Order = 1)]
        private PackageManifestContentItem[] Apps { get; set; }
    }
}