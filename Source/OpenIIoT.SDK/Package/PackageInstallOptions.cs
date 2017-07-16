using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenIIoT.SDK.Package
{
    [Flags]
    public enum PackageInstallOptions
    {
        None = 0,
        SkipVerification = 1,
        Overwrite = 2
    }
}