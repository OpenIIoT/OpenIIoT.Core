using Newtonsoft.Json;
using OpenIIoT.SDK.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenIIoT.Core.Security.WebApi.DTO
{
    public class UserCreateData
    {
        #region Public Properties

        [JsonProperty(Order = 2)]
        public string DisplayName { get; set; }

        [JsonProperty(Order = 3)]
        public string Email { get; set; }

        [JsonProperty(Order = 1)]
        public string Name { get; set; }

        [JsonProperty(Order = 5)]
        public string Password { get; set; }

        [JsonProperty(Order = 4)]
        public Role Role { get; set; }

        #endregion Public Properties
    }
}