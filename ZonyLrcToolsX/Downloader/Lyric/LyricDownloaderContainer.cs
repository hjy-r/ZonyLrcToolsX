using System.Collections.Generic;
using ZonyLrcToolsX.Downloader.Lyric.NetEase;
using ZonyLrcToolsX.Downloader.Lyric.QQMusic;

namespace ZonyLrcToolsX.Downloader.Lyric
{
    /// <summary>
    /// 歌词下载器的存储容器。
    /// </summary>
    // TODO: 后续应该增加下载优先级的配置。
    public class LyricDownloaderContainer
    {
        public LyricDownloaderContainer()
        {
            Downloader = new List<ILyricDownloader>
            {
                new NetEaseCloudMusicLyricDownloader(),
                new QQMusicCloudMusicLyricDownloader()
            };
        }

        /// <summary>
        /// 获得所有可用的歌词下载器 (<see cref="ILyricDownloader"/>) 。
        /// </summary>
        public IList<ILyricDownloader> Downloader { get; }
    }
}