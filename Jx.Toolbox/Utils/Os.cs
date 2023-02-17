using System.Runtime.InteropServices;

namespace Jx.Toolbox.Utils
{
    /// <summary>
    /// 系统类型
    /// </summary>
    public static class Os
    {
        /// <summary>
        /// 是否是Windows系统
        /// </summary>
        /// <returns></returns>
        public static bool IsWindows()
        {
            return RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
        }
        
        /// <summary>
        /// 是否是Linux系统
        /// </summary>
        /// <returns></returns>
        public static bool IsLinux()
        {
            return RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
        }
        
        /// <summary>
        /// 是否是MaxOs系统
        /// </summary>
        /// <returns></returns>
        public static bool IsMacOs()
        {
            return RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
        }
        
    }
}