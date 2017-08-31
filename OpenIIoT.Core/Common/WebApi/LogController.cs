using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using Newtonsoft.Json;
using NLog;
using NLog.RealtimeLogger;
using OpenIIoT.SDK;
using OpenIIoT.SDK.Common;
using System.Net;
using OpenIIoT.Core.Service.WebApi;

namespace OpenIIoT.Core.Common.WebApi
{
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