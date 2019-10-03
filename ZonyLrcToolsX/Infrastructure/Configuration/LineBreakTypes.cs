using System;
// ReSharper disable InconsistentNaming

namespace ZonyLrcToolsX.Infrastructure.Configuration
{
    /// <summary>
    /// 歌词文件的换行符形式。
    /// </summary>
    [Flags]
    public enum LineBreakTypes
    {
        /// <summary>
        /// Windows 样式的换行符，使用 \r\n。
        /// </summary>
        Windows,
        /// <summary>
        /// macOS 样式的换行符，使用 \r。
        /// </summary>
        macOS,
        /// <summary>
        /// Unix 样式的换行符，使用 \n。
        /// </summary>
        Unix
    }

    /// <summary>
    /// 针对于 <see cref="LineBreakTypes"/> 的扩展方法，主要返回具体的换行符实例。
    /// </summary>
    public static class LineBreakTypeExtensions
    {
        public static string GetLineBreak(this LineBreakTypes breakTypes)
        {
            switch (breakTypes)
            {
                case LineBreakTypes.Windows:
                    return "\r\n";
                case LineBreakTypes.macOS:
                    return "\r";
                case LineBreakTypes.Unix:
                    return "\n";
                default:
                    return "\n";
            }
        }
    }
}