using System;

namespace ZonyLrcToolsX.Infrastructure.Configuration
{
    /// <summary>
    /// 歌词文件内容枚举。
    /// </summary>
    [Flags]
    public enum LyricContentTypes
    {
        /// <summary>
        /// 只需要原始歌词。
        /// </summary>
        Original,
        /// <summary>
        /// 只需要翻译歌词。
        /// </summary>
        Translation,
        /// <summary>
        /// 原始歌词和翻译歌词都需要。
        /// </summary>
        OriginalAndTranslation
    }
}