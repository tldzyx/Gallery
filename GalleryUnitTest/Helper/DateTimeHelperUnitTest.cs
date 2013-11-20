using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gallery.Helper;

namespace GalleryUnitTest.Helper
{
    [TestClass]
    public class DateTimeHelperUnitTest
    {
        private const long CppTimeUtc = 1382976000000;
        private const long CppTimeLocal = 1383004800000;
        private static readonly DateTime __csTimeUtc = new DateTime(2013, 10, 28, 16, 0, 0, DateTimeKind.Utc);
        private static readonly DateTime __csTimeLocal = new DateTime(2013, 10, 29, 0, 0, 0, DateTimeKind.Local);
        
        [TestMethod]
        public void TestMethod_FromUnixTime()
        {
            DateTime csTimeUnspecifiedUtc = DateTimeHelper.FromUnixTimeUtc(CppTimeUtc, DateTimeKind.Unspecified);
            Assert.AreEqual(DateTimeKind.Unspecified, csTimeUnspecifiedUtc.Kind);
            Assert.AreEqual(__csTimeLocal, csTimeUnspecifiedUtc);
            DateTime csTimeUtcUtc = DateTimeHelper.FromUnixTimeUtc(CppTimeUtc, DateTimeKind.Utc);
            Assert.AreEqual(DateTimeKind.Utc, csTimeUtcUtc.Kind);
            Assert.AreEqual(__csTimeUtc, csTimeUtcUtc);
            DateTime csTimeLocalUtc = DateTimeHelper.FromUnixTimeUtc(CppTimeUtc, DateTimeKind.Local);
            Assert.AreEqual(DateTimeKind.Local, csTimeLocalUtc.Kind);
            Assert.AreEqual(__csTimeLocal, csTimeLocalUtc);

            DateTime csTimeUnspecified = DateTimeHelper.FromUnixTime(CppTimeLocal, DateTimeKind.Unspecified);
            Assert.AreEqual(DateTimeKind.Unspecified, csTimeUnspecified.Kind);
            Assert.AreEqual(__csTimeLocal, csTimeUnspecified);
            DateTime csTimeUtc = DateTimeHelper.FromUnixTime(CppTimeLocal, DateTimeKind.Utc);
            Assert.AreEqual(DateTimeKind.Utc, csTimeUtc.Kind);
            Assert.AreEqual(__csTimeUtc, csTimeUtc);
            DateTime csTimeLocal = DateTimeHelper.FromUnixTime(CppTimeLocal, DateTimeKind.Local);
            Assert.AreEqual(DateTimeKind.Local, csTimeLocal.Kind);
            Assert.AreEqual(__csTimeLocal, csTimeLocal);
        }

        [TestMethod]
        public void TestMethod_ToUnixTime()
        {
            long cppTimeUnspecifiedUtc = DateTimeHelper.ToUnixTimeUtc(__csTimeUtc);
            Assert.AreEqual(CppTimeUtc, cppTimeUnspecifiedUtc);
            long cppTimeUtcUtc = DateTimeHelper.ToUnixTimeUtc(__csTimeUtc);
            Assert.AreEqual(CppTimeUtc, cppTimeUtcUtc);
            long cppTimeLocalUtc = DateTimeHelper.ToUnixTimeUtc(__csTimeUtc);
            Assert.AreEqual(CppTimeUtc, cppTimeLocalUtc);

            long cppTimeUnspecified = DateTimeHelper.ToUnixTime(__csTimeLocal);
            Assert.AreEqual(CppTimeLocal, cppTimeUnspecified);
            long cppTimeUtc = DateTimeHelper.ToUnixTime(__csTimeLocal);
            Assert.AreEqual(CppTimeLocal, cppTimeUtc);
            long cppTimeLocal = DateTimeHelper.ToUnixTime(__csTimeLocal);
            Assert.AreEqual(CppTimeLocal, cppTimeLocal);
        }
    }
}
