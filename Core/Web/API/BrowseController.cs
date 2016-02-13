using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using NLog;

namespace Symbiote.Core.Web.API
{
    public class BrowseController : ApiController
    {
        private static ProgramManager manager = ProgramManager.Instance();
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static Item model = manager.ModelManager.Model;

        public HttpResponseMessage Get()
        {
            List<Item> result = model.Children;
            logger.Info("API request for " + this + "; returning HTTP 200/OK");
            return Request.CreateResponse(HttpStatusCode.OK, result, JsonFormatter());
        }

        public HttpResponseMessage Get(string fqn)
        {
            List<Item> result = new List<Item>();
            result.Add(AddressResolver.Resolve(fqn));
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
                    ContractResolver = new ContractResolver(new List<string>(new string[] { "Parent", "SourceItem", "Guid", "Value" }), ContractResolverType.OptOut)
                }
            };
        }
    }
}