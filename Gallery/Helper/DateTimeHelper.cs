using System;

namespace Gallery.Helper
{
    /// <summary>
    /// 时刻助手
    /// </summary>
    public static class DateTimeHelper
    {
        #region 换算常量

        // DateTime与time_t的精度比
        private const long TicksRatioMillisecond = 10000;
        // 从DateTime的起始时间到time_t的起始时间的间隔毫秒数
        private const long Milliseconds19700101000000Utc
            = (60 * 60 * 24) * (365 * 1969L + (1970 / 4 - 1970 / 100 + 1970 / 400)) * 1000;
        // 从DateTime的起始时间到time_t的起始时间的时钟数
        private const long Ticks19700101000000Utc
            = Milliseconds19700101000000Utc * TicksRatioMillisecond;
        // 时区GTM+8
        private const long MillisecondFromUtcToLocal
            = (60 * 60) * 8 * 1000;
        // =0x000000430e234000
        private const long TickFromUtcToLocal
            = MillisecondFromUtcToLocal * TicksRatioMillisecond;
        // =0x0000000E77926780
        private const long Millisecond19700101000000Local
            = Milliseconds19700101000000Utc + MillisecondFromUtcToLocal;
        // =0x089F803905D8C000
        private const long Ticks19700101000000Local
            = Millisecond19700101000000Local * TicksRatioMillisecond;

        #endregion

        /// <summary>
        /// 将C#的DateTime对象转换成C++time_t值,精度精确到毫秒
        /// </summary>
        /// <param name="time">Windows时间</param>
        /// <param name="kind">时间类型</param>
        /// <returns>Unix时间</returns>
        public static long ToUnixTime(DateTime time, DateTimeKind kind = DateTimeKind.Unspecified)
        {
            if (time.Kind != DateTimeKind.Unspecified)
                kind = time.Kind;
            return (time.Ticks / TicksRatioMillisecond - (DateTimeKind.Utc == kind ? Milliseconds19700101000000Utc : Millisecond19700101000000Local) + MillisecondFromUtcToLocal);
        }

        /// <summary>
        /// 将C#的DateTime对象转换成C++time_t值,精度精确到毫秒
        /// </summary>
        /// <param name="time">Windows时间</param>
        /// <param name="kind">时间类型</param>
        /// <returns>Unix时间</returns>
        public static long ToUnixTimeUtc(DateTime time, DateTimeKind kind = DateTimeKind.Unspecified)
        {
            if (time.Kind != DateTimeKind.Unspecified)
                kind = time.Kind;
            return (time.Ticks / TicksRatioMillisecond - (DateTimeKind.Utc == kind ? Milliseconds19700101000000Utc : Millisecond19700101000000Local));
        }

        /// <summary>
        /// 将C++的time_t值转换成C#的DateTime对象,精度精确到毫秒
        /// </summary>
        /// <param name="millisecond">Unix时间</param>
        /// <param name="kind">时间类型</param>
        /// <returns>Windows时间</returns>
        public static DateTime FromUnixTime(long millisecond, DateTimeKind kind = DateTimeKind.Unspecified)
        {
            return new DateTime(millisecond * TicksRatioMillisecond + (DateTimeKind.Utc == kind ? Ticks19700101000000Utc : Ticks19700101000000Local) - TickFromUtcToLocal, kind);  
        }

        /// <summary>
        /// 将C++的time_t值转换成C#的DateTime对象,精度精确到毫秒
        /// </summary>
        /// <param name="millisecond">Unix时间</param>
        /// <param name="kind">时间类型</param>
        /// <returns>Windows时间</returns>
        public static DateTime FromUnixTimeUtc(long millisecond, DateTimeKind kind = DateTimeKind.Unspecified)
        {
            return new DateTime(millisecond * TicksRatioMillisecond + (DateTimeKind.Utc == kind ? Ticks19700101000000Utc : Ticks19700101000000Local), kind);
        }
    }
}