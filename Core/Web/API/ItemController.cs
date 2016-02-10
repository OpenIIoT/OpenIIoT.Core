using System.Collections.Generic;
using System.Web.Http;

namespace Symbiote.Core.Web.API
{
    public class ItemController : ApiController
    {
        private ProgramManager manager = ProgramManager.Instance();

        public struct APIItem
        {
            public string fqn;
            public object value;
        }

        // GET api/values 
        public IEnumerable<APIItem> Get()
        {
            List<APIItem> retVal = new List<APIItem>();

            foreach (Item child in manager.ModelManager.Model.Children)
            {
                retVal.Add(new APIItem() { fqn = child.FQN, value = child.Read() });
            }
            return retVal;
        }

        // GET api/values/5 
        public APIItem Get(string fqn)
        {
            Item foundItem = AddressResolver.Resolve(fqn);

            return new APIItem() { fqn = foundItem.FQN, value = foundItem.Read() };
        }

        public APIItem Get(string fqn, bool fromSource)
        {
            Item foundItem = AddressResolver.Resolve(fqn);

            return new APIItem() { fqn = foundItem.FQN, value = foundItem.ReadFromSource() };
        }

        // POST api/values 
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5 
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5 
        public void Delete(int id)
        {
        }
    }
}