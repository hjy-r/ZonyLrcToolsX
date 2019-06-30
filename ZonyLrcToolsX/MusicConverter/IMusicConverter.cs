using System.IO;

namespace ZonyLrcToolsX.MusicConverter
{
    public interface IMusicConverter
    {
        MemoryStream Convert(MemoryStream srcStream);
    }
}
