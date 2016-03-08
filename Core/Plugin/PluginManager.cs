using System;
using System.Collections.Generic;
using System.Reflection;
using NLog;
using Symbiote.Core.Platform;
using System.Linq;
using Symbiote.Core.Configuration;
using Symbiote.Core.Plugin.Connector;
using Symbiote.Core.Plugin.Endpoint;

namespace Symbiote.Core.Plugin
{
    /// <summary>
    /// The PluginManager class controls the plugin subsystem.
    /// <remarks>
    /// This class is implemented using the Singleton and (a variant of) Factory design patterns.
    /// </remarks>
    /// </summary>
    public class PluginManager : IManager, IConfigurable<PluginManagerConfiguration>
    {
        #region Variables

        private ProgramManager manager;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static PluginManager instance;
        private bool pluginsLoaded = false;

        #endregion

        #region Properties

        /// <summary>
        /// A list of currently loaded plugin assemblies.
        /// </summary>
        public List<IPluginAssembly> PluginAssemblies { get; private set; }

        /// <summary>
        /// A list of all plugin instances.
        /// </summary>
        public List<IPluginInstance> PluginInstances { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Private constructor, only called by Instance()
        /// </summary>
        /// <param name="manager">The ProgramManager instance for the application.</param>
        private PluginManager(ProgramManager manager) {
            this.manager = manager;
            PluginAssemblies = new List<IPluginAssembly>();
            PluginInstances = new List<IPluginInstance>();
        }

        /// <summary>
        /// Instantiates and/or returns the PluginManager instance.
        /// </summary>
        /// <param name="manager">The ProgramManager instance for the application.</param>
        /// <returns>The Singleton instance of PluginManager.</returns>
        internal static PluginManager Instance(ProgramManager manager)
        {
            if (instance == null)
                instance = new PluginManager(manager);

            return instance;
        }

        #endregion

        #region IManager Implementation
        public OperationResult Start()
        {
            logger.Info("Starting the Plugin Manager...");
            Configure();

            OperationResult retVal = new OperationResult();

            retVal.LogResult(logger);
            return retVal;
        }

        #endregion

        #region IConfigurable<> Implementation

        public ConfigurationDefinition ConfigurationDefinition { get { return GetConfigurationDefinition(); } }

        public PluginManagerConfiguration Configuration { get; private set; }

        public OperationResult Configure()
        {
            return Configure(manager.ConfigurationManager.GetConfiguration<PluginManagerConfiguration>(this.GetType()).Result);
        }

        public OperationResult Configure(PluginManagerConfiguration configuration)
        {
            Configuration = configuration;
            return new OperationResult();
        }

        public OperationResult SaveConfiguration()
        {
            return manager.ConfigurationManager.SaveConfiguration(this.GetType(), Configuration);
        }

        public static ConfigurationDefinition GetConfigurationDefinition()
        {
            ConfigurationDefinition retVal = new ConfigurationDefinition();
            retVal.SetForm("[\"name\",\"email\",{\"key\":\"comment\",\"type\":\"textarea\",\"placeholder\":\"Make a comment\"},{\"type\":\"submit\",\"style\":\"btn-info\",\"title\":\"OK\"}]");
            retVal.SetSchema("{\"type\":\"object\",\"title\":\"Comment\",\"properties\":{\"name\":{\"title\":\"Name\",\"type\":\"string\"},\"email\":{\"title\":\"Email\",\"type\":\"string\",\"pattern\":\"^\\\\S+@\\\\S+$\",\"description\":\"Email will be used for evil.\"},\"comment\":{\"title\":\"Comment\",\"type\":\"string\",\"maxLength\":20,\"validationMessage\":\"Don\'t be greedy!\"}},\"required\":[\"name\",\"email\",\"comment\"]}");
            retVal.SetModel(typeof(PluginManagerConfiguration));
            return retVal;
        }

        public static PluginManagerConfiguration GetDefaultConfiguration()
        {
            PluginManagerConfiguration retVal = new PluginManagerConfiguration();
            retVal.AuthorizeNewPlugins = true;
            retVal.Assemblies = new List<PluginManagerConfigurationPluginAssembly>();
            retVal.Instances = new List<PluginManagerConfigurationPluginInstance>();

            PluginManagerConfigurationPluginInstance sim = new PluginManagerConfigurationPluginInstance();
            sim.InstanceName = "Simulation";
            sim.AssemblyName = "Symbiote.Plugin.Connector.Simulation";
            sim.Configuration = "";
            sim.AutoBuild = new PluginManagerConfigurationPluginInstanceAutoBuild() { Enabled = true, ParentFQN = "Symbiote" };

            retVal.Instances.Add(sim);
            return retVal;
        }

        #endregion

        #region Instance Methods
        
        /// <summary>
        /// Given a list of files, validate and load each assembly found in the list.
        /// </summary>
        /// <remarks>
        /// The checks performed on the files is as such:
        ///      Compute the MD5 checksum of the plugin and check it against the configuration
        ///         If it is in the authorized plugin list, proceed to the next step
        ///         If it is in the unauthorized plugin list, continue to the next file (no further checks)
        ///         If it is in neither list, add it to the unauthorized list and continue to the next file
        ///      Using GetAssemblyName, ensure the file is a valid assembly
        ///      Pass the retrieved assembly name to GetPluginValidationMessage to ensure the name meets the application requirements
        ///      If the name is correct, Load the assembly
        /// </remarks>
        /// <param name="folder">The folder containing the plugin files to load.</param>
        public void LoadPlugins(string folder)
        {
            // prevent assemblies from being loaded twice
            if (pluginsLoaded)
                throw new Exception("Error: plugins already loaded.  Restart the application to re-load.");

            // fetch a list of files from the specified directory using the platform-independent GetFileList method
            List<string> files = manager.PlatformManager.Platform.GetFileList(folder, "*.dll");

            // iterate through the found files
            foreach (string plugin in files)
            {
                AssemblyName assemblyName;
                Assembly assembly;

                logger.Trace("Found plugin: " + plugin + "'; authorizing...");

                PluginAuthorization auth = GetPluginAuthorization(plugin);

                // if the plugin authorization is unknown it does not yet exist in the list of assemblies in the config file.
                // add it to the list and, depending on configuration, either authorize it or leave it unauthorized.
                // try to add it but we don't care if it fails.
                if (auth == PluginAuthorization.Unknown)
                {
                    try
                    {
                        // update auth with the result of AddNewPlugin.  If AuthorizeNewPlugins is true this will result in authorization.
                        auth = AddNewPlugin(plugin);
                    }
                    catch (Exception ex)
                    {
                        logger.Trace("Failed to add new plugin '" + plugin + "' to the internal list of assemblies.");
                    }
                }
                    
                // the plugin hasn't been authorized yet, log a warning and move on to the next plugin.
                if (auth != PluginAuthorization.Authorized) 
                {
                    logger.Warn("Plugin '" + plugin + "' has not been added to the list of authorized plugins and will not be loaded.");
                    continue;
                }

                // ensure the file is a valid assembly and that the name meets the application requirements
                logger.Trace("Attempting to determine assembly name...");
                try
                {
                    // ensure the file is a valid assembly
                    assemblyName = AssemblyName.GetAssemblyName(plugin);

                    // check that the name meets the application requirements
                    OperationResult validationResult = ValidatePluginAssemblyName(assemblyName);
                    if (validationResult.ResultCode == OperationResultCode.Failure)
                        throw new Exception("Error validating plugin assembly name: " + validationResult.GetLastError());
                }
                catch (Exception ex)
                {
                    logger.Error(ex, "Plugin file '" + plugin + "' is not a valid plugin assembly.");                    
                    continue;
                }

                // attempt to load the assembly and add it to the internal list of plugins
                logger.Trace("Validated assembly name '" + assemblyName.ToString() + "'; attempting to load...");
                try
                {
                    assembly = Assembly.Load(assemblyName);

                    logger.Trace("Loaded assembly.  Validating...");

                    OperationResult<Type> validationResult = ValidatePluginAssembly(assembly);
                    Type pluginType;
                    
                    if (validationResult.ResultCode == OperationResultCode.Failure)
                        throw new Exception("Error validating plugin assembly: " + validationResult.GetLastError());
                    else
                    {
                        pluginType = validationResult.Result;
                        logger.Trace("Plugin type '" + pluginType.Name + "' was found in assembly '" + assembly.GetName().Name);
                    }

                    PluginAssemblies.Add(
                        new PluginAssembly(
                            assembly.GetName().Name, 
                            assembly.FullName, 
                            assembly.GetName().Version, 
                            GetPluginType(assembly.GetName().Name),
                            pluginType, 
                            assembly
                        )
                    );
                    logger.Info("Loaded plugin '" + plugin + "' as type " + pluginType.ToString());
                    logger.Trace("Plugin attributes:");
                    logger.Trace("\tName: " + assembly.GetName().Name);
                    logger.Trace("\tFull Name: " + assembly.FullName);
                    logger.Trace("\tVersion: " + assembly.GetName().Version);
                    logger.Trace("\tPluginType: " + GetPluginType(assembly.GetName().Name).ToString());
                    logger.Trace("\tType: " + pluginType.ToString());

                    OperationResult registerResult = manager.ConfigurationManager.RegisterType(pluginType);
                    if (registerResult.ResultCode == OperationResultCode.Failure)
                        throw new Exception("Failed to register the assembly type with the Configuration Manager.");
                    
                }
                catch (System.Reflection.ReflectionTypeLoadException ex)
                {
                    foreach(Exception le in ex.LoaderExceptions)
                    {
                        logger.Error(le, "\tLoader Exception: " + le.Message);
                    }
                }
                catch (Exception ex)
                {
                    logger.Error(ex, "Failed to load assembly from plugin file '" + plugin + "'.  Ignoring.");
                }
            }
            pluginsLoaded = true;
        }

        private PluginAuthorization AddNewPlugin(string fileName)
        {
            logger.Info("Encountered new plugin '" + fileName + "'; adding it to the list of assemblies.");

            AssemblyName assemblyName = AssemblyName.GetAssemblyName(fileName);

            // check that the name meets the application requirements
            // just forget it if we get any errors
            OperationResult validationResult = ValidatePluginAssemblyName(assemblyName);
            if (validationResult.ResultCode == OperationResultCode.Failure)
                return PluginAuthorization.Unknown;

            PluginManagerConfigurationPluginAssembly newPlugin = new PluginManagerConfigurationPluginAssembly()
            {
                Name = assemblyName.Name,
                FullName = assemblyName.FullName,
                Version = assemblyName.Version.ToString(),
                PluginType = GetPluginType(assemblyName.Name).ToString(),
                FileName = System.IO.Path.GetFileName(fileName),
                Checksum = GetPluginChecksum(fileName)
            };

            logger.Trace("Adding plugin assembly to configuration file with attributes:");
            logger.Trace("\tName: " + newPlugin.Name);
            logger.Trace("\tFull Name: " + newPlugin.FullName);
            logger.Trace("\tVersion: " + newPlugin.Version);
            logger.Trace("\tPluginType: " + newPlugin.PluginType.ToString());
            logger.Trace("\tFileName: " + newPlugin.FileName);
            logger.Trace("\tChecksum: " + newPlugin.Checksum);

            // TODO: check to see if the plugin exists by name only, and if so update the checksum if the config enables it
            if (Configuration.AuthorizeNewPlugins)
            {
                newPlugin.Authorization = PluginAuthorization.Authorized;
            }
            else
            {
                newPlugin.Authorization = PluginAuthorization.Unauthorized;
            }

            logger.Trace("\tAuthorization: " + newPlugin.Authorization.ToString());

            Configuration.Assemblies.Add(newPlugin);
            SaveConfiguration();
            return newPlugin.Authorization;
        }

        public string GetPluginChecksum(string fileName)
        {
            logger.Trace("Computing checksum for plugin file '" + fileName + "'...");
            string retVal = manager.PlatformManager.Platform.ComputeFileChecksum(fileName);
            logger.Trace("MD5 checksum for file '" + fileName + "' computed as '" + retVal + ".");
            return retVal;
        }

        public PluginAuthorization GetPluginAuthorization(string fileName)
        {
            string checksum = GetPluginChecksum(fileName);

            logger.Trace("Determining authorization for plugin file '" + fileName + "' with checksum '" + checksum + "'...");

            PluginManagerConfigurationPluginAssembly retObj = Configuration.Assemblies
                        .Where(p => p.FileName == System.IO.Path.GetFileName(fileName))
                        .Where(p => p.Checksum == checksum)
                        .FirstOrDefault();

            if (retObj != null)
            {
                logger.Trace("Retrieved authoriation for plugin '" + fileName + "': " + retObj.Authorization.ToString());
                return retObj.Authorization;
            }

            logger.Trace("Unable to find a matching entry in the assembly configuration for this plugin.  Returning Unknown authorization.");
            return PluginAuthorization.Unknown;
        }

        /// <summary>
        /// Given a string containing the FQN of a loaded plugin assembly, return the matching IPluginAssembly object.
        /// </summary>
        /// <param name="fqn"></param>
        /// <returns>The instance of IPluginAssembly matching the requested FQN</returns>
        public IPluginAssembly FindPluginAssembly(string fqn)
        {
            return PluginAssemblies.Where(p => p.Name == fqn).FirstOrDefault();
        }

        /// <summary>
        /// Creates and returns an instance of the specified plugin type with the specified name
        /// </summary>
        /// <remarks>
        /// The instanceName is propagated through the plugin instance and any internal reference (such as a ConnectorItem).  This name
        /// should match references to the plugin, either through fully qualified addressing or configuration.
        /// 
        /// Note that this is only called via reflection so the references will always be zero. 
        /// </remarks>
        /// <param name="instanceName">The desired internal name of the instance</param>
        /// <returns></returns>
        public T CreatePluginInstance<T>(string instanceName)
        {
            // check to see if the instance name has already been used
            if (FindPluginInstance(instanceName) == default(IPluginInstance))
            {
                logger.Trace("Creating instance of plugin type '" + typeof(T).ToString() + "' with instance name '" + instanceName + "'");
                T newPluginInstance = (T)Activator.CreateInstance(typeof(T), instanceName);
                PluginInstances.Add((IPluginInstance)newPluginInstance);
                return newPluginInstance;
            }
            else
            {
                logger.Warn("A plugin with InstanceName '" + instanceName + "' has already been intantiated.");
                return default(T);
            }
        }

        /// <summary>
        /// Attempts to resolve the supplied plugin item Fully Qualified Name to an instance of Item contained in a Connector plugin.
        /// </summary>
        /// <param name="fqn">The Fully Qualified Name of the instance to find.</param>
        /// <returns>The found Item.</returns>
        public Item FindPluginItem(string fqn)
        {
            logger.Trace("Attempting to find Connector Item '" + fqn + "'...");
            IConnector originPlugin = (IConnector)FindPluginInstance(fqn.Split('.')[0]);

            if (originPlugin != default(IConnector))
            {
                logger.Trace("Origin Plugin is '" + originPlugin.ToString() + "'.  Passing FQN to plugin FindItem() method...");

                Item retVal = originPlugin.FindItem(fqn);
                logger.Trace("Resolved Item: " + retVal.ToJson());
                return retVal;
            }

            logger.Trace("Origin plugin '" + fqn.Split('.')[0] + "' not found.");
            return default(Item);
        }

        /// <summary>
        /// Given an instance name string, return the matching instance of IPluginInstance.
        /// </summary>
        /// <param name="instanceName">The name of the instance to find.</param>
        /// <param name="pluginType">The Type of instance to find.</param>
        /// <returns>The instance of IPluginInstance matching the requested InstanceName.</returns>
        public IPluginInstance FindPluginInstance(string instanceName, PluginType pluginType = PluginType.Connector)
        {
            return PluginInstances.Where(p => p.PluginType == pluginType).Where(p => p.InstanceName == instanceName).FirstOrDefault();
        }

        public void InstantiatePlugins()
        {
            InstantiatePlugins(Configuration);
        }

        public void InstantiatePlugins(PluginManagerConfiguration configuration)
        {
            // iterate over the configured plugin instances from the configuration
            foreach (PluginManagerConfigurationPluginInstance instance in configuration.Instances)
            {
                IPluginAssembly assembly = FindPluginAssembly(instance.AssemblyName);
                if (assembly == default(IPluginAssembly))
                    throw new PluginAssemblyNotFoundException("Plugin assembly '" + instance.AssemblyName + "' not found in the collection.");

                MethodInfo method = this.GetType().GetMethod("CreatePluginInstance").MakeGenericMethod(assembly.Type);
                method.Invoke(this, new object[] { instance.InstanceName });

                logger.Info("Instantiated " + assembly.PluginType.ToString() + " plugin '" + instance.InstanceName + "'.");
            }
        }

        public void StartPlugins()
        {
            foreach (IPluginInstance instance in PluginInstances)
            {
                logger.Info("Starting Plugin '" + instance.Name + "'...");
                instance.Start();
            }
        }

        public void PerformAutoBuild()
        {
            PerformAutoBuild(PluginInstances, Configuration.Instances.Where(pi => pi.AutoBuild.Enabled = true));
        }

        public void PerformAutoBuild(List<IPluginInstance> plugins, IEnumerable<PluginManagerConfigurationPluginInstance> autoBuildInstances)
        {
            foreach (PluginManagerConfigurationPluginInstance instance in autoBuildInstances)
            {
                logger.Info("Attempting to auto build instance '" + instance.InstanceName + "'...");
                IConnector foundPluginInstance = (IConnector)FindPluginInstance(instance.InstanceName);
                if (foundPluginInstance == default(IConnector))
                {
                    logger.Warn("Unable to find plugin instance with InstanceName '" + instance.InstanceName + "', continuing auto build");
                    continue;
                }
                else
                {
                    logger.Trace("Attempting to attach plugin items for instance '" + instance.InstanceName + "' to '" + instance.AutoBuild.ParentFQN + "'");
                    manager.ModelManager.AttachItem(foundPluginInstance.Browse(), instance.AutoBuild.ParentFQN);
                    logger.Info("AutoBuild of Plugin instance '" + instance.InstanceName + "' complete.");
                }
            }
        }

        #endregion

        #region Static Methods

        /// <summary>
        /// Evaluates the supplied assembly name for correctness and returns an error message if it is incorrect.
        /// </summary>
        /// <remarks>
        /// The expected format of an assembly name is:  "Symbiote.Plugin.[Connector|Service].&gt;PluginName&lt;"
        /// If/when the plugin system expands this code will need to be made to be more dynamic.
        /// </remarks>
        /// <param name="assemblyName">The AssemblyName to be validated.</param>
        private static OperationResult ValidatePluginAssemblyName(AssemblyName assemblyName)
        {
            OperationResult retVal = new OperationResult();

            string[] name = assemblyName.Name.Split('.');
            if (name.Length != 4)
                retVal.AddError("Invalid assembly name (required: 4 tuples, supplied: " + name.Length + ")");
            if (name[0] != "Symbiote")
                retVal.AddError("Invalid application identifier (required: Symbiote, supplied: " + name[0] + ")");
            if (name[1] != "Plugin")
                retVal.AddError("Invalid namespace identifier (required: Plugin, supplied: " + name[1] + ")");
            if (GetPluginType(assemblyName.Name) == default(PluginType))
                retVal.AddError("Invalid plugin type identifier (supplied: " + name[2] + ")");
            return retVal;
        }

        /// <summary>
        /// Determines whether the supplied assembly is a valid plugin, and if so, returns the plugin type.
        /// </summary>
        /// <param name="assembly">The assembly to validate.</param>
        /// <returns>An OperationResult containing the result of the operation and, if successful, the plugin type.</returns>
        private static OperationResult<Type> ValidatePluginAssembly(Assembly assembly)
        {
            logger.Trace("Validating plugin assembly '" + assembly.FullName + "'...");
            OperationResult<Type> retVal = new OperationResult<Type>();

            logger.Trace("Validating plugin assembly name...");
            OperationResult nameValidationResult = ValidatePluginAssemblyName(assembly.GetName());
            if (nameValidationResult.ResultCode == OperationResultCode.Failure)
            {
                retVal.Messages = nameValidationResult.Messages;
                retVal.ResultCode = nameValidationResult.ResultCode;
                logger.Trace("Name validationg failed.  " + retVal.GetLastError());
                return retVal;
            }

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
                    if ((t.GetInterfaces().Contains(typeof(IConnector))) || (t.GetInterfaces().Contains(typeof(IEndpoint))))
                    {
                        retVal.Result = t;
                        break;
                    }
                }
            }

            if (retVal.Result == default(Type)) logger.Trace("Didn't find a suitable type.");

            if (retVal.Result == default(Type)) retVal.AddError("The supplied assembly '" + assembly.GetName() + "' does not contain any implementations of IConfigureable.");
            return retVal;

        }

        /// <summary>
        /// Returns an enumeration instance representing the type of the plugin, derived from the third tuple of the plugin name.
        /// </summary>
        /// <param name="name">The fully qualified assembly name from which to parse the plugin type.</param>
        /// <returns>An instance of PluginType corresponding to the parsed type.</returns>
        private static PluginType GetPluginType(string name)
        {
            logger.Trace("Attempting to determine Plugin type for '" + name + "'...");
            PluginType retVal;
            if (Enum.TryParse<PluginType>(name.Split('.')[2], out retVal))
            {
                logger.Trace("Plugin type: " + retVal);
                return retVal;
            }
            else
            {
                logger.Warn("Invalid PluginType for plugin '" + name + "'");
                return default(PluginType);
            }
        }

        #endregion
    }
}
