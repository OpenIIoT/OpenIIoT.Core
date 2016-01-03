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
using System.Timers;

namespace Symbiote.Core
{
    /// <summary>
    /// Main application class.
    /// </summary>
    class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static ProgramManager manager;
        private static IConnector test;

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

            logger.Trace("Instantiating the program manager...");
            try
            {
                manager = ProgramManager.Instance();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                logger.Error("Symbiote failed to initailize.");
                return;
            }
            logger.Trace("The program manager was instantiated successfully.");
            logger.Info("Platform: " + manager.Platform.PlatformType.ToString() + " (" + manager.Platform.Version + ")");

            // load plugins
            logger.Info("Loading plugins...");
            try
            {
                manager.PluginManager.LoadPlugins("Plugins", manager.Platform);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return;
            }
            logger.Info("Plugins loaded.");

            // start the application
            if ((manager.Platform.PlatformType == PlatformType.Windows) && (!Environment.UserInteractive))
            {
                logger.Info("Starting application in service mode...");
                ServiceBase.Run(new Service());
            }
            else
            {
                logger.Info("Starting application in interactive mode...");
                Start(args);
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

            logger.Info("Creating Platform Connector...");
            PrintConnectorPluginItemChildren(manager.Platform.Connector, null, 0);

            logger.Info("Creating connector instances...");
            logger.Info("Plugin count: " + manager.Plugins.Count());


            foreach (IPluginAssembly p in manager.Plugins)
            {
                logger.Info("Plugin: " + p.Type);
                test = manager.PluginManager.CreatePluginInstance<IConnector>("myinstance", p.Type);
            }

            logger.Info("Connector instances created.");
            Timer atimer = new Timer(15000);
            atimer.Elapsed += print;
            atimer.AutoReset = true;
            atimer.Enabled = true;
            Console.WriteLine("Press ESC to stop");
            Console.ReadLine();


        }
        public static void print(Object source, ElapsedEventArgs e)
        {
            PrintConnectorPluginItemChildren(manager.Platform.Connector, null, 0);
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
                if (i.HasChildren() == false)
                    logger.Info("level: " + indent.ToString() + " Item: " + i.Name + "; FQN: " + i.FQN + " Value: " + connector.Read(i.FQN).ToString());
                else
                    logger.Info("Folder: " + indent.ToString() + " Folder: " + i.Name);
                PrintConnectorPluginItemChildren(connector, i, indent + 1);
            }
        }
    }
}
