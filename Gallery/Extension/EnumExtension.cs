using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Gallery.Extension
{
    /// <summary>
    ///     枚举拓展
    /// </summary>
    public static class EnumExtension
    {
        private static readonly IDictionary<Type, IDictionary<string, string>> __dictionary =
            new ConcurrentDictionary<Type, IDictionary<string, string>>();

        /// <summary>
        ///     获取枚举的描述(Gallery.Extension.EnumDescriptionAttribute特性)，
        ///     约定枚举的各项值唯一
        /// </summary>
        /// <param name="value">枚举值</param>
        /// <returns>描述</returns>
        public static string ToDescription(this Enum value)
        {
            Type enumType = value.GetType();

            string enumName = Enum.GetName(enumType, value);
            if (null == enumName)
            {
                return EnumDescriptionAttribute.Default.Description;
            }

            IDictionary<string, string> valueDictionary;
            if (!__dictionary.TryGetValue(enumType, out valueDictionary))
            {
                valueDictionary = new ConcurrentDictionary<string, string>();
                __dictionary[enumType] = valueDictionary;
            }
            string enumDescription;
            if (!valueDictionary.TryGetValue(enumName, out enumDescription))
            {
                FieldInfo fieldInfo = enumType.GetField(enumName);
                EnumDescriptionAttribute attribute = fieldInfo
                    .GetCustomAttributes(typeof (EnumDescriptionAttribute), false)
                    .OfType<EnumDescriptionAttribute>().SingleOrDefault();
                enumDescription =
                    attribute != null ? attribute.Description : enumName;
                valueDictionary[enumName] = enumDescription;
            }

            return enumDescription;
        }
    }

    /// <summary>
    ///     描述
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class EnumDescriptionAttribute : Attribute
    {
        /// <summary>
        ///     默认值(空字符串)
        /// </summary>
        public static readonly EnumDescriptionAttribute Default = new EnumDescriptionAttribute(
            string.Empty);

        /// <summary>
        ///     描述
        /// </summary>
        public string Description
        {
            get { return _description; }
        }
        private readonly string _description;

        /// <summary>
        ///     初始化
        /// </summary>
        /// <param name="description">描述值</param>
        public EnumDescriptionAttribute(string description)
        {
            _description = description ?? string.Empty;
        }

        /// <summary>
        ///     确定此实例是否与指定的对象相同或具有相同的Description值。
        /// </summary>
        public override bool Equals(object obj)
        {
            if (obj == this)
            {
                return true;
            }
            var attribute = obj as EnumDescriptionAttribute;
            return ((attribute != null) && (attribute.Description == Description));
        }

        /// <summary>
        ///     返回该对象的Description属性的哈希代码
        /// </summary>
        public override int GetHashCode()
        {
            return Description.GetHashCode();
        }

        /// <summary>
        ///     是否与默认特性相同
        /// </summary>
        public override bool IsDefaultAttribute()
        {
            return Equals(Default);
        }
    }
}