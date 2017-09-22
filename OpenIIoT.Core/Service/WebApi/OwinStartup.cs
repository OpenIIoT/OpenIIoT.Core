using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using OpenIIoT.Core.Platform;
using OpenIIoT.SDK;
using OpenIIoT.SDK.Service.WebApi;
using Owin;
using Swashbuckle.Application;
using OpenIIoT.SDK.Platform;
using OpenIIoT.Core.Service.WebApi.Middleware;
using System.Reflection;

namespace OpenIIoT.Core.Service.WebApi
{
    public class OwinStartup
    {
        #region Private Fields

        private IApplicationManager manager = ApplicationManager.GetInstance();

        #endregion Private Fields

        #region Private Properties

        private WebApiServiceConfiguration WebServiceConfiguration { get; set; }

        #endregion Private Properties

        #region Public Methods

        public void Configuration(IAppBuilder app)
        {
            string webRoot = WebApiService.StaticConfiguration.Root.TrimStart('/').TrimEnd('/');

            // openiiot/signalr openiiot/help openiiot/help/docs/ openiiot/help/ui openiiot/help/ui/index openiiot/api/

            string signalRPath = $"/{webRoot}/{WebApiConstants.SignalRRoutePrefix}";
            string helpPath = $"{webRoot}/{WebApiConstants.HelpRoutePrefix}";
            string swaggerPath = $"{helpPath}/docs/{{apiVersion}}";
            string swaggerUiPath = $"{helpPath}/ui/{{*assetPath}}";
            string helpShortcut = $"{helpPath}/ui/index";

            app.Use(typeof(LoggingMiddleware));
            app.Use(typeof(NotFoundRedirectionMiddleware));

            app.UseCors(CorsOptions.AllowAll);
            app.Use(typeof(AuthenticationMiddleware));

            app.MapSignalR(signalRPath, new HubConfiguration());

            HttpConfiguration config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            config
                .EnableSwagger(swaggerPath, c =>
                {
                    c.RootUrl(req => ComputeHostAsSeenByOriginalClient(req));
                    c.SingleApiVersion("v1", manager.ProductName);
                    c.IncludeXmlComments($"{manager.ProductName}.XML");
                    c.DescribeAllEnumsAsStrings();
                    c.OperationFilter<MimeTypeOperationFilter>();
                })
                .EnableSwaggerUi(swaggerUiPath, c =>
                {
                    Assembly containingAssembly = Assembly.GetExecutingAssembly();
                    c.CustomAsset("index", containingAssembly, "OpenIIoT.Core.Service.WebApi.Swagger.index.html");
                    c.InjectStylesheet(containingAssembly, "OpenIIoT.Core.Service.WebApi.Swagger.style.css");
                    c.InjectJavaScript(containingAssembly, "OpenIIoT.Core.Service.WebApi.Swagger.index.js");
                    c.EnableApiKeySupport(WebApiConstants.ApiKeyHeaderName, "header");
                    c.DisableValidator();
                });

            config
                .Routes.MapHttpRoute(
                    name: "HelpShortcut",
                    routeTemplate: helpPath,
                    defaults: null,
                    constraints: null,
                    handler: new RedirectHandler(SwaggerDocsConfig.DefaultRootUrlResolver, helpShortcut));

            app.UseWebApi(config);

            // use Path.Combine to build the path to the filesystem for cross platform compatibility windows uses web\content,
            // linux uses web/content.
            app.UseFileServer(new FileServerOptions()
            {
                FileSystem = new PhysicalFileSystem(manager.GetManager<IPlatformManager>().Directories.Web),
                RequestPath = PathString.FromUriComponent($"/{webRoot}"),
            });
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        ///     Computes the hostname and protocol as seen by the original client for the specified <paramref name="request"/>.
        /// </summary>
        /// <param name="request">The request for which the hostname and protocol is to be computed.</param>
        /// <returns>The computed hostname and protocol.</returns>
        /// <example>
        ///     <![CDATA[ <rule name="openiiot" stopProcessing="true"> <match url = "openiiot(/.*)" /> <serverVariables> <set
        ///     name="HTTP_X_Forwarded_Host" value="whatnet.us" /> <set name = "HTTP_X_Forwarded_Proto" value="http" />
        ///     </serverVariables> <action type = "Rewrite" url="http://sandbox/{R:0}" /> </rule> ]]>
        /// </example>
        private static string ComputeHostAsSeenByOriginalClient(HttpRequestMessage request)
        {
            string authority = request.RequestUri.Authority;
            string scheme = request.RequestUri.Scheme;

            HttpRequestHeaders headers = request.Headers;

            if (request.Headers.Contains("X-Forwarded-Host"))
            {
                string xForwardedHost = request.Headers.GetValues("X-Forwarded-Host").First();
                string firstForwardedHost = xForwardedHost.Split(',')[0];

                authority = firstForwardedHost;
            }

            if (request.Headers.Contains("X-Forwarded-Proto"))
            {
                var xForwardedProto = request.Headers.GetValues("X-Forwarded-Proto").First();
                if (xForwardedProto.IndexOf(",") != -1)
                {
                    xForwardedProto = xForwardedProto.Split(',')[0];
                }

                scheme = xForwardedProto;
            }

            return scheme + "://" + authority;
        }

        #endregion Private Methods
    }
}