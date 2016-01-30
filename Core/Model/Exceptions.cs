using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core.Model
{
    public class ModelException : ApplicationException
    {
        public ModelException(string message) : base(message) { }
    }
    public class ItemJsonInvalidException : ModelException
    {
        public ItemJsonInvalidException(string message) : base(message) { }
    }
    public class ItemValidationException : ModelException
    {
        public ItemValidationException(string message) : base(message) { }
    }
    public class ItemParentMissingException : ModelException
    {
        public ItemParentMissingException(string message) : base(message) { }
    }
    public class ModelRootRemovalException : ModelException
    {
        public ModelRootRemovalException(string message) : base(message) { }
    }
    public class ItemAlreadyAddedException : ModelException
    {
        public ItemAlreadyAddedException(string message) : base(message) { }
    }

    public class ModelAttachException : ModelException
    {
        public ModelAttachException(string message) : base(message) { }
    }
}
