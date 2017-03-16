using Newtonsoft.Json;

namespace OpenIIoT.SDK.Package.Manifest
{
    public class PackageManifestSignature
    {
        [JsonProperty(Order = 1)]
        public string Digest { get; set; }

        [JsonProperty(Order = 2)]
        public string PublicKeyUrl { get; set; }

        [JsonProperty(Order = 3)]
        public string Trust { get; set; }
    }
}