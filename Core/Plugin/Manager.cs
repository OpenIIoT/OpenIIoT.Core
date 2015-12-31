using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using NLog;
using Symbiote.Core.Platform;

namespace Symbiote.Core.Plugin
{
    public class PluginManager
    {
        // private variables
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static PluginManager instance;
        private static List<IPlugin> plugins;

        // properties
        // <none>

        // enumerations
        public enum PluginType { Connector, Service }

        // constructor
        private PluginManager() {
            plugins = new List<IPlugin>();
        }

        public static PluginManager Instance()
        {
            if (instance == null)
                instance = new PluginManager();

            return instance;
        }

        // instance methods
        public List<IPlugin> GetPlugins(List<string> files)
        {
            LoadPlugins(files, plugins);
            return plugins;
        }

        public void LoadPlugins(List<string> files, List<IPlugin> plugins)
        {
            foreach (string plugin in files)
            {
                AssemblyName an;
                Assembly a;

                logger.Trace("Found plugin: " + plugin);
                logger.Trace("Attempting to determine assembly name...");
                try
                {
                    an = AssemblyName.GetAssemblyName(plugin);

                    string validationMessage = GetPluginValidationMessage(an);
                    if (validationMessage != null)
                        throw new Exception(validationMessage);
                }
                catch (Exception ex)
                {
                    logger.Error(ex, "Plugin file '" + plugin + "' is not a valid plugin assembly.  Ignoring.");
                    continue;
                }

                logger.Trace("Validated assembly '" + an.ToString() + "'; attempting to load...");

                try
                {
                    a = Assembly.Load(an);
                    plugins.Add(new Plugin(an.Name, a.FullName, (PluginType)GetPluginType(an.Name), a.GetTypes()[0], a));
                    logger.Info("Loaded plugin '" + plugin + "' as type " + a.GetTypes()[0].ToString());
                }
                catch (Exception ex)
                {
                    logger.Error(ex, "Failed to load assembly from plugin file '" + plugin + "'.  Ignoring.");
                }
            }
        }

        // static methods

        // <summary>
        // Evaluates the supplied assembly name for correctness and returns an error message if it is incorrect.
        // </summary>
        private static string GetPluginValidationMessage(AssemblyName an)
        {
            string[] name = an.Name.Split('.');
            if (name.Length != 4)
                return "Invalid assembly name (required: 4 tuples, supplied: " + name.Length + ")";
            if (name[0] != "Symbiote")
                return "Invalid application identifier (required: Symbiote, supplied: " + name[0] + ")";
            if (name[1] != "Plugin")
                return "Invalid namespace identifier (required: Plugin, supplied: " + name[1] + ")";
            if (GetPluginType(an.Name) == null)
                return "Invalid plugin type identifier (supplied: " + name[2] + ")";
            return null;
        }

        // <summary>
        // Returns an enumeration instance representing the type of the plugin, derived from the third tuple of the plugin name.
        // </summary>
        private static PluginType? GetPluginType(string name)
        {
            try
            {
                return (PluginType)Enum.Parse(typeof(PluginType), name.Split('.')[2], true);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
