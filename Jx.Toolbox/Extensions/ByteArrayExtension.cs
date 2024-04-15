using System;

namespace Jx.Toolbox.Extensions
{
    /// <summary>
    /// byte数组扩展
    /// </summary>
    public static class ByteArrayExtension
    {
        /// <summary>
        /// byte数组转16进制字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string ToHexString(this byte[] bytes)
        {
            return BitConverter.ToString(bytes).Replace("-", "");
        }
    }
}