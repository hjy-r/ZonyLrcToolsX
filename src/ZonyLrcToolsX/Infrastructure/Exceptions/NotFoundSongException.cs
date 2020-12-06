using System;

namespace ZonyLrcToolsX.Infrastructure.Exceptions
{
    public class NotFoundSongException : Exception
    {
        public NotFoundSongException(string message, MusicInfo musicInfo) : base(message)
        {
            Data["MusicInfo"] = musicInfo;
        }
    }
}