using System.Collections.Generic;

namespace ZonyLrcToolsX.Downloader.Lyric
{
    public class LyricDownloaderContainer
    {
        public IList<ILyricDownloader> Downloaders { get; private set; }
    }
}
