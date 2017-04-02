using Newtonsoft.Json;

namespace OpenIIoT.SDK.Package.Manifest
{
    public class PackageManifestFile
    {
        [JsonProperty(Order = 1)]
        private string File { get; set; }

        [JsonProperty(Order = 2)]
        private string Hash { get; set; }
    }
}