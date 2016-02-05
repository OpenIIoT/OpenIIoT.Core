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
                logger.Error(ex, "Symbiote failed to initailize.");
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
                logger.Error(ex, "Failed to instantiate the platform.");
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
                //--------------------------- - -        -------  - -   - - -  - - - -
                // load the configuration.
                //      reads the saved configuration from the config file located in Symbiote.exe.config and deserializes the json within
                //--------------------------------------- - -  - --------            -------- -
                logger.Info("Loading configuration...");
                manager.ConfigurationManager.InstantiateConfiguration();
                logger.Info("Configuration loaded.");

                //--------------------------------------------- - - --------- ----  - -    -
                // load plugins.  
                //      populates the PluginAssemblies list in the Plugin Manager with the assemblies of all of the found and authorized plugins
                //----------------------------------------------------------------  --  ---         ------ - 
                logger.Info("Loading plugins...");
                manager.PluginManager.LoadPlugins("Plugins");
                logger.Info(manager.PluginManager.PluginAssemblies.Count() + " Plugin(s) loaded.");

                //--------------------- - --------------------- -  -
                // create plugin instances.
                //      statically creates the simulation plugin instance, then creates the instances specified within the configuration
                //--------------------------------------------- - -   -     -------  -     - - -  ---
                logger.Info("Creating plugin instances...");
                manager.PluginManager.InstantiatePlugins();


                Utility.PrintConnectorPluginItemChildren(logger, (IConnector)manager.PluginManager.FindPluginInstance("Simulation"));
                //manager.PluginManager.CreatePluginInstance<IConnector>("Simulation", manager.PluginManager.FindPluginAssembly("Symbiote.Plugin.Connector.Simulation").Type);

                // TODO: fetch list of plugin instances from the configuration and instantiate them

                logger.Info(manager.PluginManager.PluginInstances.Count() + " Plugin instance(s) created.");


                //------------- - ----------------------- - - -------------------  -- - --- - 
                // instantiate the item model.
                //      builds and attaches the model stored within the configuration file to the Model Manager.
                //---------------------------- - --------- - - -  ---        ------- -  --------------  - --
                logger.Info("Attaching model...");
                Model.ModelBuildResult modelBuildResult = manager.ModelManager.BuildModel(manager.ConfigurationManager.Configuration.Model.Items);
                manager.ModelManager.AttachModel(modelBuildResult);
                logger.Info("Attached model.");

                // debug/temporary
                Utility.PrintItemChildren(logger, manager.ModelManager.Model, 0);

                //----------------------------------- - - --------  - -------- -  -   -  -           -
                // attach the Platform connector items to the model
                //------------------------------------------------------ -  -         -   - ------  - -         -  - - --
                // detatch anything that was loaded from the config file
                manager.ModelManager.RemoveItem(manager.ModelManager.FindItem("Symbiote.System.Platform"));
                logger.Info("Removed previous platform items:");
                logger.Info("---------------------------------------------------------------------------------------------------------------------------");
                Utility.PrintItemChildren(logger, manager.ModelManager.Model, 0);
                logger.Info("---------------------------------------------------------------------------------------------------------------------------");

                //////logger.Info("Attaching new platform items:");
                manager.PlatformManager.Platform.InstantiateConnector("Platform");
                Item systemItem = manager.ModelManager.AddItem(new Item("Symbiote.System"));

                manager.ModelManager.AttachItem(manager.PlatformManager.Platform.Connector.Browse(), systemItem);

                logger.Info("---------------------------------------------------------------------------------------------------------------------------");
                Utility.PrintItemChildren(logger, manager.ModelManager.Model, 0);
                logger.Info("---------------------------------------------------------------------------------------------------------------------------");

                Console.WriteLine("Press ESC to stop");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Fatal error.");
            }
        }

        /// <summary>
        /// Exit point for the application logic.
        /// </summary>
        public static void Stop()
        {
            logger.Info("Symbiote is stopping.  Saving configuration...");

            try
            {
                if (manager.ModelManager.SaveModel())
                    manager.ConfigurationManager.SaveConfiguration();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error saving configuration.");
            }

            logger.Info("Configuration saved.");

            logger.Info("Symbiote stopped.");
        }
    }
}
