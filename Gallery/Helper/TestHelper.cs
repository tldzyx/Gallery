using System;
using System.Diagnostics;

namespace Gallery.Helper
{
    /// <summary>
    /// 测试助手
    /// </summary>
    public static class TestHelper
    {
        /// <summary>
        /// 操作计时器
        /// </summary>
        public class OperationTimer : IDisposable
        {
            private readonly long _startTime;
            private readonly string _text;
            private readonly int _collectionCount;

            /// <summary>
            /// 初始化操作计时器，开始计时
            /// </summary>
            /// <param name="text">计时器名称</param>
            public OperationTimer(string text)
            {
                PrepareForOperationg();

                _text = text;
                _collectionCount = GC.CollectionCount(0);

                _startTime = Stopwatch.GetTimestamp();
            }
        
            /// <summary>
            /// 结束计时，输出结果
            /// </summary>
            public void Dispose()
            {
                Console.WriteLine(
                    "{0,6:##0.00} seconds (GCs={1,3}) {2}",
                    (Stopwatch.GetTimestamp() - _startTime) /
                        (double)Stopwatch.Frequency,
                    GC.CollectionCount(0) - _collectionCount,
                    _text);
            }

            /// <summary>
            /// 强制垃圾回收
            /// </summary>
            private void PrepareForOperationg()
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }
        }
    }
}
