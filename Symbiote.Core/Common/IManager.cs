using System;
using System.Collections.Generic;

namespace Symbiote.Core
{
    public interface IManager : IStateful
    {
        List<Type> Dependencies { get; }
    }
}
