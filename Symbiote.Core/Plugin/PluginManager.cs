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
      █  Copyright (C) 2016 JP Dillingham (jp@dillingham.ws)
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
using Symbiote.Core.Configuration;
using Symbiote.Core.Platform;
using Symbiote.Core.Plugin.Connector;
using Symbiote.Core.Plugin.Endpoint;
using NLog.xLogger;

namespace Symbiote.Core.Plugin
{
    /// <summary>
    /// Represents and manages the Plugin subsystem.
    /// </summary>
    public class PluginManager : Manager, IStateful, IManager, IConfigurable<PluginManagerConfiguration>, IPluginManager
    {
        #region Fields

        /// <summary>
        /// The Logger for this class.
        /// </summary>
        private static new xLogger logger = (xLogger)LogManager.GetCurrentClassLogger(typeof(xLogger));

        /// <summary>
        /// The Singleton instance of PluginManager.
        /// </summary>
        private static PluginManager instance;

        /// <summary>
        /// An array of loadable plugin types.
        /// </summary>
        /// <seealso cref="IsPluginLoadable(Plugin)"/>
        private static PluginType[] loadablePluginTypes = new PluginType[] { PluginType.Connector, PluginType.Endpoint };

        /// <summary>
        /// Lock object for installation/uninstallation of Plugins.
        /// </summary>
        private object installationLock = new object();

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PluginManager"/> class.  
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

            PluginAssemblies = new List<PluginAssembly>();
            PluginInstances = new Dictionary<string, IPluginInstance>();

            ChangeState(State.Initialized);

            logger.ExitMethod();
        }

        #endregion

        #region Properties

        #region IStateful Properties

        //// See the Manager class for the IStateful implementation for this class.

        #endregion

        #region IManager Properties

        //// See the Manager class for the IManager implementation for this class.

        #endregion

        #region IConfigurable Properties

        /// <summary>
        /// Gets the ConfigurationDefinition for the Manager.
        /// </summary>
        public ConfigurationDefinition ConfigurationDefinition
        {
            get
            {
                return GetConfigurationDefinition();
            }
        }

        /// <summary>
        /// Gets the Configuration for the Manager.
        /// </summary>
        public PluginManagerConfiguration Configuration { get; private set; }

        #endregion

        #region IPluginManager Properties

        /// <summary>
        /// Gets a list of currently loaded plugin assemblies.
        /// </summary>
        public List<PluginAssembly> PluginAssemblies { get; private set; }

        /// <summary>
        /// Gets a Dictionary of all Plugin Instances, keyed by instance name.
        /// </summary>
        public Dictionary<string, IPluginInstance> PluginInstances { get; private set; }

        /// <summary>
        /// Gets a list of installed plugins.
        /// </summary>
        public List<Plugin> Plugins { get; private set; }

        /// <summary>
        /// Gets a list of all Plugin Archives.
        /// </summary>
        public List<PluginArchive> PluginArchives { get; private set; }

        /// <summary>
        /// Gets a list of all invalid Plugin Archives.
        /// </summary>
        public List<InvalidPluginArchive> InvalidPluginArchives { get; private set; }

        #endregion

        #endregion

        #region Methods

        #region Public Methods

        #region Public Static Methods

        #region IConfigurable<T> Implementation

        /// <summary>
        /// Returns the ConfigurationDefinition for the Type.
        /// </summary>
        /// <returns>The ConfigurationDefinition for the Type.</returns>
        public static ConfigurationDefinition GetConfigurationDefinition()
        {
            ConfigurationDefinition retVal = new ConfigurationDefinition();
            retVal.Form = "[\"name\",\"email\",{\"key\":\"comment\",\"type\":\"textarea\",\"placeholder\":\"Make a comment\"},{\"type\":\"submit\",\"style\":\"btn-info\",\"title\":\"OK\"}]";
            retVal.Schema = "{\"type\":\"object\",\"title\":\"Comment\",\"properties\":{\"name\":{\"title\":\"Name\",\"type\":\"string\"},\"email\":{\"title\":\"Email\",\"type\":\"string\",\"pattern\":\"^\\\\S+@\\\\S+$\",\"description\":\"Email will be used for evil.\"},\"comment\":{\"title\":\"Comment\",\"type\":\"string\",\"maxLength\":20,\"validationMessage\":\"Don\'t be greedy!\"}},\"required\":[\"name\",\"email\",\"comment\"]}";
            retVal.Model = typeof(PluginManagerConfiguration);
            return retVal;
        }

        /// <summary>
        /// Returns the default instance of the configuration Model for the Type.
        /// </summary>
        /// <returns>The default instance of the configuration Model for the Type.</returns>
        public static PluginManagerConfiguration GetDefaultConfiguration()
        {
            PluginManagerConfiguration retVal = new PluginManagerConfiguration();
            retVal.Instances = new List<PluginManagerConfigurationPluginInstance>();

            PluginManagerConfigurationPluginInstance sim = new PluginManagerConfigurationPluginInstance();
            sim.InstanceName = "Simulation";
            sim.AssemblyName = "Symbiote.Plugin.Connector.Simulation";

            retVal.Instances.Add(sim);
            return retVal;
        }

        #endregion

        #endregion

        #region Public Instance Methods

        #region IStateful Implementation

        //// See the Manager class for the IStateful implementation for this class.

        #endregion

        #region IManager Implementation

        //// See the Manager class for the IManager implementation for this class.

        #endregion

        #region IConfigurable Implementation

        /// <summary>
        /// Configures the Manager using the configuration stored in the Configuration Manager, or, failing that, using the default configuration.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        public Result Configure()
        {
            logger.EnterMethod();
            Result retVal = new Result();

            Result<PluginManagerConfiguration> fetchResult = Dependency<IConfigurationManager>().GetInstanceConfiguration<PluginManagerConfiguration>(this.GetType());

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
                Result<PluginManagerConfiguration> createResult = Dependency<IConfigurationManager>().AddInstanceConfiguration<PluginManagerConfiguration>(this.GetType(), GetDefaultConfiguration());
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
        /// Configures the Manager using the supplied configuration, then saves the configuration to the Model Manager.
        /// </summary>
        /// <param name="configuration">The configuration with which the Model Manager should be configured.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public Result Configure(PluginManagerConfiguration configuration)
        {
            logger.EnterMethod(xLogger.Params(configuration));
            logger.Info("Retrieving and applying the configuration from the Configuration Manager...");

            Result retVal = new Result();

            // update the configuration
            Configuration = configuration;

            // populate the plugin list
            Plugins = Configuration.InstalledPlugins;

            logger.Debug("Successfully configured the Manager.");

            // save it
            logger.Debug("Saving the new configuration...");
            retVal.Incorporate(SaveConfiguration());

            retVal.LogResult(logger);
            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        /// Saves the configuration to the Configuration Manager.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        public Result SaveConfiguration()
        {
            logger.EnterMethod();
            logger.Info("Saving the configuration to the Configuration Manager...");

            Result retVal = new Result();

            // update the list of plugins
            Configuration.InstalledPlugins = Plugins;

            retVal.Incorporate(Dependency<IConfigurationManager>().UpdateInstanceConfiguration(this.GetType(), Configuration));

            retVal.LogResult(logger);
            logger.ExitMethod(retVal);
            return retVal;
        }

        #endregion

        #region IPluginManager Implementation

        #region Plugin and PluginArchive Management

        /// <summary>
        /// Refreshes the lists of valid and invalid Plugin Archives.
        /// </summary>
        /// <returns>An instance of PluginArchiveLoadResult.</returns>
        public PluginArchiveLoadResult ReloadPluginArchives()
        {
            Guid guid = logger.EnterMethod(true);

            logger.Info("Reloading Plugin Archives...");
            PluginArchiveLoadResult retVal = LoadPluginArchives();

            if (retVal.ResultCode != ResultCode.Failure)
            {
                PluginArchives = retVal.ValidArchives;
                InvalidPluginArchives = retVal.InvalidArchives;
            }

            retVal.LogResult(logger);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        /// <summary>
        /// Asynchronously installs the Plugin contained within the supplied PluginArchive.
        /// </summary>
        /// <param name="archive">The PluginArchive from which the Plugin is to be installed.</param>
        /// <returns>A Result containing the result of the operation and the installed Plugin.</returns>
        public async Task<Result<Plugin>> InstallPluginAsync(PluginArchive archive)
        {
            return await Task.Run(() => InstallPlugin(archive));
        }

        /// <summary>
        /// Installs the Plugin contained within the supplied PluginArchive.
        /// </summary>
        /// <param name="archive">The PluginArchive from which the Plugin is to be installed.</param>
        /// <param name="updatePlugin">When true, bypasses checks that prevent</param>
        /// <returns>A Result containing the result of the operation and the installed Plugin.</returns>
        public Result<Plugin> InstallPlugin(PluginArchive archive, bool updatePlugin = false)
        {
            return InstallPlugin(archive, Plugins, Dependency<IPlatformManager>().Platform, updatePlugin);
        }

        /// <summary>
        /// Asynchronously uninstalls the supplied plugin by deleting the directory using the default IPlatform, then removes it from the default
        /// PluginManagerConfiguration.
        /// </summary>
        /// <param name="plugin">The Plugin to uninstall.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public async Task<Result> UninstallPluginAsync(Plugin plugin)
        {
            return await Task.Run(() => UninstallPlugin(plugin));
        }

        /// <summary>
        /// Uninstalls the supplied plugin by deleting the directory using the default IPlatform, then removes it from the default 
        /// PluginManagerConfiguration.
        /// </summary>
        /// <param name="plugin">The Plugin to uninstall.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public Result UninstallPlugin(Plugin plugin)
        {
            return UninstallPlugin(plugin, Plugins, Dependency<IPlatformManager>().Platform);
        }

        /// <summary>
        /// Asynchronously reinstalls the specified Plugin by uninstalling, then installing from the original archive.
        /// </summary>
        /// <param name="plugin">The Plugin to reinstall.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public async Task<Result> ReinstallPluginAsync(Plugin plugin)
        {
            return await Task.Run(() => ReinstallPlugin(plugin));
        }

        /// <summary>
        /// Reinstalls the specified Plugin by uninstalling, then installing from the original archive.
        /// </summary>
        /// <param name="plugin">The Plugin to reinstall.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public Result ReinstallPlugin(Plugin plugin)
        {
            Guid guid = logger.EnterMethod(xLogger.Params(plugin), true);

            logger.Info("Reinstalling Plugin '" + plugin.FQN + "'...");
            Result retVal = new Result();

            logger.Debug("Attempting to locate the Plugin Archive for the supplied Plugin...");
            PluginArchive foundArchive = PluginArchives.Where(p => p.Plugin.FQN == plugin.FQN).FirstOrDefault();
            if (foundArchive == default(PluginArchive))
            {
                retVal.AddError("Unable to locate the Plugin Archive for the supplied Plugin.  The Plugin can not be reinstalled.");
            }
            else
            {
                logger.Debug("Uninstalling the Plugin...");
                retVal.Incorporate(UninstallPlugin(plugin));

                logger.Debug("Reinstalling the Plugin...");
                if (retVal.ResultCode != ResultCode.Failure)
                {
                    retVal.Incorporate(InstallPlugin(foundArchive));
                }
            }

            retVal.LogResult(logger);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        /// <summary>
        /// Asynchronously Updates the Plugin contained within the specified PluginArchive.
        /// </summary>
        /// <param name="archive">The PluginArchive to use for the update.</param>
        /// <returns>A Result containing the result of the operation and the updated Plugin.</returns>
        public async Task<Result<Plugin>> UpdatePluginAsync(PluginArchive archive)
        {
            return await Task.Run(() => UpdatePlugin(archive));
        }

        /// <summary>
        /// Updates the Plugin contained within the specified PluginArchive.
        /// </summary>
        /// <param name="archive">The PluginArchive to use for the update.</param>
        /// <returns>A Result containing the result of the operation and the updated Plugin.</returns>
        public Result<Plugin> UpdatePlugin(PluginArchive archive)
        {
            return InstallPlugin(archive, true);
        }

        /// <summary>
        /// Searches the Plugins list for a Plugin with an FQN matching the supplied FQN and returns it if found.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Plugin to find.</param>
        /// <returns>The Plugin matching the supplied FQN, or the default Plugin if not found.</returns>
        public Plugin FindPlugin(string fqn)
        {
            return FindPlugin(fqn, Plugins);
        }

        #endregion

        #region Plugin Assembly Management

        /// <summary>
        /// Loads the Plugin Assembly belonging to the specified Plugin and stores the instance in the PluginAssemblies list.
        /// </summary>
        /// <param name="plugin">The Plugin to which the Plugin Assembly to load belongs.</param>
        /// <returns>A Result containing the result of the operation and the newly created PluginAssembly instance.</returns>
        public Result<PluginAssembly> LoadPluginAssembly(Plugin plugin)
        {
            return LoadPluginAssembly(plugin, PluginAssemblies);
        }

        /// <summary>
        /// Finds and returns the PluginAssembly in the PluginAssemblies list whose FQN matches the specified FQN.
        /// </summary>
        /// <param name="fqn">The FQN of the desired PluginAssembly.</param>
        /// <returns>The PluginAssembly instance whose FQN matches the specified FQN, or the default PluginAssembly if not found.</returns>
        public PluginAssembly FindPluginAssembly(string fqn)
        {
            return FindPluginAssembly(fqn, PluginAssemblies);
        }

        #endregion

        #region Plugin Instance Management

        /// <summary>
        /// Creates and returns an instance of the specified plugin type with the specified name
        /// </summary>
        /// <remarks>
        /// <para>
        ///     The instanceName is propagated through the plugin instance and any internal reference (such as a ConnectorItem).  This name
        ///     should match references to the plugin, either through fully qualified addressing or configuration.
        /// </para>
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
        /// Given an instance name string, return the matching instance of IPluginInstance.
        /// </summary>
        /// <param name="instanceName">The name of the instance to find.</param>
        /// <param name="pluginType">The Type of instance to find.</param>
        /// <returns>The instance of IPluginInstance matching the requested InstanceName.</returns>
        public IPluginInstance FindPluginInstance(string instanceName, PluginType pluginType = PluginType.Connector)
        {
            // return PluginInstances.Where(p => p.PluginType == pluginType).Where(p => p.InstanceName == instanceName).FirstOrDefault();
            if (PluginInstances.ContainsKey(instanceName))
            {
                return PluginInstances[instanceName];
            }
            else
            {
                return null;
            }
        }

        #endregion

        /// <summary>
        /// Attempts to resolve the supplied plugin item Fully Qualified Name to an instance of Item contained in a Connector plugin.
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

        #endregion

        #endregion

        #endregion

        #region Protected Methods

        #region Protected Instance Methods

        /// <summary>
        /// Executed upon instantiation of all program Managers.  Not implemented.
        /// </summary>
        /// <param name="managerInstances"></param>
        /// <returns>A Result containing the result of the operation.</returns>
        protected override Result Setup(List<IManager> managerInstances)
        {
            return new Result();
        }

        /// <summary>
        /// <para>
        /// Executed upon startup of the Manager.
        /// </para>
        /// <para>
        ///     Configures the Manager using the Configuration Manager, generates a list of the available Plugin Archives,
        ///     loads installed Plugin Assemblies and registers them for configuration, and instantiates configured Plugin
        ///     Instances.
        /// </para>
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        protected override Result Startup()
        {
            Guid guid = logger.EnterMethod(true);
            logger.Debug("Performing Startup for '" + GetType().Name + "'...");
            Result retVal = new Result();

            // Configure the manager
            Result configureResult = Configure();
            if (configureResult.ResultCode == ResultCode.Failure)
            {
                throw new Exception("Failed to start the Plugin Manager: " + configureResult.GetLastError());
            }

            retVal.Incorporate(configureResult);
            logger.Checkpoint("Configured the Plugin Manager", guid);

            // generate a list of valid archive files in the archive directory 
            logger.SubSubHeading(LogLevel.Debug, "Archives...");

            PluginArchiveLoadResult pluginArchiveLoadResult = LoadPluginArchives();

            if (pluginArchiveLoadResult.ResultCode != ResultCode.Failure)
            {
                PluginArchives = pluginArchiveLoadResult.ValidArchives;
                InvalidPluginArchives = pluginArchiveLoadResult.InvalidArchives;
            }

            retVal.Incorporate(pluginArchiveLoadResult);

            // print the lists of valid and invalid archives
            if (PluginArchives.Count > 0)
            {
                logger.Info("Valid Plugin Archives:");
            }

            foreach (PluginArchive archive in PluginArchives)
            {
                logger.Info("\t" + System.IO.Path.GetFileName(archive.FileName) + " (" + archive.Plugin.FQN + ")");
            }

            if (InvalidPluginArchives.Count > 0)
            {
                logger.Info("Invalid Plugin Archives:");
            }

            foreach (InvalidPluginArchive invalidArchive in InvalidPluginArchives)
            {
                logger.Info(new string(' ', 5) + System.IO.Path.GetFileName(invalidArchive.FileName) + " (" + invalidArchive.Message + ")");
            }

            logger.Info(PluginArchives.Count + " Plugin " + (PluginArchives.Count == 1 ? "Archive" : "Archives") + " loaded.");

            logger.Checkpoint("Plugin Archives loaded", xLogger.Vars(PluginArchives, InvalidPluginArchives), xLogger.Names("PluginArchives", "InvalidPluginArchives"), guid);

            // load installed plugin assemblies into memory and register them with the configuration manager
            logger.SubSubHeading(LogLevel.Debug, "Assemblies...");

            Result<List<PluginAssembly>> pluginAssemblyLoadResult = LoadPluginAssemblies();

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

            foreach (PluginAssembly assembly in PluginAssemblies)
            {
                logger.Info(new string(' ', 5) + assembly.FQN);
            }

            logger.Info(PluginAssemblies.Count + " Plugin " + (PluginAssemblies.Count == 1 ? "Assembly" : "Assemblies") + " loaded.");

            logger.Checkpoint("Plugin Assemblies loaded", xLogger.Vars(PluginAssemblies), xLogger.Names("PluginAssemblies"), guid);
            
            // instantiate all of the configured Plugin instances
            logger.SubSubHeading(LogLevel.Debug, "Instances...");

            Result<Dictionary<string, IPluginInstance>> pluginInstantiationResult = InstantiatePlugins();

            if (pluginInstantiationResult.ResultCode != ResultCode.Failure)
            {
                PluginInstances = pluginInstantiationResult.ReturnValue;
            }

            // print the list of instantiated plugins
            if (PluginInstances.Count > 0)
            {
                logger.Info("Plugin Instances:");
            }

            foreach (string key in PluginInstances.Keys)
            {
                logger.Info(new string(' ', 5) + key + " (" + PluginInstances[key].FQN + ")");
            }

            logger.Info(PluginInstances.Count + " Plugin" + (PluginInstances.Count > 1 ? "s" : string.Empty) + " instantiated.");

            logger.Checkpoint("Plugins instantiated", xLogger.Vars(PluginInstances), xLogger.Names("PluginInstances"), guid);

            Dependency<IPlatformManager>().Platform.InstantiateConnector("Platform");
            PluginInstances.Add("Platform", Dependency<IPlatformManager>().Platform.Connector);

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        /// <summary>
        /// Executed upon shutdown of the Manager.
        /// </summary>
        /// <param name="stopType">The nature of the stoppage.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        protected override Result Shutdown(StopType stopType = StopType.Stop)
        {
            Guid guid = logger.EnterMethod(true);
            logger.Debug("Performing Shutdown for '" + GetType().Name + "'...");
            Result retVal = new Result();

            // re-initialize/nullify all properties
            PluginAssemblies = new List<PluginAssembly>();
            PluginInstances = new Dictionary<string, IPluginInstance>();
            Plugins = null;
            PluginArchives = null;
            InvalidPluginArchives = null;

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        #endregion

        #endregion

        #region Private Methods

        #region Private Static Methods
        
        /// <summary>
        /// Instantiates and/or returns the PluginManager instance.
        /// </summary>
        /// <remarks>
        /// Invoked via reflection from ApplicationManager.  The parameters are used to build an array of IManager parameters which are then passed
        /// to this method.  To specify additional dependencies simply insert them into the parameter list for the method and they will be 
        /// injected when the method is invoked.
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
        /// Evaluates the supplied assembly name for correctness and returns an error message if it is incorrect.
        /// </summary>
        /// <remarks>
        /// The expected format of an assembly name is:  "Symbiote.Plugin.[Connector|Service].{PluginName}"
        /// The third tuple may match any enumerated value in PluginType.
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
                retVal.AddError("Invalid application identifier (required: Symbiote, supplied: " + name[0] + ")");
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
        /// Determines whether the supplied assembly is a valid plugin, and if so, returns the plugin type.
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
        /// Returns an enumeration instance representing the type of the plugin, derived from the third tuple of the plugin name.
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
        /// Returns the base directory in which the specified Plugin should be installed, based on the type and name of the 
        /// specified Plugin.
        /// </summary>
        /// <param name="plugin">The Plugin for which the directory is to be returned.</param>
        /// <returns>The directory in which the specified Plugin should be installed.</returns>
        private static string GetPluginDirectory(Plugin plugin)
        {
            if (plugin.PluginType == PluginType.App)
            {
                return System.IO.Path.Combine(ApplicationManager.GetInstance().GetManager<IPlatformManager>().Directories.Web, plugin.Name);
            }
            else
            {
                return System.IO.Path.Combine(ApplicationManager.GetInstance().GetManager<IPlatformManager>().Directories.Plugins, plugin.PluginType.ToString(), plugin.Name);
            }
        }

        /// <summary>
        /// Returns true if the supplied Plugin is capable of being loaded, false otherwise.
        /// </summary>
        /// <param name="plugin">The Plugin to check.</param>
        /// <returns>True if the Plugin is capable of being loaded, false otherwise.</returns>
        /// <seealso cref="loadablePluginTypes"/>
        private static bool IsPluginLoadable(Plugin plugin)
        {
            return loadablePluginTypes.Contains(plugin.PluginType);
        }

        #region Settings

        /// <summary>
        /// Retrieves the PluginArchiveConfigurationFileName setting or substitutes "SymbiotePlugin.json" if retrieval fails.
        /// </summary>
        /// <returns>The name of the Plugin Archive configuration file.</returns>
        private static string GetPluginArchiveConfigurationFileName()
        {
            return Utility.GetSetting("PluginArchiveConfigurationFileName", "SymbiotePlugin.json");
        }

        /// <summary>
        /// Retrieves the PluginArchivePayloadFileName setting or substitutes "Plugin.zip" if retrieval fails.
        /// </summary>
        /// <returns>The name of the Plugin payload file contained within a Plugin Archive.</returns>
        private static string GetPluginArchivePayloadFileName()
        {
            return Utility.GetSetting("PluginArchivePayloadFileName", "Plugin.zip");
        }

        /// <summary>
        /// Retrieves the PluginArchiveExtension setting or substitutes "*.zip" if retrieval fails.
        /// </summary>
        /// <returns>The wildcard mask of the file extension for Plugin Archives.</returns>
        private static string GetPluginArchiveExtension()
        {
            return Utility.GetSetting("PluginArchiveExtension", "*.zip");
        }

        #endregion

        #endregion

        #region Private Instance Methods

        /// <summary>
        /// Loads all valid Plugin Archives in the archive directory into a list of type PluginArchive and returns it.
        /// </summary>
        /// <returns>An instance of PluginArchiveLoadResult.</returns>
        private PluginArchiveLoadResult LoadPluginArchives()
        {
            return LoadPluginArchives(Dependency<IPlatformManager>().Directories.Archives, GetPluginArchiveExtension(), Dependency<IPlatformManager>().Platform);
        }

        /// <summary>
        /// Loads all valid Plugin Archives matching the supplied searchPattern in the supplied directory using the supplied IPlatform 
        /// into a list of type PluginArchive and returns it.
        /// </summary>
        /// <param name="directory">The directory to search.</param>
        /// <param name="searchPattern">The file extension of Plugin Archives.</param>
        /// <param name="platform">The IPlatform instance to use to perform the search.</param>
        /// <returns>An instance of PluginArchiveLoadResult.</returns>
        private PluginArchiveLoadResult LoadPluginArchives(string directory, string searchPattern, IPlatform platform)
        {
            Guid guid = logger.EnterMethod(xLogger.Params(directory, searchPattern, platform), true);

            logger.Info("Loading Plugin Archives...");
            PluginArchiveLoadResult retVal = new PluginArchiveLoadResult();

            // retrieve a list of probable plugin archive files from the configured plugin archive directory
            logger.Trace("Listing matching files...");
            Result<List<string>> searchResult = platform.ListFiles(directory, searchPattern);
            logger.Debug("Found " + searchResult.ReturnValue.Count + " Archives.");

            retVal.Incorporate(searchResult);

            // iterate over the list of found files
            foreach (string fileName in searchResult.ReturnValue)
            {
                logger.SubSubHeading(LogLevel.Debug, "Archive: .." + string.Join(".", System.IO.Path.GetFileName(fileName).Split('.').TakeLast(2).ToArray()));
                logger.Debug("Parsing Archive file '" + fileName + "'...");

                // parse the current plugin archive file
                Result<PluginArchive> parseResult = ParsePluginArchive(fileName);

                if (parseResult.ResultCode != ResultCode.Failure)
                {
                    parseResult.ReturnValue.SetFileName(System.IO.Path.GetFileName(fileName));
                    retVal.ValidArchives.Add(parseResult.ReturnValue);
                }
                else
                {
                    retVal.InvalidArchives.Add(new InvalidPluginArchive(System.IO.Path.GetFileName(fileName), parseResult.GetLastError()));
                }

                parseResult.LogResult(logger.Debug, "ParsePluginArchive");
            }

            retVal.LogResult(logger);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        /// <summary>
        /// Parses a Plugin Archive file into a PluginArchive object and validates it using default parameters.
        /// </summary>
        /// <param name="fileName">The Plugin Archive file to parse.</param>
        /// <returns>A Result containing the result of the operation and the parsed PluginArchive.</returns>
        private Result<PluginArchive> ParsePluginArchive(string fileName)
        {
            return ParsePluginArchive(fileName, GetPluginArchiveConfigurationFileName(), GetPluginArchivePayloadFileName(), Dependency<IPlatformManager>().Platform);
        }

        /// <summary>
        /// Parses a Plugin Archive file into a PluginArchive object and validates it.
        /// </summary>
        /// <param name="fileName">The Plugin Archive file to parse.</param>
        /// <param name="configFileName">The name of the Plugin config file expected to be found within the archive.</param>
        /// <param name="payloadFileName">The name of the file containing the Plugin files expected to be found within the archive.</param>
        /// <param name="platform">The IPlatform instance to use to carry out the parse.</param>
        /// <returns>A Result containing the result of the operation and the parsed PluginArchive.</returns>
        private Result<PluginArchive> ParsePluginArchive(string fileName, string configFileName, string payloadFileName, IPlatform platform)
        {
            Guid guid = logger.EnterMethod(xLogger.Params(fileName, configFileName, payloadFileName, platform), true);

            logger.Trace("Parsing Plugin Archive '" + fileName + "'...");

            Result<PluginArchive> retVal = new Result<PluginArchive>();
            retVal.ReturnValue = new PluginArchive(fileName);

            // retrieve the contents of the configuration file and deserialize it to an instance of Plugin
            logger.Trace("Retrieving the configuration file...");
            Result<List<string>> zipFileListResult = platform.ListZipFiles(fileName, configFileName);
            if (zipFileListResult.ResultCode != ResultCode.Failure)
            {
                // ensure that a file named configFileName exists within the archive
                string foundConfigFile = zipFileListResult.ReturnValue.FirstOrDefault();
                if (foundConfigFile != default(string))
                {
                    logger.Trace("Configuration file found.  Extracting it from the archive...");

                    // extract the config file to the temp directory
                    Result<string> extractConfigFileResult = platform.ExtractZipFile(fileName, foundConfigFile, Dependency<IPlatformManager>().Directories.Temp);
                    if (extractConfigFileResult.ResultCode != ResultCode.Failure)
                    {
                        logger.Trace("File extracted successfully.  Attempting to read contents...");
                        
                        // read the contents of the file
                        Result<string> readConfigFileResult = platform.ReadFile(extractConfigFileResult.ReturnValue);
                        if (readConfigFileResult.ResultCode != ResultCode.Failure)
                        {
                            // the contents of the config file are in readConfigFileResult.ReturnValue.  try to deserialize it..
                            try
                            {
                                logger.Trace("File contents read.  Attempting to deserialize...");
                                retVal.ReturnValue.SetPlugin(Newtonsoft.Json.JsonConvert.DeserializeObject<Plugin>(readConfigFileResult.ReturnValue));
                            }
                            catch (Exception ex)
                            {
                                retVal.AddError("Failed to deserialize the contents of the configuration file.");
                                logger.Exception(LogLevel.Debug, ex, guid);
                            }
                        }
                        else
                        {
                            retVal.AddError("Failed to read the contents of the extracted file.");
                        }
                    }
                    else
                    {
                        retVal.AddError("Failed to extract the configuration file.");
                    }
                }
                else
                {
                    retVal.AddError("The file does not contain a valid plugin configuration file.");
                }
            }
            else
            {
                retVal.AddError("Failed to retrieve a list of files from zip file.");
            }

            // clean up the temp directory.  this will fail if the file wasn't extracted but we don't care.
            logger.Trace("Cleaning up the temp directory...");
            platform.DeleteFile(System.IO.Path.Combine(Dependency<IPlatformManager>().Directories.Temp, configFileName));

            // if we've encountered any errors, bail out.
            if (retVal.ResultCode == ResultCode.Failure)
            {
                logger.ExitMethod(retVal, guid);
                return retVal;
            }

            logger.Checkpoint("Retrieved configuration file", xLogger.Vars(retVal.ReturnValue.Plugin), xLogger.Names("Plugin"), guid);

            // create a place to stash the payload checksum
            string payloadChecksum = string.Empty;

            // ensure the plugin contains the Plugin.zip file and calculate its checksum
            logger.Trace("Looking for the Plugin payload file...");
            Result<List<string>> zipPayloadCheckResult = platform.ListZipFiles(fileName, payloadFileName);
            if (zipPayloadCheckResult.ResultCode != ResultCode.Failure)
            {
                // ensure that the payload file exists within the zip
                string foundPayloadFile = zipPayloadCheckResult.ReturnValue.FirstOrDefault();
                if (foundPayloadFile != default(string))
                {
                    logger.Trace("Payload file found.  Attempting to extract...");

                    // extract the file to the temp directory
                    Result<string> extractPayloadResult = platform.ExtractZipFile(fileName, foundPayloadFile, Dependency<IPlatformManager>().Directories.Temp);
                    if (extractPayloadResult.ResultCode != ResultCode.Failure)
                    {
                        logger.Trace("Payload file extracted.  Attempting to calculate checksum...");

                        // compute the checksum of the file
                        Result<string> payloadChecksumResult = platform.ComputeFileChecksum(extractPayloadResult.ReturnValue);
                        if (payloadChecksumResult.ResultCode != ResultCode.Failure)
                        {
                            logger.Trace("Payload checksum: " + payloadChecksumResult.ReturnValue);
                            payloadChecksum = payloadChecksumResult.ReturnValue;
                        }
                        else
                        {
                            retVal.AddError("Failed to compute the checksum of the payload: " + payloadChecksumResult.GetLastError());
                        }

                        // if the plugin archive contains a Connector or Endpoint, make sure the zip file contains a .dll with the proper name.
                        if ((retVal.ReturnValue.Plugin.PluginType == PluginType.Connector) || (retVal.ReturnValue.Plugin.PluginType == PluginType.Connector))
                        {
                            logger.Trace("The Plugin contains a binary.  Make sure it exists...");

                            Result<List<string>> zipFileDllResult = platform.ListZipFiles(extractPayloadResult.ReturnValue, "*.dll");
                            if (zipFileDllResult.ResultCode != ResultCode.Failure)
                            {
                                if (zipFileDllResult.ReturnValue.Where(d => d == retVal.ReturnValue.Plugin.FQN + ".dll").FirstOrDefault() == default(string))
                                {
                                    retVal.AddError("The archive does not contain a dll with the expected name (" + retVal.ReturnValue.Plugin.FQN + ".dll)");
                                }
                            }

                            retVal.Incorporate(zipFileDllResult);
                        }
                    }
                    else
                    {
                        retVal.AddError("Failed to extract the payload from the archive: " + extractPayloadResult.GetLastError());
                    }
                }
                else
                {
                    retVal.AddError("The file does not contain a valid payload.");
                }
            }
            else
            {
                retVal.AddError("Failed to retrieve a list of files from zip file: " + zipPayloadCheckResult.GetLastError());
            }

            // clean up the temp directory.  this will fail if the file wasn't extracted but we don't care.
            logger.Trace("Cleaning up the temp directory (again)...");
            platform.DeleteFile(System.IO.Path.Combine(Dependency<IPlatformManager>().Directories.Temp, payloadFileName));

            // if we've encountered any errors up to this point, bail out.
            if (retVal.ResultCode == ResultCode.Failure)
            {
                logger.ExitMethod(retVal, guid);
                return retVal;
            }

            logger.Checkpoint("Validated payload file", guid);

            // validate the deserialized Plugin.
            logger.Trace("Validating Plugin contents...");
            Plugin p = retVal.ReturnValue.Plugin;

            if (p.FQN != System.IO.Path.GetFileNameWithoutExtension(fileName))
            {
                retVal.AddError("The filename doesn't match the FQN of the plugin.");
            }

            if (p.Name == string.Empty)
            {
                retVal.AddError("The Name field is blank.");
            }

            if (p.FQN == string.Empty)
            {
                retVal.AddError("The FQN field is blank.");
            }

            if (p.Version == string.Empty)
            {
                retVal.AddError("The Version field is null or invalid.");
            }

            if (p.PluginType == default(PluginType))
            {
                retVal.AddError("The PluginType field is invalid (expected: Connector, Endpoint or App, actual: " + p.PluginType + ").");
            }

            if (p.Fingerprint.Length != 64)
            {
                retVal.AddError("The Fingerprint field is invalid (expected length: 64, actual: " + p.Fingerprint.Length + ").");
            }

            // validate the FQN
            string[] sfqn = p.FQN.Split('.');
            if (sfqn[0] != Dependency<IApplicationManager>().ProductName)
            {
                retVal.AddError("The FQN field doesn't start with '" + Dependency<IApplicationManager>().ProductName + "'.");
            }

            if (sfqn[1] != "Plugin")
            {
                retVal.AddError("The second tuple of the FQN isn't 'Plugin'.");
            }

            if (sfqn[2] != p.PluginType.ToString())
            {
                retVal.AddError("The third tuple of the FQN doesn't agree with the PluginType field (FQN: '" + sfqn[2] + "'; PluginType: '" + p.PluginType + "').");
            }

            if (sfqn[3] != p.Name)
            {
                retVal.AddError("The final tuple of the FQN doesn't agree with the Name field (Name: '" + p.Name + "'; FQN: '" + sfqn[3] + "').");
            }
            
            logger.Checkpoint("Validated Plugin json", guid);

            // validate the fingerprint.
            logger.Trace("Validating Plugin fingerprint...");

            logger.Trace("ADD THIS BACK IN");
            
            logger.Checkpoint("Validated Plugin fingerprint", guid);

            retVal.LogResult(logger.Trace);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        /// <summary>
        /// <para>
        /// Installs the Plugin contained within the supplied PluginArchive using the supplied IPlatform and adds the installed Plugin to the
        /// supplied PluginManagerConfiguration.
        /// </para>
        /// <para>
        /// Prior to installing, the Plugin Archive is re-parsed to ensure it did not changed between the time it was loaded into the PluginArchives
        /// list and when installation was requested.  If the Plugin within the archive is the same as the loaded plugin, installation continues, otherwise
        /// the operation fails and requests that the user refreshes the list.
        /// </para>
        /// </summary>
        /// <param name="archive">The PluginArchive from which the Plugin is to be installed.</param>
        /// <param name="plugins">The List of type Plugin to which the installed Plugin should be added.</param>
        /// <param name="platform">The IPlatform instance with which the archive should be extracted.</param>
        /// <param name="updatePlugin">When true, bypasses checks that prevent duplicate installations.</param>
        /// <returns>A Result containing the result of the operation and the created Plugin instance.</returns>
        private Result<Plugin> InstallPlugin(PluginArchive archive, List<Plugin> plugins, IPlatform platform, bool updatePlugin = false)
        {
            Guid guid = logger.EnterMethod(xLogger.Params(archive, new xLogger.ExcludedParam(), new xLogger.ExcludedParam(), updatePlugin), true);

            logger.Info("Installing Plugin '" + archive.Plugin.FQN + "' from archive '" + System.IO.Path.GetFileName(archive.FileName) + "'...");
            Result<Plugin> retVal = new Result<Plugin>();

            string fullFileName = System.IO.Path.Combine(Dependency<IPlatformManager>().Directories.Archives, archive.FileName);

            // check to see if the app is installed already
            Plugin foundPlugin = FindPlugin(archive.Plugin.FQN);
            if (foundPlugin != default(Plugin))
            {
                // plugin was found.  If we aren't updating then add an error.
                if (!updatePlugin)
                {
                    retVal.AddError("A Plugin with the name '" + archive.Plugin.Name + "' is already installed.");
                }
                else
                {
                    // we are updating.  Make sure the plugins have the same Name, FQN and PluginType.
                    // updated plugins are expected to be different among Version and Fingerprint.
                    Plugin p = foundPlugin;
                    Plugin a = archive.Plugin;
                    if ((p.Name != a.Name) || (p.FQN != a.FQN) || (p.PluginType != a.PluginType))
                    {
                        retVal.AddError("The archive '" + System.IO.Path.GetFileName(archive.FileName) + "' can't be used to update the Plugin '" + foundPlugin.FQN + "'; one or more of the Name, FQN or PluginType fields are different.");
                    }
                }
            }

            // if we've encountered an error, either the plugin is installed and the updatePlugin flag wasn't true, or it was true
            // and the old and new plugins are mismatched.
            if (retVal.ResultCode == ResultCode.Failure)
            {
                retVal.LogResult(logger);
                logger.ExitMethod(retVal, guid);
                return retVal;
            }
            
            // re-validate the file; it may have changed between the time it was loaded and when installation was requested.
            logger.Debug("Re-parsing the archive to ensure that it hasn't changed since it was loaded.");
            Result<PluginArchive> parseResult = ParsePluginArchive(System.IO.Path.Combine(Dependency<IPlatformManager>().Directories.Archives, archive.FileName));
            if (parseResult.ResultCode != ResultCode.Failure)
            {
                if (!parseResult.ReturnValue.Plugin.Equals(archive.Plugin))
                {
                    retVal.AddError("The archive '" + System.IO.Path.GetFileName(archive.FileName) + "' has changed since it was loaded.  Refresh Plugin Archives and try again.");
                }
            }

            retVal.Incorporate(parseResult);

            // exit if we encountered an error
            if (retVal.ResultCode == ResultCode.Failure)
            {
                retVal.LogResult(logger);
                logger.ExitMethod(retVal, guid);
                return retVal;
            }

            logger.Checkpoint("Re-parse succeeded", guid);
            
            // determine the destination folders
            logger.Debug("Determining output directories...");
            string tempDestination;
            string destination;

            tempDestination = System.IO.Path.Combine(Dependency<IPlatformManager>().Directories.Temp, archive.Plugin.FQN);

            // ..\Web\AppName
            if (archive.Plugin.PluginType == PluginType.App)
            {
                destination = System.IO.Path.Combine(Dependency<IPlatformManager>().Directories.Web, archive.Plugin.Name);
            }
            else
            {
                // ..\Plugins\(Connector|Endpoint)\AppName
                destination = System.IO.Path.Combine(Dependency<IPlatformManager>().Directories.Plugins, archive.Plugin.PluginType.ToString(), archive.Plugin.Name);
            }

            logger.Debug("Output folders: Temp: '" + tempDestination + "'; Plugin: '" + destination + "'");

            logger.Checkpoint("Destination folders", xLogger.Vars(tempDestination, destination), xLogger.Names("tempDestination", "destination"), guid);
            
            // extract the archive; first to the temp directory, then extract the payload to the plugin destination and copy the configuration file
            logger.Info("Extracting '" + System.IO.Path.GetFileName(fullFileName) + "' to '" + tempDestination.Replace(Dependency<IPlatformManager>().Directories.Root, string.Empty) + "'...");

            Result extractResult;
            Result payloadExtractResult;

            // lock the file system and InstalledPlugins manipulation to ensure thread safety
            lock (installationLock)
            {
                // extract the archive to the temp directory
                logger.Debug("Extracting the archive to the temp directory...");
                extractResult = platform.ExtractZip(fullFileName, tempDestination, true);
                if (extractResult.ResultCode != ResultCode.Failure)
                {
                    // ensure the payload archive was extracted properly
                    logger.Debug("Checking to ensure the payload file was extracted...");
                    string payloadFileName = System.IO.Path.Combine(tempDestination, GetPluginArchiveConfigurationFileName());
                    if (platform.FileExists(payloadFileName))
                    {
                        // extract the payload archive to the plugin destination
                        logger.Debug("Extracting the payload file to the Plugin destination...");
                        payloadExtractResult = platform.ExtractZip(System.IO.Path.Combine(tempDestination, GetPluginArchivePayloadFileName()), destination, true);
                        if (payloadExtractResult.ResultCode != ResultCode.Failure)
                        {
                            logger.Debug("Payload extracted successfully.");

                            // the payload extracted without any issues.  if the plugin is a binary, calculate the checksum of the dll
                            // and store it in the Fingerprint field.
                            if ((archive.Plugin.PluginType == PluginType.Connector) || (archive.Plugin.PluginType == PluginType.Endpoint))
                            {
                                // locate the plugin assembly among the extracted files.
                                // a valid assembly is named 'FQN.dll' where FQN is the FQN of the plugin 
                                logger.Debug("Attempting to locate the extracted assembly...");
                                Result<List<string>> findDllResult = platform.ListFiles(destination, "*.dll");
                                if (findDllResult.ResultCode != ResultCode.Failure)
                                {
                                    logger.Debug("Trying to fetch '" + archive.Plugin.FQN + ".dll' from the list of files...");
                                    string dllFile = findDllResult.ReturnValue.Where(f => System.IO.Path.GetFileName(f) == archive.Plugin.FQN + ".dll").FirstOrDefault();

                                    if (dllFile != default(string))
                                    {
                                        // the plugin assembly was found.  calculate the fingerprint.
                                        logger.Debug("Assembly found.  Calculating checksum for the Plugin fingerprint...");
                                        Result<string> checksumResult = platform.ComputeFileChecksum(dllFile);
                                        if (checksumResult.ResultCode != ResultCode.Failure)
                                        {
                                            logger.Trace("Checksum: " + checksumResult.ReturnValue);

                                            // create the fingerprint.
                                            // hash the SHA256 of the dll with the FQN and version of the plugin
                                            // because we've already passed the more rigorous check using the FingerprintValidator, we only need to save
                                            // the hash of the file that came from the zip to ensure it is not tampered with.
                                            string hash = Utility.ComputeHash(archive.Plugin.FQN + archive.Plugin.Version + checksumResult.ReturnValue);
                                            logger.Trace("Hash: " + hash);

                                            // set the fingerprint
                                            archive.Plugin.SetFingerprint(hash);

                                            // add the plugin to the list of installed plugins
                                            logger.Debug("Adding the installed Plugin to the InstalledPlugin list...");
                                            retVal.ReturnValue = archive.Plugin;
                                            plugins.Add(retVal.ReturnValue);
                                        }
                                    }
                                    else
                                    {
                                        retVal.AddError("Error calculating checksum for Plugin fingerprint; unable to find the plugin assembly in the destination directory.");
                                    }
                                }
                                else
                                {
                                    retVal.AddError("Failed to calculate checksum for the plugin assembly; unable to list the files in the destination directory.");
                                }

                                retVal.Incorporate(findDllResult);
                            }
                        }

                        retVal.Incorporate(payloadExtractResult);
                    }
                    else
                    {
                        retVal.AddError("The payload archive is missing from the extraction directory.");
                    }
                }

                retVal.Incorporate(extractResult);
            }

            logger.Checkpoint("Installation complete", guid);

            // cleanup the temp directory
            logger.Debug("Cleaning up the temporary directory...");
            platform.DeleteDirectory(tempDestination);
            
            retVal.LogResult(logger);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        /// <summary>
        /// Uninstalls the supplied Plugin by deleting the directory using the supplied IPlatform, then removes it from the supplied
        /// PluginManagerConfiguration.
        /// </summary>
        /// <param name="plugin">The Plugin to uninstall.</param>
        /// <param name="plugins">The List of type Plugin from which the Plugin is to be removed.</param>
        /// <param name="platform">The IPlatform instance with which the directory should be deleted.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        private Result UninstallPlugin(Plugin plugin, List<Plugin> plugins, IPlatform platform)
        {
            Guid guid = logger.EnterMethod(true);
            logger.Checkpoint(xLogger.Vars(plugin), xLogger.Names("plugin"), guid);

            if (plugin == default(Plugin))
            {
                return new Result().AddError("The specified Plugin is invalid.");
            }

            logger.Info("Uninstalling Plugin '" + plugin.FQN + "'...");
            Result retVal = new Result();

            Plugin foundPlugin = FindPlugin(plugin.FQN);

            // ensure the plugin is installed
            if (foundPlugin != default(Plugin))
            {
                string pluginDirectory = GetPluginDirectory(plugin);
                try
                {
                    logger.Debug("Deleting Plugin from directory '" + pluginDirectory + "'...");

                    // lock the file system and InstalledPlugins manipulations to ensure thread safety
                    lock (installationLock)
                    {
                        // delete the plugin directory
                        Result deleteResult = platform.DeleteDirectory(pluginDirectory);
                        if (deleteResult.ResultCode != ResultCode.Failure)
                        {
                            logger.Debug("Removing Plugin from PluginManager configuration...");
                            plugins.Remove(plugin);
                        }

                        retVal.Incorporate(deleteResult);
                    }
                }
                catch (Exception ex)
                {
                    retVal.AddError("Exception caught while attempting to delete directory '" + pluginDirectory + "': " + ex.Message);
                    logger.Exception(LogLevel.Debug, ex);
                }
            }
            else
            {
                retVal.AddError("The specified Plugin '" + plugin.FQN + "' is not installed.");
            }

            retVal.LogResult(logger);
            logger.ExitMethod(retVal, guid);
            return retVal;
        }

        /// <summary>
        /// Searches the specified List of type Plugin for a Plugin with an FQN matching the supplied FQN and returns it if found.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the Plugin to find.</param>
        /// <param name="plugins">The List of type Plugin to search.</param>
        /// <returns>The Plugin matching the supplied FQN, or the default Plugin if not found.</returns>
        private Plugin FindPlugin(string fqn, List<Plugin> plugins)
        {
            logger.EnterMethod(xLogger.Params(fqn, new xLogger.ExcludedParam()));

            Plugin retVal = plugins.Where(p => p.FQN == fqn).FirstOrDefault();

            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        /// Loads the Plugin Assemblies specified in the InstalledPlugins list of the Plugin Manager configuration.
        /// </summary>
        /// <returns>A Result containing the result of the operation and a list of the loaded PluginAssembly instances.</returns>
        private Result<List<PluginAssembly>> LoadPluginAssemblies()
        {
            return LoadPluginAssemblies(Plugins);
        }

        /// <summary>
        /// Loads the Plugin Assemblies specified in the supplied list of Plugins using the supplied IPlatform instance.
        /// </summary>
        /// <param name="plugins">The list of Plugins from which the Plugin Assemblies should be loaded.</param>
        /// <returns>A Result containing the result of the operation and a list of the loaded PluginAssembly instances.</returns>
        private Result<List<PluginAssembly>> LoadPluginAssemblies(List<Plugin> plugins)
        {
            Guid guid = logger.EnterMethod(xLogger.Params(plugins), true);
            logger.Info("Loading Plugin Assemblies...");

            Result<List<PluginAssembly>> retVal = new Result<List<PluginAssembly>>();
            retVal.ReturnValue = new List<PluginAssembly>();

            // discard any plugins that aren't loadable (e.g. apps)
            plugins = plugins.Where(p => IsPluginLoadable(p)).ToList();

            // load the assemblies
            foreach (Plugin plugin in plugins)
            {
                string assemblyFileName = System.IO.Path.Combine(GetPluginDirectory(plugin), plugin.FQN + ".dll");

                logger.SubSubHeading(LogLevel.Debug, "Assembly: .." + string.Join(".", System.IO.Path.GetFileName(assemblyFileName).Split('.').TakeLast(2).ToArray()));

                // load the assembly
                Result<PluginAssembly> loadResult = LoadPluginAssembly(plugin);

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
        /// Loads the Plugin Assembly belonging to the specified Plugin and stores the instance in the specified list.
        /// </summary>
        /// <param name="plugin">The Plugin to which the Plugin Assembly to load belongs.</param>
        /// <param name="pluginAssemblies">The list of type PluginAssembly to which the new instance should be added.</param>
        /// <returns>A Result containing the result of the operation and the newly created PluginAssembly instance.</returns>
        private Result<PluginAssembly> LoadPluginAssembly(Plugin plugin, List<PluginAssembly> pluginAssemblies)
        {
            logger.EnterMethod(xLogger.Params(plugin, new xLogger.ExcludedParam()));
            logger.Info("Loading Plugin Assembly for Plugin '" + plugin.FQN + "'...");

            Result<PluginAssembly> retVal = new Result<PluginAssembly>();
            Assembly assembly;

            if (pluginAssemblies.Exists(p => p.FQN == plugin.FQN))
            {
                return retVal.AddError("The Plugin Assembly for Plugin '" + plugin.FQN + "' has already been loaded.");
            }

            string assemblyFileName = System.IO.Path.Combine(GetPluginDirectory(plugin), plugin.FQN + ".dll");

            // attempt to load the assembly and add it to the internal list of plugins
            try
            {
                // validate the assembly fingerprint
                Result<string> checksumResult = Dependency<IPlatformManager>().Platform.ComputeFileChecksum(assemblyFileName);
                if (checksumResult.ResultCode != ResultCode.Failure)
                {
                    string computedFingerprint = Utility.ComputeHash(plugin.FQN + plugin.Version + checksumResult.ReturnValue);

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

                // register the plugin type
                // as a design rule, all plugins must implement IConfigurable and either IConnector or IEndpoint
                Result registerResult = Dependency<IConfigurationManager>().RegisterType(validationResult.ReturnValue);
                if (registerResult.ResultCode == ResultCode.Failure)
                {
                    throw new Exception("Failed to register the assembly type with the Configuration Manager.");
                }
            }
            catch (ReflectionTypeLoadException ex)
            {
                logger.Exception(LogLevel.Debug, ex);

                // a multitude of exceptions can be thrown under the ReflectionTypeLoaderException type
                // iterate over them
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

        /// <summary>
        /// Finds and returns the PluginAssembly in the specified list of type PluginAssembly whose FQN matches the specified FQN.
        /// </summary>
        /// <param name="fqn">The FQN of the desired PluginAssembly.</param>
        /// <param name="assemblies">The List of type PluginAssembly in which to search.</param>
        /// <returns>The PluginAssembly instance whose FQN matches the specified FQN, or the default PluginAssembly if not found.</returns>
        private PluginAssembly FindPluginAssembly(string fqn, List<PluginAssembly> assemblies)
        {
            logger.EnterMethod(xLogger.Params(fqn, new xLogger.ExcludedParam()));

            PluginAssembly retVal = assemblies.Where(p => p.FQN == fqn).FirstOrDefault();

            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        /// Iterates over the configured list of Plugin Instances, retrieves the matching PluginAssembly from the list of 
        /// loaded PluginAssemblies and instantiates each instance
        /// </summary>
        /// <returns>A Result containing the result of the operation and a Dictionary containing the instantiated Plugins.</returns>
        private Result<Dictionary<string, IPluginInstance>> InstantiatePlugins()
        {
            return InstantiatePlugins(Configuration.Instances, PluginAssemblies, Dependency<IApplicationManager>());
        }

        /// <summary>
        ///     Iterates over the specified List of type <see cref="PluginManagerConfigurationPluginInstance"/>, retrieves the matching PluginAssembly
        ///     from the supplied List of type PluginAssembly and instantiates each instance, passing the instance name and an instance of 
        ///     xLogger with the Fully Qualified Name of the instance.
        /// </summary>
        /// <remarks>
        ///     The <see cref="InstantiatePlugin{T}(IApplicationManager, string, xLogger)"/> method is invoked via reflection so that the type parameter for
        ///     the method can be specified dynamically.
        /// </remarks>
        /// <param name="configuredInstances">The List of type PluginManagerConfigurationPluginInstance containing the list of Plugin instances to create.</param>
        /// <param name="assemblies">The List of type PluginAssembly containing the assemblies to which the supplied instances should be matched</param>
        /// <param name="instanceManager">The ApplicationManager instance to be passed to Plugin instances.</param>
        /// <returns>A Result containing the result of the operation and a Dictionary containing the instantiated Plugins.</returns>
        private Result<Dictionary<string, IPluginInstance>> InstantiatePlugins(List<PluginManagerConfigurationPluginInstance> configuredInstances, List<PluginAssembly> assemblies, IApplicationManager instanceManager)
        {
            logger.EnterMethod(xLogger.Params(configuredInstances, assemblies));
            logger.Info("Creating Plugin Instances...");

            Result<Dictionary<string, IPluginInstance>> retVal = new Result<Dictionary<string, IPluginInstance>>();
            retVal.ReturnValue = new Dictionary<string, IPluginInstance>();

            // iterate over the configured plugin instances from the configuration
            foreach (PluginManagerConfigurationPluginInstance instance in configuredInstances)
            {
                logger.SubSubHeading(LogLevel.Debug, "Instance: " + instance.InstanceName);
                logger.Info("Creating instance '" + instance.InstanceName + "' of Type '" + instance.AssemblyName + "'...");

                // locate the PluginAssembly matching the instance
                PluginAssembly assembly = FindPluginAssembly(instance.AssemblyName);
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
                    Result<IPluginInstance> invokeResult = (Result<IPluginInstance>)method.Invoke(this, new object[] { instanceManager, instance.InstanceName, instanceLogger });

                    // if the invocation succeeded, add the result to the Instances Dictionary
                    if (invokeResult.ResultCode == ResultCode.Success)
                    {
                        retVal.ReturnValue.Add(instance.InstanceName, invokeResult.ReturnValue);
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

        #endregion

        #endregion

        #endregion
    }
}
