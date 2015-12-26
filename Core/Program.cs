using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Symbiote.Core
{
    class Program
    {
        private static Logger logger;
        private static Platform.IPlatform platform;

        static void Main(string[] args)
        {
            logger = LogManager.GetCurrentClassLogger();

            logger.Info("Symbiote is starting...");

            logger.Trace("Intantiating platform...");
            platform = Platform.PlatformManager.GetPlatform();
            logger.Trace("Platform instantiated.");

            logger.Info("Platform: " + platform.Type.ToString() + " (" + platform.Version + ")");

            if ((platform.Type == Platform.PlatformManager.PlatformType.Windows) && (!Environment.UserInteractive))
            {
                logger.Info("Platform is Windows and mode is non-interactive; starting in service mode");
                ServiceBase.Run(new Service());
            }
            else
            {
                logger.Info("Starting in interactive mode");
                Start(args);
                Console.ReadKey(true);
                Stop();
            }
        }

        public static void Start(string[] args)
        {
            logger.Info("Symbiote started.");
            PrintStartupMessage();
        }

        public static void Stop()
        {
            logger.Info("Symbiote stopped.");
        }

        static void PrintStartupMessage()
        {
            logger.Info("Symbiote is starting...");
            logger.Info("Platform: " + platform.Type.ToString() + " (" + platform.Version + ")");
            logger.Info("CPU %: " + platform.Info.CPUTime.ToString());
            logger.Info("RAM: " + platform.Info.MemoryUsage.ToString());

            foreach (Platform.IDiskInfo s in platform.Info.Disks)
            {
                logger.Info("Drive: " + s.Name);
                logger.Info("Path: " + s.Path);
                logger.Info("Type: " + s.Type);
                logger.Info("Total Size: " + s.Capacity.ToString());
                logger.Info("Used Space: " + s.UsedSpace.ToString());
                logger.Info("Free Space: " + s.FreeSpace.ToString());
                logger.Info("% Used: " + (s.PercentUsed * 100).ToString() + "%");
                logger.Info("% Free: " + (s.PercentFree * 100).ToString() + "%");
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
