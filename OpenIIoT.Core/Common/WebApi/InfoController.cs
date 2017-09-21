using System.Net;
using System.Net.Http;
using System.Web.Http;
using OpenIIoT.Core.Service.WebApi;
using OpenIIoT.SDK;
using OpenIIoT.SDK.Common;
using Swashbuckle.Swagger.Annotations;

namespace OpenIIoT.Core.Common.WebApi
{
    /// <summary>
    ///     WebApi controller for common application information.
    /// </summary>
    [WebApiRoutePrefix("v1/info")]
    public class InfoController : ApiBaseController
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="InfoController"/> class.
        /// </summary>
        public InfoController()
            : base(ApplicationManager.GetInstance())
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="InfoController"/> class with the specified
        ///     <see cref="IApplicationManager"/> instance.
        /// </summary>
        /// <param name="manager">The IApplicationManager instance used to resolve dependencies.</param>
        public InfoController(IApplicationManager manager)
            : base(manager)
        {
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///     Gets application information.
        /// </summary>
        /// <returns>An HTTP response message.</returns>
        [HttpGet]
        [Route("state")]
        [Authorize]
        [SwaggerResponse(HttpStatusCode.OK, "The state was retrieved successfully.", typeof(State))]
        [SwaggerResponse(HttpStatusCode.Unauthorized, "Authorization denied.", typeof(string))]
        public HttpResponseMessage GetState()
        {
            return Request.CreateResponse(HttpStatusCode.OK, Manager.State, JsonFormatter());
        }

        /// <summary>
        ///     Gets application information.
        /// </summary>
        /// <returns>An HTTP response message.</returns>
        [HttpGet]
        [Route("")]
        [Authorize]
        [SwaggerResponse(HttpStatusCode.OK, "The info was retrieved successfully.", typeof(StatusData))]
        [SwaggerResponse(HttpStatusCode.Unauthorized, "Authorization denied.", typeof(string))]
        public HttpResponseMessage GetStatus()
        {
            StatusData status = new StatusData()
            {
                InstanceName = Manager.InstanceName,
                ProductName = Manager.ProductName,
                ProductVersion = Manager.ProductVersion.ToString(),
                State = Manager.State,
            };

            return Request.CreateResponse(HttpStatusCode.OK, status, JsonFormatter());
        }

        /// <summary>
        ///     Application status information.
        /// </summary>
        public class StatusData
        {
            #region Private Properties

            /// <summary>
            ///     Gets or sets the application instance name.
            /// </summary>
            public string InstanceName { get; set; }

            /// <summary>
            ///     Gets or sets the application product name.
            /// </summary>
            public string ProductName { get; set; }

            /// <summary>
            ///     Gets or sets the application product version.
            /// </summary>
            public string ProductVersion { get; set; }

            /// <summary>
            ///     Gets or sets the application state.
            /// </summary>
            public State State { get; set; }

            #endregion Private Properties
        }

        #endregion Public Methods
    }
}