using System;
using System.Text;

namespace Jx.Toolbox.Utils
{
    /// <summary>
    /// Base64编码解码
    /// </summary>
    public static class Base64
    {
        
        private const char   Base64Character62        = '+';
        private const char   Base64Character63        = '/';
        private const string Base64DoublePadCharacter = "==";
        private const char   Base64PadCharacter       = '=';
        private const char   Base64UrlCharacter62     = '-';
        private const char   Base64UrlCharacter63     = '_';
        
        /// <summary>
        /// 转Base64
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string Encode(byte[] data)
        {
            return Convert.ToBase64String(data);
        }
        
        /// <summary>
        /// Base64编码，默认编码UTF8
        /// </summary>
        /// <param name="plainText"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string Encode(string plainText, Encoding encoding = null)
        {
            if (encoding == null)
                encoding = Encoding.UTF8;

            var plainTextBytes = encoding.GetBytes(plainText);
            return Encode(plainTextBytes);
        }
        
        public static string EncodeUrl(string plainText, Encoding encoding = null)
        {
            if (encoding == null)
                encoding = Encoding.UTF8;
            if (plainText == null) throw new ArgumentNullException(nameof(plainText));
            return EncodeUrl(encoding.GetBytes(plainText));
        }
        
        public static string EncodeUrl(byte[] data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
 
            var s = Convert.ToBase64String(data, 0, data.Length);
            s        = s.Split(Base64PadCharacter)[0];                     // Remove trailing padding i.e. = or ==
            s        = s.Replace(Base64Character62, Base64UrlCharacter62); // Replace + with -
            s        = s.Replace(Base64Character63, Base64UrlCharacter63); // Replace / with _
 
            return s;
        }

        /// <summary>
        /// Base64解码
        /// </summary>
        /// <param name="base64String"></param>
        /// <returns></returns>
        public static byte[] Decode(string base64String)
        {
            return Convert.FromBase64String(base64String);
        }
        
        /// <summary>
        /// Base64解码，默认编码UTF8
        /// </summary>
        /// <param name="base64String"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string DecodeToString(string base64String, Encoding encoding = null)
        {
            if (encoding == null)
                encoding = Encoding.UTF8;

            var base64EncodedBytes = Decode(base64String);
            return encoding.GetString(base64EncodedBytes);
        }
        
        /// <summary>
        /// 解码URL安全的Base64
        /// </summary>
        /// <param name="base64UrlString"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FormatException"></exception>
        public static byte[] DecodeUrl(string base64UrlString)
        {
            if (base64UrlString == null) throw new ArgumentNullException(nameof(base64UrlString));
            var base64String = base64UrlString.Replace(Base64UrlCharacter62, Base64Character62)
                .Replace(Base64UrlCharacter63, Base64Character63);
            switch (base64UrlString.Length % 4)
            {
                case 0: // No pad characters.
                    break;
                case 2: // Two pad characters.
                    base64String += Base64DoublePadCharacter;
                    break;
                case 3: // One pad character.
                    base64String += Base64PadCharacter;
                    break;
                default:
                    throw new FormatException("Invalid Base64 URL encoding.");
            }
            return Decode(base64String);
        }
        
        /// <summary>
        /// 解码Url安全的Base64，默认编码UTF8
        /// </summary>
        /// <param name="base64UrlString"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string DecodeUrlToString(string base64UrlString, Encoding encoding = null)
        {
            if (encoding == null)
                encoding = Encoding.UTF8;

            var base64EncodedBytes = DecodeUrl(base64UrlString);
            return encoding.GetString(base64EncodedBytes);
        }
    }
}