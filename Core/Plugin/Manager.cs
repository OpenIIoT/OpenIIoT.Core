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

        // static methods
        public static void LoadPlugins(List<string> files, List<IPlugin> plugins)
        {
            foreach (string plugin in files)
            {
                AssemblyName an;
                Assembly a;

                logger.Trace("Found plugin: " + plugin);
                logger.Trace("\t Attempting to determine assembly name...");
                try
                {
                    an = AssemblyName.GetAssemblyName(plugin);
                }
                catch (Exception ex)
                {
                    logger.Error(ex, "Plugin file '" + plugin + "' is not a valid assembly.  Ignoring.");
                    continue;
                }

                logger.Trace("\t Found assembly '" + an.ToString() + "'; attempting to load...");

                try
                {
                    a = Assembly.Load(an);
                    
                    plugins.Add(new Connector(an.Name, a.FullName, PluginType.Connector, a.GetTypes()[0], a));

                    logger.Info("Loaded plugin '" + plugin + "' as type " + a.GetTypes()[0].ToString());
                }
                catch (Exception ex)
                {
                    logger.Error(ex, "Failed to load assembly from plugin file '" + plugin + "'.  Ignoring.");
                }



            }
        }
    }
}
