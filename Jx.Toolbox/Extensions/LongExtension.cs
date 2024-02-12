using System;

namespace Jx.Toolbox.Extensions
{
    public static class LongExtension
    {
        private static readonly string[] SizeSuffixes = { "B", "KB", "MB", "GB", "TB", "PB", "EB" };

        /// <summary>
        /// 转换为可读进制（B,KB,MB,GB,TB,PB,EB）并保留两位小数
        /// </summary>
        /// <param name="value">要转换的数字（需可以转换为long）</param>
        /// <typeparam name="T"></typeparam>
        /// <returns>00.00 MB(KB,GB等)的字符串</returns>
        /// <exception cref="ArgumentException"></exception>
        public static string ToSizeString<T>(this T value) where T : IConvertible
        {
            try
            {
                // 将值转换为 long，这是因为字节通常是整数
                long byteCount = value.ToInt64(System.Globalization.CultureInfo.CurrentCulture);

                if (byteCount < 0) { return "-" + ToSizeString(-byteCount); }
                if (byteCount == 0) { return "0 B"; }

                int i = 0;
                double dValue = byteCount;
                while (dValue >= 1024 && i < SizeSuffixes.Length - 1)
                {
                    dValue /= 1024;
                    i++;
                }

                return string.Format("{0:0.##} {1}", dValue, SizeSuffixes[i]);
            }
            catch (OverflowException)
            {
                throw new ArgumentException("Value is too large to be represented as a byte count", nameof(value));
            }
            catch (InvalidCastException)
            {
                throw new ArgumentException("Value is not a recognized numeric type", nameof(value));
            }
        }
        
        /// <summary>
        /// 转换为00:00:00的格式
        /// </summary>
        /// <param name="value">要转换的数字（需可以转换为long）</param>
        /// <typeparam name="T"></typeparam>
        /// <returns>00:00:00格式的字符串</returns>
        /// <exception cref="ArgumentException"></exception>
        public static string ToTimeString<T>(this T value) where T : IConvertible
        {
            try
            {
                // 将值转换为long类型，这里假设传入的值表示的是秒数
                long seconds = value.ToInt64(System.Globalization.CultureInfo.CurrentCulture);

                // 使用TimeSpan从秒数创建时间间隔
                TimeSpan time = TimeSpan.FromSeconds(seconds);

                // 返回格式化的时间字符串
                return time.ToString(@"hh\:mm\:ss");
            }
            catch (OverflowException)
            {
                throw new ArgumentException("Value is too large to be represented as seconds", nameof(value));
            }
            catch (InvalidCastException)
            {
                throw new ArgumentException("Value is not a recognized numeric type", nameof(value));
            }
        }
    }
}