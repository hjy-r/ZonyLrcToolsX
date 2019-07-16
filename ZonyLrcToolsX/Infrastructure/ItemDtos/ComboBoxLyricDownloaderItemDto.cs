using ZonyLrcToolsX.Downloader.Lyric;

namespace ZonyLrcToolsX.Infrastructure.ItemDtos
{
    class ComboBoxLyricDownloaderItemDto
    {
        public string Text { get; set; }

        public LyricDownloaderEnum Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
