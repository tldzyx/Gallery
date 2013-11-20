using System;
using Gallery.Extension;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GalleryUnitTest.Extension
{
    [TestClass]
    public class EventHandlerExtensionUnitTest
    {
        private enum Position
        {
            Number,
            Zero,
            First,
            Second
        }

        private class TestArgs : EventArgs
        {
            public Position Position { get; private set; }

            public ulong Count { get; private set; }

            public static void Zero_Method(object sender, TestArgs e)
            {
                e.Position = Position.Zero;
                ++e.Count;
            }

            public static void First_Method(object sender, TestArgs e)
            {
                e.Position = Position.First;
                ++e.Count;
            }

            public static void Second_Method(object sender, TestArgs e)
            {
                e.Position = Position.Second;
                ++e.Count;
            }
        }

        [TestMethod]
        public void TestMethod_Handler()
        {
            TestArgs e = new TestArgs();

            EventHandler<TestArgs> zeroHandle = TestArgs.Zero_Method;
            EventHandler<TestArgs> firstHandle = TestArgs.First_Method;
            EventHandler<TestArgs> secondHandle = TestArgs.Second_Method;


            e.Raise(this, ref zeroHandle);
            Assert.AreEqual(Position.Zero, e.Position);
            Assert.AreEqual(1U, e.Count);

            firstHandle.AddHandler(ref zeroHandle);
            e.Raise(this, ref zeroHandle);
            Assert.AreEqual(Position.First, e.Position);
            Assert.AreEqual(3U, e.Count);

            secondHandle.AddHandler(ref zeroHandle);
            e.Raise(this, ref zeroHandle);
            Assert.AreEqual(Position.Second, e.Position);
            Assert.AreEqual(6U, e.Count);

            firstHandle.AddHandler(ref zeroHandle);
            e.Raise(this, ref zeroHandle);
            Assert.AreEqual(Position.First, e.Position);
            Assert.AreEqual(10U, e.Count);

            secondHandle.AddHandler(ref zeroHandle);
            e.Raise(this, ref zeroHandle);
            Assert.AreEqual(Position.Second, e.Position);
            Assert.AreEqual(15U, e.Count);

            secondHandle.ClearHandler(ref zeroHandle);
            e.Raise(this, ref zeroHandle);
            Assert.AreEqual(Position.First, e.Position);
            Assert.AreEqual(18U, e.Count);

            firstHandle.RemoveHandler(ref zeroHandle);
            e.Raise(this, ref zeroHandle);
            Assert.AreEqual(Position.First, e.Position);
            Assert.AreEqual(20U, e.Count);

        }
    }
}
