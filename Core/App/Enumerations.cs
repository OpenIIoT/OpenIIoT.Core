using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core.App
{
    /// <summary>
    /// Determines the app type.
    /// </summary>
    public enum AppType
    {
        /// <summary>
        /// Default type.
        /// </summary>
        Unknown,
        /// <summary>
        /// Ordinary App.
        /// </summary>
        App,
        /// <summary>
        /// Console App.  
        /// </summary>
        /// <remarks>Only one Console App may be installed at a time.</remarks>
        Console
    }
}
