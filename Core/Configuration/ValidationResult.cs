using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core.Configuration
{
    /// <summary>
    /// Contains the ValidationResultCode and optional message resulting from a configuration validation.
    /// </summary>
    public class ValidationResult
    {
        /// <summary>
        /// The ValidationResultCode representing the outcome of the validation;  Valid, Warning or Invalid.
        /// </summary>
        public ValidationResultCode Result { get; set; }
        /// <summary>
        /// If the ValidationResultCode is not Valid, contains additional information describing the reason for the Warning or Invalid result code.
        /// </summary>
        public string Message { get; set; }
    }
}
