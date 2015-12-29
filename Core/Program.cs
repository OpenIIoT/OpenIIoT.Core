using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using NLog;
using System.Reflection;
using Symbiote.Core.Platform;
using Symbiote.Core.Plugin;

namespace Symbiote.Core
{
    class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static PlatformManager platformManager = PlatformManager.Instance();
        private static PluginManager pluginManager = PluginManager.Instance();

        private static IPlatform platform;
        private static List<IPlugin> plugins;

        static void Main(string[] args)
        {
            logger.Info("Symbiote is initializing...");

            // instantiate the platform
            logger.Trace("Intantiating platform...");
            platform = platformManager.GetCurrentPlatform();
            logger.Trace("Platform instantiated.");
            logger.Info("Platform: " + platform.Type.ToString() + " (" + platform.Version + ")");

            // load plugins
            logger.Info("Loading plugins...");
            plugins = pluginManager.GetPlugins(platform.GetFileList("Plugins", "*.dll"));

            if ((platform.Type == PlatformManager.PlatformType.Windows) && (!Environment.UserInteractive))
            {
                logger.Info("Platform is Windows and mode is non-interactive; starting in service mode");
                ServiceBase.Run(new Service());
            }
            else
            {
                if (platform.Type == PlatformManager.PlatformType.Windows) Console.SetWindowSize(180, 60);
                logger.Info("Starting in interactive mode");
                Start(args);
                Console.ReadKey(true);
                Stop();
            }
        }

        public static void Start(string[] args)
        {
            logger.Info("Symbiote started.");
            logger.Info("Creating connector instances...");

            logger.Info("Plugin count: " + plugins.Count());

            foreach (IPlugin p in plugins)
            {
                logger.Info("Plugin: " + p.Type);
                IConnector test = (IConnector)Activator.CreateInstance(plugins[0].Type);
                foreach (IConnectorItem i in test.Browse(null))
                {
                    logger.Info("Item: " + i.Name);
                }
            }

            


            logger.Info("Connector instances created.");

            PrintStartupMessage();
        }

        public static void Stop()
        {
            logger.Info("Symbiote stopped.");
        }

        static void PrintStartupMessage()
        {
            logger.Info("Symbiote is starting...");
            logger.Info("Platform: " + platform.Type.ToString() + " (" + platform.Version + ")");
            logger.Info("CPU %: " + platform.Info.CPUTime.ToString());
            logger.Info("RAM: " + platform.Info.MemoryUsage.ToString());

            foreach (Platform.IDiskInfo s in platform.Info.Disks)
            {
                logger.Info("Drive: " + s.Name);
                logger.Info("Path: " + s.Path);
                logger.Info("Type: " + s.Type);
                logger.Info("Total Size: " + s.Capacity.ToString());
                logger.Info("Used Space: " + s.UsedSpace.ToString());
                logger.Info("Free Space: " + s.FreeSpace.ToString());
                logger.Info("% Used: " + (s.PercentUsed * 100).ToString() + "%");
                logger.Info("% Free: " + (s.PercentFree * 100).ToString() + "%");
            }
        }

        static void LoadPlugins(string path, Dictionary<string, Assembly> plugins)
        {

        }
    }

    class Service : ServiceBase
    {
        public Service()
        {
            ServiceName = "Symbiote";
        }

        protected override void OnStart(string[] args)
        {
            Program.Start(args);
        }

        protected override void OnStop()
        {
            Program.Stop();
        }
    }
}
