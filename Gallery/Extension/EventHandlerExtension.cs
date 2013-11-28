using System;
using System.Threading;

namespace Gallery.Extension
{
    /// <summary>
    /// 处理事件的方法拓展
    /// </summary>
    public static class EventHandlerExtension
    {
        /// <summary>
        /// 将委托添加到事件
        /// </summary>
        /// <typeparam name="TEventArgs">委托参数类型</typeparam>
        /// <param name="delegateHandler">待添加的委托</param>
        /// <param name="eventHandler">事件</param>
        public static void AddHandler<TEventArgs>(
            this EventHandler<TEventArgs> delegateHandler,
            ref EventHandler<TEventArgs> eventHandler)
            where TEventArgs : EventArgs
        {
            // 通过循环和对CompareExchange的调用，可以
            // 以一种线程安全的方式向事件添加一个委托
            EventHandler<TEventArgs> prevHandler;
            EventHandler<TEventArgs> currentHandler = eventHandler;
            do 
            {
                prevHandler = currentHandler;
                EventHandler<TEventArgs> nextHandler =
                    (EventHandler<TEventArgs>)Delegate.Combine(prevHandler, delegateHandler);
                currentHandler = Interlocked.CompareExchange(
                    ref eventHandler, nextHandler, prevHandler);
            } while (currentHandler != prevHandler);
        }

        /// <summary>
        /// 将委托从事件移除
        /// </summary>
        /// <typeparam name="TEventArgs">委托参数类型</typeparam>
        /// <param name="delegateHandler">待移除的委托</param>
        /// <param name="eventHandler">事件</param>
        public static void RemoveHandler<TEventArgs>(
            this EventHandler<TEventArgs> delegateHandler,
            ref EventHandler<TEventArgs> eventHandler)
            where TEventArgs : EventArgs
        {
            // 通过循环和对CompareExchange的调用，可以
            // 以一种线程安全的方式从事件中移除一个委托
            EventHandler<TEventArgs> prevHandler;
            EventHandler<TEventArgs> currentHandler = eventHandler;
            do
            {
                prevHandler = currentHandler;
                EventHandler<TEventArgs> nextHandler =
                    (EventHandler<TEventArgs>)Delegate.Remove(prevHandler, delegateHandler);
                currentHandler = Interlocked.CompareExchange(
                    ref eventHandler, nextHandler, prevHandler);
            } while (currentHandler != prevHandler);
        }

        /// <summary>
        /// 将委托从事件清除
        /// </summary>
        /// <typeparam name="TEventArgs">委托参数类型</typeparam>
        /// <param name="delegateHandler">待清除的委托</param>
        /// <param name="eventHandler">事件</param>
        public static void ClearHandler<TEventArgs>(
            this EventHandler<TEventArgs> delegateHandler,
            ref EventHandler<TEventArgs> eventHandler)
            where TEventArgs : EventArgs
        {
            // 通过循环和对CompareExchange的调用，可以
            // 以一种线程安全的方式从事件中清除一个委托
            EventHandler<TEventArgs> prevHandler;
            EventHandler<TEventArgs> currentHandler = eventHandler;
            do
            {
                prevHandler = currentHandler;
                EventHandler<TEventArgs> nextHandler =
                    (EventHandler<TEventArgs>)Delegate.RemoveAll(prevHandler, delegateHandler);
                currentHandler = Interlocked.CompareExchange(
                    ref eventHandler, nextHandler, prevHandler);
            } while (currentHandler != prevHandler);
        }
    }
}
