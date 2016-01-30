using System;
using System.Collections.Generic;

namespace Symbiote.Core.Composite
{
    public interface IComposite
    {
        IComposite Parent { get; }
        string Name { get; }
        string FQN { get; }
        string Path { get; }
        Type Type { get; }
        bool IsDataStructure { get; }
        bool IsDataMember { get; }
        List<IComposite> Children { get; }
        IComposite SetParent(IComposite parent);
        IComposite AddChild(IComposite item);
        IComposite RemoveChild(IComposite item);
        IComposite DesignateAsDataStucture();
        IComposite DesignateAsDataMember();
        bool HasChildren();
        string ToJson();
        bool IsValid();
    }
}
