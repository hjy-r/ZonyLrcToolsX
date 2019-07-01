using System.Threading.Tasks;
using ZonyLrcToolsX.Infrastructure.Lyric;
using ZonyLrcToolsX.Infrastructure.MusicTag;

namespace ZonyLrcToolsX.Downloader.Lyric
{
    public interface ILyricDownloader
    {
        Task<LyricItemCollection> DownloadAsync(MusicInfo musicInfo);
    }
}