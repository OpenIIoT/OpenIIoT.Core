using OpenIIoT.Core.Service.WebApi;
using System.Collections.Generic;
using System.Web.Http;

namespace OpenIIoT.Core.Service.Web.WebApi
{
    public class ValuesController : ApiBaseController
    {
        #region Public Methods

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        #endregion Public Methods
    }
}