using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.OperationResult;

namespace OpenIIoT.SDK.Package
{
    public interface IPackageInstaller
    {
        IResult InstallPackage(string package, string publicKey = "");

        IResult InstallPackage(string package, PackageInstallOptions options = PackageInstallOptions.None, string publicKey = "");

        IResult InstallPackageAsync(string package, string publicKey = "");

        IResult InstallPackageAsync(string package, PackageInstallOptions options = PackageInstallOptions.None, string publicKey = "");

        IResult UninstallPackage(string FQN);

        IResult UninstallPackageAsync(string FQN);
    }
}