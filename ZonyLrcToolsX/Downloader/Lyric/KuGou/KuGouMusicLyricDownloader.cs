using System;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json.Linq;
using ZonyLrcToolsX.Downloader.Lyric.Exceptions;
using ZonyLrcToolsX.Infrastructure.Lyric;
using ZonyLrcToolsX.Infrastructure.MusicTag;
using ZonyLrcToolsX.Infrastructure.Network.Http;
using ZonyLrcToolsX.Infrastructure.Network.Http.Exceptions;

namespace ZonyLrcToolsX.Downloader.Lyric.KuGou
{
    public class KuGouMusicLyricDownloader : ILyricDownloader
    {
        private readonly WrappedHttpClient _wrappedHttpClient = new WrappedHttpClient();

        public async Task<LyricItemCollection> DownloadAsync(MusicInfo musicInfo)
        {
            if (string.IsNullOrEmpty(musicInfo.Name) && string.IsNullOrEmpty(musicInfo.Artist))
            {
                throw new NotFoundSongException("没有搜索到指定的歌曲。", musicInfo);
            }

            var searchResponseStr = await _wrappedHttpClient.GetAsync(@"https://songsearch.kugou.com/song_search_v2", new
            {
                filter = 2,
                platform = "WebFilter",
                keyword = HttpUtility.UrlEncode($"{musicInfo.Name} - {musicInfo.Artist}")
            });

            var searchResponseJObj = ValidateResponse(searchResponseStr, musicInfo);
            var musicFileHash = searchResponseJObj.SelectToken("$.data.lists[0].FileHash").Value<string>();

            var lyricResponseJObj = JObject.Parse(await _wrappedHttpClient.GetAsync(@"https://www.kugou.com/yy/index.php", new
            {
                r = "play/getdata",
                hash = musicFileHash
            }, null, request => { request.Headers.Add("Cookie", "kg_mid=123"); }));

            if (lyricResponseJObj.SelectToken($"$.err_code").Value<int>() == 30020)
            {
                throw new ServerUnavailableException("服务接口限制，无法进行请求，请尝试使用代理服务器。");
            }

            var lyricString = lyricResponseJObj.SelectToken("$.data.lyrics")?.Value<string>() ?? throw new NotFoundSongException("没有搜索到指定的歌曲。", musicInfo);
            if (lyricString.Contains("纯音乐，请欣赏")) return new LyricItemCollection(string.Empty);

            // 带歌词的接口可能不会返回歌词数据。
            if (!string.IsNullOrEmpty(lyricString)) return new LyricItemCollection(HttpUtility.HtmlDecode(lyricString));


            var result = await PlanB(musicFileHash, musicInfo);
            if (result.isPrune)
            {
                return new LyricItemCollection(string.Empty);
            }

            var planBLyricString = Encoding.UTF8.GetString(Convert.FromBase64String(result.lyricText));
            return new LyricItemCollection(planBLyricString);
        }

        protected virtual JObject ValidateResponse(string searchResponseStr, MusicInfo musicInfo)
        {
            var searchResponseJObj = JObject.Parse(searchResponseStr);

            if (searchResponseJObj.SelectToken("$.error_code").Value<int>() != 0 &&
                searchResponseJObj.SelectToken("$.status").Value<int>() != 1 ||
                searchResponseJObj.SelectToken("$.data.lists[0]") == null)
            {
                throw new NotFoundSongException("没有搜索到指定的歌曲。", musicInfo);
            }

            return searchResponseJObj;
        }

        private async Task<(bool isPrune, string lyricText)> PlanB(string fileHash, MusicInfo musicInfo)
        {
            var searchResultJObj = JObject.Parse(await _wrappedHttpClient.GetAsync(@"http://lyrics.kugou.com/search", new
            {
                ver = 1,
                man = "yes",
                client = "mobi",
                hash = fileHash
            }));

            if (searchResultJObj.SelectToken("$.errcode").Value<int>() == 404)
            {
                return (isPrune: true, null);
            }

            var accessKey = searchResultJObj.SelectToken("$.candidates[0].accesskey").Value<string>();
            var songId = searchResultJObj.SelectToken("$.candidates[0].id").Value<int>();
            var lyricSearchResponseJObj = JObject.Parse(await _wrappedHttpClient.GetAsync(@"http://lyrics.kugou.com/download", new
            {
                ver = 1,
                client = "iphone",
                fmt = "lrc",
                charset = "utf8",
                id = songId,
                accesskey = accessKey
            }));

            if (lyricSearchResponseJObj.SelectToken("$.status").Value<int>() != 200) throw new NotFoundSongException("没有搜索到指定的歌曲。", musicInfo);

            return (isPrune: false, lyricSearchResponseJObj.SelectToken("$.content").Value<string>());
        }
    }
}