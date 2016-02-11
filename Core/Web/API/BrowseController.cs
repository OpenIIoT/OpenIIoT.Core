using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace Symbiote.Core.Web.API
{
    public class BrowseController : ApiController
    {
        public HttpResponseMessage Get()
        {
            var formatter = new JsonMediaTypeFormatter();
            var json = formatter.SerializerSettings;

            json.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.MicrosoftDateFormat;
            json.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;
            json.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            json.Formatting = Newtonsoft.Json.Formatting.Indented;
            json.ContractResolver = new ContractResolver(new string[] { "Parent", "SourceItem", "Guid", "Value" });

            List<Item> result = ProgramManager.Instance().ModelManager.Model.Children;

            return Request.CreateResponse(HttpStatusCode.OK, result, formatter);
        }
    }
}