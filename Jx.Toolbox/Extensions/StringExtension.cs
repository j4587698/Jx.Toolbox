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
    }
}