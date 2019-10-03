using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZonyLrcToolsX.Forms;
using ZonyLrcToolsX.Infrastructure.Utils;

// ReSharper disable LocalizableElement

namespace ZonyLrcToolsX
{
    static class Program
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        [STAThread]
        static void Main()
        {
            // 全局异常处理。
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.UnhandledException += async (sender, args) => await HandleException(args.ExceptionObject as Exception);
            Application.ThreadException += async (sender, args) => await HandleException(args.Exception);
            
            LogUtils.Instance.Initialize();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        private static async Task HandleException(Exception exception)
        {
            MessageBox.Show("产生了未经处理的异常，请将程序目录下的 exception.log 文件发送给作者，程序即将退出。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            await LogUtils.Instance.WriteExceptionAsync(exception);
            ProgramUtils.ExitProgram();
        }
    }
}