using NLog;
using Symbiote.Core.Services.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core.Services.Web
{
    class APIOperationResult
    {
        public HttpRequestMessage Request { get; private set; }
        public string ShortGuid { get; private set; }
        public string Route { get { return Request.RequestUri.PathAndQuery; } }
        public string RemoteIP { get { return Request.GetOwinContext().Request.RemoteIpAddress; } }
        public HttpStatusCode StatusCode { get; set; }
        public HttpResponseMessage Response { get; set; }
        public Logger Logger { get; set; }

        public APIOperationResult(HttpRequestMessage request, Logger logger)
        {
            Request = request;
            Logger = logger;
            ShortGuid = Utility.ShortGuid();
            StatusCode = HttpStatusCode.OK;

            LogRequest(logger);
        }

        private void LogRequest(Logger logger)
        {
            logger.Info("API Request [ID: " + ShortGuid + "]; Route: " + Route + "; Remote IP: " + RemoteIP);
            foreach (var header in Request.Headers)
                logger.Info("\t" + header.Key.ToString() + ": " + Request.Headers.GetValues(header.Key).FirstOrDefault());
        }

        protected void LogResponse(Logger logger)
        {
            logger.Info("API Request [ID: " + ShortGuid + "]; Route: " + Route + "; Remote IP: " + RemoteIP + "; Response: " + StatusCode);
        }

    }

    class APIRequest<T> : APIOperationResult
    {
        public RequestInfo RequestInfo { get; set; }
        public HttpStatusCode ReturnCode { get; set; }
        public T Result { get; set; }

        public APIRequest(HttpRequestMessage request, Logger logger) : base(request, logger)
        {
            Result = default(T);
        }

        public HttpResponseMessage CreateResponse(JsonMediaTypeFormatter jsonFormatter)
        {
            Response = Request.CreateResponse(StatusCode, Result, jsonFormatter);
            LogResponse(Logger);
            return Response;
        }
    }
}
