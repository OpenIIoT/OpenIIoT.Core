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

namespace OpenIIoT.Core.Service.WebAPI
{
    public class OwinStartup
    {
        #region Private Fields

        private IApplicationManager manager = ApplicationManager.GetInstance();

        #endregion Private Fields

        #region Private Properties

        private WebAPIServiceConfiguration WebServiceConfiguration { get; set; }

        #endregion Private Properties

        #region Public Methods

        public void Configuration(IAppBuilder app)
        {
            WebServiceConfiguration = WebAPIService.GetConfiguration;
            string webRoot = WebServiceConfiguration.Root;

            app.UseCors(CorsOptions.AllowAll);

            app.MapSignalR((webRoot.Length > 0 ? "/" : string.Empty) + webRoot + "/signalr", new HubConfiguration());

            HttpConfiguration config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", manager.ProductName);
                    c.IncludeXmlComments($"{manager.ProductName}.XML");
                    c.DescribeAllEnumsAsStrings();
                    c.OperationFilter<MimeTypesOperationFilter>();
                }
                )
                .EnableSwaggerUi();

            // config.Routes.MapHttpRoute(
            // name: "DefaultApi",
            // routeTemplate: webRoot + (webRoot.Length > 0 ? "/" : string.Empty) + "api/{controller}/{id}",
            // defaults: new { id = RouteParameter.Optional } );

            // config.Formatters.Clear(); config.Formatters.Add(new JsonMediaTypeFormatter());
            // config.Formatters.JsonFormatter.SerializerSettings = new JsonSerializerSettings { ContractResolver = new
            // DefaultContractResolver() };
            app.UseWebApi(config);

            // use Path.Combine to build the path to the filesystem for cross platform compatibility windows uses web\content,
            // linux uses web/content.
            app.UseFileServer(new FileServerOptions()
            {
                FileSystem = new PhysicalFileSystem(manager.GetManager<PlatformManager>().Platform.Directories.Web),
                RequestPath = PathString.FromUriComponent((webRoot.Length > 0 ? "/" : string.Empty) + webRoot),
            });
        }

        #endregion Public Methods
    }
}