using Symbiote.Core.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.OperationResult;

namespace Symbiote.Core.Tests.Mockups
{
    public class MockManagerNoDependencies : Manager, IStateful, IManager
    {
        private static MockManagerNoDependencies instance;

        private MockManagerNoDependencies()
        {
            ManagerName = "Mock Manager";

            ChangeState(State.Initialized);
        }

        public static MockManagerNoDependencies Instantiate()
        {
            if (instance == null)
            {
                instance = new MockManagerNoDependencies();
            }

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
            return new Result();
        }
    }
}
