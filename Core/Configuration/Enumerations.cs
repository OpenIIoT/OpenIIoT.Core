using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core.Configuration
{
    /// <summary>
    /// Enumeration for Configuration validation results
    /// </summary>
    public enum ConfigurationValidationResultCode {
        /// <summary>
        /// Default value.
        /// </summary>
        Unknown,
        /// <summary>
        /// Configuration is valid.
        /// </summary>
        Valid,
        /// <summary>
        /// Configuration is valid, but issues were detected during load and were either corrected or ignored.
        /// </summary>
        Warning,
        /// <summary>
        /// Configuration is invalid.
        /// </summary>
        Invalid
    }
}
