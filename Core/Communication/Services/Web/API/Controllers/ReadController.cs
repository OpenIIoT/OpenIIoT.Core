using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace Symbiote.Core.Communication.Services.Web.API
{
    public class ReadController : ApiController, IApiController
    {
        private static ProgramManager manager = ProgramManager.Instance();
        private static Item model = manager.ModelManager.Model;

        [Route("api/read")]
        [HttpGet]
        public HttpResponseMessage Read()
        {
            List<Item> result = model.Children;
            return Request.CreateResponse(HttpStatusCode.OK, result, JsonFormatter(new List<string>(new string[] { "FQN", "Type", "Value", "Children" }), ContractResolverType.OptIn, true));
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
            List<Item> result = new List<Item>();
            Item foundItem = AddressResolver.Resolve(fqn);

            if (fromSource)
                foundItem.ReadFromSource();
            
            result.Add(foundItem);


            return Request.CreateResponse(HttpStatusCode.OK, result, JsonFormatter(new List<string>(new string[] { "FQN", "Type", "Value", "Children" }), ContractResolverType.OptIn, true));
        }

        public JsonMediaTypeFormatter JsonFormatter(List<string> serializationProperties, ContractResolverType contractResolverType, bool includeSecondaryTypes = false)
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