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

[assembly: OwinStartup(typeof(Symbiote.Core.Web.Startup))]

namespace Symbiote.Core.Web
{
    public class Startup
    {
        private ProgramManager manager = ProgramManager.Instance();

        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR();

            string webRoot = manager.ConfigurationManager.Configuration.Web.Root;

            HttpConfiguration config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: webRoot + (webRoot.Length > 0 ? "/" : "") + "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());
            config.Formatters.JsonFormatter.SerializerSettings =
            new JsonSerializerSettings { ContractResolver = new DefaultContractResolver() };

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
