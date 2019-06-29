using System.Threading.Tasks;
using ZonyLrcToolsX.Infrastructure.Lyric;

namespace ZonyLrcToolsX.Downloader.Lyric
{
    public interface ILyricDownloader
    {
        Task<LyricItemCollection> DownloadAsync();
    }
}