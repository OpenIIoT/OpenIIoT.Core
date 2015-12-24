using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbiote.Core
{
    class Platform
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
                return new WindowsPlatform();
            }
            return null;
        }

        public static PlatformType GetPlatformType()
        {
            int p = (int)Environment.OSVersion.Platform;
            return ((p == 4) || (p == 6) || (p == 128) ? PlatformType.UNIX : PlatformType.Windows);
        }
    }
}
