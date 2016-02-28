using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core
{
    /// <summary>
    /// Represents a group of Items that is not a data structure
    /// </summary>
    public class Folder
    {
        /// <summary>
        /// Returns the string representation of the object.
        /// </summary>
        /// <returns>The string representation of the object.</returns>
        public override string ToString()
        {
            return "Folder";
        }
    }

    /// <summary>
    /// Represents a group of Items that is a data structure.  
    /// Binds items such that reads and writes are performed as a group and/or executed against the data structure itself rather than individual elements.
    /// </summary>
    public class Structure
    {
        /// <summary>
        /// Returns the string representation of the object.
        /// </summary>
        /// <returns>The string representation of the object.</returns>
        public override string ToString()
        {
            return "Structure";
        }
    }
}
