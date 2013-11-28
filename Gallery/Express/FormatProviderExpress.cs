using System;
using System.Threading;

namespace Gallery.Express
{
    /// <summary>
    /// 定制格式化器
    /// </summary>
    public class FormatProviderExpress : IFormatProvider, ICustomFormatter
    {
        /// <summary>
        /// 返回一个对象，该对象为指定类型提供格式设置服务。
        /// </summary>
        /// <param name="formatType">一个对象，该对象指定要返回的格式对象的类型。</param>
        /// <returns>如果 System.IFormatProvider 实现能够提供该类型的对象，则为 formatType 所指定对象的实例；否则为 null。</returns>
        public virtual object GetFormat(Type formatType)
        {
            return formatType == typeof (ICustomFormatter)
                ? this
                : Thread.CurrentThread.CurrentCulture.GetFormat(formatType);
        }

        /// <summary>
        /// 使用指定的格式和区域性特定格式设置信息将指定对象的值转换为等效的字符串表示形式。
        /// </summary>
        /// <param name="format">包含格式规范的格式字符串。</param>
        /// <param name="arg">要设置格式的对象。</param>
        /// <param name="formatProvider">一个对象，它提供有关当前实例的格式信息。</param>
        /// <returns>arg 的值的字符串表示形式，按照 format 和 formatProvider 的指定来进行格式设置。</returns>
        public virtual string Format(string format, object arg, IFormatProvider formatProvider)
        {
            IFormattable formattable = arg as IFormattable;

            return null == formattable
                ? arg.ToString()
                : formattable.ToString(format, formatProvider);
        }
    }
}
