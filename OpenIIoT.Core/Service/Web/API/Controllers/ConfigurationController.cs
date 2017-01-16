using Newtonsoft.Json;
using NLog;
using OpenIIoT.Core.Configuration;
using OpenIIoT.SDK;
using OpenIIoT.SDK.Common;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace OpenIIoT.Core.Service.Web.API
{
    public class ConfigurationController : ApiController
    {
        private static IApplicationManager manager = ApplicationManager.GetInstance();
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static Dictionary<string, Dictionary<string, object>> configuration = manager.GetManager<ConfigurationManager>().Configuration;

        private static List<string> serializationProperties = new List<string>(new string[] { });

        [Route("api/configuration")]
        [HttpGet]
        public HttpResponseMessage GetConfiguration()
        {
            return Request.CreateResponse(HttpStatusCode.OK, manager.GetManager<ConfigurationManager>().Configuration, JsonFormatter(serializationProperties, ContractResolverType.OptOut));
        }

        private static JsonMediaTypeFormatter JsonFormatter(List<string> serializationProperties, ContractResolverType contractResolverType)
        {
            JsonMediaTypeFormatter retVal = new JsonMediaTypeFormatter();

            retVal.SerializerSettings = new JsonSerializerSettings();

            retVal.SerializerSettings.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
            retVal.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
            retVal.SerializerSettings.Formatting = Formatting.Indented;
            retVal.SerializerSettings.ContractResolver = new ContractResolver(serializationProperties, contractResolverType);
            retVal.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());

            return retVal;
        }
    }
}