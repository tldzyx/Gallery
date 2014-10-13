using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gallery.Helper;

namespace GalleryUnitTest.Helper
{
    [TestClass]
    public class DateTimeHelperUnitTest
    {
        private static readonly DateTime __csTimeUtc = new DateTime(2014, 10, 13, 14, 0, 0, DateTimeKind.Utc);
        private static readonly long CppTimeUtc = (long)(__csTimeUtc - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
        private static readonly DateTime __csTimeLocal = __csTimeUtc.ToLocalTime();
        
        [TestMethod]
        public void TestMethod_FromUnixTime()
        {
            DateTime csTimeUtcUtc = DateTimeHelper.FromUnixTimeUtc(CppTimeUtc);
            Assert.AreEqual(DateTimeKind.Utc, csTimeUtcUtc.Kind);
            Assert.AreEqual(__csTimeUtc, csTimeUtcUtc);
            DateTime csTimeLocalUtc = DateTimeHelper.FromUnixTimeUtc(CppTimeUtc).ToLocalTime();
            Assert.AreEqual(DateTimeKind.Local, csTimeLocalUtc.Kind);
            Assert.AreEqual(__csTimeLocal, csTimeLocalUtc);
        }

        [TestMethod]
        public void TestMethod_ToUnixTime()
        {
            long cppTimeUtcUtc = DateTimeHelper.ToUnixTimeUtc(__csTimeUtc);
            Assert.AreEqual(CppTimeUtc, cppTimeUtcUtc);
            long cppTimeLocalUtc = DateTimeHelper.ToUnixTimeUtc(__csTimeLocal);
            Assert.AreEqual(CppTimeUtc, cppTimeLocalUtc);
        }
    }
}
