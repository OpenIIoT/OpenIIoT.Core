using Xunit;
using Moq;
using OpenIIoT.SDK.Platform;
using System;
using System.IO;

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
        }

        public void Dispose()
        {
            Directory.Delete(Temp, true);
        }

        [Fact]
        public void ListEmptyDirectory()
        {
        }

        #endregion Public Methods
    }
}