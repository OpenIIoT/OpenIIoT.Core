using System;
using System.Collections.Generic;
using System.Reflection;
using NLog;
using Symbiote.Core.Platform;
using System.Linq;

namespace Symbiote.Core.Plugin
{
    /// <summary>
    /// The PluginManager class controls the plugin subsystem.
    /// <remarks>
    /// This class is implemented using the Singleton and (a variant of) Factory design patterns.
    /// </remarks>
    /// </summary>
    public class PluginManager
    {
        private ProgramManager manager;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static PluginManager instance;
        private bool pluginsLoaded = false;

        /// <summary>
        /// A list of currently loaded plugin assemblies.
        /// </summary>
        public List<IPluginAssembly> PluginAssemblies { get; private set; }

        /// <summary>
        /// A list of all plugin instances.
        /// </summary>
        public List<IPluginInstance> PluginInstances { get; private set; }

        /// <summary>
        /// Private constructor, only called by Instance()
        /// </summary>
        private PluginManager(ProgramManager manager) {
            this.manager = manager;
            PluginAssemblies = new List<IPluginAssembly>();
            PluginInstances = new List<IPluginInstance>();
        }

        /// <summary>
        /// Instantiates and/or returns the PluginManager instance.
        /// </summary>
        internal static PluginManager Instance(ProgramManager manager)
        {
            if (instance == null)
                instance = new PluginManager(manager);

            return instance;
        }

        /// <summary>
        /// Given a list of files, validate and load each assembly found in the list.
        /// </summary>
        /// <remarks>
        /// The checks performed on the files is as such:
        ///      Using GetAssemblyName, ensure the file is a valid assembly
        ///      Pass the retrieved assembly name to GetPluginValidationMessage to ensure the name meets the application requirements
        ///      If the name is correct, Load the assembly
        /// </remarks>
        /// <param name="folder">The folder containing the plugin files to load.</param>
        /// <param name="platform">The IPlatform representing the current platform for the application.</param>
        public void LoadPlugins(string folder, IPlatform platform)
        {
            // prevent assemblies from being loaded twice
            if (pluginsLoaded)
                throw new Exception("Error: plugins already loaded.  Restart the application to re-load.");

            // fetch a list of files from the specified directory using the platform-independent GetFileList method
            List<string> files = platform.GetFileList(folder, "*.dll");

            // iterate through the found files
            foreach (string plugin in files)
            {
                AssemblyName assemblyName;
                Assembly assembly;

                logger.Trace("Found plugin: " + plugin);

                // ensure the file is a valid assembly and that the name meets the application requirements
                logger.Trace("Attempting to determine assembly name...");
                try
                {
                    // ensure the file is a valid assembly
                    assemblyName = AssemblyName.GetAssemblyName(plugin);

                    // check that the name meets the application requirements
                    string validationMessage = GetPluginValidationMessage(assemblyName);
                    if (validationMessage != null)
                        throw new Exception(validationMessage);
                }
                catch (Exception ex)
                {
                    logger.Error(ex, "Plugin file '" + plugin + "' is not a valid plugin assembly.");                    
                    continue;
                }

                // attempt to load the assembly and add it to the internal list of plugins
                logger.Trace("Validated assembly '" + assemblyName.ToString() + "'; attempting to load...");
                try
                {
                    assembly = Assembly.Load(assemblyName);
                    PluginAssemblies.Add(
                        new PluginAssembly(
                            assembly.GetName().Name, 
                            assembly.FullName, 
                            assembly.GetName().Version, 
                            GetPluginType(assembly.GetName().Name), 
                            assembly.GetTypes()[0], 
                            assembly
                        )
                    );
                    logger.Info("Loaded plugin '" + plugin + "' as type " + assembly.GetTypes()[0].ToString());
                    logger.Trace("Plugin attributes:");
                    logger.Trace("\tName: " + assembly.GetName().Name);
                    logger.Trace("\tFull Name: " + assembly.FullName);
                    logger.Trace("\tVersion: " + assembly.GetName().Version);
                    logger.Trace("\tPluginType: " + GetPluginType(assembly.GetName().Name).ToString());
                    logger.Trace("\tType: " + assembly.GetTypes()[0].ToString());
                }
                catch (Exception ex)
                {
                    logger.Error(ex, "Failed to load assembly from plugin file '" + plugin + "'.  Ignoring.");
                }
            }
            pluginsLoaded = true;
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
        /// </remarks>
        /// <param name="instanceName">The desired internal name of the instance</param>
        /// <param name="type">The type to be instantiated</param>
        /// <returns></returns>
        public T CreatePluginInstance<T>(string instanceName, Type type)
        {
            // check to see if the instance name has already been used
            if (FindPluginInstance(instanceName) == default(IPluginInstance))
            {
                logger.Trace("Creating instance of plugin type '" + type.ToString() + "' with instance name '" + instanceName + "'");
                T newPluginInstance = (T)Activator.CreateInstance(type, instanceName);
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
        /// Given an instance name string, return the matching instance of IPluginInstance.
        /// </summary>
        /// <param name="instanceName"></param>
        /// <returns>The instance of IPluginInstance matching the requested InstanceName.</returns>
        public IPluginInstance FindPluginInstance(string instanceName)
        {
            return PluginInstances.Where(p => p.InstanceName == instanceName).FirstOrDefault();
        }

        // static methods

        /// <summary>
        /// Evaluates the supplied assembly name for correctness and returns an error message if it is incorrect.
        /// </summary>
        /// <remarks>
        /// The expected format of an assembly name is:  "Symbiote.Plugin.[Connector|Service].&gt;PluginName&lt;"
        /// If/when the plugin system expands this code will need to be made to be more dynamic.
        /// </remarks>
        /// <param name="assemblyName">The AssemblyName to be validated.</param>
        private static string GetPluginValidationMessage(AssemblyName assemblyName)
        {
            string[] name = assemblyName.Name.Split('.');
            if (name.Length != 4)
                return "Invalid assembly name (required: 4 tuples, supplied: " + name.Length + ")";
            if (name[0] != "Symbiote")
                return "Invalid application identifier (required: Symbiote, supplied: " + name[0] + ")";
            if (name[1] != "Plugin")
                return "Invalid namespace identifier (required: Plugin, supplied: " + name[1] + ")";
            if (GetPluginType(assemblyName.Name) == default(PluginType))
                return "Invalid plugin type identifier (supplied: " + name[2] + ")";
            return default(string);
        }

        /// <summary>
        /// Returns an enumeration instance representing the type of the plugin, derived from the third tuple of the plugin name.
        /// </summary>
        /// <param name="name">The fully qualified assembly name from which to parse the plugin type.</param>
        /// <returns>An instance of PluginType corresponding to the parsed type.</returns>
        private static PluginType GetPluginType(string name)
        {
            PluginType retVal;
            if (Enum.TryParse<PluginType>(name.Split('.')[2], out retVal))
                return retVal;
            else return default(PluginType);
        }
    }
}
