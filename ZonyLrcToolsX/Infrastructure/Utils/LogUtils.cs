using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// ReSharper disable LocalizableElement
// ReSharper disable InconsistentNaming

namespace ZonyLrcToolsX.Infrastructure.Utils
{
    /// <summary>
    /// 提供程序的日志记录功能，包括常规日志与异常记录。
    /// </summary>
    /// <remarks>
    /// 这里没有使用 log4net 等日志记录框架，是因为小工具没必要
    /// 使用那些庞大的第三方库。
    /// </remarks>
    public class LogUtils
    {
        private static readonly object _locker = new object();

        private static LogUtils _instance;
        private FileStream _logFileStream;
        private FileStream _exceptionFileStream;
        private StreamWriter _logFileStreamWriter;
        private StreamWriter _exceptionFileStreamWriter;

        /// <summary>
        /// 构建一个 <see cref="LogUtils"/> 对象实例。
        /// </summary>
        private LogUtils()
        {
            
        }

        /// <summary>
        /// 获得 <see cref="LogUtils"/> 的单例实例。
        /// </summary>
        public static LogUtils Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_locker)
                    {
                        if (_instance == null) _instance = new LogUtils();
                    }
                }

                return _instance;
            }
        }

        /// <summary>
        /// 初始化日志记录系统，一般在程序启动时(<see cref="Program.Main"/>)调用本方法。
        /// </summary>
        public void Initialize()
        {
            try
            {
                
            }
            catch (Exception e)
            {
                MessageBox.Show("日志组件初始化失败，程序即将退出。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProgramUtils.ExitProgram();
            }
        }

        public void WriteLog(string message)
        {
            _logFileStreamWriter.WriteLine($"{GetNowDateTimeString()} - 日志：{message}");
            _logFileStreamWriter.Flush();
        }

        public async Task WriteLogAsync(string message)
        {
            await _logFileStreamWriter.WriteLineAsync($"{GetNowDateTimeString()} - 日志：{message}");
            await _logFileStreamWriter.FlushAsync();
        }

        public void WriteException(Exception exception)
        {
            if (exception == null) return;

            var messageBuilder = new StringBuilder();
            messageBuilder.Append(GetNowDateTimeString()).Append(" - 产生了异常。").Append("\r\n");
            messageBuilder.Append(exception.GetFormatExceptionMessage()).Append("\r\n");

            _logFileStreamWriter.WriteLine(messageBuilder.ToString());
            _logFileStreamWriter.Flush();
        }

        public async Task WriteExceptionAsync(Exception exception)
        {
            if (exception == null) return;

            var messageBuilder = new StringBuilder();
            messageBuilder.Append(GetNowDateTimeString()).Append(" - 产生了异常。").Append("\r\n");
            messageBuilder.Append(exception.GetFormatExceptionMessage()).Append("\r\n");

            await _logFileStreamWriter.WriteLineAsync(messageBuilder.ToString());
            await _logFileStreamWriter.FlushAsync();
        }

        private string GetNowDateTimeString()
        {
            return DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss");
        }
    }
}