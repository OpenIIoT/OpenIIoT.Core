using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using Newtonsoft.Json;
using NLog;
using OpenIIoT.Core.Model;
using OpenIIoT.SDK;
using OpenIIoT.SDK.Common;
using OpenIIoT.SDK.Model;

namespace OpenIIoT.Core.Service.Web.API
{
    public class BrowseController : ApiController
    {
        #region Private Fields

        private static List<string> conciseSerializationProperties = new List<string>(new string[] { "FQN", "Children" });
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static IApplicationManager manager = ApplicationManager.GetInstance();
        private static Item model = manager.GetManager<ModelManager>().Model;
        private static List<string> verboseSerializationProperties = new List<string>(new string[] { "Parent", "SourceItem", "Lock", "HasChildren", "IsOrphaned" });

        #endregion Private Fields

        #region Public Methods

        [Route("api/browse")]
        [HttpGet]
        public HttpResponseMessage Browse()
        {
            return Browse("verbose");
        }

        [Route("api/browse/{verbosity}")]
        [HttpGet]
        public HttpResponseMessage Browse(string verbosity)
        {
            return Browse(model.FQN, verbosity);
        }

        [Route("api/browse/{fqn}/{verbosity}")]
        [HttpGet]
        public HttpResponseMessage Browse(string fqn, string verbosity = "verbose")
        {
            List<Item> result = new List<Item>();
            result.Add(manager.GetManager<IModelManager>().FindItem(fqn));

            JsonMediaTypeFormatter formatter;

            if (verbosity == "concise")
            {
                formatter = JsonFormatter(conciseSerializationProperties, ContractResolverType.OptIn);
            }
            else
            {
                formatter = JsonFormatter();
            }

            logger.Info("API request; FQN:" + fqn + "; Verbosity: " + verbosity + ". Remote IP: " + Request.GetOwinContext().Request.RemoteIpAddress + "; returning HTTP 200/OK");
            return Request.CreateResponse(HttpStatusCode.OK, result, formatter);
        }

        #endregion Public Methods

        #region Private Methods

        private static JsonMediaTypeFormatter JsonFormatter()
        {
            return JsonFormatter(verboseSerializationProperties, ContractResolverType.OptOut);
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

        #endregion Private Methods
    }
}