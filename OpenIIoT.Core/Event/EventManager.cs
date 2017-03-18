/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄████████                                         ▄▄▄▄███▄▄▄▄
      █     ███    ███                                       ▄██▀▀▀███▀▀▀██▄
      █     ███    █▀   █    █     ▄█████ ██▄▄▄▄      ██     ███   ███   ███   ▄█████  ██▄▄▄▄    ▄█████     ▄████▄     ▄█████    █████
      █    ▄███▄▄▄     ██    ██   ██   █  ██▀▀▀█▄ ▀███████▄  ███   ███   ███   ██   ██ ██▀▀▀█▄   ██   ██   ██    ▀    ██   █    ██  ██
      █   ▀▀███▀▀▀     ██    ██  ▄██▄▄    ██   ██     ██  ▀  ███   ███   ███   ██   ██ ██   ██   ██   ██  ▄██        ▄██▄▄     ▄██▄▄█▀
      █     ███    █▄  ██    ██ ▀▀██▀▀    ██   ██     ██     ███   ███   ███ ▀████████ ██   ██ ▀████████ ▀▀██ ███▄  ▀▀██▀▀    ▀███████
      █     ███    ███  █▄  ▄█    ██   █  ██   ██     ██     ███   ███   ███   ██   ██ ██   ██   ██   ██   ██    ██   ██   █    ██  ██
      █     ██████████   ▀██▀     ███████  █   █     ▄██▀     ▀█   ███   █▀    ██   █▀  █   █    ██   █▀   ██████▀    ███████   ██  ██
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Represents and controls the Event subsystem.
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
using NLog;
using OpenIIoT.SDK.Configuration;
using OpenIIoT.SDK.Event;
using OpenIIoT.SDK;
using NLog.xLogger;
using Utility.OperationResult;
using OpenIIoT.SDK.Common;
using OpenIIoT.SDK.Common.Provider.EventProvider;

namespace OpenIIoT.Core.Event
{
    /// <summary>
    ///     Represents and controls the Event subsystem.
    /// </summary>
    public sealed class EventManager : Manager, IStateful, IManager, IConfigurable<EventManagerConfiguration>, IEventManager
    {
        #region Private Fields

        /// <summary>
        ///     The Singleton instance of EventManager.
        /// </summary>
        private static EventManager instance;

        /// <summary>
        ///     The Logger for this class.
        /// </summary>
        private static new xLogger logger = (xLogger)LogManager.GetCurrentClassLogger(typeof(xLogger));

        #endregion Private Fields

        #region Private Constructors

        /// <summary>
        ///     Initializes a new instance of the EventManager class.
        /// </summary>
        /// <remarks>
        ///     This constructor is marked private and is intended to be called from the
        ///     <see cref="Instantiate(IApplicationManager, IConfigurationManager)"/> method exclusively in order to implement the
        ///     Singleton design pattern.
        /// </remarks>
        /// <param name="manager">The ApplicationManager instance for the application.</param>
        /// <param name="configurationManager">The ConfigurationManager instance for the application.</param>
        private EventManager(IApplicationManager manager, IConfigurationManager configurationManager)
        {
            base.logger = logger;
            logger.EnterMethod();

            ManagerName = "Event Manager";

            // register dependencies
            RegisterDependency<IApplicationManager>(manager);
            RegisterDependency<IConfigurationManager>(configurationManager);

            RegisteredProviders = new Dictionary<Type, List<string>>();
            RegisteredEvents = new Dictionary<Type, List<KeyValuePair<string, string>>>();

            ChangeState(State.Initialized);

            logger.ExitMethod();
        }

        #endregion Private Constructors

        #region Public Properties

        /// <summary>
        ///     Gets the Configuration for the Manager.
        /// </summary>
        public EventManagerConfiguration Configuration { get; private set; }

        /// <summary>
        ///     Gets the ConfigurationDefinition for the Manager.
        /// </summary>
        public ConfigurationDefinition ConfigurationDefinition
        {
            get
            {
                return GetConfigurationDefinition();
            }
        }

        /// <summary>
        ///     Gets the Dictionary, keyed on Type, of registered Events.
        /// </summary>
        public Dictionary<Type, List<KeyValuePair<string, string>>> RegisteredEvents { get; private set; }

        /// <summary>
        ///     Gets the Dictionary, keyed on Type, of registered Event Provider instances.
        /// </summary>
        public Dictionary<Type, List<string>> RegisteredProviders { get; private set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        ///     Returns the ConfigurationDefinition for the Event Manager.
        /// </summary>
        /// <returns>The ConfigurationDefinition for the Event Manager.</returns>
        public static ConfigurationDefinition GetConfigurationDefinition()
        {
            ConfigurationDefinition retVal = new ConfigurationDefinition();
            retVal.Form = "[\"name\",\"email\",{\"key\":\"comment\",\"type\":\"textarea\",\"placeholder\":\"Make a comment\"},{\"type\":\"submit\",\"style\":\"btn-info\",\"title\":\"OK\"}]";
            retVal.Schema = "{\"type\":\"object\",\"title\":\"Comment\",\"properties\":{\"name\":{\"title\":\"Name\",\"type\":\"string\"},\"email\":{\"title\":\"Email\",\"type\":\"string\",\"pattern\":\"^\\\\S+@\\\\S+$\",\"description\":\"Email will be used for evil.\"},\"comment\":{\"title\":\"Comment\",\"type\":\"string\",\"maxLength\":20,\"validationMessage\":\"Don\'t be greedy!\"}},\"required\":[\"name\",\"email\",\"comment\"]}";
            retVal.Model = typeof(EventManagerConfiguration);

            EventManagerConfiguration config = new EventManagerConfiguration();
            config.Events.Add("Hello World!");

            retVal.DefaultConfiguration = config;

            return retVal;
        }

        /// <summary>
        ///     Instantiates and/or returns the EventManager instance.
        /// </summary>
        /// <remarks>
        ///     Invoked via reflection from ApplicationManager. The parameters are used to build an array of IManager parameters
        ///     which are then passed to this method. To specify additional dependencies simply insert them into the parameter list
        ///     for the method and they will be injected when the method is invoked.
        /// </remarks>
        /// <param name="manager">The ApplicationManager instance for the application.</param>
        /// <param name="configurationManager">The ConfigurationManager instance for the application.</param>
        /// <returns>The Singleton instance of the EventManager.</returns>
        public static EventManager Instantiate(IApplicationManager manager, IConfigurationManager configurationManager)
        {
            if (instance == null)
            {
                instance = new EventManager(manager, configurationManager);
            }

            return instance;
        }

        //// See the Manager class for the IStateful implementation for this class.

        //// See the Manager class for the IManager implementation for this class.

        /// <summary>
        ///     Configures the Manager using the configuration stored in the Configuration Manager, or, failing that, using the
        ///     default configuration.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        public IResult Configure()
        {
            logger.EnterMethod();

            logger.Debug("Attempting to Configure with the configuration from the Configuration Manager...");
            Result retVal = new Result();

            IResult<EventManagerConfiguration> fetchResult = Dependency<IConfigurationManager>().Configuration.GetInstance<EventManagerConfiguration>(this.GetType());

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
                IResult<EventManagerConfiguration> createResult = Dependency<IConfigurationManager>().Configuration.AddInstance<EventManagerConfiguration>(this.GetType(), GetConfigurationDefinition().DefaultConfiguration);
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
        /// <param name="configuration">The configuration with which the Manager should be configured.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public IResult Configure(EventManagerConfiguration configuration)
        {
            logger.EnterMethod(xLogger.Params(configuration));

            Result retVal = new Result();

            // update the configuration
            Configuration = configuration;
            logger.Debug("Successfully configured the Manager.");

            // save it
            logger.Debug("Saving the new configuration...");
            retVal.Incorporate(SaveConfiguration());

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal);
            return retVal;
        }

        /// <summary>
        ///     Registers the specified object with the Event Manager.
        /// </summary>
        /// <param name="registrant">The object to register.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public Result RegisterProvider(object registrant)
        {
            return RegisterProvider(registrant, RegisteredProviders, RegisteredEvents);
        }

        /// <summary>
        ///     Registers each object within the supplied list which implements the IEventProvider interface.
        /// </summary>
        /// <param name="registrants">The list of objects to register.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        public Result RegisterProviders(List<object> registrants)
        {
            logger.EnterMethod();
            logger.Debug("Attempting to register " + registrants.Count() + "' objects...");
            Result retVal = new Result();

            foreach (object registrant in registrants)
            {
                if (registrant is IEventProvider)
                {
                    retVal.Incorporate(RegisterProvider(registrant));
                }
                else
                {
                    logger.Debug("The object of Type '" + registrant.GetType() + "' does not implement IEventProvider and was not registered.");
                }
            }

            retVal.LogResult(logger.Debug);
            logger.ExitMethod();
            return retVal;
        }

        /// <summary>
        ///     Saves the configuration to the Configuration Manager.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        public IResult SaveConfiguration()
        {
            logger.EnterMethod();
            Result retVal = new Result();

            retVal.Incorporate(Dependency<IConfigurationManager>().Configuration.UpdateInstance(this.GetType(), Configuration));

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal);
            return retVal;
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        ///     <para>Executed upon instantiation of all program Managers.</para>
        ///     <para>Registers all IManagers in the specified list implementing IEventProvider.</para>
        /// </summary>
        protected override void Setup()
        {
            logger.EnterMethod();
            logger.Debug("Performing Setup for '" + GetType().Name + "'...");

            IReadOnlyList<IManager> managerInstances = Dependency<IApplicationManager>().Managers;

            // register Managers with the Event Manager
            logger.Info("Registering Managers with the Event Manager...");
            RegisterProviders(managerInstances.ToList().ConvertAll<object>(o => (object)o));

            logger.ExitMethod();
        }

        /// <summary>
        ///     Executed upon shutdown of the Manager.
        /// </summary>
        /// <param name="stopType">The nature of the stoppage.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        protected override Result Shutdown(StopType stopType = StopType.Stop)
        {
            return new Result();
        }

        /// <summary>
        ///     Executed upon startup of the Manager.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        protected override Result Startup()
        {
            return new Result();
        }

        #endregion Protected Methods

        #region Private Methods

        /// <summary>
        ///     Occurs when a monitored Event occurs.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The arguments for the event.</param>
        private void ProviderEventRaised(object sender, EventArgs e)
        {
            logger.Info("********************* EVENT RAISED:" + sender.GetType() + ": " + e.ToString());
        }

        /// <summary>
        ///     Registers the specified object with the Event Manager.
        /// </summary>
        /// <param name="registrant">The object to register.</param>
        /// <param name="registeredProviders">The Dictionary, keyed on Type, of registered Event Provider instances.</param>
        /// <param name="registeredEvents">The Dictionary, keyed on Type, of registered Events.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        private Result RegisterProvider(object registrant, Dictionary<Type, List<string>> registeredProviders, Dictionary<Type, List<KeyValuePair<string, string>>> registeredEvents)
        {
            logger.EnterMethod(xLogger.Params(registrant.GetType(), new xLogger.ExcludedParam(), new xLogger.ExcludedParam()));
            logger.Debug("Registering object of Type '" + registrant.GetType().Name + "...");
            Result retVal = new Result();

            // check to ensure the provided object implements IEventProvider
            logger.Trace("Checking to see if the registrant implements IEventProvider...");
            if (!(registrant is IEventProvider))
            {
                return retVal.AddError("The specified object does not implement IEventProvider and can not be registered.");
            }

            logger.Trace("Casting the registrant object to IEventProvider...");
            IEventProvider provider = (IEventProvider)registrant;

            // check to see if the specified type has previously been registered
            logger.Trace("Checking the registration of the Type and event list...");
            if (registeredProviders.ContainsKey(provider.GetType()))
            {
                logger.Trace("The Type '" + provider.GetType() + "' is registered.  Checking the instance name...");

                // check to see if the type contains the specified provider instance
                if (registeredProviders[provider.GetType()].Contains(provider.EventProviderName))
                {
                    // if it does, exit.
                    return retVal.AddError("The provider '" + provider.EventProviderName + "' has already been registered.");
                }
                else
                {
                    // if not, add it.
                    logger.Trace("The instance '" + provider.EventProviderName + "' isn't registered.  Adding it to the list...");
                    registeredProviders[provider.GetType()].Add(provider.EventProviderName);
                }
            }
            else
            {
                // if the provider dictionary doesn't contain the Type, add the key and initialize the provider list with this
                // provider name.
                logger.Trace("The Type '" + provider.GetType() + "' hasn't yet been registered.  Adding it to the Dictionary with the instance '" + provider.EventProviderName + "'...");
                List<string> list = new List<string>();
                list.Add(provider.EventProviderName);

                registeredProviders.Add(provider.GetType(), list);
            }

            // next, add the Type to the event dictionary. check to make sure it doesn't exist, just in case. it shouldn't.
            logger.Trace("Checking whether the events for '" + provider.GetType() + "' have been registered...");
            if (!registeredEvents.ContainsKey(provider.GetType()))
            {
                logger.Trace("Adding the Type '" + provider.GetType() + "' to the event Dictionary with an empty list...");
                registeredEvents.Add(provider.GetType(), new List<KeyValuePair<string, string>>());
            }
            else
            {
                logger.Trace("Type '" + provider.GetType() + "' is already registered; no changes made to the event Dictionary.");
            }

            // at this point we have ensured that the type and instance exist in both the provider and event dictionaries. next we
            // will iterate over the events in the specified Type, attach our generic handler and, if an event is missing from the
            // registered events dictionary, we will add it. begin by retrieving a list of events for the specified Type
            logger.Trace("Retrieving list of events from the Type '" + provider.GetType() + "'...");
            EventInfo[] events = provider.GetType().GetEvents(BindingFlags.Instance | BindingFlags.Public);

            // iterate over each event. add the event to the list of registered events for the Type if it doesn't yet exist, then
            // attach our generic event handler.
            logger.Debug("The Type '" + provider.GetType().Name + "' contains " + events.Length + " events.  Enumerating...");
            foreach (EventInfo eventInfo in events)
            {
                // attempt to fetch the description from the Event attribute that *should* be attached to the event.
                logger.Trace("Attempting to fetch the description for event '" + eventInfo.Name + "'...");
                string description = string.Empty;
                EventAttribute eventAttribute = (EventAttribute)eventInfo.GetCustomAttributes().Where(a => a is EventAttribute).FirstOrDefault();

                if (eventAttribute != default(Attribute))
                {
                    // the attribute was attached; grab the description.
                    description = eventAttribute.Description;
                    logger.Trace("Fetched '" + description + "'.");
                }
                else
                {
                    logger.Trace("Event attribute was not attached to the event '" + eventInfo.Name + "; skipping registration.");
                    continue;
                }

                logger.Debug("Processing event '" + eventInfo.Name + "' with description '" + description + "'...");

                // create a new key value pair for the current event
                KeyValuePair<string, string> currentEvent = new KeyValuePair<string, string>(eventInfo.Name, description);

                // check to see if the event has been registered and add it if it hasn't.
                if (!registeredEvents[provider.GetType()].Exists(k => k.Key == currentEvent.Key))
                {
                    logger.Trace("Adding event '" + eventInfo.Name + "' to the event dictionary...");
                    registeredEvents[provider.GetType()].Add(currentEvent);
                }

                // attach the generic event handler to the event
                logger.Trace("Attaching event handler to '" + eventInfo.Name + "'...");
                eventInfo.AddEventHandler(provider, Delegate.CreateDelegate(eventInfo.EventHandlerType, this, GetType().GetMethod("ProviderEventRaised", BindingFlags.NonPublic | BindingFlags.Instance)));
            }

            retVal.LogResult(logger.Debug);
            logger.ExitMethod(retVal);
            return retVal;
        }

        #endregion Private Methods
    }
}