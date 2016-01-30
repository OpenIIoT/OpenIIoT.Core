using System;

namespace Symbiote.Core.Configuration
{
    /// <summary>
    /// Base exception for the Configuration namespace
    /// </summary>
    public class ConfigurationException : ApplicationException
    {
        /// <summary>
        /// Default constructor for the base exception
        /// </summary>
        /// <param name="message">The exception message</param>
        public ConfigurationException(string message) : base(message) { }
    }

    /// <summary>
    /// Exception thrown when an unrecoverable exception is encountered when instantiating the configuration
    /// </summary>
    public class ConfigurationInstantiationException : ConfigurationException
    {
        /// <summary>
        /// Default constructor for the instantiation exception
        /// </summary>
        /// <param name="message">The exception message</param>
        public ConfigurationInstantiationException(string message) : base(message) { }
    }
}
