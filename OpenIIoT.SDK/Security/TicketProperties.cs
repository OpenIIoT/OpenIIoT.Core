using System;
using System.Collections.Generic;
using System.Text;

namespace OpenIIoT.SDK.Security
{
    public class TicketProperties
    {
        public DateTimeOffset? IssuedUtc { get; set; }
        public DateTimeOffset? ExpiresUtc { get; set; }
    }
}
