namespace ZonyLrcToolsX.Infrastructure.ItemDtos
{
    public class ComboboxLyricFileEncodingItemDto
    {
        public string Text { get; set; }

        public int Value { get; set; }

        public ComboboxLyricFileEncodingItemDto(string text,int value)
        {
            Text = text;
            Value = value;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}