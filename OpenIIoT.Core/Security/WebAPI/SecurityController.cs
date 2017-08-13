using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using OpenIIoT.Core.Service.WebAPI;
using OpenIIoT.SDK;

namespace OpenIIoT.Core.Security.WebAPI
{
    /// <summary>
    ///     API methods for application security.
    /// </summary>
    [RoutePrefix("api")]
    public class SecurityController : ApiBaseController
    {
        #region Variables

        /// <summary>
        ///     The ApplicationManager for the application.
        /// </summary>
        private IApplicationManager manager = ApplicationManager.GetInstance();

        #endregion Variables

        #region Instance Methods

        [HttpPost]
        [Route("v1/security/login/{user}/{password}")]
        public async Task<HttpResponseMessage> Login(string user, string password)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        #endregion Instance Methods
    }
}