namespace OpenIIoT.Core.Common.WebApi
{
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using NLog;
    using NLog.RealtimeLogger;
    using OpenIIoT.Core.Service.WebApi;
    using OpenIIoT.SDK;

    public class LogController : ApiBaseController
    {
        #region Private Fields

        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static IApplicationManager manager = ApplicationManager.GetInstance();

        #endregion Private Fields

        #region Public Methods

        [Route("api/log")]
        [HttpGet]
        public HttpResponseMessage GetLog()
        {
            var log = RealtimeLogger.LogHistory.ToArray();

            return Request.CreateResponse(HttpStatusCode.OK, log, JsonFormatter());
        }

        #endregion Public Methods
    }
}