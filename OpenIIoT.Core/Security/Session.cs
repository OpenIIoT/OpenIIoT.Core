using Microsoft.Owin.Security;
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

        public Session(string apiKey, AuthenticationTicket ticket)
        {
            ApiKey = apiKey;
            Ticket = ticket;
        }

        #endregion Public Constructors

        #region Private Properties

        public string ApiKey { get; }
        public AuthenticationTicket Ticket { get; }

        #endregion Private Properties
    }
}