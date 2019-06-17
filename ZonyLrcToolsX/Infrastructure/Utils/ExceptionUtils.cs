using System;
using System.Text;

namespace ZonyLrcToolsX.Infrastructure.Utils
{
    /// <summary>
    /// 提供异常处理相关的辅助方法。
    /// </summary>
    public static class ExceptionUtils
    {
        /// <summary>
        /// 格式化异常对象，将其转换为可阅读的字符串信息。
        /// </summary>
        /// <exception cref="ArgumentNullException">当用户传入的异常 <paramref name="exception"/> 为 Null 时，会引发本异常。</exception>
        public static string GetFormatExceptionMessage(this Exception exception)
        {
            var messageBuilder = new StringBuilder();
            
            messageBuilder.Append("异常提示信息：").Append(exception.InnerException?.Message ?? exception.Message).Append("\r\n");
            messageBuilder.Append("异常堆栈信息：").Append(exception.InnerException?.StackTrace ?? exception.StackTrace).Append("\r\n");

            return messageBuilder.ToString();
        }
    }
}