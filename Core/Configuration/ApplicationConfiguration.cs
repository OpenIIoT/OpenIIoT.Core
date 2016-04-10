using Newtonsoft.Json;
using System.Collections.Generic;
using System;

namespace Symbiote.Core.Configuration
{
    public class ApplicationConfiguration
    {
        public Dictionary<Type, Dictionary<string, object>> Configuration { get; private set; }

        public ApplicationConfiguration()
        {
            Configuration = new Dictionary<Type, Dictionary<string, object>>();
        }
    }
}
