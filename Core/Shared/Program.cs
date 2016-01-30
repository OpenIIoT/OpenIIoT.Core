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
    /// The Core namespace contains all of the code relating to the core functions of the application.
    /// </summary>
    [System.Runtime.CompilerServices.CompilerGenerated]
    class NamespaceDoc { }

    /// <summary>
    /// Main application class.
    /// </summary>
    class Program
    {
        /// <summary>
        /// The main logger for the application.
        /// </summary>
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The ProgramManager for the application.
        /// </summary>
        private static ProgramManager manager;

        /// <summary>
        /// Main entry point for the application.
        /// </summary>
        /// <remarks>
        /// Responsible for instantiating the platform, and determining whether to start
        /// the application as a Windows service or console/interactive application.
        /// </remarks>
        /// <param name="args">Command line arguments.</param>
        static void Main(string[] args)
        {
            logger.Info("Symbiote is initializing...");

            // instantiate the program manager.
            // the program manager acts as a Service Locator for the symbiote core.
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


            // instantiate the platform.
            logger.Trace("Instantiating the platform...");
            try
            {
                manager.PlatformManager.InstantiatePlatform();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                logger.Error("Failed to instantiate the platform.");
                return;
            }

            // display platform information.
            logger.Info("Platform: " + manager.PlatformManager.Platform.PlatformType.ToString() + " (" + manager.PlatformManager.Platform.Version + ")");

            // start the application
            // if the platform is windows and it is not being run as an interactive application, Windows 
            // is trying to start it as a service, so instantiate the service.  Otherwise launch it as a normal console application.
            if ((manager.PlatformManager.Platform.PlatformType == PlatformType.Windows) && (!Environment.UserInteractive))
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
            try
            {
                // load the configuration.
                logger.Info("Loading configuration...");
                manager.ConfigurationManager.InstantiateConfiguration();


                // load plugins.  Calls the LoadPlugins method of the PluginManager and passes in the
                // platform instance which contains methods used to list directory contents.  This is necessary for platform independence.
                logger.Info("Loading plugins...");
                manager.PluginManager.LoadPlugins("Plugins");
                logger.Info(manager.PluginManager.PluginAssemblies.Count() + " Plugins loaded.");

                manager.ModelManager.AttachModel(manager.ModelManager.BuildModel(manager.ConfigurationManager.Configuration.Model.Items));
                PrintItemChildren(manager.ModelManager.Model, 0);

                manager.ModelManager.AddItem(new Model.ModelItem("Symbiote.Folder3"));

                Model.ModelItem itemd = new Model.ModelItem("Symbiote.Folder3.DELETEME");
                manager.ModelManager.AddItem(itemd);

                Model.ModelItem itemm = new Model.ModelItem("Symbiote.Folder3.MOVEME");
                manager.ModelManager.AddItem(itemm);

                Model.ModelItem itemx = new Model.ModelItem("Symbiote.Folder3.SATest", typeof(string), "N47:0");
                manager.ModelManager.AddItem(itemx);

                PrintItemChildren(manager.ModelManager.Model, 0);

                // save
                logger.Info("-------------- saving");

                if (manager.ModelManager.SaveModel())
                    manager.ConfigurationManager.SaveConfiguration();

                Console.WriteLine("Press ESC to stop");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }



        }
        public static void print(Object source, ElapsedEventArgs e)
        {
            PrintConnectorPluginItemChildren(manager.PlatformManager.Platform.Connector, null, 0);
        }

        /// <summary>
        /// Exit point for the application logic.
        /// </summary>
        public static void Stop()
        {
            logger.Info("Symbiote stopped.");
        }

        private static void PrintItemChildren(Model.ModelItem root, int indent)
        {
            logger.Info(new string('\t',indent) + root.FQN + " [" + root.SourceAddress + "] children: " + root.Children.Count());

            foreach (Model.ModelItem i in root.Children)
            {
                PrintItemChildren(i, indent + 1);
            }
        }

        private static void PrintConnectorPluginItemChildren(IConnector connector, IConnectorItem root, int indent)
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

        public static string GetItemName(string fqn)
        {
            string[] splitFQN = fqn.Split('.');

            if (splitFQN.Length > 1)
                return splitFQN[splitFQN.Length - 1];

            return fqn;
        }

        public static string GetItemPath(string fqn)
        {
            string[] splitFQN = fqn.Split('.');

            if (splitFQN.Length > 1)
                return String.Join(".", splitFQN.Take<string>(splitFQN.Length - 1));

            return fqn;
        }
    }
}
