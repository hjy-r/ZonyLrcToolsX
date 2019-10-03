using System;
// ReSharper disable InconsistentNaming

namespace ZonyLrcToolsX.Infrastructure.Configuration
{
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