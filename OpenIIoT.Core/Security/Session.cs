using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OpenIIoT.Core.Security
{
    public class Session
    {
        #region Public Constructors

        public Session(string apiKey, ClaimsPrincipal principal)
        {
            ApiKey = apiKey;
            Principal = principal;
        }

        #endregion Public Constructors

        #region Private Properties

        public string ApiKey { get; }
        public ClaimsPrincipal Principal { get; }

        #endregion Private Properties
    }
}