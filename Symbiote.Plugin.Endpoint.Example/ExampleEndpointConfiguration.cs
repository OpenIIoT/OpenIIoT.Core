using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Symbiote.Core.Configuration;
using Symbiote.Core.Plugin;

namespace Symbiote.Plugin.Endpoint.Example
{
    /// <summary>
    /// The ExampleEndpointConfiguration class is an example of what a configuration/model class for an Endpoint might look like.
    /// 
    /// The configuration model is not limited to just one class; complext examples may have any structure consisting of any number of classes.
    /// </summary>
    public class ExampleEndpointConfiguration
    {
        // this configuration model example contains one property of type string
        public string Example { get; set; }

        // typically the constructor wouldn't set any values, but this example does for illustrative purposes.
        public ExampleEndpointConfiguration()
        {
            Example = "Hello World!";
        }
    }
}
