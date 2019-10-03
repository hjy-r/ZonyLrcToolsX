using System.Threading.Tasks;
using ZonyLrcToolsX.Infrastructure.MusicTag;

namespace ZonyLrcToolsX.Downloader.Album
{
    public interface IAlbumDownloader
    {
        Task<byte[]> DownloadAsync(MusicInfo musicInfo);

        byte[] Download(MusicInfo musicInfo);
    }
}