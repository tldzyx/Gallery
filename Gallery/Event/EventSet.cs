using System;
using System.Collections.Generic;

namespace Gallery.Event
{
    /// <summary>
    /// 事件容器
    /// </summary>
    public class EventSet : IDisposable
    {
        // 私有字典用于维护EventKey -> Delegate映射
        private readonly Dictionary<EventKey, Delegate> _events =
            new Dictionary<EventKey, Delegate>();

        private readonly object _lock = new object();

        /// <summary>
        /// 添加一个EventKey -> Delegate映射(如果EventKey不存在),
        /// 或者将一个委托与一个现有的EventKey合并
        /// </summary>
        /// <param name="eventKey">事件组键</param>
        /// <param name="handler">事件方法</param>
        public void Add(EventKey eventKey, Delegate handler)
        {
            Delegate d;
            lock (_lock)
            {
                _events.TryGetValue(eventKey, out d);
                _events[eventKey] = Delegate.Combine(d, handler);
            }
        }

        /// <summary>
        /// 从EventKey(如果它存在)删除一个委托，并且
        /// 在删除最后一个委托时删除EventKey -> Delegate映射
        /// </summary>
        /// <param name="eventKey">事件组键</param>
        /// <param name="handler">事件方法</param>
        public void Remove(EventKey eventKey, Delegate handler)
        {
            Delegate d;
            lock (_lock)
            {
                // 调用TryGetValue，确保在尝试从集合中删除一个不存在的EventKey时，
                // 不会抛出一个异常。
                if (_events.TryGetValue(eventKey, out d))
                {
                    d = Delegate.Remove(d, handler);

                    // 如果还有委托，就设置新的头部(地址)，否则删除EventKey
                    if (d != null)
                        _events[eventKey] = d;
                    else
                        _events.Remove(eventKey);
                }
            }
        }

        /// <summary>
        /// 从EventKey(如果它存在)清除一个委托，并且
        /// 在清除最后一个委托时删除EventKey -> Delegate映射
        /// </summary>
        /// <param name="eventKey">事件组键</param>
        /// <param name="handler">事件方法</param>
        public void Clear(EventKey eventKey, Delegate handler)
        {
            Delegate d;
            lock (_lock)
            {
                // 调用TryGetValue，确保在尝试从集合中清除一个不存在的EventKey时，
                // 不会抛出一个异常。
                if (_events.TryGetValue(eventKey, out d))
                {
                    d = Delegate.RemoveAll(d, handler);

                    // 如果还有委托，就设置新的头部(地址)，否则删除EventKey
                    if (d != null)
                        _events[eventKey] = d;
                    else
                        _events.Remove(eventKey);
                }
            }
        }

        /// <summary>
        /// 为指定的EventKey引发事件
        /// </summary>
        /// <param name="eventKey">事件组键</param>
        /// <param name="args">事件方法参数</param>
        public void Raise(EventKey eventKey, params object[] args)
        {
            Delegate d;
            lock (_lock)
            {
                // 如果EventKey不在集合中，不抛出一个异常
                _events.TryGetValue(eventKey, out d);
            }

            if (d != null)
            {
                // 由于字典可能包含几个不同的委托类型，
                // 所以无法在编译时构造一个类型安全的委托调用。
                // 因此，我们调用System.Delegate类型的DynamicInvoke
                // 方法，以一个对象数组的形式向它传递回调方法的参数。
                // 在内部，DynamicInvoke会向调用的回调方法查证参数的
                // 类型安全性，并调用方法。
                // 如果存在类型不匹配的情况，DynamicInvoke会抛出一个异常。
                d.DynamicInvoke(args);
            }
        }

        void IDisposable.Dispose()
        {
            lock (_lock)
            {
                _events.Clear();
            }
        }
    }
}
