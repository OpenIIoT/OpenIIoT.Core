using OpenIIoT.SDK.Common.Provider;
using System.Collections.Generic;
using System.Web.Http;
using OpenIIoT.SDK.Common.Discovery;
using OpenIIoT.SDK.Common.Provider.APIProvider;
using OpenIIoT.SDK;
using System.Linq;
using System.Reflection;
using OpenIIoT.SDK.Common;

namespace OpenIIoT.Core.Service.Web.API
{
    public class APIController : ApiController
    {
        private static IApplicationManager manager = ApplicationManager.GetInstance();
        private IList<IAPIProvider> providers;

        [Route("api/providers")]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            if (providers == default(IList<IAPIProvider>))
            {
                Discover();
            }

            return providers.Select(p => p.APIProviderName);
        }

        private void Discover()
        {
            providers = Discoverer.Discover<IAPIProvider>(manager);
        }

        private IList<MethodInfo> DiscoverControllers(IAPIProvider provider)
        {
            MethodInfo[] methods = provider.GetType().GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);

            return methods?.Where(m => m.HasCustomAttribute<APIAttribute>()).ToList();
        }

        private IAPIProvider FindAPIProvider(string apiProviderName, bool discover = false)
        {
            IAPIProvider provider = providers?.Where(p => p.APIProviderName == apiProviderName).FirstOrDefault();

            if (provider == default(IAPIProvider) && !discover)
            {
                Discover();
                return FindAPIProvider(apiProviderName, true);
            }

            return provider;
        }

        [Route("api/provider/{provider}")]
        [HttpGet]
        public IList<MethodInfo> Get(string provider)
        {
            IAPIProvider foundProvider = FindAPIProvider(provider);

            if (foundProvider == default(IAPIProvider))
            {
                return new List<MethodInfo>();
            }

            return DiscoverControllers(foundProvider);
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