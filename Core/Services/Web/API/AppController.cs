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
    public class AppController : ApiController
    {
        private static ProgramManager manager = ProgramManager.Instance();
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private static List<string> appSerializationProperties = new List<string>(new string[] { "FQN", "URL", "Version", "AppType", "ConfigurationDefinition" });
        private static List<string> appArchiveSerializationProperties = new List<string>(new string[] { "FQN", "FileName", "Version", "AppType", "ConfigurationDefinition" });


        [Route("api/app")]
        [HttpGet]
        public HttpResponseMessage ListApps()
        {
            APIOperationResult<List<App.App>> retVal = new APIOperationResult<List<App.App>>(Request);
            retVal.LogRequest(logger);

            retVal.Result = manager.AppManager.Apps;

            retVal.LogResult(logger);
            return retVal.CreateResponse(JsonFormatter(appSerializationProperties, ContractResolverType.OptIn, true));
        }

        [Route("api/app/{fqn}")]
        [HttpGet]
        public HttpResponseMessage GetApp(string fqn)
        {
            APIOperationResult<App.App> retVal = new APIOperationResult<App.App>(Request);
            retVal.Result = manager.AppManager.FindApp(fqn);

            if (retVal.Result == default(App.App))
                retVal.StatusCode = HttpStatusCode.NotFound;

            return retVal.CreateResponse(JsonFormatter(new List<string>(new string[] { }), ContractResolverType.OptOut, true));
        }

        [Route("api/app/{fqn}/reinstall")]
        [HttpGet]
        public async Task<HttpResponseMessage> ReinstallApp(string fqn)
        {
            APIOperationResult<OperationResult<App.App>> retVal = new APIOperationResult<OperationResult<App.App>>(Request);

            if (manager.AppManager.InstallInProgress)
                retVal.Result = new OperationResult<App.App>().AddError("An installation is already in progress.");
            else
                retVal.Result = await manager.AppManager.ReinstallAppAsync(fqn);

            return retVal.CreateResponse(JsonFormatter(new List<string>(new string[] { }), ContractResolverType.OptOut, true));
        }

        [Route("api/app/{fqn}/uninstall")]
        [HttpGet]
        public async Task<HttpResponseMessage> UninstallApp(string fqn)
        {
            APIOperationResult<OperationResult> retVal = new APIOperationResult<OperationResult>(Request);

            retVal.Result = await manager.AppManager.UninstallAppAsync(fqn);
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