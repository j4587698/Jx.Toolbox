using System;
using System.ComponentModel;
using System.Reflection;

namespace Jx.Toolbox.Extensions
{
    /// <summary>
    /// 枚举类型扩展
    /// </summary>
    public static class EnumExtension
    {
        /// <summary>
        /// 将字符串转换位对应的枚举
        /// </summary>
        /// <param name="value"></param>
        /// <param name="ignoreCase"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T ToEnum<T>(this string value, bool ignoreCase = true) where T: Enum
        {
            return (T)ToEnum(typeof(T), value, ignoreCase);
        }

        /// <summary>
        /// 将字符串转换位对应的枚举，如果转换失败，返回默认值
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <param name="ignoreCase"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T ToEnum<T>(this string value, T defaultValue, bool ignoreCase = true) where T : struct, Enum
        {
            return !value.IsNullOrWhiteSpace() && Enum.TryParse(value, ignoreCase, out T @enum)
                ? @enum
                : defaultValue;
        }

        /// <summary>
        /// 将字符串转换成对应的枚举
        /// </summary>
        /// <param name="enumType"></param>
        /// <param name="value"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static object ToEnum(this Type enumType, string value, bool ignoreCase = true)
        {
            if (!enumType.IsEnum)
            {
                throw new ArgumentException("类型不是枚举类型");
            }
            return Enum.Parse(enumType, value, ignoreCase);
        }

        /// <summary>
        /// 获取枚举对应的Description，为空则返回枚举本身
        /// </summary>
        /// <param name="enum"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum @enum)
        {
            var field = @enum.GetType().GetField(@enum.ToString());
            var attr = field.GetCustomAttribute(typeof(DescriptionAttribute));
            return attr == null ? @enum.ToString() : (attr as DescriptionAttribute)?.Description;
        }
    }
}