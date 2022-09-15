using System.Collections.Generic;

namespace Jx.Toolbox.Extensions
{
    public static class StringArrayExtension
    {
        /// <summary>
        /// 合并内容，默认为使用逗号
        /// </summary>
        /// <param name="strList"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string Join(this IEnumerable<string> strList, string separator = ",")
        {
            return string.Join(separator, strList);
        }
    }
}