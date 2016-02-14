using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core
{
    /// <summary>
    /// Specifies how the array of properties passed to the constructor of the ContractResolver is to be used.
    /// </summary>
    public enum ContractResolverType
    {
        /// <summary>
        /// The default type
        /// </summary>
        Undefined,
        /// <summary>
        /// Resolves the data contract using only the properties in accompanying list of properties
        /// </summary>
        OptIn,
        /// <summary>
        /// Resolves the data contract using all properties not included in the accompanying list of properties
        /// </summary>
        OptOut
    }

    /// <summary>
    /// Defines the return result of an action
    /// </summary>
    public enum ActionResultCode
    {
        /// <summary>
        /// The default return type
        /// </summary>
        Unknown,
        /// <summary>
        /// The action succeeded
        /// </summary>
        Success,
        /// <summary>
        /// The action encountered recoverable issues but ultimately succeeded
        /// </summary>
        Warning,
        /// <summary>
        /// The action encountered unrecoverable errors and did not succeed
        /// </summary>
        Failure
    }
}
