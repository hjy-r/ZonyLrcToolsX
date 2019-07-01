using System.Threading.Tasks;
using ZonyLrcToolsX.Infrastructure.Lyric;
using ZonyLrcToolsX.Infrastructure.MusicTag;

namespace ZonyLrcToolsX.Downloader.Lyric
{
    /// <summary>
    /// 歌词下载器的接口定义。
    /// </summary>
    public interface ILyricDownloader
    {
        Task<LyricItemCollection> DownloadAsync(MusicInfo musicInfo);
    }
}