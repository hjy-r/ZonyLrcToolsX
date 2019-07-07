using System.Threading.Tasks;
using ZonyLrcToolsX.Infrastructure.Lyric;
using ZonyLrcToolsX.Infrastructure.MusicTag;

namespace ZonyLrcToolsX.Downloader.Lyric.QQMusic
{
    public class QQMusicCloudMusicLyricDownloader : ILyricDownloader
    {
        public Task<LyricItemCollection> DownloadAsync(MusicInfo musicInfo)
        {
            throw new System.NotImplementedException();
        }
    }
}