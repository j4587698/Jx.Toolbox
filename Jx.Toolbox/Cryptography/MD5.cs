using System.Text;

namespace Jx.Toolbox.Cryptography
{
    public static class MD5
    {
        /// <summary>
        /// 获取MD5加密字符串
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string MD5String(string input)
        {
            var md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Convert the byte array to hexadecimal string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}