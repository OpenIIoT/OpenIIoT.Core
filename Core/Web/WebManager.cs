using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Symbiote.Core.Web
{
    public class WebManager
    {
        private ProgramManager manager;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static WebManager instance;

        private WebManager(ProgramManager manager)
        {
            this.manager = manager;
        }

        internal static WebManager Instance(ProgramManager manager)
        {
            if (instance == null)
                instance = new WebManager(manager);

            return instance;
        }
    }
}
