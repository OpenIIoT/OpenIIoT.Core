using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenIIoT.Core.Security.WebApi.DTO
{
    public class SessionStartData
    {
        #region Public Properties

        [JsonProperty(Order = 1)]
        public string Name { get; set; }

        [JsonProperty(Order = 2)]
        public string Password { get; set; }

        #endregion Public Properties
    }
}