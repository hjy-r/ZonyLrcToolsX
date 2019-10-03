using ZonyLrcToolsX.Infrastructure.Configuration;

namespace ZonyLrcToolsX.Infrastructure.ItemDtos
{
    public class ComboBoxLineBreakItemDto
    {
        protected ComboBoxLineBreakItemDto()
        {

        }

        public ComboBoxLineBreakItemDto(string text,LineBreakTypes value)
        {
            Text = text;
            Value = value;
        }

        public string Text { get; }

        public LineBreakTypes Value { get; }

        public override string ToString()
        {
            return Text;
        }
    }
}
