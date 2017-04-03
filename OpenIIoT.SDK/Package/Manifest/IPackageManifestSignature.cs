using Newtonsoft.Json;

namespace OpenIIoT.SDK.Package.Manifest
{
    public interface IPackageManifestSignature
    {
        #region Public Properties

        [JsonProperty(Order = 1)]
        string Digest { get; set; }

        [JsonProperty(Order = 2)]
        string Key { get; set; }

        [JsonProperty(Order = 3)]
        string Trust { get; set; }

        #endregion Public Properties
    }
}