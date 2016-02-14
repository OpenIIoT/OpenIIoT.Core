using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core.App
{
    public class AppLoadResult : ActionResult
    {
        public List<IApp> Apps { get; set; }

        public AppLoadResult() : base()
        {
            Apps = new List<IApp>();
        }
    }
}
