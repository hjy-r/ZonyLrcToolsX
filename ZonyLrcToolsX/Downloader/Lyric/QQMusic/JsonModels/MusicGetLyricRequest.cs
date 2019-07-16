using Newtonsoft.Json;

namespace ZonyLrcToolsX.Downloader.Lyric.QQMusic.JsonModels
{
    public class MusicGetLyricRequest
    {
        [JsonProperty("nobase64")]
        public int IsNoBase64Encoding { get; set; }

        [JsonProperty("musicid")]
        public int SongId { get; set; }

        [JsonProperty("platform")]
        public string ClientPlatform { get; set; }

        public MusicGetLyricRequest(int songId)
        {
            IsNoBase64Encoding = 1;
            SongId = songId;
            ClientPlatform = "yqq";
        }
    }
}
