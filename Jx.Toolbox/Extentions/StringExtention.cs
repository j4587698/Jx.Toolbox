namespace Jx.Toolbox.Extentions
{
    public static class StringExtention
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
    }
}