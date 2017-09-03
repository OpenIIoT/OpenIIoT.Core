﻿using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using Newtonsoft.Json;
using NLog;
using OpenIIoT.Core.Configuration;
using OpenIIoT.SDK;
using OpenIIoT.SDK.Common;
using OpenIIoT.SDK.Configuration;
using OpenIIoT.Core.Service.WebApi;

namespace OpenIIoT.Core.Configuration.WebApi
{
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