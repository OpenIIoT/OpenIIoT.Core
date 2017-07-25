/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄███████▄                                            ▄▄▄▄███▄▄▄▄
      █     ███    ███                                          ▄██▀▀▀███▀▀▀██▄
      █     ███    ███  █       ██   █     ▄████▄   █  ██▄▄▄▄   ███   ███   ███   ▄█████  ██▄▄▄▄    ▄█████     ▄████▄     ▄█████    █████
      █     ███    ███ ██       ██   ██   ██    ▀  ██  ██▀▀▀█▄  ███   ███   ███   ██   ██ ██▀▀▀█▄   ██   ██   ██    ▀    ██   █    ██  ██
      █   ▀█████████▀  ██       ██   ██  ▄██       ██▌ ██   ██  ███   ███   ███   ██   ██ ██   ██   ██   ██  ▄██        ▄██▄▄     ▄██▄▄█▀
      █     ███        ██       ██   ██ ▀▀██ ███▄  ██  ██   ██  ███   ███   ███ ▀████████ ██   ██ ▀████████ ▀▀██ ███▄  ▀▀██▀▀    ▀███████
      █     ███        ██▌    ▄ ██   ██   ██    ██ ██  ██   ██  ███   ███   ███   ██   ██ ██   ██   ██   ██   ██    ██   ██   █    ██  ██
      █    ▄████▀      ████▄▄██ ██████    ██████▀  █    █   █    ▀█   ███   █▀    ██   █▀  █   █    ██   █▀   ██████▀    ███████   ██  ██
      █
 ▄ ▄▄ █ ▄▄▄▄▄▄▄▄▄  ▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █ ██ █ █████████  ████ ██████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      █
      █  Represents and manages the Plugin subsystem.
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using NLog;
using NLog.xLogger;
using OpenIIoT.SDK;
using OpenIIoT.SDK.Common;
using OpenIIoT.SDK.Common.Discovery;
using OpenIIoT.SDK.Configuration;
using OpenIIoT.SDK.Platform;
using OpenIIoT.SDK.Plugin;
using OpenIIoT.SDK.Plugin.Connector;
using OpenIIoT.SDK.Plugin.Endpoint;
using Utility.OperationResult;

namespace OpenIIoT.Core.Plugin
{
    /// <summary>
    ///     Represents and manages the Plugin subsystem.
    /// </summary>
    [Discoverable]
    public class PluginManager : Manager, IStateful, IManager, IConfigurable<PluginManagerConfiguration>, IPluginManager
    {
        #region Private Fields

        /// <summary>
        ///     The Singleton instance of PluginManager.
        /// </summary>
        private static PluginManager instance;

        /// <summary>
        ///     An array of loadable plugin types.
        /// </summary>
        private static PluginType[] loadablePluginTypes = new PluginType[] { PluginType.Connector, PluginType.Endpoint };

        /// <summary>
        ///     The Logger for this class.
        /// </summary>
        private static new xLogger logger = (xLogger)LogManager.GetCurrentClassLogger(typeof(xLogger));

        /// <summary>
        ///     Lock object for installation/uninstallation of Plugins.
        /// </summary>
        private object installationLock = new object();

        #endregion Private Fields

        #region Private Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="PluginManager"/> class.
        /// </summary>
        /// <param name="manager">The ApplicationManager instance for the application.</param>
        /// <param name="platformManager">The PlatformManager instance for the application.</param>
        /// <param name="configurationManager">The ConfigurationManager instance for the application.</param>
        private PluginManager(IApplicationManager manager, IPlatformManager platformManager, IConfigurationManager configurationManager)
        {
            base.logger = logger;
            logger.EnterMethod();

            ManagerName = "Plugin Manager";

            RegisterDependency<IApplicationManager>(manager);
            RegisterDependency<IPlatformManager>(platformManager);
            RegisterDependency<IConfigurationManager>(configurationManager);

            PluginAssemblies = new List<IPluginAssembly>();
            PluginInstances = new List<IPluginInstance>();

            ChangeState(State.Initialized);

            logger.ExitMethod();
        }

        #endregion Private Constructors

        #region Public Properties

        /// <summary>
        ///     Gets the Configuration for the Manager.
        /// </summary>
        public PluginManagerConfiguration Configuration { get; private set; }

        /// <summary>
        ///     Gets a list of currently loaded plugin assemblies.
        /// </summary>
        public IList<IPluginAssembly> PluginAssemblies { get; private set; }

        /// <summary>
        ///     Gets a Dictionary of all Plugin Instances, keyed by instance name.
        /// </summary>
        [Discoverable]
        public IList<IPluginInstance> PluginInstances { get; private set; }

        /// <summary>
        ///     Gets a list of installed plugins.
        /// </summary>
        public IList<IPlugin> Plugins { get; private set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        ///     Returns the ConfigurationDefinition for the Type.
        /// </summary>
        /// <returns>The ConfigurationDefinition for the Type.</returns>
        public static IConfigurationDefinition GetConfigurationDefinition()
        {
            ConfigurationDefinition retVal = new ConfigurationDefinition();
            retVal.Form = "[\"name\",\"email\",{\"key\":\"comment\",\"type\":\"textarea\",\"placeholder\":\"Make a comment\"},{\"type\":\"submit\",\"style\":\"btn-info\",\"title\":\"OK\"}]";
            retVal.Schema = "{\"type\":\"object\",\"title\":\"Comment\",\"properties\":{\"name\":{\"title\":\"Name\",\"type\":\"string\"},\"email\":{\"title\":\"Email\",\"type\":\"string\",\"pattern\":\"^\\\\S+@\\\\S+$\",\"description\":\"Email will be used for evil.\"},\"comment\":{\"title\":\"Comment\",\"type\":\"string\",\"maxLength\":20,\"validationMessage\":\"Don\'t be greedy!\"}},\"required\":[\"name\",\"email\",\"comment\"]}";
            retVal.Model = typeof(PluginManagerConfiguration);

            // create the default configuration
            PluginManagerConfiguration config = new PluginManagerConfiguration();
            config.Instances = new List<PluginManagerConfigurationPluginInstance>();

            PluginManagerConfigurationPluginInstance sim = new PluginManagerConfigurationPluginInstance();
            sim.InstanceName = "Simulation";
            sim.AssemblyName = "OpenIIoT.Plugin.Connector.Simulation";

            config.Instances.Add(sim);

            retVal.DefaultConfiguration = config;

            return retVal;
        }

        /// <summary>
        ///     Configures the Manager using the configuration stored in the Configuration Manager, or, failing that, using the
        ///     default configuration.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        public IResult Configure()
        {
            logger.EnterMethod();
            Result retVal = new Result();

            IResult<PluginManagerConfiguration> fetchResult = Dependency<IConfigurationManager>().Configuration.GetInstance<PluginManagerConfiguration>(this.GetType());

            // if the fetch succeeded, configure this instance with the result.
            if (fetchResult.ResultCode != ResultCode.Failure)
            {
                logger.Debug("Successfully fetched the configuration from the Configuration Manager.");
                Configure(fetchResult.ReturnValue);
            }
            else
            {
                // if the fetch failed, add a new default instance to the configuration and try again.
                logger.Debug("Unable to fetch the configuration.  Adding the default configuration to the Configuration Manager...");
                IResult<PluginManagerConfiguration> createResult = Dependency<IConfigurationManager>().Configuration.AddInstance<PluginManagerConfiguration>(this.GetType(), GetConfigurationDefinition().DefaultConfiguration);
                if (createResult.ResultCode != ResultCode.Failure)
                {
                    logger.Debug("Successfully added the configuration.  Configuring...");
                    Configure(createResult.ReturnValue);
                }
                else
                {
                    retVal.Incorporate(createResult);
                }
            }

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        ///     Configures the Manager using the supplied configuration, then saves the configuration to the Model Manager.
        /// </summary>
        /// <param name="configuration">The configuration with which the Model Manager should be configured.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public IResult Configure(PluginManagerConfiguration configuration)
        {
            logger.EnterMethod(xLogger.Params(configuration));
            logger.Info("Retrieving and applying the configuration from the Configuration Manager...");

            Result retVal = new Result();

            // update the configuration
            Configuration = configuration;

            // populate the plugin list
            Plugins = Configuration.InstalledPlugins.ToList<IPlugin>();

            logger.Debug("Successfully configured the Manager.");

            // save it
            logger.Debug("Saving the new configuration...");
            retVal.Incorporate(SaveConfiguration());

            retVal.LogResult(logger);
            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        ///     Searches the specified List of type Plugin for a Plugin with an FQN matching the supplied FQN and returns it if found.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Plugin to find.</param>
        /// <returns>The Plugin matching the supplied FQN, or the default Plugin if not found.</returns>
        public IPlugin FindPlugin(string fqn)
        {
            logger.EnterMethod(xLogger.Params(fqn, new xLogger.ExcludedParam()));

            IPlugin retVal = Plugins.Where(p => p.FQN == fqn).FirstOrDefault();

            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        ///     Finds and returns the PluginAssembly in the specified list of type PluginAssembly whose FQN matches the specified FQN.
        /// </summary>
        /// <param name="fqn">The FQN of the desired PluginAssembly.</param>
        /// <returns>
        ///     The PluginAssembly instance whose FQN matches the specified FQN, or the default PluginAssembly if not found.
        /// </returns>
        public IPluginAssembly FindPluginAssembly(string fqn)
        {
            logger.EnterMethod(xLogger.Params(fqn, new xLogger.ExcludedParam()));

            IPluginAssembly retVal = PluginAssemblies.Where(p => p.FQN == fqn).FirstOrDefault();

            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        ///     Given an instance name string, return the matching instance of IPluginInstance.
        /// </summary>
        /// <param name="instanceName">The name of the instance to find.</param>
        /// <param name="pluginType">The Type of instance to find.</param>
        /// <returns>The instance of IPluginInstance matching the requested InstanceName.</returns>
        public IPluginInstance FindPluginInstance(string instanceName, PluginType pluginType = PluginType.Connector)
        {
            return PluginInstances.Where(p => p.PluginType == pluginType).Where(p => p.InstanceName == instanceName).FirstOrDefault();
        }

        /// <summary>
        ///     Attempts to resolve the supplied plugin item Fully Qualified Name to an instance of Item contained in a Connector plugin.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the instance to find.</param>
        /// <returns>The found Item.</returns>
        public Item FindPluginItem(string fqn)
        {
            logger.Trace("Attempting to find Connector Item '" + fqn + "'...");

            Item retVal = default(Item);

            IConnector originPlugin = (IConnector)FindPluginInstance(fqn.Split('.')[0]);

            if (originPlugin != default(IConnector))
            {
                try
                {
                    logger.Trace("Origin Plugin is '" + originPlugin.ToString() + "'.. Performing lookup..");
                    retVal = originPlugin.Find(fqn);
                }
                catch (Exception ex)
                {
                    logger.Trace("Exception thrown from FindPluginItem(): " + ex);
                }
            }
            else
            {
                logger.Trace("Origin plugin '" + fqn.Split('.')[0] + "' not found.");
            }

            logger.Trace(retVal == default(Item) ? "Unable to resolve Item." : "Resolved Item: " + retVal.ToJson());
            return retVal;
        }

        /// <summary>
        ///     Creates and returns an instance of the specified plugin type with the specified name
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         The instanceName is propagated through the plugin instance and any internal reference (such as a
        ///         ConnectorItem). This name should match references to the plugin, either through fully qualified addressing or configuration.
        ///     </para>
        /// </remarks>
        /// <param name="instanceManager">The ApplicationManager instance to be passed to the Plugin instance.</param>
        /// <param name="instanceName">The desired internal name of the instance</param>
        /// <param name="instanceLogger">The logger for the plugin instance.</param>
        /// <typeparam name="T">The Type of the Plugin instance to create.</typeparam>
        /// <returns>A Result containing the result of the operation and the created Plugin instance.</returns>
        public Result<IPluginInstance> InstantiatePlugin<T>(IApplicationManager instanceManager, string instanceName, xLogger instanceLogger)
        {
            logger.EnterMethod(xLogger.Params(instanceName));
            logger.Debug("Creating plugin instance '" + instanceName + "' of Type '" + typeof(T).Name + "'...");

            Result<IPluginInstance> retVal = new Result<IPluginInstance>();

            try
            {
                // check to see if the instance name has already been used
                if (FindPluginInstance(instanceName) == default(IPluginInstance))
                {
                    logger.Trace("Creating instance of plugin type '" + typeof(T).ToString() + "' with instance name '" + instanceName + "'");
                    retVal.ReturnValue = (IPluginInstance)Activator.CreateInstance(typeof(T), instanceManager, instanceName, instanceLogger);
                }
                else
                {
                    retVal.AddError("A plugin with InstanceName '" + instanceName + "' has already been instantiated.");
                }
            }
            catch (Exception ex)
            {
                logger.Exception(LogLevel.Error, ex);
                retVal.AddError("Exception caught while creating plugin instance '" + instanceName + "': " + ex.Message);
            }

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        ///     Loads the Plugin Assembly belonging to the specified Plugin and stores the instance in the PluginAssemblies list.
        /// </summary>
        /// <param name="plugin">The Plugin to which the Plugin Assembly to load belongs.</param>
        /// <returns>A Result containing the result of the operation and the newly created PluginAssembly instance.</returns>
        public Result<IPluginAssembly> LoadPluginAssembly(IPlugin plugin)
        {
            return LoadPluginAssembly(plugin, PluginAssemblies);
        }

        /// <summary>
        ///     Saves the configuration to the Configuration Manager.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        public IResult SaveConfiguration()
        {
            logger.EnterMethod();
            logger.Info("Saving the configuration to the Configuration Manager...");

            Result retVal = new Result();

            // update the list of plugins
            List<Plugin> installedPluginList = new List<Plugin>();

            foreach (IPlugin p in Plugins)
            {
                installedPluginList.Add((Plugin)p);
            }

            Configuration.InstalledPlugins = installedPluginList;

            retVal.Incorporate(Dependency<IConfigurationManager>().Configuration.UpdateInstance(this.GetType(), Configuration));

            retVal.LogResult(logger);
            logger.ExitMethod(retVal);
            return retVal;
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        ///     Executed upon shutdown of the Manager.
        /// </summary>
        /// <param name="stopType">The nature of the stoppage.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        protected override IResult Shutdown(StopType stopType = StopType.Stop)
        {
            Guid guid = logger.EnterMethod(true);
            logger.Debug("Performing Shutdown for '" + GetType().Name + "'...");
            IResult retVal = new Result();

            // re-initialize/nullify all properties
            PluginAssemblies = new List<IPluginAssembly>();
            PluginInstances = new List<IPluginInstance>();
            Plugins = null;

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        /// <summary>
        ///     <para>Executed upon startup of the Manager.</para>
        ///     <para>
        ///         Configures the Manager using the Configuration Manager, generates a list of the available Plugin Packages,
        ///         loads installed Plugin Assemblies and registers them for configuration, and instantiates configured Plugin Instances.
        ///     </para>
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        protected override IResult Startup()
        {
            Guid guid = logger.EnterMethod(true);
            logger.Debug("Performing Startup for '" + GetType().Name + "'...");
            IResult retVal = new Result();

            // Configure the manager
            IResult configureResult = Configure();
            if (configureResult.ResultCode == ResultCode.Failure)
            {
                throw new Exception("Failed to start the Plugin Manager: " + configureResult.GetLastError());
            }

            retVal.Incorporate(configureResult);
            logger.Checkpoint("Configured the Plugin Manager", guid);

            // load installed plugin assemblies into memory and register them with the configuration manager
            logger.SubSubHeading(LogLevel.Debug, "Assemblies...");

            Result<List<IPluginAssembly>> pluginAssemblyLoadResult = LoadPluginAssemblies();

            if (pluginAssemblyLoadResult.ResultCode != ResultCode.Failure)
            {
                PluginAssemblies = pluginAssemblyLoadResult.ReturnValue;
            }

            retVal.Incorporate(pluginAssemblyLoadResult);

            // print the list of loaded assemblies
            if (PluginAssemblies.Count > 0)
            {
                logger.Info("Loaded Assemblies:");
            }

            foreach (IPluginAssembly assembly in PluginAssemblies)
            {
                logger.Info(new string(' ', 5) + assembly.FQN);
            }

            logger.Info(PluginAssemblies.Count + " Plugin " + (PluginAssemblies.Count == 1 ? "Assembly" : "Assemblies") + " loaded.");

            logger.Checkpoint("Plugin Assemblies loaded", xLogger.Vars(PluginAssemblies), xLogger.Names("PluginAssemblies"), guid);

            // instantiate all of the configured Plugin instances
            logger.SubSubHeading(LogLevel.Debug, "Instances...");

            // Result<Dictionary<string, IPluginInstance>> pluginInstantiationResult = InstantiatePlugins();
            Result<List<IPluginInstance>> pluginInstantiationResult = InstantiatePlugins();

            if (pluginInstantiationResult.ResultCode != ResultCode.Failure)
            {
                PluginInstances = pluginInstantiationResult.ReturnValue;
            }

            // print the list of instantiated plugins
            if (PluginInstances.Count > 0)
            {
                logger.Info("Plugin Instances:");
            }

            foreach (IPluginInstance plugin in PluginInstances)
            {
                logger.Info(new string(' ', 5) + plugin.InstanceName + " (" + plugin.GetType().FullName + ")");
            }

            logger.Info(PluginInstances.Count + " Plugin" + (PluginInstances.Count > 1 ? "s" : string.Empty) + " instantiated.");

            logger.Checkpoint("Plugins instantiated", xLogger.Vars(PluginInstances), xLogger.Names("PluginInstances"), guid);

            // TODO: replace this with manual registration somewhere. probably not anywhere in the Plugin namespace.
            // PluginInstances.Add("Platform", Dependency<IPlatformManager>().Platform.Connector);
            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        #endregion Protected Methods

        #region Private Methods

        /// <summary>
        ///     Retrieves the PackageConfigurationFileName setting or substitutes "OpenIIoTPlugin.json" if retrieval fails.
        /// </summary>
        /// <returns>The name of the Plugin Package configuration file.</returns>
        private static string GetPackageConfigurationFileName()
        {
            return Utility.GetSetting("PackageConfigurationFileName", "OpenIIoTPlugin.json");
        }

        /// <summary>
        ///     Retrieves the PackageExtension setting or substitutes "*.zip" if retrieval fails.
        /// </summary>
        /// <returns>The wildcard mask of the file extension for Plugin Packages.</returns>
        private static string GetPackageExtension()
        {
            return Utility.GetSetting("PackageExtension", "*.zip");
        }

        /// <summary>
        ///     Retrieves the PackagePayloadFileName setting or substitutes "Plugin.zip" if retrieval fails.
        /// </summary>
        /// <returns>The name of the Plugin payload file contained within a Plugin Package.</returns>
        private static string GetPackagePayloadFileName()
        {
            return Utility.GetSetting("PackagePayloadFileName", "Plugin.zip");
        }

        /// <summary>
        ///     Returns the base directory in which the specified Plugin should be installed, based on the type and name of the
        ///     specified Plugin.
        /// </summary>
        /// <param name="plugin">The Plugin for which the directory is to be returned.</param>
        /// <returns>The directory in which the specified Plugin should be installed.</returns>
        private static string GetPluginDirectory(IPlugin plugin)
        {
            if (plugin.PluginType == PluginType.App)
            {
                return System.IO.Path.Combine(ApplicationManager.GetInstance().GetManager<IPlatformManager>().Platform.Directories.Web, plugin.Name);
            }
            else
            {
                return System.IO.Path.Combine(ApplicationManager.GetInstance().GetManager<IPlatformManager>().Platform.Directories.Plugins, plugin.PluginType.ToString(), plugin.Name);
            }
        }

        /// <summary>
        ///     Returns an enumeration instance representing the type of the plugin, derived from the third tuple of the plugin name.
        /// </summary>
        /// <param name="name">The fully qualified assembly name from which to parse the plugin type.</param>
        /// <returns>An instance of PluginType corresponding to the parsed type.</returns>
        private static PluginType GetPluginType(string name)
        {
            logger.EnterMethod(xLogger.Params(name));
            logger.Trace("Attempting to determine Plugin type for '" + name + "'...");

            PluginType retVal;

            if (Enum.TryParse<PluginType>(name.Split('.')[2], out retVal))
            {
                logger.Trace("Plugin type: " + retVal);
            }
            else
            {
                logger.Trace("Invalid PluginType for plugin '" + name + "'");
            }

            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        ///     Instantiates and/or returns the PluginManager instance.
        /// </summary>
        /// <remarks>
        ///     Invoked via reflection from ApplicationManager. The parameters are used to build an array of IManager parameters
        ///     which are then passed to this method. To specify additional dependencies simply insert them into the parameter list
        ///     for the method and they will be injected when the method is invoked.
        /// </remarks>
        /// <param name="manager">The ApplicationManager instance for the application.</param>
        /// <param name="platformManager">The PlatformManager instance for the application.</param>
        /// <param name="configurationManager">The ConfigurationManager instance for the application.</param>
        /// <returns>The Singleton instance of PluginManager.</returns>
        private static PluginManager Instantiate(IApplicationManager manager, IPlatformManager platformManager, IConfigurationManager configurationManager)
        {
            if (instance == null)
            {
                instance = new PluginManager(manager, platformManager, configurationManager);
            }

            return instance;
        }

        /// <summary>
        ///     Returns true if the supplied Plugin is capable of being loaded, false otherwise.
        /// </summary>
        /// <param name="plugin">The Plugin to check.</param>
        /// <returns>True if the Plugin is capable of being loaded, false otherwise.</returns>
        /// <seealso cref="loadablePluginTypes"/>
        private static bool IsPluginLoadable(IPlugin plugin)
        {
            return loadablePluginTypes.Contains(plugin.PluginType);
        }

        /// <summary>
        ///     Determines whether the supplied assembly is a valid plugin, and if so, returns the plugin type.
        /// </summary>
        /// <param name="assembly">The assembly to validate.</param>
        /// <returns>A Result containing the result of the operation and, if successful, the plugin type.</returns>
        private static Result<Type> ValidatePluginAssembly(Assembly assembly)
        {
            logger.EnterMethod(xLogger.Params(assembly));
            logger.Debug("Validating plugin assembly '" + assembly.FullName + "'...");

            Result<Type> retVal = new Result<Type>();

            // validate the assembly name
            Result nameValidationResult = ValidatePluginAssemblyName(assembly.GetName());
            retVal.Incorporate(nameValidationResult);

            if (nameValidationResult.ResultCode != ResultCode.Failure)
            {
                logger.Trace("Name validated; searching for the type that implements IConfigurable<> and either IConnector or IEndpoint...");

                // passed name validation, find an implementation of IConfigurable and either IConnector or IEndpoint
                foreach (Type t in assembly.GetTypes())
                {
                    logger.Trace("Checking type '" + t.Name + "'...");

                    // ensure the type implements IConfigurable<>
                    if (t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IConfigurable<>)))
                    {
                        logger.Trace("IConfigurable is implemented.  Looking for either IConnector or IEndpoint...");

                        // ensure it implements either IConnector or IEndpoint
                        // TODO: refactor this to check IsAssignableFrom(IPluginInstance)) to handle other types of Plugin.
                        if (t.GetInterfaces().Contains(typeof(IConnector)) || t.GetInterfaces().Contains(typeof(IEndpoint)))
                        {
                            retVal.ReturnValue = t;
                            break;
                        }
                        else
                        {
                            retVal.AddError("Neither IConnector nor IEndpoint interfaces are implemented; plugin assembly is invalid.");
                        }
                    }
                    else
                    {
                        retVal.AddError("Interface IConfigurable is not implemented; plugin assembly is invalid.");
                    }
                }

                // if we successfully grabbed a suitable type, clear the errors in the Result and reset the ResultCode.
                if (retVal.ReturnValue != default(Type))
                {
                    retVal.RemoveMessages(MessageType.Error).SetResultCode(ResultCode.Success);
                }
            }

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        ///     Evaluates the supplied assembly name for correctness and returns an error message if it is incorrect.
        /// </summary>
        /// <remarks>
        ///     The expected format of an assembly name is: "OpenIIoT.Plugin.[Connector|Service].{PluginName}" The third tuple may
        ///     match any enumerated value in PluginType.
        /// </remarks>
        /// <returns>A Result containing the result of the operation.</returns>
        /// <param name="assemblyName">The AssemblyName to be validated.</param>
        private static Result ValidatePluginAssemblyName(AssemblyName assemblyName)
        {
            logger.EnterMethod(xLogger.Params(assemblyName));
            logger.Debug("Validating assembly name for '" + assemblyName.FullName + "'...");

            Result retVal = new Result();

            string[] name = assemblyName.Name.Split('.');

            if (name.Length != 4)
            {
                retVal.AddError("Invalid assembly name (required: 4 tuples, supplied: " + name.Length + ")");
            }

            if (name[0] != ApplicationManager.GetInstance().ProductName)
            {
                retVal.AddError("Invalid application identifier (required: OpenIIoT, supplied: " + name[0] + ")");
            }

            if (name[1] != "Plugin")
            {
                retVal.AddError("Invalid namespace identifier (required: Plugin, supplied: " + name[1] + ")");
            }

            if (GetPluginType(assemblyName.Name) == default(PluginType))
            {
                retVal.AddError("Invalid plugin type identifier (supplied: " + name[2] + ")");
            }

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        ///     Iterates over the specified List of type <see cref="PluginManagerConfigurationPluginInstance"/>, retrieves the
        ///     matching PluginAssembly from the supplied List of type PluginAssembly and instantiates each instance, passing the
        ///     instance name and an instance of xLogger with the Fully Qualified Name of the instance.
        /// </summary>
        /// <remarks>
        ///     The <see cref="InstantiatePlugin{T}(IApplicationManager, string, xLogger)"/> method is invoked via reflection so
        ///     that the type parameter for the method can be specified dynamically.
        /// </remarks>
        /// <returns>A Result containing the result of the operation and a Dictionary containing the instantiated Plugins.</returns>
        private Result<List<IPluginInstance>> InstantiatePlugins()
        {
            logger.EnterMethod();
            logger.Info("Creating Plugin Instances...");

            Result<List<IPluginInstance>> retVal = new Result<List<IPluginInstance>>();
            retVal.ReturnValue = new List<IPluginInstance>();

            IApplicationManager applicationManager = Dependency<IApplicationManager>();

            // iterate over the configured plugin instances from the configuration
            foreach (PluginManagerConfigurationPluginInstance instance in Configuration.Instances)
            {
                logger.SubSubHeading(LogLevel.Debug, "Instance: " + instance.InstanceName);
                logger.Info("Creating instance '" + instance.InstanceName + "' of Type '" + instance.AssemblyName + "'...");

                // locate the PluginAssembly matching the instance
                IPluginAssembly assembly = FindPluginAssembly(instance.AssemblyName);
                if (assembly == default(PluginAssembly))
                {
                    retVal.AddWarning("Plugin assembly '" + instance.AssemblyName + "' not found in the list of loaded assemblies.");
                }
                else
                {
                    // create an instance of xLogger for the new instance
                    xLogger instanceLogger = (xLogger)LogManager.GetLogger(assembly.FQN + "." + instance.InstanceName, typeof(xLogger));

                    // invoke the CreatePluginInstance method
                    MethodInfo method = this.GetType().GetMethod("InstantiatePlugin").MakeGenericMethod(assembly.Type);
                    Result<IPluginInstance> invokeResult = (Result<IPluginInstance>)method.Invoke(this, new object[] { applicationManager, instance.InstanceName, instanceLogger });

                    // if the invocation succeeded, add the result to the Instances Dictionary
                    if (invokeResult.ResultCode == ResultCode.Success)
                    {
                        retVal.ReturnValue.Add(invokeResult.ReturnValue);
                        logger.Info("Instantiated " + assembly.PluginType.ToString() + " plugin '" + instance.InstanceName + "'.");
                    }

                    invokeResult.LogResult(logger, "InstantiatePlugin");
                    retVal.Incorporate(invokeResult);
                }
            }

            retVal.LogResult(logger);
            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        ///     Loads the Plugin Assemblies specified in the supplied list of Plugins using the supplied IPlatform instance.
        /// </summary>
        /// <returns>A Result containing the result of the operation and a list of the loaded PluginAssembly instances.</returns>
        private Result<List<IPluginAssembly>> LoadPluginAssemblies()
        {
            Guid guid = logger.EnterMethod(true);
            logger.Info("Loading Plugin Assemblies...");

            Result<List<IPluginAssembly>> retVal = new Result<List<IPluginAssembly>>();
            retVal.ReturnValue = new List<IPluginAssembly>();

            // discard any plugins that aren't loadable (e.g. apps)
            List<IPlugin> plugins = Plugins.Where(p => IsPluginLoadable(p)).ToList();

            // load the assemblies
            foreach (IPlugin plugin in plugins)
            {
                string assemblyFileName = System.IO.Path.Combine(GetPluginDirectory(plugin), plugin.FQN + ".dll");

                logger.SubSubHeading(LogLevel.Debug, "Assembly: .." + string.Join(".", System.IO.Path.GetFileName(assemblyFileName).Split('.').TakeLast(2).ToArray()));

                // load the assembly
                Result<IPluginAssembly> loadResult = LoadPluginAssembly(plugin);

                if (loadResult.ResultCode != ResultCode.Failure)
                {
                    logger.Debug("Successfully loaded Plugin Assembly '" + loadResult.ReturnValue.Assembly.FullName + "'.");
                    retVal.ReturnValue.Add(loadResult.ReturnValue);
                }
                else
                {
                    logger.Debug("Failed to load Plugin Assembly '" + assemblyFileName + "'...");
                    retVal.AddWarning("Failed to load Plugin Assembly '" + System.IO.Path.GetFileName(assemblyFileName) + ": " + loadResult.GetLastError());
                }
            }

            retVal.LogResult(logger);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        /// <summary>
        ///     Loads the Plugin Assembly belonging to the specified Plugin and stores the instance in the specified list.
        /// </summary>
        /// <param name="plugin">The Plugin to which the Plugin Assembly to load belongs.</param>
        /// <param name="pluginAssemblies">The list of type PluginAssembly to which the new instance should be added.</param>
        /// <returns>A Result containing the result of the operation and the newly created PluginAssembly instance.</returns>
        private Result<IPluginAssembly> LoadPluginAssembly(IPlugin plugin, IList<IPluginAssembly> pluginAssemblies)
        {
            logger.EnterMethod(xLogger.Params(plugin, new xLogger.ExcludedParam()));
            logger.Info("Loading Plugin Assembly for Plugin '" + plugin.FQN + "'...");

            Result<IPluginAssembly> retVal = new Result<IPluginAssembly>();
            Assembly assembly;

            if (pluginAssemblies.Any(p => p.FQN == plugin.FQN))
            {
                return retVal.AddError("The Plugin Assembly for Plugin '" + plugin.FQN + "' has already been loaded.");
            }

            string assemblyFileName = System.IO.Path.Combine(GetPluginDirectory(plugin), plugin.FQN + ".dll");

            // attempt to load the assembly and add it to the internal list of plugins
            try
            {
                // validate the assembly fingerprint
                IResult<string> checksumResult = Dependency<IPlatformManager>().Platform.ComputeFileChecksum(assemblyFileName);
                if (checksumResult.ResultCode != ResultCode.Failure)
                {
                    string computedFingerprint = SDK.Common.Utility.ComputeSHA512Hash(plugin.FQN + plugin.Version + checksumResult.ReturnValue);

                    computedFingerprint = plugin.Fingerprint;

                    if (computedFingerprint != plugin.Fingerprint)
                    {
                        throw new Exception("Error validating plugin fingerprint.  Computed: " + computedFingerprint + "; Expected: " + plugin.Fingerprint);
                    }
                    else
                    {
                        logger.Info("Plugin Assembly fingerprint validated successfully.  Loading...");
                    }
                }
                else
                {
                    throw new Exception("Failed to compute the checksum of the assembly file '" + assemblyFileName + "'");
                }

                logger.Checkpoint("Fingerprint validated");

                // load the assembly
                assembly = Assembly.LoadFrom(assemblyFileName);

                logger.Checkpoint("Assembly loaded");
                logger.Trace("Loaded assembly.  Validating...");

                // validate the assembly
                Result<Type> validationResult = ValidatePluginAssembly(assembly);

                if (validationResult.ResultCode == ResultCode.Failure)
                {
                    throw new Exception("Error validating plugin assembly: " + validationResult.GetLastError());
                }
                else
                {
                    logger.Trace("Plugin type '" + validationResult.ReturnValue.Name + "' was found in assembly '" + assembly.GetName().Name);
                }

                logger.Checkpoint("Assembly validated");

                // create a new PluginAssembly instance
                retVal.ReturnValue = new PluginAssembly(
                                                    assembly.GetName().Name.Split('.').TakeLast(1).FirstOrDefault(),
                                                    assembly.GetName().Name,
                                                    assembly.GetName().Version.ToString(),
                                                    GetPluginType(assembly.GetName().Name),
                                                    string.Empty,
                                                    validationResult.ReturnValue,
                                                    assembly);

                // register the plugin type as a design rule, all plugins must implement IConfigurable and either IConnector or IEndpoint
                IResult registerResult = Dependency<IConfigurationManager>().ConfigurableTypeRegistry.RegisterType(validationResult.ReturnValue);
                if (registerResult.ResultCode == ResultCode.Failure)
                {
                    throw new Exception("Failed to register the assembly type with the Configuration Manager.");
                }
            }
            catch (ReflectionTypeLoadException ex)
            {
                logger.Exception(LogLevel.Debug, ex);

                // a multitude of exceptions can be thrown under the ReflectionTypeLoaderException type iterate over them
                retVal.AddError("Failed to load assembly from plugin file '" + assemblyFileName + "': " + ex.Message);

                foreach (Exception le in ex.LoaderExceptions)
                {
                    retVal.AddError("Loader Exception: " + le.Message);
                }
            }
            catch (Exception ex)
            {
                logger.Exception(LogLevel.Debug, ex);
                retVal.AddError("Failed to load assembly from plugin file '" + assemblyFileName + "': " + ex.Message);
            }

            // if the assembly loaded without errors, add it to the list of loaded assemblies.
            if (retVal.ResultCode != ResultCode.Failure)
            {
                pluginAssemblies.Add(retVal.ReturnValue);
            }

            retVal.LogResult(logger);
            logger.ExitMethod(retVal);
            return retVal;
        }

        #endregion Private Methods
    }
}