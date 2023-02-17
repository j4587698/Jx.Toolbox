using System.Diagnostics;

namespace Jx.Toolbox.Utils
{
    public class ProcessUtil
    {
        public static void KillProcess(string processName)
        {
            foreach (var process in Process.GetProcessesByName(processName))
            {
                process.Kill();
            }
        }
        
        public static void KillProcess(int processId)
        {
            Process.GetProcessById(processId).Kill();
        }
        
        public static void StartProcess(string fileName, string arguments)
        {
            Process.Start(fileName, arguments);
        }
    }
}