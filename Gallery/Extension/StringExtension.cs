
namespace Gallery.Extension
{
    /// <summary>
    /// 字符串拓展
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// 返回当前字符串对象的转换为大写形式的副本，返回时使用序号排序规则。
        /// </summary>
        /// <param name="str">当前字符串</param>
        /// <returns>当前字符串的大写形式。</returns>
        public static string ToUpperOrdinal(this string str)
        {
            return str.ToUpperInvariant();
        }

        /// <summary>
        /// 返回当前字符串转换为小写形式的副本，返回时使用序号排序规则。
        /// </summary>
        /// <param name="str">当前字符串</param>
        /// <returns>当前字符串的等效小写形式。</returns>
        public static string ToLowerOrdinal(this string str)
        {
            return str.ToLowerInvariant();
        }
    }
}
