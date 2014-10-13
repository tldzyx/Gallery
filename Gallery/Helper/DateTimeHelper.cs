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

        #endregion

        /// <summary>
        /// 将C#的DateTime对象转换成C++time_t值,精度精确到毫秒
        /// </summary>
        /// <param name="time">Windows时间</param>
        /// <returns>Unix时间</returns>
        public static long ToUnixTimeUtc(DateTime time)
        {
            if (DateTimeKind.Local == time.Kind)
            {
                time = time.ToUniversalTime();
            }
            return (time.Ticks / TicksRatioMillisecond - Milliseconds19700101000000Utc);
        }

        /// <summary>
        /// 将C++的time_t值转换成C#的DateTime对象,精度精确到毫秒
        /// </summary>
        /// <param name="millisecond">Unix时间</param>
        /// <returns>Windows时间</returns>
        public static DateTime FromUnixTimeUtc(long millisecond)
        {
            return new DateTime(millisecond * TicksRatioMillisecond + Ticks19700101000000Utc, DateTimeKind.Utc);
        }
    }
}