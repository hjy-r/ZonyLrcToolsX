using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json.Linq;
using ZonyLrcToolsX.Downloader.Lyric.Exceptions;
using ZonyLrcToolsX.Downloader.Lyric.QQMusic.JsonModels;
using ZonyLrcToolsX.Infrastructure.Lyric;
using ZonyLrcToolsX.Infrastructure.MusicTag;
using ZonyLrcToolsX.Infrastructure.Network.Http;

namespace ZonyLrcToolsX.Downloader.Lyric.QQMusic
{
    public class QQMusicCloudMusicLyricDownloader : ILyricDownloader
    {
        private readonly WrappedHttpClient _wrappedHttpClient;

        public QQMusicCloudMusicLyricDownloader()
        {
            _wrappedHttpClient = new WrappedHttpClient();
        }

        public async Task<LyricItemCollection> DownloadAsync(MusicInfo musicInfo)
        {
            if (string.IsNullOrEmpty(musicInfo.Name) && string.IsNullOrEmpty(musicInfo.Artist))
            {
                throw new NotFoundSongException("没有搜索到指定的歌曲。", musicInfo);
            }

            var requestParameter = new MusicSearchRequestModel(musicInfo.Name, musicInfo.Artist);
            var searchResult = await _wrappedHttpClient.GetAsync<MusicSearchResponseModel>(
                url: @"http://c.y.qq.com/soso/fcgi-bin/client_search_cp",
                parameters: requestParameter);

            // 校验请求结果的有效性。
            ValidateResponse(searchResult, musicInfo);

            // 获取具体的歌曲歌词信息。
            var lyricJsonStr = await GetLyricJsonStringAsync(searchResult);
            lyricJsonStr = lyricJsonStr.Replace(@"MusicJsonCallback(", string.Empty).TrimEnd(')');
            if (lyricJsonStr.Contains("\"code\":-1901")) throw new NotFoundSongException("没有搜索到指定的歌曲。", musicInfo);
            if (lyricJsonStr.Contains("此歌曲为没有填词的纯音乐，请您欣赏")) return new LyricItemCollection(string.Empty);

            var sourceLyric = HttpUtility.HtmlDecode(HttpUtility.HtmlDecode(JObject.Parse(lyricJsonStr).SelectToken("$.lyric").Value<string>()));
            var translateLyric = HttpUtility.HtmlDecode(HttpUtility.HtmlDecode(JObject.Parse(lyricJsonStr).SelectToken("$.trans").Value<string>()));

            return new LyricItemCollection(sourceLyric).Merge(new LyricItemCollection(translateLyric));
        }

        protected virtual void ValidateResponse(MusicSearchResponseModel searchResult, MusicInfo musicInfo)
        {
            if (searchResult == null || searchResult.StatusCode != 0 || searchResult.Data.Song.SongItems == null)
            {
                throw new RequestErrorException("QQ 音乐接口没有正常返回结果...", musicInfo);
            }

            if (searchResult.Data.Song.SongItems.Count <= 0) throw new NotFoundSongException("没有搜索到指定的歌曲。", musicInfo);
        }

        protected virtual Task<string> GetLyricJsonStringAsync(MusicSearchResponseModel searchResult)
        {
            return _wrappedHttpClient.GetAsync(
                url: @"http://c.y.qq.com/lyric/fcgi-bin/fcg_query_lyric_new.fcg",
                parameters: new MusicGetLyricRequest(searchResult.Data.Song.SongItems[0].SongId),
                refererUrl: @"https://y.qq.com/"
            );
        }
    }
}