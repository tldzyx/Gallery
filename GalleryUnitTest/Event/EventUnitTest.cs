using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace GalleryUnitTest.Event
{
    [TestClass]
    public class EventUnitTest
    {
        [TestMethod]
        public void TestMethod_Event()
        {
            TypeWithLotsOfEvents twle = new TypeWithLotsOfEvents();

            // 添加一个回调
            twle.Foo += FooEventArgs.HandleFooEvent;

            // 证明确实可行
            FooEventArgs e = new FooEventArgs();
            twle.SimulateFoo(this, e);
            Assert.IsTrue(e.IsHandled);

        }
    }
}
