using System.Threading.Tasks;
using ZonyLrcToolsX.Infrastructure.Lyric;
using ZonyLrcToolsX.Infrastructure.MusicTag;

namespace ZonyLrcToolsX.Downloader.Lyric.NetEase
{
    public class NetEaseCloudMusicLyricDownloader : ILyricDownloader
    {
        public Task<LyricItemCollection> DownloadAsync(MusicInfo musicInfo)
        {
            throw new System.NotImplementedException();
        }
    }
}
