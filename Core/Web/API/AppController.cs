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
            return Request.CreateResponse(HttpStatusCode.OK, manager.AppManager.Apps , JsonFormatter(appSerializationProperties, ContractResolverType.OptIn, true));
        }

        [Route("api/app/archive")]
        [HttpGet]
        public HttpResponseMessage ListAppArchives()
        {
            return Request.CreateResponse(HttpStatusCode.OK, manager.AppManager.AppArchives, JsonFormatter(appArchiveSerializationProperties, ContractResolverType.OptIn, true));
        }

        [Route("api/app/archive/reload")]
        [HttpGet]
        public HttpResponseMessage ReloadAppArchives()
        {
            manager.AppManager.ReloadAppArchives();
            return ListAppArchives();
        }

        [Route("api/app/archive/{fqn}/install")]
        [HttpGet]
        public async Task<HttpResponseMessage> InstallApp(string fqn)
        {
            RequestInfo requestInfo = new RequestInfo(Request);
            OperationResult<App.App> result;

            logger.Info(requestInfo);

            if (manager.AppManager.InstallInProgress)
                result = new OperationResult<App.App>().AddError("Another install is already in progress.");
            else
                result = await manager.AppManager.InstallAppAsync(fqn);

            logger.Info(requestInfo + " returned " + result.ResultCode);
            return Request.CreateResponse(HttpStatusCode.OK, result, JsonFormatter(new List<string>(new string[] { }), ContractResolverType.OptOut, true));
        }

        [Route("api/app/{fqn}/reinstall")]
        [Route("api/app/archive/{fqn}/reinstall")]
        [HttpGet]
        public async Task<HttpResponseMessage> ReinstallApp(string fqn)
        {
            OperationResult<App.App> result = await manager.AppManager.ReinstallAppAsync(fqn);
            return Request.CreateResponse(HttpStatusCode.OK, result, JsonFormatter(new List<string>(new string[] { }), ContractResolverType.OptOut, true));
        }

        [Route("api/app/{fqn}/uninstall")]
        [HttpGet]
        public async Task<HttpResponseMessage> UninstallApp(string fqn)
        {
            OperationResult result = await manager.AppManager.UninstallAppAsync(fqn);
            return Request.CreateResponse(HttpStatusCode.OK, result, JsonFormatter(new List<string>(new string[] { }), ContractResolverType.OptOut, true));
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