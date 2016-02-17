using Newtonsoft.Json;
using NLog;
using Symbiote.Core.App;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web.Http;

namespace Symbiote.Core.Web.API
{
    public class AppArchiveController : ApiController
    {
        private static ProgramManager manager = ProgramManager.Instance();
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private static List<string> appArchiveSerializationProperties = new List<string>(new string[] { "FQN", "FileName", "Version", "AppType", "ConfigurationDefinition" });

        [Route("api/apparchive")]
        [HttpGet]
        public HttpResponseMessage ListAppArchives()
        {
            APIRequest<List<AppArchive>> retVal = new APIRequest<List<AppArchive>>(Request, logger);

            retVal.Result = manager.AppManager.AppArchives;
        
            return retVal.CreateResponse(JsonFormatter(appArchiveSerializationProperties, ContractResolverType.OptIn, true));
        }

        [Route("api/apparchive/reload")]
        [HttpGet]
        public HttpResponseMessage ReloadAppArchives()
        {
            APIRequest<OperationResult<List<AppArchive>>> retVal = new APIRequest<OperationResult<List<AppArchive>>>(Request, logger);

            retVal.Result = manager.AppManager.ReloadAppArchives();

            if (retVal.Result.ResultCode == OperationResultCode.Failure)
                retVal.StatusCode = HttpStatusCode.InternalServerError;

            return retVal.CreateResponse(JsonFormatter(appArchiveSerializationProperties, ContractResolverType.OptIn, true));
        }

        [Route("api/apparchive/{fqn}")]
        [HttpGet]
        public HttpResponseMessage GetAppArchive(string fqn)
        {
            APIRequest<AppArchive> retVal = new APIRequest<AppArchive>(Request, logger);

            retVal.Result = manager.AppManager.FindAppArchive(fqn);

            if (retVal.Result == default(AppArchive))
                retVal.StatusCode = HttpStatusCode.NotFound;

            return retVal.CreateResponse(JsonFormatter(new List<string>(new string[] { }), ContractResolverType.OptOut, true));
        }

        [Route("api/apparchive/{fqn}/install")]
        [HttpGet]
        public async Task<HttpResponseMessage> InstallApp(string fqn)
        {
            APIRequest<OperationResult<App.App>> retVal = new APIRequest<OperationResult<App.App>>(Request, logger);

            if (manager.AppManager.InstallInProgress)
                retVal.Result = new OperationResult<App.App>().AddError("Another install is already in progress.");
            else
                retVal.Result = await manager.AppManager.InstallAppAsync(fqn);

            if (retVal.Result.ResultCode == OperationResultCode.Failure)
                retVal.StatusCode = HttpStatusCode.InternalServerError;

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