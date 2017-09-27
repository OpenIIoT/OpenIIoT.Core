using Newtonsoft.Json;
using OpenIIoT.SDK.Common;
using OpenIIoT.SDK.Security;

namespace OpenIIoT.Core.Security.WebApi.DTO
{
    public class UserData
    {
        #region Public Constructors

        public UserData(User user)
        {
            this.CopyPropertyValuesFrom(user);
        }

        #endregion Public Constructors

        #region Public Properties

        [JsonProperty(Order = 2)]
        public string DisplayName { get; set; }

        [JsonProperty(Order = 3)]
        public string Email { get; set; }

        [JsonProperty(Order = 1)]
        public string Name { get; set; }

        [JsonProperty(Order = 4)]
        public Role Role { get; set; }

        #endregion Public Properties
    }
}