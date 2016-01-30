using System;
using System.Collections.Generic;

namespace Symbiote.Core
{
    public interface IComposite
    {
        IComposite Parent { get; }
        string Name { get; }
        string FQN { get; }
        string Path { get; }
        Type Type { get; }
        List<IComposite> Children { get; }
        IComposite SetParent(IComposite parent);
        IComposite AddChild(IComposite item);
        IComposite RemoveChild(IComposite item);
        bool HasChildren();
        string ToJson();
        bool IsValid();
    }
}
