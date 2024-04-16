using System.IO;
using System.Security.Cryptography;
using Jx.Toolbox.Extensions;
using Jx.Toolbox.Utils;

namespace Jx.Toolbox.Cryptography
{
    /// <summary>
    /// Des加解密
    /// </summary>
    public static class DesEncryption
    {
        /// <summary>
        /// 生成密钥
        /// </summary>
        /// <returns></returns>
        public static string CreateKey()
        {
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                return des.Key.ToHexString();
            }
        }
        
        /// <summary>
        /// 生成IV
        /// </summary>
        /// <returns></returns>
        public static string CreateIv()
        {
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                return des.IV.ToHexString();
            }
        }
        
        /// <summary>
        /// Des加密
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
        /// Des加密
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
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                des.Key = key;
                des.IV = iv;
                des.Mode = cipherMode;
                des.Padding = paddingMode;

                ICryptoTransform encryptor = des.CreateEncryptor(des.Key, des.IV);
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
        /// Des解密
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

        /// <summary>
        /// Des解密
        /// </summary>
        /// <param name="cipherText"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <param name="cipherMode"></param>
        /// <param name="paddingMode"></param>
        /// <returns></returns>
        public static string Decrypt(byte[] cipherText, byte[] key, byte[] iv, CipherMode cipherMode = CipherMode.CBC,
            PaddingMode paddingMode = PaddingMode.PKCS7)
        {
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                des.Key = key;
                des.IV = iv;
                des.Mode = cipherMode;
                des.Padding = paddingMode;

                ICryptoTransform decryptor = des.CreateDecryptor(des.Key, des.IV);
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