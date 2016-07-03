/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀ 
      █   
      █    ▄█  ▄████████                                                                                                    
      █   ███  ███    ███                                                                                                   
      █   ███▌ ███    █▀   ██████  ██▄▄▄▄     ▄█████  █     ▄████▄  ██   █     █████   ▄█████  ▀██████▄   █          ▄█████ 
      █   ███▌ ███        ██    ██ ██▀▀▀█▄   ██   ▀█ ██    ██    ▀  ██   ██   ██  ██   ██   ██   ██   ██ ██         ██   █  
      █   ███▌ ███        ██    ██ ██   ██  ▄██▄▄    ██▌  ▄██       ██   ██  ▄██▄▄█▀   ██   ██  ▄██▄▄█▀  ██        ▄██▄▄    
      █   ███  ███    █▄  ██    ██ ██   ██ ▀▀██▀▀    ██  ▀▀██ ███▄  ██   ██ ▀███████ ▀████████ ▀▀██▀▀█▄  ██       ▀▀██▀▀    
      █   ███  ███    ███ ██    ██ ██   ██   ██      ██    ██    ██ ██   ██   ██  ██   ██   ██   ██   ██ ██▌    ▄   ██   █  
      █   █▀   ████████▀   ██████   █   █    ██      █     ██████▀  ██████    ██  ██   ██   █▀ ▄██████▀  ████▄▄██   ███████ 
      █   
 ▄ ▄▄ █ ▄▄▄▄▄▄▄▄▄  ▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄ 
 █ ██ █ █████████  ████ ██████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █ 
      █  
      █  Defines the interface for Configurable objects.  When implemented, the implementing class gains the ability to store named
      █  named instances of type T in the application configuration file, where the type T is defined by the implementing class.
      █  
      ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀  ▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀██ 
                                                                                                   ██ 
                                                                                               ▀█▄ ██ ▄█▀ 
                                                                                                 ▀████▀   
                                                                                                   ▀▀                            */
namespace Symbiote.Core.Configuration
{
    /// <summary>
    /// Defines the interface for Configurable objects.  When implemented, the implementing class gains the ability to store named instances of type T
    /// in the application configuration file.  The type T is defined by the implementing class.
    /// </summary>
    /// <remarks>
    /// <para>
    ///     Any class wishing to store configuration information must to implement this interface and must also provide two
    ///     static methods; GetConfigurationDefinition() and GetDefaultConfiguration().  
    /// </para>
    /// <para>
    ///     These static methods are implemented to allow the <see cref="ConfigurationManager"/> to configure new instances of a class 
    ///     (for instance, a Plugin) without requiring an instance to be created first. Without this functionality the 
    ///     ConfigurationManager (or API, or whatever is trying to configure a new instance) would need to create a temporary "dummy" 
    ///     instance of the object, fetch the ConfigurationDefinition and default Configuration from that instance, then discard it.
    ///     The static methods provide a cleaner method for doing this.
    /// </para>
    /// </remarks>
    /// <typeparam name="T">The Configuration type</typeparam>
    public interface IConfigurable<T> 
    {
        /// <summary>
        /// The ConfigurationDefinition for the class.  
        /// </summary>
        ConfigurationDefinition ConfigurationDefinition { get; }

        /// <summary>
        /// The instance of T representing the Configuration for the implementation instance.
        /// </summary>
        /// <remarks>
        /// It is suggested that the implementing class also implements a special Type to model the configuration, however
        /// any type will work here.
        /// </remarks>
        T Configuration { get; }

        /// <summary>
        /// Fetches the configuration for the current instance of the implementation from the Configuration Manager
        /// and configures the instance with the returned Configuration T.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        Result Configure();

        /// <summary>
        /// Configures the current instance of the implementation with the supplied Configuration T.
        /// </summary>
        /// <param name="configuration">The instance of T containing the Configuration to be used to configure the instance.</param>
        /// <returns>A Result containing the result of the operation.</returns>
        Result Configure(T configuration);

        /// <summary>
        /// Stores the Configuration for the current instance of the implementation to the Configuration Manager.
        /// </summary>
        /// <returns>A Result containing the result of the operation.</returns>
        Result SaveConfiguration();
    }
}
