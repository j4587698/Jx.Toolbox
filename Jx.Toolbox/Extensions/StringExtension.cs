using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Jx.Toolbox.Extensions
{
    public static class StringExtension
    {
        /// <summary>
        /// 字符串是否为空
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        /// <summary>
        /// 字符串是否为空或空格
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }
        
        
        /// <summary>
        /// 检测字符串中是否包含列表中的关键词
        /// </summary>
        /// <param name="s">源字符串</param>
        /// <param name="keys">关键词列表</param>
        /// <param name="ignoreCase">忽略大小写</param>
        /// <returns></returns>
        public static bool Contains(this string s, IEnumerable<string> keys, bool ignoreCase = true)
        {
            if (!keys.Any() || string.IsNullOrEmpty(s))
            {
                return false;
            }

            return ignoreCase ? Regex.IsMatch(s, string.Join("|", keys.Select(Regex.Escape)), RegexOptions.IgnoreCase) : Regex.IsMatch(s, string.Join("|", keys.Select(Regex.Escape)));
        }

        /// <summary>
        /// 转为驼峰，默认转换 '/', ' ', '-', '.', '_'
        /// </summary>
        /// <param name="str"></param>
        /// <param name="splitChar"></param>
        /// <returns></returns>
        public static string ToPascal(this string str, params char[] splitChar)
        {
            if (splitChar == null || splitChar.Length == 0)
            {
                splitChar = new[] { '/', ' ', '-', '.', '_' };
            }

            var split = str.Split(splitChar);
            return split.Select(FirstLetterToUpper).Join("");
        }

        /// <summary>
        /// 驼峰转下划线
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToUnderLine(this string str)
        {
            return Regex.Replace(str, "([A-Z])", "_$1").ToLower().TrimStart('_');
        }

        /// <summary>
        /// 首字母转大写
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string FirstLetterToUpper(this string str)
        {
            return str.Remove(1).ToUpper() + str.Substring(1);
        }

        /// <summary>
        /// 首字母转小写
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string FirstLetterToLower(this string str)
        {
            return str.Remove(1).ToLower() + str.Substring(1);
        }

        /// <summary>
        /// 扩展Trim方法，避免null报错
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string TrimEx(this string str)
        {
            return str == null ? string.Empty : str.Trim();
        }
    }
}