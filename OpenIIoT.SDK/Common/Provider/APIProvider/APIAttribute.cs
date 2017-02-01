using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenIIoT.SDK.Common.Provider.APIProvider
{
    [ExcludeFromCodeCoverage]
    [AttributeUsage(AttributeTargets.Method)]
    public class APIAttribute : Attribute
    {
        public APIVerb Verb { get; set; }
    }
}