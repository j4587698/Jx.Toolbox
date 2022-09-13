using System;
using System.Collections.Generic;
using System.Linq;

namespace Jx.Toolbox.Utils
{
    /// <summary>
    /// 数字格式化
    /// </summary>
    public static class NumberFormat
    {
        /// <summary>
        /// 默认的进制字符串
        /// </summary>
        public static string DefaultDigits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        /// <summary>
        /// 数字转换为对应进制字符串
        /// </summary>
        /// <param name="number">要转换的数字</param>
        /// <param name="radix">进制</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static string ToDecimalString(long number, int radix)
        {
            if (radix < 2 || radix > DefaultDigits.Length)
            {
                throw new ArgumentException($"进制必须在2到{DefaultDigits.Length}之间，如需更多进制，请修改DefaultDigits");
            }

            if (number == 0)
            {
                return "0";
            }

            List<char> ret = new List<char>();
            long currentNumber = Math.Abs(number);

            while (currentNumber != 0)
            {
                var remainder = (int)(currentNumber % radix);
                ret.Insert(0, DefaultDigits[remainder]);
                currentNumber /= radix;
            }

            if (number < 0)
            {
                ret.Insert(0, '-');
            }

            return new string(ret.ToArray());
        }

        /// <summary>
        /// 进制字符串转换为数字
        /// </summary>
        /// <param name="decimalStr">对应的字符串</param>
        /// <param name="radix">字符串的进制</param>
        /// <returns></returns>
        public static long ToLong(string decimalStr, int radix)
        {
            int j = 0;
            return decimalStr.ToCharArray().Reverse().Where(ch => DefaultDigits.Contains(ch))
                .Sum(ch => DefaultDigits.IndexOf(ch) * (long)Math.Pow(radix, j++));
        }
    }
}