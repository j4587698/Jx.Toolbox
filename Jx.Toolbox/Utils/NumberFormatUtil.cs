using System;
using System.Collections.Generic;
using System.Linq;

namespace Jx.Toolbox.Utils
{
    public class NumberFormatUtil
    {
        public static string DefaultDigits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

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

        public static long ToLong(string decimalStr, int radix)
        {
            int j = 0;
            return decimalStr.ToCharArray().Reverse().Where(ch => DefaultDigits.Contains(ch))
                .Sum(ch => DefaultDigits.IndexOf(ch) * (long)Math.Pow(radix, j++));
        }
    }
}