using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace Symbiote.Core.Web.API
{
    public class ReadController : ApiController
    {
        private static ProgramManager manager = ProgramManager.Instance();
        private static Item model = manager.ModelManager.Model;

        public HttpResponseMessage Get()
        {
            List<Item> result = model.Children;
            return Request.CreateResponse(HttpStatusCode.OK, result, JsonFormatter());
        }

        public HttpResponseMessage Get(string fqn)
        {
            return Get(fqn, false);
        }

        public HttpResponseMessage Get(string fqn, bool fromSource)
        {
            List<Item> result = new List<Item>();
            Item foundItem = AddressResolver.Resolve(fqn);

            if (fromSource)
                foundItem.ReadFromSource();
            
            result.Add(foundItem);


            return Request.CreateResponse(HttpStatusCode.OK, result, JsonFormatter());
        }

        private static JsonMediaTypeFormatter JsonFormatter()
        {
            return new JsonMediaTypeFormatter()
            {
                SerializerSettings = new JsonSerializerSettings()
                {
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat,
                    DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                    NullValueHandling = NullValueHandling.Ignore,
                    Formatting = Formatting.Indented,
                    ContractResolver = new ContractResolver(new List<string>(new string[] { "FQN", "Type", "Value", "Children" }), true)
                }
            };
        }
    }
}