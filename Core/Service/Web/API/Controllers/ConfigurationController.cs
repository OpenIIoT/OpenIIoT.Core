using Newtonsoft.Json;
using NLog;
using Symbiote.Core.Configuration;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web.Http;

namespace Symbiote.Core.Service.Web.API
{
    public class ConfigurationController : ApiController
    {
        private static ProgramManager manager = ProgramManager.Instance();
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static ApplicationConfiguration configuration = manager.ConfigurationManager.Configuration;

        private static List<string> serializationProperties = new List<string>(new string[] { });
         
        [Route("api/configuration")]
        [HttpGet]
        public HttpResponseMessage GetConfiguration()
        {
            return Request.CreateResponse(HttpStatusCode.OK, manager.ConfigurationManager.Configuration , JsonFormatter(serializationProperties, ContractResolverType.OptOut, true));
        }

        [Route("api/configuration/{section}")]
        [HttpGet]
        public HttpResponseMessage GetConfiguration(string section)
        {
            section = section.ToLower();
            object retVal = default(object);

            switch (section)
            {
                case "apps":
                    retVal = configuration.Apps;
                    break;
            }

            return Request.CreateResponse(HttpStatusCode.OK, retVal, JsonFormatter(serializationProperties, ContractResolverType.OptOut, true));
        }

        private static JsonMediaTypeFormatter JsonFormatter(List<string> serializationProperties, ContractResolverType contractResolverType, bool includeSecondaryTypes = false)
        {
            JsonMediaTypeFormatter retVal = new JsonMediaTypeFormatter();

            retVal.SerializerSettings = new JsonSerializerSettings();

            retVal.SerializerSettings.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
            retVal.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
            retVal.SerializerSettings.Formatting = Formatting.Indented;
            retVal.SerializerSettings.ContractResolver = new ContractResolver(serializationProperties, contractResolverType, includeSecondaryTypes);
            retVal.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());

            return retVal;
        }
    }
}