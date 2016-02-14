using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core.App
{
    public class AppParseResult : ActionResult
    {
        public App App { get; set; }

        public AppParseResult() : base() { }
    }
}
