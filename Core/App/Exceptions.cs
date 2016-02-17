using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core.App
{
    /// <summary>
    /// Base Exception for the App namespace.
    /// </summary>
    public class AppException : Exception
    {
        /// <summary>
        /// Instantiates a new AppException with the optionally supplied message and inner exception.
        /// </summary>
        /// <param name="message">The message describing the exception.</param>
        /// <param name="innerException">The inner exception.</param>
        public AppException(string message = "", Exception innerException = null) : base(message, innerException) { }
    }

    /// <summary>
    /// Exception raised during an App load operation.
    /// </summary>
    public class AppLoadException : AppException
    {
        /// <summary>
        /// Instantiates a new AppLoadException with the optionally supplied message and inner exception.
        /// </summary>
        /// <param name="message">The message describing the exception.</param>
        /// <param name="innerException">The inner exception.</param>
        public AppLoadException(string message = "", Exception innerException = null) : base(message, innerException) { }
    }

    /// <summary>
    /// Exception raised during a configuration save operation.
    /// </summary>
    public class AppConfigurationSaveException : AppException
    {
        /// <summary>
        /// Instantiates a new AppConfigurationSaveException with the optionally supplied message and inner exception.
        /// </summary>
        /// <param name="message">The message describing the exception.</param>
        /// <param name="innerException">The inner exception.</param>
        public AppConfigurationSaveException(string message = "", Exception innerException = null) : base(message, innerException) { }
    }
}
