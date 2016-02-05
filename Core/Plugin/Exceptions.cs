using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core.Plugin
{
    class PluginException : ApplicationException
    {
        public PluginException(string message) : base(message) { }
    }

    class PluginAssemblyNotFoundException : PluginException
    {
        public PluginAssemblyNotFoundException(string message) : base(message) { }
    }
    class PluginTypeInvalidException : PluginException
    {
        public PluginTypeInvalidException(string message) : base(message) { }
    }
}
