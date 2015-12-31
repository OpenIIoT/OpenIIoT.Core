using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Symbiote.Core.Platform
{
    public class PlatformManager
    {
        // private variables
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static PlatformManager instance;

        // enumerations
        public enum PlatformType { Windows, UNIX }
        
        // properties
        // <none>

        // constructor
        // in the case of a singleton the Instance() static method should come immediately after the constructor
        private PlatformManager() { }

        public static PlatformManager Instance()
        {
            if (instance != null)
                instance = new PlatformManager();
           
            return new PlatformManager();
        }

        // instance methods
        public IPlatform GetCurrentPlatform()
        {
            try
            {
                PlatformType platform = GetPlatformType();

                if (platform == PlatformType.Windows) return new Platform.Windows();
                else if (platform == PlatformType.UNIX) return new Platform.UNIX();
                else throw new System.Exception("Unable to determine platform. Environment.OSVersion.Platform: " + Environment.OSVersion.Platform.ToString());
            }
            catch(Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }

        // events
        // <none>

        // static methods
        // when the class is a singleton the Instance() method will appear immediately after the constructor
        private static PlatformType GetPlatformType()
        {
            int p = (int)Environment.OSVersion.Platform;
            return ((p == 4) || (p == 6) || (p == 128) ? PlatformType.UNIX : PlatformType.Windows);
        }
    }
}
