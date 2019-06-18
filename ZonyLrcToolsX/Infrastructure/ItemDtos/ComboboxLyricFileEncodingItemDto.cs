namespace ZonyLrcToolsX.Infrastructure.ItemDtos
{
    public class ComboboxLyricFileEncodingItemDto
    {
        public string Text { get; set; }

        public int Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}