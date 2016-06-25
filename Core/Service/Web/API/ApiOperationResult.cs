using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Runtime.CompilerServices;
using System;
using Symbiote.Core.OperationResult;

namespace Symbiote.Core.Service.Web
{
    /// <summary>
    /// Encapsulates the result of an API operation. 
    /// </summary>
    /// <typeparam name="T">The type of the Result object.</typeparam>
    public class ApiResult<T> : Result<T>
    {
        #region Properties
        /// <summary>
        /// The HttpRequestMessage that originated the API request.
        /// </summary>
        public HttpRequestMessage Request { get; private set; }

        /// <summary>
        /// A shortened Guid for the request.  The lifespan of the request is such that a full length Guid is not necessary.
        /// </summary>
        public string ShortGuid { get; private set; }

        /// <summary>
        /// The route of the original request.
        /// </summary>
        public string Route { get { return Request.RequestUri.PathAndQuery;  } }

        /// <summary>
        /// The remote IP address of the original request.
        /// </summary>
        public string RemoteIP { get { return Request.GetOwinContext().Request.RemoteIpAddress; } }

        /// <summary>
        /// The HttpStatusCode to return to the requestor.
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// The HttpResponseMessage to return to the requestor.
        /// </summary>
        public HttpResponseMessage Response { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructs a new APIResult using the supplied request, a new ShortGuid and with a StatusCode of 200/OK.
        /// </summary>
        /// <param name="request"></param>
        public ApiResult(HttpRequestMessage request) : base()
        {
            Request = request;
            ShortGuid = Utility.ShortGuid();
            StatusCode = HttpStatusCode.OK;
        }

        #endregion

        #region Instance Methods

        /// <summary>
        /// Logs information about the API request to the supplied logger using the supplied log level.
        /// </summary>
        /// <param name="logLevel">The logging level to apply to the message.</param>
        public void LogRequest(Action<string> logLevel)
        {
            base.Log(logLevel, "API Request [ID: " + ShortGuid + "]; Route: " + Route + "; Remote IP: " + RemoteIP);
            foreach (var header in Request.Headers)
                base.Log(logLevel, "\t" + header.Key.ToString() + ": " + Request.Headers.GetValues(header.Key).FirstOrDefault());
        }

        /// <summary>
        /// Logs information about the result of the API request to the supplied logger using the supplied log levels for success, warning and failure messages.
        /// </summary>
        /// <param name="successLogLevel">The logging level to apply to success messages.</param>
        /// <param name="warningLogLevel">The logging level to apply to warning messages.</param>
        /// <param name="failureLogLevel">The logging level to apply to failure messages.</param>
        /// <param name="caller">The name of the method that called this method.</param>
        new public ApiResult<T> LogResult(Action<string> successLogLevel, Action<string> warningLogLevel, Action<string> failureLogLevel, [CallerMemberName]string caller = "")
        {
            if (ResultCode != ResultCode.Failure)
            {
                Log(successLogLevel, "API Request [ID: " + ShortGuid + "]; Route: " + Route + "; Remote IP: " + RemoteIP + "; Response: " + StatusCode);

                // if any warnings were generated, print them to the logger
                if (ResultCode == ResultCode.Warning)
                    LogAllMessages(warningLogLevel, "The following warnings were generated during the operation:");
            }
            // the operation failed
            else
            {
                Log(failureLogLevel, "API Request [ID: " + ShortGuid + "]; Route: " + Route + "; Remote IP: " + RemoteIP + "; Response: " + StatusCode);
                LogAllMessages(failureLogLevel, "The following messages were generated during the operation:");
            }

            return this;
        }

        /// <summary>
        /// Generates an HttpResponseMessage using the StatusCode, Result object and the supplied JsonMediaTypeFormatter.
        /// </summary>
        /// <param name="jsonFormatter">The JsonMediaTypeFormatter instance to use to serialize the response.</param>
        /// <returns>The generated HttpResponseMessage.</returns>
        public HttpResponseMessage CreateResponse(JsonMediaTypeFormatter jsonFormatter)
        {
            Response = Request.CreateResponse(StatusCode, ReturnValue, jsonFormatter);
            return Response;
        }

        #endregion Instance Methods
    }
}
