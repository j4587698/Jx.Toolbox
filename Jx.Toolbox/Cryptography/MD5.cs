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

        /// <summary>
        /// MD5加盐加密
        /// </summary>
        /// <param name="input"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public static string MD5StringWithSalt(string input, string salt) => MD5String(input + salt);

        /// <summary>
        /// 二次MD5加密
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string MD5String2(string input) => MD5String(MD5String(input));

        /// <summary>
        /// 二次MD5加盐加密
        /// </summary>
        /// <param name="input"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public static string MD5String2WithSalt(string input, string salt) =>
            MD5StringWithSalt(MD5StringWithSalt(input, salt), salt);
    }
}