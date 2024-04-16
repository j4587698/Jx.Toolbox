using System.IO;
using System.Security.Cryptography;
using System.Text;
using Jx.Toolbox.Extensions;
using Jx.Toolbox.Utils;

namespace Jx.Toolbox.Cryptography
{
    /// <summary>
    /// Aes加解密
    /// </summary>
    public static class AesEncryption
    {
        /// <summary>
        /// 生成密钥
        /// </summary>
        /// <returns></returns>
        public static string CreateKey()
        {
            using (Aes aes = Aes.Create())
            {
                return aes.Key.ToHexString();
            }
        }
        
        /// <summary>
        /// 生成IV
        /// </summary>
        /// <returns></returns>
        public static string CreateIv()
        {
            using (Aes aes = Aes.Create())
            {
                return aes.IV.ToHexString();
            }
        }
        
        /// <summary>
        /// Aes加密
        /// </summary>
        /// <param name="plainText"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <param name="cipherMode"></param>
        /// <param name="paddingMode"></param>
        /// <returns></returns>
        public static string Encrypt(string plainText, string key, string iv, CipherMode cipherMode = CipherMode.CBC,
            PaddingMode paddingMode = PaddingMode.PKCS7)
        {
            return Base64.Encode(Encrypt(plainText, key.HexStringToBytes(), iv.HexStringToBytes(), cipherMode, paddingMode));
        }
        
        /// <summary>
        /// Aes加密
        /// </summary>
        /// <param name="plainText"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <param name="cipherMode"></param>
        /// <param name="paddingMode"></param>
        /// <returns></returns>
        public static byte[] Encrypt(string plainText, byte[] key, byte[] iv, CipherMode cipherMode = CipherMode.CBC,
            PaddingMode paddingMode = PaddingMode.PKCS7)
        {
            using (var aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;
                aesAlg.Padding = paddingMode;
                aesAlg.Mode = cipherMode;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                    }
                    return msEncrypt.ToArray();
                }
            }
        }
        
        /// <summary>
        /// Aes解密
        /// </summary>
        /// <param name="cipherText"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <param name="cipherMode"></param>
        /// <param name="paddingMode"></param>
        /// <returns></returns>
        public static string Decrypt(string cipherText, string key, string iv, CipherMode cipherMode = CipherMode.CBC,
            PaddingMode paddingMode = PaddingMode.PKCS7)
        {
            return Decrypt(Base64.Decode(cipherText), key.HexStringToBytes(), iv.HexStringToBytes(), cipherMode, paddingMode);
        }

        public static string Decrypt(byte[] cipherText, byte[] key, byte[] iv, CipherMode cipherMode = CipherMode.CBC,
            PaddingMode paddingMode = PaddingMode.PKCS7)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;
                aesAlg.Padding = paddingMode;
                aesAlg.Mode = cipherMode;
                
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}