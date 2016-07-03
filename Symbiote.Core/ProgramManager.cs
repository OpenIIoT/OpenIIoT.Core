using System;
using System.Collections.Generic;
using Symbiote.Core.Platform;
using Symbiote.Core.Plugin;
using Symbiote.Core.Model;
using Symbiote.Core.Configuration;
using NLog;
using Symbiote.Core.Service;

namespace Symbiote.Core
{
    /// <summary>
    /// The ProgramManager acts as a Service Locator for the application and contains references to both 
    /// the Manager for each service as well as references to the key resources contained within each namespace.
    /// </summary>
    public class ProgramManager : IManager
    {
        #region Variables

        /// <summary>
        /// The logger for this class.
        /// </summary>
        private static xLogger logger = (xLogger)LogManager.GetCurrentClassLogger(typeof(xLogger));

        /// <summary>
        /// The Singleton instance of ProgramManager.
        /// </summary>
        private static ProgramManager instance;

        #endregion

        #region Properties

        #region IManager Implementation

        /// <summary>
        /// The state of the Manager.
        /// </summary>
        public State State { get; private set; }

        #endregion

        /// <summary>
        /// Indicates whether the program is in Safe Mode.  Safe Mode is a sort of fault tolerant mode designed
        /// to allow the application to run under conditions that would otherwise raise fatal errors.
        /// </summary>
        public bool SafeMode { get; private set; }

        /// <summary>
        /// The name of the product, retrieved from AssemblyInfo.cs.
        /// </summary>
        public string ProductName { get { return System.Reflection.Assembly.GetExecutingAssembly().GetName().Name; } }

        /// <summary>
        /// The version of the product, retrieved from AssemblyInfo.cs.
        /// </summary>
        public Version ProductVersion { get { return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version; } }

        /// <summary>
        /// The name of the application instance.
        /// </summary>
        public string InstanceName { get { return Utility.GetSetting("InstanceName");  } }


        //------------------------------------------- - - ------------ - -
        // Properties related to the PlatformManager.
        /// <summary>
        /// The PlatformManager for the application.
        /// </summary>
        public PlatformManager PlatformManager { get; private set; }
        /// <summary>
        /// The Platform for the application.
        /// </summary>
        public IPlatform Platform { get { return PlatformManager.Platform; } }
        /// <summary>
        /// The directories used by the application.
        /// </summary>
        public PlatformDirectories Directories { get { return PlatformManager.Directories; } }
        //---------------------------------- - -         --------- - --------------  -


        //-------------------- - - ---------------- - -  -             --------- - 
        // Properties related to the ConfigurationManager
        /// <summary>
        /// The ConfigurationManager for the application.
        /// </summary>
        public ConfigurationManager ConfigurationManager { get; private set; }
        /// <summary>
        /// The configuration for the application.
        /// </summary>
        public Dictionary<string, Dictionary<string, object>> Configuration { get { return ConfigurationManager.Configuration; } }
        /// <summary>
        /// The filename of the configuration file.
        /// </summary>
        public string ConfigurationFileName { get { return ConfigurationManager.ConfigurationFileName; } }
        /// <summary>
        /// A dictionary containing the types and ConfigurationDefinitions for the configurable types within the application.
        /// </summary>
        public Dictionary<string, ConfigurationDefinition> RegisteredTypes { get { return ConfigurationManager.RegisteredTypes; } }
        //---------------------------------- -   ----------------- - -------------------------------------------------  ---------- 


        /// <summary>
        /// The PluginManager for the application.
        /// </summary>
        public PluginManager PluginManager { get; private set; }

        /// <summary>
        /// The ModelManager for the application.
        /// </summary>
        public ModelManager ModelManager { get; private set; }

        /// <summary>
        /// The ServiceManager for the application.
        /// </summary>
        public ServiceManager ServiceManager { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// The default constructor.
        /// </summary>
        /// <remarks>
        /// If you've forgotten, you made this code dynamic so that you coud iterate over IManagers and it was 
        /// a mess.  Even more verbose than the way it is now, plus debugging it was a nightmare.  Don't try it again.
        /// </remarks>
        private ProgramManager(bool safeMode = false)
        {
            Guid guid = logger.EnterMethod(xLogger.Params(safeMode), true);

            SafeMode = safeMode;

            if (safeMode)
                logger.Info("Safe Mode enabled.  The program is now running in a limited fault tolerant mode.");

            logger.Debug("Instantiating Managers...");

            //------- - ------- -         --
            // Platform Manager
            logger.Separator(LogLevel.Trace);
            logger.Debug("Instantiating the PlatformManager...");
            PlatformManager = PlatformManager.Instance(this);
            logger.Debug("Successfully instantiated the Platform Manager.");
            //----------------------- -- -------------   - -- ------------


            //------------ -        -- -   -
            // Configuration Manager
            logger.Separator(LogLevel.Trace);
            logger.Debug("Instantiating the Configuration Manager...");
            ConfigurationManager = ConfigurationManager.Instance(this);
            logger.Debug("Successfully instantiated the Configuration Manager.");
            //--------------- --- ---       -


            //------- - - ------------------ - - ------------
            // Plugin Manager
            logger.Separator(LogLevel.Trace);
            logger.Debug("Instantiating the Plugin Manager...");
            PluginManager = PluginManager.Instance(this);
            ConfigurationManager.RegisterType(typeof(PluginManager));
            logger.Debug("Successfully instantiated the Plugin Manager.");
            //----------------------------- ------ -- --


            //-------- -------------- -    -
            // Model Manager
            logger.Separator(LogLevel.Trace);
            logger.Debug("Instantiating the Model Manager...");
            ModelManager = ModelManager.Instance(this);
            ConfigurationManager.RegisterType(typeof(ModelManager));
            logger.Debug("Successfully instantiated the Model Manager.");
            //---- - -----------  -----


            //--------------------  - -
            // Service Manager
            logger.Separator(LogLevel.Trace);
            logger.Debug("Instantiating the Service Manager...");
            ServiceManager = ServiceManager.Instance(this);
            //ConfigurationManager.RegisterType(typeof(ServiceManager));
            logger.Debug("Successfully instantiated the Service Manager.");
            //---------------  --    -  -     -  

            logger.ExitMethod(guid);
        }

        /// <summary>
        /// Returns the singleton instance of the ProgramManager.  Creates an instance if null.
        /// </summary>
        /// <returns>The singleton instance of the ProgramManager</returns>
        internal static ProgramManager Instance(bool safeMode = false)
        {
            if (instance == null)
                instance = new ProgramManager(safeMode);

            return instance;
        }

        #endregion

        #region Instance Methods

        #region IManager Implementation

        /// <summary>
        /// Starts the Program Manager.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        public Result Start()
        {
            Guid guid = logger.EnterMethod(true);

            logger.Info("Starting the Program Manager...");
            Result retVal = new Result();

            State = State.Starting;

            if (retVal.ResultCode != ResultCode.Failure)
                State = State.Running;
            else
                State = State.Faulted;

            retVal.LogResult(logger);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        /// <summary>
        /// Restarts the Program Manager.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        public Result Restart()
        {
            Guid guid = logger.EnterMethod(true);

            logger.Info("Restarting the Program Manager...");
            Result retVal = new Result();
            
            retVal.Incorporate(Stop());
            retVal.Incorporate(Start());

            retVal.LogResult(logger);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        /// <summary>
        /// Stops the Program Manager.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        public Result Stop()
        {
            logger.EnterMethod();

            logger.Info("Stopping the Program Manager...");
            Result retVal = new Result();

            State = State.Stopping;

            if (retVal.ResultCode != ResultCode.Failure)
                State = State.Stopped;
            else
                State = State.Faulted;

            retVal.LogResult(logger);
            logger.ExitMethod(retVal);
            return new Result();
        }

        #endregion

        /// <summary>
        /// Starts the specified IManager instance
        /// </summary>
        /// <param name="manager">The IManager instance to start.</param>
        /// <returns>A Result containing the result of the operation and the specified IManager instance.</returns>
        internal Result<IManager> StartManager(IManager manager)
        {
            Guid guid = logger.EnterMethod(xLogger.Params(manager), true);

            logger.Debug("Starting " + manager.GetType().Name + "...");
            Result<IManager> retVal = new Result<IManager>();

            // invoke the Start() method on the specified manager
            Result startResult = manager.Start();

            // if the manager fails to start, throw an exception and halt the program
            if (startResult.ResultCode == ResultCode.Failure)
                throw new Exception("Failed to start " + manager.GetType().Name + "." + startResult.LastErrorMessage());

            retVal.ReturnValue = manager;
            retVal.Incorporate(startResult);

            retVal.LogResult(logger);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        #endregion

        #region Static Methods

        /// <summary>
        /// Returns the "InstanceName" setting from the app.config file, or the default value if the setting is not retreived.
        /// </summary>
        /// <returns>The name of the program instance.</returns>
        public static string GetInstanceName()
        {
            return Utility.GetSetting("InstanceName", "Symbiote");
        }

        #endregion
    }
}
