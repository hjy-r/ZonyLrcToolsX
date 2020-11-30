using System.Threading.Tasks;

namespace ZonyLrcToolsX.Infrastructure.Lyric
{
    public interface ILyricDownloader
    {
        ValueTask<LyricItemCollection> DownloadAsync();
    }
}