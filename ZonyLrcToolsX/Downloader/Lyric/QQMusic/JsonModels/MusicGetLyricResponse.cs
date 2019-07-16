using Newtonsoft.Json;

namespace ZonyLrcToolsX.Downloader.Lyric.QQMusic.JsonModels
{
    public class MusicGetLyricResponse
    {
        [JsonProperty("lyric")]
        public string LyricText { get; set; }
    }
}
