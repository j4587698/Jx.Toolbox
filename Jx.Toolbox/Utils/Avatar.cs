using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Jx.Toolbox.Cryptography;
using Jx.Toolbox.Extensions;

namespace Jx.Toolbox.Utils
{
    public static class Avatar
    {
        /// <summary>
        /// 获取头像的Url
        /// </summary>
        /// <param name="email">要获取的Email地址</param>
        /// <returns></returns>
        public static string GetAvatarUrl(string email)
        {
            return email.IsNullOrEmpty() ? null : $"https://cravatar.cn/avatar/{MD5.MD5String(email.ToLower())}";
        }

        /// <summary>
        /// 获取头像数组
        /// </summary>
        /// <param name="email">要获取的Email地址</param>
        /// <returns></returns>
        public static async Task<byte[]> GetAvatarBytesAsync(string email)
        {
            if (email.IsNullOrEmpty())
            {
                return null;
            }

            var url = GetAvatarUrl(email);
            using (var httpClient = new HttpClient())
            {
                return await httpClient.GetByteArrayAsync(url);
            }
        }
        
    }
}