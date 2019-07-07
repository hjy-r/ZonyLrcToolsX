using System.Threading.Tasks;

namespace ZonyLrcToolsX.Downloader.Album
{
    public interface IAlbumDownloader
    {
        Task<byte[]> DownloadAsync();
    }
}