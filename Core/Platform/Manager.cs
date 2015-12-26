using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core.Platform
{
    public class PlatformManager
    {
        public enum PlatformType { Windows, UNIX }
        
        public static IPlatform GetPlatform()
        {
            if (GetPlatformType() == PlatformType.Windows)
            {
                return new WindowsPlatform();
            }
            else if (GetPlatformType() == PlatformType.UNIX)
            {
                return new UNIXPlatform();
            }
            return null;
        }

        private static PlatformType GetPlatformType()
        {
            int p = (int)Environment.OSVersion.Platform;
            return ((p == 4) || (p == 6) || (p == 128) ? PlatformType.UNIX : PlatformType.Windows);
        }
    }
}
