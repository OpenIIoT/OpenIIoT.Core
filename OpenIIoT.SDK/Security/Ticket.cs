using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace OpenIIoT.SDK.Security
{
    public class Ticket
    {
        public Ticket(ClaimsIdentity identity) : this(identity, new TicketProperties())
        {
        }

        public Ticket(ClaimsIdentity identity, TicketProperties properties)
        {
            Identity = identity;
            Properties = properties;
        }

        public ClaimsIdentity Identity { get; }
        public TicketProperties Properties { get; }
    }
}
