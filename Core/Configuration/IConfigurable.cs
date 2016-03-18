namespace Symbiote.Core.Configuration
{
    /// <summary>
    /// Defines the interface for Configurable objects.  When implemented, the implementing class gains the ability to store named instances of type T
    /// in the application configuration file.  The type T is defined by the implementing class.
    /// </summary>
    /// <remarks>Implementations of IConfigurable must implement this interface as well as the static methods "GetConfigurationDefinition" and "GetDefaultConfiguration".</remarks>
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
        T Configuration { get; }

        /// <summary>
        /// Fetches the configuration for the current instance of the implementation from the Configuration Manager
        /// and configures the instance with the returned Configuration T.
        /// </summary>
        /// <returns>An OperationResult containing the result of the operation.</returns>
        OperationResult Configure();

        /// <summary>
        /// Configures the current instance of the implementation with the supplied Configuration T.
        /// </summary>
        /// <param name="configuration">The instance of T containing the Configuration to be used to configure the instance.</param>
        /// <returns>An OperationResult containing the result of the operation.</returns>
        OperationResult Configure(T configuration);

        /// <summary>
        /// Stores the Configuration for the current instance of the implementation to the Configuration Manager.
        /// </summary>
        /// <returns></returns>
        OperationResult SaveConfiguration();
    }
}
