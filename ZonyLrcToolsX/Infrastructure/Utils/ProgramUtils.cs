using System;
using System.IO;
using System.Windows.Forms;

namespace ZonyLrcToolsX.Infrastructure.Utils
{
    /// <summary>
    /// 提供程序运行时的辅助方法。
    /// </summary>
    public static class ProgramUtils
    {
        /// <summary>
        /// 退出当前程序，并结束掉进程。
        /// </summary>
        public static void ExitProgram()
        {
            if(Application.MessageLoop)
            {
                Application.Exit();
            }
            else
            {
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// 获得程序的真实所在文件夹路径，与 <see cref="Environment.CurrentDirectory"/> 不同，本方法
        /// 获得的路径是固定的。
        /// </summary>
        /// <returns>当前程序的所在文件夹路径。</returns>
        public static string GetCurrentDirectory()
        {
            return Path.GetDirectoryName(typeof(Program).Assembly.Location);
        }
    }
}