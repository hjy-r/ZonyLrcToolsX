using System;

namespace ZonyLrcToolsX.Infrastructure.MusicTag
{
    /// <summary>
    /// 歌曲当前的状态。
    /// </summary>
    [Flags]
    public enum MusicInfoStatus
    {
        /// <summary>
        /// 正在等待下载歌词/专辑图像。
        /// </summary>
        WaitingDownload,
        /// <summary>
        /// 歌词/专辑图像，已经下载完成。
        /// </summary>
        DownloadCompleted,
        /// <summary>
        /// 歌曲的标签信息无效。
        /// </summary>
        MusicTagInvalid
    }
}
