using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ZonyLrcToolsX.Infrastructure.DependencyInject;
using ZonyLrcToolsX.Infrastructure.Lyric.QQMusic.JsonModel;
using ZonyLrcToolsX.Infrastructure.Network;

namespace ZonyLrcToolsX.Infrastructure.Album.QQMusic
{
    public class QQMusicAlbumDownloader : IAlbumDownloader,ITransientDependency
    {
        private readonly IWarpHttpClient _warpHttpClient;
        private readonly Action<HttpRequestMessage> _defaultOption;
        
        private const string SearchApi = "https://c.y.qq.com/soso/fcgi-bin/client_search_cp";
        private const string DefaultReferer = "https://y.qq.com";

        public QQMusicAlbumDownloader(IWarpHttpClient warpHttpClient)
        {
            _warpHttpClient = warpHttpClient;
            _defaultOption = message =>
            {
                message.Headers.Referrer = new Uri(DefaultReferer);

                if (message.Content != null)
                {
                    message.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");
                }
            };
        }
        
        public async ValueTask<byte[]> DownloadAsync(MusicInfo info)
        {
            var requestParameter = new SongSearchRequest(info.Name, info.Artist);
            var searchResult = await _warpHttpClient.GetAsync<SongSearchResponse>(
                SearchApi,
                requestParameter);

            return null;
        }
    }
}