using Newtonsoft.Json;
using OpenIIoT.SDK.Security;

namespace OpenIIoT.Core.Security.WebApi.DTO
{
    public class UserUpdateData
    {
        #region Public Properties

        [JsonProperty(Order = 1)]
        public string DisplayName { get; set; }

        [JsonProperty(Order = 2)]
        public string Email { get; set; }

        [JsonProperty(Order = 4)]
        public string Password { get; set; }

        [JsonProperty(Order = 3)]
        public Role? Role { get; set; }

        #endregion Public Properties
    }
}