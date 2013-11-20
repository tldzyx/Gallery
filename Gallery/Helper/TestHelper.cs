using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Gallery.Helper
{
    public static class TestHelper
    {
        public class OperationTimer : IDisposable
        {
            private long _startTime;
            private string _text;
            private int _collectionCount;

            public OperationTimer(string text)
            {
                PrepareForOperationg();

                _text = text;
                _collectionCount = GC.CollectionCount(0);

                _startTime = Stopwatch.GetTimestamp();
            }
        
            public void Dispose()
            {
                Console.WriteLine(
                    "{0,6:##0.00} seconds (GCs={1,3}) {2}",
                    (Stopwatch.GetTimestamp() - _startTime) /
                        (double)Stopwatch.Frequency,
                    GC.CollectionCount(0) - _collectionCount,
                    _text);
            }

            private void PrepareForOperationg()
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }
        }
    }
}
