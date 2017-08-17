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
        #region Private Properties

        public Session(ClaimsPrincipal principal)
        {
        }

        private ClaimsPrincipal Principal { get; }

        #endregion Private Properties
    }
}