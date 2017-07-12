using Xunit;
using Moq;
using OpenIIoT.SDK.Platform;
using System;
using System.IO;
using Utility.OperationResult;
using System.Collections.Generic;
using OpenIIoT.SDK.Plugin;

namespace OpenIIoT.Core.Tests.Plugin
{
    public class PackageLister : IDisposable
    {
        #region Public Methods

        public PackageLister()
        {
            Temp = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());

            Directory.CreateDirectory(Temp);

            Mock<IDirectories> directories = new Mock<IDirectories>();
            directories.Setup(s => s.Packages).Returns(Temp);

            Mock<IPlatform> platform = new Mock<IPlatform>();
            platform.Setup(p => p.Directories).Returns(directories.Object);
            platform.Setup(p => p.ListDirectories(It.IsAny<string>(), It.IsAny<string>()).Returns();

            Platform = platform.Object;

            Lister = new Core.Plugin.PackageLister(Platform);
        }

        private Core.Plugin.PackageLister Lister { get; set; }
        private IPlatform Platform { get; set; }
        private string Temp { get; set; }

        [Fact]
        public void Constructor()
        {
            Assert.IsType<Core.Plugin.PackageLister>(Lister);
            Assert.NotNull(Lister.Directory);
        }

        public void Dispose()
        {
            Directory.Delete(Temp, true);
        }

        [Fact]
        public void ListEmptyDirectory()
        {
            IResult<IList<IPackage>> list = Lister.List();

            Assert.Equal(ResultCode.Success, list.ResultCode);

            Assert.NotNull(list.ReturnValue);
            Assert.Equal(0, list.ReturnValue.Count);
        }

        [Fact]
        public void ListNoPackages()
        {
            File.WriteAllText(Path.Combine(Temp, "package.zip"), "hello world!");

            IResult<IList<IPackage>> list = Lister.List();

            Assert.Equal(ResultCode.Warning, list.ResultCode);
            Assert.Equal(0, list.ReturnValue.Count);
        }

        #endregion Public Methods
    }
}