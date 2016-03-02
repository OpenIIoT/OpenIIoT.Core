using System.ServiceProcess;

namespace Symbiote.Core
{
    class WindowsService : ServiceBase
    {
        public WindowsService()
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
