using Newtonsoft.Json;

namespace OpenIIoT.Core.Package
{
    internal class ManifestContent
    {
        [JsonProperty(Order = 2)]
        private ManifestContentItem[] Plugins { get; set; }

        [JsonProperty(Order = 1)]
        private ManifestContentItem[] Apps { get; set; }
    }
}