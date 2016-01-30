using System;

namespace Symbiote.Core
{
    public class CompositeException : ApplicationException
    {
        public CompositeException(string message) : base(message) { }
    }
    
    public class ParentNotDataStructureNorMemberException : CompositeException
    {
        public ParentNotDataStructureNorMemberException(string message) : base(message) { }
    }

    public class ItemAccessException : CompositeException
    {
        public ItemAccessException(string message) : base(message) { }
    }

    public class ItemNotReadableException : ItemAccessException
    {
        public ItemNotReadableException(string message) : base(message) { }
    }

    public class ItemNotWriteableException : ItemAccessException
    {
        public ItemNotWriteableException(string message) : base(message) { }
    }
}
