using Newtonsoft.Json;

namespace OpenIIoT.Core.Package
{
    public class ManifestSignature
    {
        [JsonProperty(Order = 1)]
        public string Digest { get; set; }

        [JsonProperty(Order = 2)]
        public string KeyUrl { get; set; }
    }
}