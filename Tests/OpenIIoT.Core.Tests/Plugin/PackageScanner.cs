using Xunit;
using Moq;
using OpenIIoT.SDK.Platform;
using System;
using System.IO;
using Utility.OperationResult;
using System.Collections.Generic;
using OpenIIoT.SDK.Plugin;
using System.Linq;

namespace OpenIIoT.Core.Tests.Plugin
{
    public class PackageScanner : IDisposable
    {
        #region Public Methods

        public PackageScanner()
        {
            Temp = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());

            Directory.CreateDirectory(Temp);

            Uri codeBaseUri = new Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            string codeBasePath = Uri.UnescapeDataString(codeBaseUri.AbsolutePath);
            string dirPath = Path.GetDirectoryName(codeBasePath);

            Data = Path.Combine(dirPath, "Plugin", "Data", "Package");
        }

        private string Data { get; set; }
        private string Temp { get; set; }

        [Fact]
        public void Constructor()
        {
            Core.Plugin.PackageScanner scanner = new Core.Plugin.PackageScanner(Directory.EnumerateFiles(Temp).ToList());

            Assert.IsType<Core.Plugin.PackageScanner>(scanner);
            Assert.NotNull(scanner.FileList);
        }

        public void Dispose()
        {
            Directory.Delete(Temp, true);
        }

        [Fact]
        public void ListEmptyDirectory()
        {
            Core.Plugin.PackageScanner lister = new Core.Plugin.PackageScanner(Directory.EnumerateFiles(Temp).ToList());

            IResult<IList<IPackage>> list = lister.Scan();

            Assert.Equal(ResultCode.Success, list.ResultCode);

            Assert.NotNull(list.ReturnValue);
            Assert.Equal(0, list.ReturnValue.Count);
        }

        [Fact]
        public void ListNoPackages()
        {
            File.WriteAllText(Path.Combine(Temp, "package.zip"), "hello world!");

            Core.Plugin.PackageScanner scanner = new Core.Plugin.PackageScanner(Directory.EnumerateFiles(Temp).ToList());

            IResult<IList<IPackage>> list = scanner.Scan();

            Assert.Equal(ResultCode.Warning, list.ResultCode);
            Assert.Equal(0, list.ReturnValue.Count);
        }

        [Fact]
        public void ListPackages()
        {
            Core.Plugin.PackageScanner scanner = new Core.Plugin.PackageScanner(Directory.EnumerateFiles(Data).ToList());

            IResult<IList<IPackage>> list = scanner.Scan();

            Assert.Equal(ResultCode.Success, list.ResultCode);
            Assert.Equal(3, list.ReturnValue.Count);

            // spot check a few Manifest fields to see if the manifest was fetched properly
            Assert.NotNull(list.ReturnValue[0].FQN);
            Assert.NotEqual(0, list.ReturnValue[0].FQN.Length);
        }

        #endregion Public Methods
    }
}