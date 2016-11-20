using NLog;
using NLog.xLogger;
using Symbiote.Core.SDK;
using Symbiote.Core.SDK.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.OperationResult;

namespace Symbiote.Core.Plugin
{
    class PluginTypeManager<T> : IStateful
    {
        #region Variables

        /// <summary>
        /// The Logger for this class.
        /// </summary>
        private static xLogger logger = (xLogger)LogManager.GetCurrentClassLogger(typeof(xLogger));

        /// <summary>
        /// The ApplicationManager for the application.
        /// </summary>
        private ApplicationManager manager;

        #endregion

        #region Properties

        #region IManager Implementation

        /// <summary>
        /// The state of the Manager.
        /// </summary>
        public State State { get; private set; }

        #endregion

        /// <summary>
        /// The list of Plugin Instances from the Plugin Manager Configuration which are managed by this Plugin Type Manager.
        /// </summary>
        public List<PluginManagerConfigurationPluginInstance> ConfiguredInstances { get; private set; }

        /// <summary>
        /// The list of Plugin Instances managed by this Plugin Type Manager.
        /// </summary>
        public List<T> Instances { get; private set; }

        #endregion

        #region Events

        #region IManager Events

        public event EventHandler<StateChangedEventArgs> StateChanged;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// The default constructor.
        /// </summary>
        /// <param name="manager">The ApplicationManager instance for the application.</param>
        /// <param name="configuredInstances">A list of Plugin Instances from the Plugin Manager configuration which match this Plugin Type.</param>
        public PluginTypeManager(ApplicationManager manager, List<PluginManagerConfigurationPluginInstance> configuredInstances)
        {
            this.manager = manager;
            ConfiguredInstances = configuredInstances;
        }

        #endregion

        #region Instance Methods

        #region IManager Implementation

        /// <summary>
        /// Returns true if any of the specified <see cref="State"/>s match the current <see cref="State"/>.
        /// </summary>
        /// <param name="states">The list of States to check.</param>
        /// <returns>True if the current State matches any of the specified States, false otherwise.</returns>
        public virtual bool IsInState(params State[] states)
        {
            return states.Any(s => s == State);
        }

        /// <summary>
        /// Starts the Manager.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        public Result Start()
        {
            return new Result();
        }

        /// <summary>
        /// Restarts the Manager.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        public Result Restart(StopType stopType = StopType.Stop)
        {
            return new Result();
        }

        /// <summary>
        /// Stops the Manager.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        public Result Stop(StopType stopType = StopType.Stop)
        {
            return new Result();
        }

        #endregion

        #endregion
    }
}
