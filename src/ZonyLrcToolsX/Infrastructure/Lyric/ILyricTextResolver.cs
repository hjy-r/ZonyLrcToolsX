namespace ZonyLrcToolsX.Infrastructure.Lyric
{
    public interface ILyricTextResolver
    {
        LyricItemCollection Resolve(string lyricText);
    }
}