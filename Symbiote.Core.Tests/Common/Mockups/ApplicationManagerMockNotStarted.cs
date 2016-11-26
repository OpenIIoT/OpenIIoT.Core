using Symbiote.Core.SDK;
using System;
using Utility.OperationResult;
using System.Collections.Immutable;

namespace Symbiote.Core.Tests.Common.Mockups
{
    public class ApplicationManagerMockNotStarted : Manager, IApplicationManager
    {
        private static ApplicationManagerMock instance;

        public ApplicationManagerMockNotStarted()
        {
            ManagerName = "Mock Application Manager";
            RegisterDependency<IApplicationManager>(this);

            ChangeState(State.Stopped);
        }

        public string InstanceName
        {
            get
            {
                return ManagerName;
            }
        }

        public string ProductName
        {
            get
            {
                return "ProductName";
            }
        }

        public Version ProductVersion
        {
            get
            {
                return new Version(1, 0, 0, 0);
            }
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

        public T GetManager<T>() where T : IManager
        {
            throw new NotImplementedException();
        }

        public ImmutableList<IManager> GetManagers()
        {
            throw new NotImplementedException();
        }
    }
}