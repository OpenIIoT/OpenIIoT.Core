using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core.Model
{
    public class ItemJsonInvalidException : ApplicationException
    {
        public ItemJsonInvalidException(string message) : base(message) { }
    }
    public class ItemValidationException : ApplicationException
    {
        public ItemValidationException(string message) : base(message) { }
    }
    public class ItemParentMissingException : ApplicationException
    {
        public ItemParentMissingException(string message) : base(message) { }
    }
}
