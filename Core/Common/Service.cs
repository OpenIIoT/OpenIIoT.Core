using System.ServiceProcess;

namespace Symbiote.Core
{
    class Service : ServiceBase
    {
        public Service()
        {
            ServiceName = "Symbiote";
        }

        protected override void OnStart(string[] args)
        {
            Program.Start(args);
        }

        protected override void OnStop()
        {
            Program.Stop();
        }
    }
}
