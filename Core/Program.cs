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
    /// <summary>
    /// Main application class.
    /// </summary>
    class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static PlatformManager platformManager = PlatformManager.Instance();
        private static PluginManager pluginManager = PluginManager.Instance();

        private static IPlatform platform;

        /// <summary>
        /// Main entry point for the application.
        /// </summary>
        /// <remarks>
        /// Responsible for instantiating the platform, loading plugins and determining whether to start
        /// the application as a Windows service or console/interactive application.
        /// </remarks>
        /// <param name="args">Command line arguments.</param>
        static void Main(string[] args)
        {
            logger.Info("Symbiote is initializing...");

            // instantiate the platform
            logger.Info("Intantiating platform...");
            platformManager.InstantiatePlatform();
            logger.Info("Platform: " + platformManager.Platform.PlatformType.ToString() + " (" + platformManager.Platform.Version + ")");

            // load plugins
            logger.Info("Loading plugins...");
            try
            {
                pluginManager.LoadPlugins("Plugins", platformManager.Platform);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            logger.Info("Plugins loaded.");

            // start the application
            if ((platformManager.Platform.PlatformType == PlatformType.Windows) && (!Environment.UserInteractive))
            {
                logger.Info("Starting application in service mode...");
                ServiceBase.Run(new Service());
            }
            else
            {
                logger.Info("Starting application in interactive mode...");
                Start(args);
                Console.ReadKey(true);
                Stop();
            }
        }

        /// <summary>
        /// Entry point for the application logic.
        /// </summary>
        /// <param name="args">Command line arguments, passed from Main().</param>
        public static void Start(string[] args)
        {
            logger.Info("Symbiote started.");


            logger.Info("Creating connector instances...");

            logger.Info("Plugin count: " + pluginManager.Plugins.Count());

            foreach (IPluginAssembly p in pluginManager.Plugins)
            {
                logger.Info("Plugin: " + p.Type);
                IConnector test = pluginManager.CreateConnectorInstance("myinstance", p.Type);
                PrintConnectorPluginItemChildren(test, null, 0);
            }
            logger.Info("Connector instances created.");
        }

        /// <summary>
        /// Exit point for the application logic.
        /// </summary>
        public static void Stop()
        {
            logger.Info("Symbiote stopped.");
        }

        static void PrintConnectorPluginItemChildren(IConnector connector, IConnectorItem root, int indent)
        {
            foreach (IConnectorItem i in connector.Browse(root))
            {
                logger.Info("level: " + indent.ToString() + " Item: " + i.Name + "; FQN: " + i.FQN);
                PrintConnectorPluginItemChildren(connector, i, indent + 1);
            }
        }
    }
}
