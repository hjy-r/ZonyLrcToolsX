using System;
using System.Threading.Tasks;
using ZonyLrcToolsX.Infrastructure.Network.Http;

namespace ZonyLrcToolsX.Downloader.Album.NetEase
{
    /// <summary>
    /// 基于网易云音乐实现的专辑下载器，用于下载歌曲的专辑封面。
    /// </summary>
    public class NetEaseCloudMusicAlbumDownloader : IAlbumDownloader
    {
        private readonly WrappedHttpClient _wrappedHttpClient;

        public NetEaseCloudMusicAlbumDownloader()
        {
            _wrappedHttpClient = new WrappedHttpClient();
        }

        public Task<byte[]> DownloadAsync()
        {
            throw new NotImplementedException();
        }
    }
}