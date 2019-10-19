using System;
using ZonyLrcToolsX.Infrastructure.MusicTag;

namespace ZonyLrcToolsX.Downloader.Lyric.Exceptions
{
    public class RequestErrorException : Exception
    {
        public RequestErrorException(string message,MusicInfo musicInfo,Exception exception = null) : base(message, exception)
        {
            Data["MusicInfo"] = musicInfo;
        }
    }
}