using Newtonsoft.Json;

namespace OpenIIoT.SDK.Package.Manifest
{
    internal class ManifestContentItem
    {
        [JsonProperty(Order = 1)]
        private string Name { get; set; }

        [JsonProperty(Order = 2)]
        private string Path { get; set; }
    }
}