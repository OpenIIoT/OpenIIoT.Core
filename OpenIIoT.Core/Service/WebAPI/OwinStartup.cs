using System.Web.Http;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using OpenIIoT.Core.Platform;
using OpenIIoT.SDK;
using Owin;
using Swashbuckle.Application;
using System;
using Utility.OperationResult;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using NLog.xLogger;
using NLog;
using OpenIIoT.SDK.Common;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Linq;
using System.Net.Http.Headers;

namespace OpenIIoT.Core.Service.WebAPI
{
    public class OwinStartup
    {
        #region Private Fields

        private IApplicationManager manager = ApplicationManager.GetInstance();

        #endregion Private Fields

        #region Private Properties

        public static string Authority { get; private set; }
        private WebAPIServiceConfiguration WebServiceConfiguration { get; set; }

        #endregion Private Properties

        #region Public Methods

        public void Configuration(IAppBuilder app)
        {
            WebServiceConfiguration = WebAPIService.GetConfiguration;
            string webRoot = new ApplicationSettings().WebRoot;
            string slash = webRoot.Length > 0 ? "/" : string.Empty;

            app.UseCors(CorsOptions.AllowAll);

            app.Use(typeof(LogMiddleware));
            app.Use(typeof(AuthMiddleware));

            app.MapSignalR(slash + webRoot + "/signalr", new HubConfiguration());

            HttpConfiguration config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            config
                .EnableSwagger(webRoot + slash + "help/docs/{apiVersion}", c =>
                {
                    c.RootUrl(req => ComputeHostAsSeenByOriginalClient(req));
                    c.SingleApiVersion("v1", manager.ProductName);
                    c.IncludeXmlComments($"{manager.ProductName}.XML");
                    c.DescribeAllEnumsAsStrings();
                    c.OperationFilter<MimeTypeOperationFilter>();
                })
                .EnableSwaggerUi(webRoot + slash + "help/ui/{*assetPath}", c =>
                {
                    c.EnableApiKeySupport("X-ApiKey", "header");
                    c.DisableValidator();
                });

            config
                .Routes.MapHttpRoute(
                    name: "help_ui_shortcut",
                    routeTemplate: webRoot + slash + "help",
                    defaults: null,
                    constraints: null,
                    handler: new RedirectHandler(SwaggerDocsConfig.DefaultRootUrlResolver, webRoot + slash + "help/ui/index"));

            app.UseWebApi(config);

            // use Path.Combine to build the path to the filesystem for cross platform compatibility windows uses web\content,
            // linux uses web/content.
            app.UseFileServer(new FileServerOptions()
            {
                FileSystem = new PhysicalFileSystem(manager.GetManager<PlatformManager>().Platform.Directories.Web),
                RequestPath = PathString.FromUriComponent(slash + webRoot),
            });
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        /// <example>
        ///     <![CDATA[ <rule name="openiiot" stopProcessing="true"> <match url = "openiiot(/.*)" /> <serverVariables> <set
        ///     name="HTTP_X_Forwarded_Host" value="whatnet.us" /> <set name = "HTTP_X_Forwarded_Proto" value="http" />
        ///     </serverVariables> <action type = "Rewrite" url="http://sandbox/{R:0}" /> </rule> ]]>
        /// </example>
        private static string ComputeHostAsSeenByOriginalClient(HttpRequestMessage req)
        {
            string authority = req.RequestUri.Authority;
            string scheme = req.RequestUri.Scheme;

            HttpRequestHeaders headers = req.Headers;

            if (req.Headers.Contains("X-Forwarded-Host"))
            {
                string xForwardedHost = req.Headers.GetValues("X-Forwarded-Host").First();
                string firstForwardedHost = xForwardedHost.Split(',')[0];

                authority = firstForwardedHost;
            }

            if (req.Headers.Contains("X-Forwarded-Proto"))
            {
                var xForwardedProto = req.Headers.GetValues("X-Forwarded-Proto").First();
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