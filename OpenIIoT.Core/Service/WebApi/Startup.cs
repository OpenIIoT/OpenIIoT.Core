/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄████████
      █     ███    ███
      █     ███    █▀      ██      ▄█████     █████     ██    ██   █     █████▄
      █     ███        ▀███████▄   ██   ██   ██  ██ ▀███████▄ ██   ██   ██   ██
      █   ▀███████████     ██  ▀   ██   ██  ▄██▄▄█▀     ██  ▀ ██   ██   ██   ██
      █            ███     ██    ▀████████ ▀███████     ██    ██   ██ ▀██████▀
      █      ▄█    ███     ██      ██   ██   ██  ██     ██    ██   ██   ██
      █    ▄████████▀     ▄██▀     ██   █▀   ██  ██    ▄██▀   ██████   ▄███▀
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  The Owin startup class.
      █
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀ ▀ ▀▀▀     ▀▀               ▀
      █  The GNU Affero General Public License (GNU AGPL)
      █
      █  Copyright (C) 2016-2017 JP Dillingham (jp@dillingham.ws)
      █
      █  This program is free software: you can redistribute it and/or modify
      █  it under the terms of the GNU Affero General Public License as published by
      █  the Free Software Foundation, either version 3 of the License, or
      █  (at your option) any later version.
      █
      █  This program is distributed in the hope that it will be useful,
      █  but WITHOUT ANY WARRANTY; without even the implied warranty of
      █  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
      █  GNU Affero General Public License for more details.
      █
      █  You should have received a copy of the GNU Affero General Public License
      █  along with this program.  If not, see <http://www.gnu.org/licenses/>.
      █
      ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀  ▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀██
                                                                                                   ██
                                                                                               ▀█▄ ██ ▄█▀
                                                                                                 ▀████▀
                                                                                                   ▀▀                            */

namespace OpenIIoT.Core.Service.WebApi
{
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Reflection;
    using System.Web.Http;
    using Microsoft.AspNet.SignalR;
    using Microsoft.Owin;
    using Microsoft.Owin.Cors;
    using Microsoft.Owin.FileSystems;
    using Microsoft.Owin.StaticFiles;
    using OpenIIoT.Core.Service.WebApi.Middleware;
    using OpenIIoT.Core.Service.WebApi.Swagger;
    using OpenIIoT.SDK;
    using OpenIIoT.SDK.Platform;
    using OpenIIoT.SDK.Service.WebApi;
    using Owin;
    using Swashbuckle.Application;

    /// <summary>
    ///     The <see cref="Owin"/> startup class.
    /// </summary>
    public class Startup
    {
        #region Private Fields

        private IApplicationManager manager = ApplicationManager.GetInstance();

        #endregion Private Fields

        #region Public Methods

        public void Configuration(IAppBuilder app)
        {
            WebApiServiceConfiguration configuration = WebApiService.GetConfiguration();

            string webRoot = configuration.Root.TrimStart('/').TrimEnd('/');

            // openiiot/signalr openiiot/help openiiot/help/docs/ openiiot/help/ui openiiot/help/ui/index openiiot/api/

            string signalRPath = $"/{webRoot}/{WebApiConstants.SignalRRoutePrefix}".Replace("//", "/");
            string helpPath = $"{webRoot}/{WebApiConstants.HelpRoutePrefix}".TrimStart('/');
            string swaggerPath = $"{helpPath}/docs/{{apiVersion}}";
            string swaggerUiPath = $"{helpPath}/ui/{{*assetPath}}";
            string helpShortcut = $"{helpPath}/ui/index";

            app.Use(typeof(LoggingMiddleware), configuration);

            app.UseCors(CorsOptions.AllowAll);

            app.Use(typeof(NotFoundRedirectionMiddleware), configuration);
            app.Use(typeof(AuthenticationMiddleware), configuration);

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
                    c.CustomAsset("index", containingAssembly, "OpenIIoT.Core.Service.WebApi.Swagger.Content.index.html");
                    c.InjectStylesheet(containingAssembly, "OpenIIoT.Core.Service.WebApi.Swagger.Content.style.css");
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
                RequestPath = PathString.FromUriComponent($"/{webRoot}".TrimEnd('/')),
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