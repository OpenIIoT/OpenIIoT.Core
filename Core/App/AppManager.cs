using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Symbiote.Core.App
{
    public class AppManager
    {
        private ProgramManager manager;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static AppManager instance;

        private AppManager(ProgramManager manager)
        {
            this.manager = manager;
        }

        internal static AppManager Instance(ProgramManager manager)
        {
            if (instance == null)
                instance = new AppManager(manager);

            return instance;
        }
    }
}
