using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core
{
    class Program
    {
        static IPlatform platform;
        static void Main(string[] args)
        {
            platform = Platform.GetPlatform();

            if ((platform.Type() == Platform.PlatformType.Windows) && (!Environment.UserInteractive))
                ServiceBase.Run(new Service());
            else
            {
                Start(args);
                Console.ReadKey(true);
                Stop();
            }
        }

        public static void Start(string[] args)
        {
            PrintStartupMessage();
        }

        public static void Stop()
        {
            Console.WriteLine("Goodbye.");
        }

        static void PrintStartupMessage()
        {
            Console.WriteLine("Symbiote is starting...");
            Console.WriteLine("Platform: " + platform.Type().ToString() + " (" + platform.Version() + ")");
            Console.WriteLine("CPU %: " + platform.Info().CPUTime().ToString());
            Console.WriteLine("RAM: " + platform.Info().MemoryUsage().ToString());

            foreach (IDiskInfo s in platform.Info().Disks())
            {
                Console.WriteLine("Drive: " + s.Name);
                Console.WriteLine("Path: " + s.Path);
                Console.WriteLine("Type: " + s.Type);
                Console.WriteLine("Total Size: " + s.Capacity.ToString());
                Console.WriteLine("Used Space: " + s.UsedSpace.ToString());
                Console.WriteLine("Free Space: " + s.FreeSpace.ToString());
                Console.WriteLine("% Used: " + (s.PercentUsed * 100).ToString() + "%");
                Console.WriteLine("% Free: " + (s.PercentFree * 100).ToString() + "%");
            }
        }
    }

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
