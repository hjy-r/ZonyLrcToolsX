using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using ZonyLrcToolsX.Infrastructure.DependencyInject;
using ZonyLrcToolsX.Infrastructure.Exceptions;
using ZonyLrcToolsX.Infrastructure.Lyric.NetEase.JsonModel;
using ZonyLrcToolsX.Infrastructure.Network;

namespace ZonyLrcToolsX.Infrastructure.Album.NetEase
{
    public class NetEaseAlbumDownloader : IAlbumDownloader, ITransientDependency
    {
        private readonly IWarpHttpClient _warpHttpClient;
        private readonly Action<HttpRequestMessage> _defaultOption;

        private const string SearchMusicApi = "https://music.163.com/api/search/get/web";
        private const string GetMusicInfoApi = "https://music.163.com/api/song/detail";
        private const string DefaultReferer = "https://music.163.com";

        public NetEaseAlbumDownloader(IWarpHttpClient warpHttpClient)
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
            var searchResult = await _warpHttpClient.PostAsync<SongSearchResponse>(
                SearchMusicApi,
                requestParameter,
                true,
                _defaultOption);

            if (searchResult == null || searchResult.StatusCode != 200 || searchResult.Items?.SongCount <= 0)
            {
                throw new NotFoundSongException("没有搜索到指定的歌曲...", info);
            }

            var songDetailJsonStr = await _warpHttpClient.GetAsync(
                GetMusicInfoApi,
                new GetSongDetailsRequest(searchResult.GetFirstSongId()),
                _defaultOption);

            var url = JObject.Parse(songDetailJsonStr).SelectToken("$.songs[0].album.picUrl")?.Value<string>();
            if (string.IsNullOrEmpty(url))
            {
                throw new RequestErrorException("网易云音乐接口没有正常返回结果...", info);
            }

            return await new HttpClient().GetByteArrayAsync(new Uri(url));
        }
    }
}