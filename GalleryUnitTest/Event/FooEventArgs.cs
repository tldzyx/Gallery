using System;

namespace GalleryUnitTest.Event
{
    // 为这个事件定义从EventArgs派生的类型
    public class FooEventArgs : EventArgs
    {
        public bool IsHandled { get; private set; }

        public static void HandleFooEvent(object sender, FooEventArgs e)
        {
            e.IsHandled = true;
        }
    }
}
