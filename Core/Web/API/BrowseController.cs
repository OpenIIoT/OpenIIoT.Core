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

        private static List<string> conciseSerializationProperties = new List<string>(new string[] { "FQN", "Children" });
        private static List<string> verboseSerializationProperties = new List<string>(new string[] { "Parent", "SourceItem", "Guid", "Value" });

        public HttpResponseMessage Get(string verbosity = "verbose")
        {
            return Get(model.FQN, verbosity);
        }

        public HttpResponseMessage Get(string fqn, string verbosity = "verbose")
        {
            List<Item> result = new List<Item>();
            result.Add(AddressResolver.Resolve(fqn));

            JsonMediaTypeFormatter formatter;

            if (verbosity == "concise") formatter = JsonFormatter(conciseSerializationProperties, ContractResolverType.OptIn);
            else formatter = JsonFormatter();

            logger.Info("API request; FQN:" + fqn + "; Verbosity: " + verbosity + ". Remote IP: " + Request.GetOwinContext().Request.RemoteIpAddress + "; returning HTTP 200/OK");
            return Request.CreateResponse(HttpStatusCode.OK, result, formatter);
        }

        private static JsonMediaTypeFormatter JsonFormatter()
        {
            return JsonFormatter(verboseSerializationProperties, ContractResolverType.OptOut);
        }

        private static JsonMediaTypeFormatter JsonFormatter(List<string> serializationProperties, ContractResolverType contractResolverType)
        {
            return new JsonMediaTypeFormatter()
            {
                SerializerSettings = new JsonSerializerSettings()
                {
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat,
                    DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                    NullValueHandling = NullValueHandling.Ignore,
                    Formatting = Formatting.Indented,
                    ContractResolver = new ContractResolver(serializationProperties, contractResolverType)
                }
            };
        }
    }
}