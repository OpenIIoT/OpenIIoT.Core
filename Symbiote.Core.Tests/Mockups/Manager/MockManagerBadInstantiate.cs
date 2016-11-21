using Symbiote.Core.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.OperationResult;

namespace Symbiote.Core.Tests.Mockups
{
    public class MockManagerBadInstantiate : Manager, IStateful, IManager
    {
        private static MockManagerBadInstantiate instance;

        private MockManagerBadInstantiate(IApplicationManager manager)
        {
            ManagerName = "Mock Manager";
            RegisterDependency<IApplicationManager>(manager);

            ChangeState(State.Initialized);
        }

        public static MockManagerBadInstantiate Instantiate(IApplicationManager manager)
        {
            if (instance == null)
            {
                instance = new MockManagerBadInstantiate(manager);
            }

            return null;
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
