using System;
using ZonyLrcToolsX.Infrastructure.MusicTag;

namespace ZonyLrcToolsX.Downloader.Lyric.Exceptions
{
    public class NotFoundSongException : Exception
    {
        public NotFoundSongException(string message, MusicInfo musicInfo) : base(message)
        {
            Data["MusicInfo"] = musicInfo;
        }
    }
}