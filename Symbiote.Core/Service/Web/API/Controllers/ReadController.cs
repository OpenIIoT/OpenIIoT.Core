using Newtonsoft.Json;
using NLog;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using Symbiote.Core.Model;

namespace Symbiote.Core.Service.Web.API
{
    public class ReadController : ApiController, IApiController
    {
        /// <summary>
        /// The Logger for this class.
        /// </summary>
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The ProgramManager for the application.
        /// </summary>
        private static ProgramManager manager = ProgramManager.GetInstance();

        private static Item model = manager.GetManager<ModelManager>().Model;

        [Route("api/read")]
        [HttpGet]
        public HttpResponseMessage Read()
        {
            List<Item> result = model.Children;
            return Request.CreateResponse(HttpStatusCode.OK, result, JsonFormatter(new List<string>(new string[] { "FQN", "Type", "Value", "Children" }), ContractResolver.ContractResolverType.OptIn, true));
        }

        [Route("api/read/{fqn}")]
        [HttpGet]
        public HttpResponseMessage Read(string fqn)
        {
            return Read(fqn, false);
        }

        [Route("api/read/{fqn}/{fromSource}")]
        [HttpGet]
        public HttpResponseMessage Read(string fqn, bool fromSource)
        {
            ApiResult<List<Item>> retVal = new ApiResult<List<Item>>(Request);
            retVal.ReturnValue = new List<Item>();

            retVal.LogRequest(logger.Info);

            fqn = fqn.Replace("%25", "%");

            Item foundItem = FQNResolver.Resolve(fqn);

            if (fromSource)
                foundItem.ReadFromSource();
            
            retVal.ReturnValue.Add(foundItem);

            retVal.LogResult(logger);
            return retVal.CreateResponse(JsonFormatter(new List<string>(new string[] { "FQN", "Type", "Value", "Children" }), ContractResolver.ContractResolverType.OptIn, true));
        }

        public JsonMediaTypeFormatter JsonFormatter(List<string> serializationProperties, ContractResolver.ContractResolverType contractResolverType, bool includeSecondaryTypes = false)
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