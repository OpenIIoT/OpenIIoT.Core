using Newtonsoft.Json;

namespace OpenIIoT.SDK.Package.Manifest
{
    public interface IPackageManifestFile
    {
        #region Private Properties

        [JsonProperty(Order = 2)]
        string Hash { get; set; }

        [JsonProperty(Order = 1)]
        string Source { get; set; }

        #endregion Private Properties
    }
}