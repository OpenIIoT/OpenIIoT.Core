using Newtonsoft.Json;
using NLog;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace Symbiote.Core.Web.API
{
    public class AppController : ApiController
    {
        private static ProgramManager manager = ProgramManager.Instance();
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private static List<string> serializationProperties = new List<string>(new string[] { "FQN", "Version", "AppType" });
         
        [Route("api/app")]
        [HttpGet]
        public HttpResponseMessage ListApps()
        {
            return Request.CreateResponse(HttpStatusCode.OK, manager.AppManager.AppArchives , JsonFormatter(serializationProperties, ContractResolverType.OptIn));
        }

        [Route("api/app/{fqn}/install")]
        [HttpGet]
        public HttpResponseMessage InstallApp(string fqn)
        {
            ActionResult result = manager.AppManager.InstallApp(fqn);

            return Request.CreateResponse(HttpStatusCode.OK, result, JsonFormatter(new List<string>(new string[] { "Result" }), ContractResolverType.OptIn));
        }

        private static JsonMediaTypeFormatter JsonFormatter(List<string> serializationProperties, ContractResolverType contractResolverType)
        {
            JsonMediaTypeFormatter retVal = new JsonMediaTypeFormatter();

            retVal.SerializerSettings = new JsonSerializerSettings();

            retVal.SerializerSettings.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
            retVal.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
            retVal.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            retVal.SerializerSettings.Formatting = Formatting.Indented;
            retVal.SerializerSettings.ContractResolver = new ContractResolver(serializationProperties, contractResolverType);
            retVal.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());

            return retVal;
        }
    }
}