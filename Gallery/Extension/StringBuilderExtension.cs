using System.Globalization;
using System.Text;

namespace Gallery.Extension
{
    /// <summary>
    /// 可变字符字符串拓展
    /// </summary>
    public static class StringBuilderExtension
    {
        /// <summary>
        /// 将字符串转换为小写形式。
        /// </summary>
        /// <param name="builder">可变字符字符串。</param>
        /// <returns>完成转换操作后字符串的引用。</returns>
        public static StringBuilder ToLower(this StringBuilder builder)
        {
            string str = builder.ToString();
            builder.Clear();
            builder.Append(str.ToLower());
            return builder;
        }

        /// <summary>
        /// 根据指定区域性的大小写规则将字符串转换为小写形式。
        /// </summary>
        /// <param name="builder">可变字符字符串。</param>
        /// <param name="culture">一个对象，用于提供区域性特定的大小写规则。</param>
        /// <returns>完成转换操作后字符串的引用。</returns>
        public static StringBuilder ToLower(this StringBuilder builder, CultureInfo culture)
        {
            string str = builder.ToString();
            builder.Clear();
            builder.Append(str.ToLower(culture));
            return builder;
        }

        /// <summary>
        /// 使用固定区域性的大小写规则将字符串转换为小写形式。
        /// </summary>
        /// <param name="builder">可变字符字符串。</param>
        /// <returns>完成转换操作后字符串的引用。</returns>
        public static StringBuilder ToLowerInvariant(this StringBuilder builder)
        {
            string str = builder.ToString();
            builder.Clear();
            builder.Append(str.ToLowerInvariant());
            return builder;
        }

        /// <summary>
        /// 将字符串转换为大写形式。
        /// </summary>
        /// <param name="builder">可变字符字符串。</param>
        /// <returns>完成转换操作后字符串的引用。</returns>
        public static StringBuilder ToUpper(this StringBuilder builder)
        {
            string str = builder.ToString();
            builder.Clear();
            builder.Append(str.ToUpper());
            return builder;
        }

        /// <summary>
        /// 根据指定区域性的大小写规则将字符串转换为大写形式。
        /// </summary>
        /// <param name="builder">可变字符字符串。</param>
        /// <param name="culture">一个对象，用于提供区域性特定的大小写规则。</param>
        /// <returns>完成转换操作后字符串的引用。</returns>
        public static StringBuilder ToUpper(this StringBuilder builder, CultureInfo culture)
        {
            string str = builder.ToString();
            builder.Clear();
            builder.Append(str.ToUpper(culture));
            return builder;
        }

        /// <summary>
        /// 使用固定区域性的大小写规则将字符串转换为大写形式。
        /// </summary>
        /// <param name="builder">可变字符字符串。</param>
        /// <returns>完成转换操作后字符串的引用。</returns>
        public static StringBuilder ToUpperInvariant(this StringBuilder builder)
        {
            string str = builder.ToString();
            builder.Clear();
            builder.Append(str.ToUpperInvariant());
            return builder;
        }

        /// <summary>
        /// 字符串通过在此实例中的字符左侧填充空格来达到指定的总长度，从而实现右对齐。
        /// </summary>
        /// <param name="builder">可变字符字符串。</param>
        /// <param name="totalWidth">结果字符串中的字符数，等于原始字符数加上任何其他填充字符。</param>
        /// <returns>完成填充操作后字符串的引用。</returns>
        public static StringBuilder PadLeft(this StringBuilder builder, int totalWidth)
        {
            string str = builder.ToString();
            builder.Clear();
            builder.Append(str.PadLeft(totalWidth));
            return builder;
        }

        /// <summary>
        /// 字符串通过在此实例中的字符左侧填充指定的 Unicode 字符来达到指定的总长度，从而使这些字符右对齐。
        /// </summary>
        /// <param name="builder">可变字符字符串。</param>
        /// <param name="totalWidth">结果字符串中的字符数，等于原始字符数加上任何其他填充字符。</param>
        /// <param name="paddingChar">Unicode 填充字符。</param>
        /// <returns>完成填充操作后字符串的引用。</returns>
        public static StringBuilder PadLeft(this StringBuilder builder, int totalWidth, char paddingChar)
        {
            string str = builder.ToString();
            builder.Clear();
            builder.Append(str.PadLeft(totalWidth, paddingChar));
            return builder;
        }

        /// <summary>
        /// 字符串通过在此实例中的字符右侧填充空格来达到指定的总长度，从而实现左对齐。
        /// </summary>
        /// <param name="builder">可变字符字符串。</param>
        /// <param name="totalWidth">结果字符串中的字符数，等于原始字符数加上任何其他填充字符。</param>
        /// <returns>完成填充操作后字符串的引用。</returns>
        public static StringBuilder PadRight(this StringBuilder builder, int totalWidth)
        {
            string str = builder.ToString();
            builder.Clear();
            builder.Append(str.PadRight(totalWidth));
            return builder;
        }

        /// <summary>
        /// 字符串通过在此实例中的字符右侧填充指定的 Unicode 字符来达到指定的总长度，从而使这些字符左对齐。
        /// </summary>
        /// <param name="builder">可变字符字符串。</param>
        /// <param name="totalWidth">结果字符串中的字符数，等于原始字符数加上任何其他填充字符。</param>
        /// <param name="paddingChar">Unicode 填充字符。</param>
        /// <returns>完成填充操作后字符串的引用。</returns>
        public static StringBuilder PadRight(this StringBuilder builder, int totalWidth, char paddingChar)
        {
            string str = builder.ToString();
            builder.Clear();
            builder.Append(str.PadRight(totalWidth, paddingChar));
            return builder;
        }

        /// <summary>
        /// 从字符串对象移除所有前导空白字符和尾部空白字符。
        /// </summary>
        /// <param name="builder">可变字符字符串。</param>
        /// <returns>完成移除操作后字符串的引用。</returns>
        public static StringBuilder Trim(this StringBuilder builder)
        {
            string str = builder.ToString();
            builder.Clear();
            builder.Append(str.Trim());
            return builder;
        }

        /// <summary>
        /// 从字符串对象移除数组中指定的一组字符的所有前导匹配项和尾部匹配项。
        /// </summary>
        /// <param name="builder">可变字符字符串。</param>
        /// <param name="trimChars">要删除的 Unicode 字符的数组，或 null。</param>
        /// <returns>完成移除操作后字符串的引用。</returns>
        public static StringBuilder Trim(this StringBuilder builder, params char[] trimChars)
        {
            string str = builder.ToString();
            builder.Clear();
            builder.Append(str.Trim(trimChars));
            return builder;
        }

        /// <summary>
        /// 从字符串对象移除数组中指定的一组字符的所有前导匹配项。
        /// </summary>
        /// <param name="builder">可变字符字符串。</param>
        /// <param name="trimChars">要删除的 Unicode 字符的数组，或 null。</param>
        /// <returns>完成移除操作后字符串的引用。</returns>
        public static StringBuilder TrimStart(this StringBuilder builder, params char[] trimChars)
        {
            string str = builder.ToString();
            builder.Clear();
            builder.Append(str.TrimStart(trimChars));
            return builder;
        }

        /// <summary>
        /// 从字符串对象移除数组中指定的一组字符的所有尾部匹配项。
        /// </summary>
        /// <param name="builder">可变字符字符串。</param>
        /// <param name="trimChars">要删除的 Unicode 字符的数组，或 null。</param>
        /// <returns>完成移除操作后字符串的引用。</returns>
        public static StringBuilder TrimEnd(this StringBuilder builder, params char[] trimChars)
        {
            string str = builder.ToString();
            builder.Clear();
            builder.Append(str.TrimEnd(trimChars));
            return builder;
        }
    }
}
