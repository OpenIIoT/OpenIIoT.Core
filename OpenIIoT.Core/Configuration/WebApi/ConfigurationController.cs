namespace OpenIIoT.Core.Configuration.WebApi
{
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using NLog;
    using OpenIIoT.Core.Service.WebApi;
    using OpenIIoT.SDK;
    using OpenIIoT.SDK.Common;
    using OpenIIoT.SDK.Configuration;

    public class ConfigurationController : ApiBaseController
    {
        #region Private Fields

        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static IApplicationManager manager = ApplicationManager.GetInstance();
        private static List<string> serializationProperties = new List<string>(new string[] { });

        #endregion Private Fields

        #region Public Methods

        [Route("api/configuration")]
        [HttpGet]
        public HttpResponseMessage GetConfiguration()
        {
            IConfiguration configuration = manager.GetManager<ConfigurationManager>().Configuration;

            return Request.CreateResponse(HttpStatusCode.OK, configuration, JsonFormatter(ContractResolverType.OptOut, serializationProperties));
        }

        #endregion Public Methods
    }
}