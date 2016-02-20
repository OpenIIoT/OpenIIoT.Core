using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core.Services.Web
{
    public class RequestInfo
    {
        public string ShortGuid { get; private set; }
        public string Route { get; private set; }
        public string RemoteIP { get; private set; }

        public RequestInfo(HttpRequestMessage request)
        {
            ShortGuid = Utility.ShortGuid();
            Route = request.RequestUri.PathAndQuery;
            RemoteIP = request.GetOwinContext().Request.RemoteIpAddress;
        }

        public override string ToString()
        {
            return "API Request [ID: " + ShortGuid + "]; Route: " + Route + "; Remote IP: " + RemoteIP;
        }

        public string ReturnString(HttpStatusCode returnCode)
        {
            return ToString() + " returned " + returnCode;
        }
    }
}
