using ZonyLrcToolsX.Infrastructure.Configuration;

namespace ZonyLrcToolsX.Infrastructure.ItemDtos
{
    public class ComboBoxLyricContentTypeItemDto
    {
        public string Text { get; set; }

        public LyricContentTypes Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}