using System;

namespace Symbiote.Core.Platform
{
    public class PlatformException : ApplicationException
    {
        public PlatformException(string message) : base(message) { }
    }

    public class PlatformUndeterminedException : PlatformException
    {
        public PlatformUndeterminedException(string message) : base(message) { }
    }
}
