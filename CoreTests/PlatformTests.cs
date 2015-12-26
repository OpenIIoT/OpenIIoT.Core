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
            var windowsPlatform = new WindowsPlatform();
            Assert.IsNotNull(windowsPlatform.Info);
            Assert.IsNotNull(windowsPlatform.Type);
            Assert.AreNotEqual("", windowsPlatform.Version);
            Assert.AreNotEqual(0, windowsPlatform.Info.CPUTime);
        }
    }
}
