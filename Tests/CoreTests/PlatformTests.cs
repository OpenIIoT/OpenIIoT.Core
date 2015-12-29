using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Symbiote.Core;
using Symbiote.Core.Platform;

namespace CoreTests
{
    [TestClass]
    public class PlatformTests
    {
        [TestMethod]
        public void TestWindowsRefresh()
        {
            var platform = new WindowsPlatform();
            Assert.IsNotNull(platform.Info);
            Assert.IsNotNull(platform.Type);
            Assert.AreNotEqual("", platform.Version);
            Assert.AreNotEqual(0, platform.Info.CPUTime);
        }

        [TestMethod]
        public void TestUNIXRefresh()
        {
            var platform = new UNIXPlatform();
            Assert.IsNotNull(platform.Info);
            Assert.IsNotNull(platform.Type);
            Assert.AreNotEqual("", platform.Version);
            Assert.AreNotEqual(0, platform.Info.CPUTime);
        }
    }
}
