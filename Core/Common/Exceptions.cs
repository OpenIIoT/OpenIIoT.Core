using System;

namespace Symbiote.Core
{
    public class ItemException : ApplicationException
    {
        public ItemException(string message) : base(message) { }
    }
    
    public class ParentNotDataStructureNorMemberException : ItemException
    {
        public ParentNotDataStructureNorMemberException(string message) : base(message) { }
    }

    public class ItemAccessException : ItemException
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

    public class SourceItemInvalidException : ItemException
    {
        public SourceItemInvalidException(string message) : base(message) { }
    }
}
