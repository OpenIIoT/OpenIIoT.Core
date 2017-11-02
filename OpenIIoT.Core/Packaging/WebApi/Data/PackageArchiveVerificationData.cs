namespace OpenIIoT.Core.Packaging.WebApi.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using OpenIIoT.SDK.Common.OperationResult;
    using OpenIIoT.SDK.Packaging;

    [DataContract]
    public class PackageArchiveVerificationData
    {
        #region Public Constructors

        public PackageArchiveVerificationData(IResult<bool> result)
        {
            Verification = PackageVerification.Refuted;

            if (result.ReturnValue)
            {
                Verification = PackageVerification.Verified;
            }

            Messages = result.Messages.Select(m => m.Text).ToList();
        }

        #endregion Public Constructors

        #region Public Properties

        [DataMember(Order = 2)]
        [JsonProperty(Order = 2)]
        public IList<string> Messages { get; set; }

        [DataMember(Order = 1)]
        [JsonProperty(Order = 1)]
        public PackageVerification Verification { get; set; }

        #endregion Public Properties
    }
}