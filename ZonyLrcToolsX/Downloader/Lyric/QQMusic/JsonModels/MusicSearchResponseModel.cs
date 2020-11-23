﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace ZonyLrcToolsX.Downloader.Lyric.QQMusic.JsonModels
{
    public class MusicSearchResponseModel
    {
        [JsonProperty("code")]
        public int StatusCode { get; set; }

        [JsonProperty("data")]
        public QQMusicInnerDataModel Data { get; set; }
    }

    public class QQMusicInnerDataModel
    {
        [JsonProperty("song")]
        public QQMusicInnerSongModel Song { get; set; }
    }

    public class QQMusicInnerSongModel
    {
        [JsonProperty("list")]
        public List<QQMusicInnerSongItem> SongItems { get; set; }
    }

    public class QQMusicInnerSongItem
    {
        [JsonProperty("mid")]
        public string SongId { get; set; }
    }
}
