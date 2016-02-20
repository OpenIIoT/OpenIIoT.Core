using Newtonsoft.Json;
using NLog;
using Symbiote.Core.App;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web.Http;

namespace Symbiote.Core.Services.Web.API
{
    public class LogController : ApiController
    {
        private static ProgramManager manager = ProgramManager.Instance();
        private static Logger logger = LogManager.GetCurrentClassLogger();

        //private static List<string> appArchiveSerializationProperties = new List<string>(new string[] { "FQN", "FileName", "Version", "AppType", "ConfigurationDefinition" });

        [Route("api/log")]
        [HttpGet]
        public HttpResponseMessage GetLog()
        {
            APIRequest<string[]> retVal = new APIRequest<string[]>(Request, logger);

            string newestLog = manager.PlatformManager.Platform.GetLogFile(manager.InternalSettings.LogDirectory);

            retVal.Result = manager.PlatformManager.Platform.ReadAllLinesFromFile(newestLog);
        
            return retVal.CreateResponse(JsonFormatter(new List<string>(new string[] { }), ContractResolverType.OptOut, true));
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