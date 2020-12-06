using System.Threading.Tasks;

namespace ZonyLrcToolsX.Infrastructure.Album
{
    public interface IAlbumDownloader
    {
        ValueTask<byte[]> DownloadAsync(MusicInfo info);
    }
}