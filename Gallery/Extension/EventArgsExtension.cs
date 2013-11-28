using System;
using System.Threading;

namespace Gallery.Extension
{
    /// <summary>
    /// 事件拓展
    /// </summary>
    public static class EventArgsExtension
    {
        /// <summary>
        /// 线程安全的事件调用拓展
        /// </summary>
        /// <typeparam name="TEventArgs">事件数据类型</typeparam>
        /// <param name="e">事件数据</param>
        /// <param name="sender">事件源</param>
        /// <param name="eventDelegate">处理事件的方法</param>
        public static void Raise<TEventArgs>(
            this TEventArgs e,
            object sender,
            ref EventHandler<TEventArgs> eventDelegate)
            where TEventArgs : EventArgs
        {
            // 出于线程安全的考虑，现在将对委托字段的引用复制到一个临时字段中
            EventHandler<TEventArgs> handle =
                Interlocked.CompareExchange(ref eventDelegate, null, null);

            // 任何方法登记了对我们事件的关注，就通知它们
            if (handle != null)
                handle(sender, e);
        }
    }
}
