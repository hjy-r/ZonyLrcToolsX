using System.Collections.Generic;
using System.Linq;
using ZonyLrcToolsX.Downloader.Lyric.NetEase;
using ZonyLrcToolsX.Downloader.Lyric.QQMusic;
using ZonyLrcToolsX.Infrastructure.Configuration;

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

        /// <summary>
        /// 根据设置页面里面的歌词源，下载歌词数据。
        /// </summary>
        public ILyricDownloader GetDownloader()
        {
            switch (AppConfiguration.Instance.Configuration.SelectedLyricDownloader)
            {
                case LyricDownloaderEnum.NetEase:
                    return Downloader.FirstOrDefault(type => type.GetType().FullName.Contains("NetEase"));
                case LyricDownloaderEnum.QQMusic:
                    return Downloader.FirstOrDefault(type => type.GetType().FullName.Contains("QQMusic"));
                default:
                    return Downloader.First();
            }
        }
    }
}