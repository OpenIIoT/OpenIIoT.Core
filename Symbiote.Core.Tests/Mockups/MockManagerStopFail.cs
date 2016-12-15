using Symbiote.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.OperationResult;

namespace Symbiote.Core.Tests.Mockups
{
    public class MockManagerStopFail : Manager, IStateful, IManager
    {
        private static MockManagerStopFail instance;

        private MockManagerStopFail(IApplicationManager manager)
        {
            ManagerName = "Mock Manager";
            RegisterDependency<IApplicationManager>(manager);

            ChangeState(State.Initialized);
        }

        public static MockManagerStopFail Instantiate(IApplicationManager manager)
        {
            // remove the code that makes this a singleton so that test runners can get a fresh
            // instance each time.
            instance = new MockManagerStopFail(manager);
            return instance;
        }

        protected override void Setup()
        {
            return;
        }

        protected override Result Startup()
        {
            return new Result();
        }

        protected override Result Shutdown(StopType stopType = StopType.Stop)
        {
            throw new Exception("");
        }
    }
}
