using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.OperationResult;

namespace Symbiote.Core.Tests.Mockups
{
    public class MockManagerBroken : Manager, IStateful, IManager
    {
        private static MockManagerBroken instance;

        private MockManagerBroken(IApplicationManager manager)
        {
            ManagerName = "Mock Manager";
            RegisterDependency<IApplicationManager>(manager);

            ChangeState(State.Initialized);
        }

        public static MockManagerBroken Instantiate(IApplicationManager manager)
        {
            if (instance == null)
            {
                instance = new MockManagerBroken(manager);
            }

            return instance;
        }

        protected override void Setup()
        {
            throw new ManagerSetupException("");
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
