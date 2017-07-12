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
    public class PackageLister : IDisposable
    {
        #region Public Methods

        public PackageLister()
        {
            Temp = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());

            Directory.CreateDirectory(Temp);
        }

        private string Temp { get; set; }

        [Fact]
        public void Constructor()
        {
            Core.Plugin.PackageLister lister = new Core.Plugin.PackageLister(Directory.EnumerateFiles(Temp).ToList());

            Assert.IsType<Core.Plugin.PackageLister>(lister);
            Assert.NotNull(lister.FileList);
        }

        public void Dispose()
        {
            Directory.Delete(Temp, true);
        }

        [Fact]
        public void ListEmptyDirectory()
        {
            Core.Plugin.PackageLister lister = new Core.Plugin.PackageLister(Directory.EnumerateFiles(Temp).ToList());

            IResult<IList<IPackage>> list = lister.List();

            Assert.Equal(ResultCode.Success, list.ResultCode);

            Assert.NotNull(list.ReturnValue);
            Assert.Equal(0, list.ReturnValue.Count);
        }

        [Fact]
        public void ListNoPackages()
        {
            File.WriteAllText(Path.Combine(Temp, "package.zip"), "hello world!");

            Core.Plugin.PackageLister lister = new Core.Plugin.PackageLister(Directory.EnumerateFiles(Temp).ToList());

            IResult<IList<IPackage>> list = lister.List();

            Assert.Equal(ResultCode.Warning, list.ResultCode);
            Assert.Equal(0, list.ReturnValue.Count);
        }

        [Fact]

        #endregion Public Methods
    }
}