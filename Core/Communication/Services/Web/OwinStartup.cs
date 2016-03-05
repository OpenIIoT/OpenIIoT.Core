using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.StaticFiles;
using Microsoft.Owin.FileSystems;
using System.IO;
using System.Web.Http;
using System;
using System.Net.Http.Formatting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNet.SignalR;
using Symbiote.Core.Communication.Services.Web.SignalR;
using Symbiote.Core.Communication.Services.Web.API;
using System.Web.Routing;

namespace Symbiote.Core.Communication.Services.Web
{
    public class OwinStartup
    {
        private ProgramManager manager = ProgramManager.Instance();

        private WebServiceConfiguration WebServiceConfiguration { get; set; }

        public void Configuration(IAppBuilder app)
        {
            WebServiceConfiguration = WebService.GetConfiguration;
            string webRoot = WebServiceConfiguration.Root;

            app.UseCors(CorsOptions.AllowAll);

            app.MapSignalR((webRoot.Length > 0 ? "/" : "") + webRoot + "/signalr", new HubConfiguration());
            //app.MapSignalR("/signalr", new HubConfiguration());

            Console.WriteLine((webRoot.Length > 0 ? "/" : "") + webRoot + "/signalr");

            HttpConfiguration config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: webRoot + (webRoot.Length > 0 ? "/" : "") + "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            //config.Formatters.Clear();
            //config.Formatters.Add(new JsonMediaTypeFormatter());
            //config.Formatters.JsonFormatter.SerializerSettings = new JsonSerializerSettings { ContractResolver = new DefaultContractResolver() };

            app.UseWebApi(config);

            // use Path.Combine to build the path to the filesystem for cross platform compatibility
            // windows uses web\content, linux uses web/content. 
            app.UseFileServer(new FileServerOptions()
            {
                FileSystem = new PhysicalFileSystem(Path.Combine("Web")),
                RequestPath = PathString.FromUriComponent((webRoot.Length > 0 ? "/" : "") + webRoot)
            });
        }
    }
}
