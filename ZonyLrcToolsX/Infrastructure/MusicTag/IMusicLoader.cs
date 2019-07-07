using System.Threading.Tasks;

namespace ZonyLrcToolsX.Infrastructure.MusicTag
{
    public interface IMusicLoader
    {
        MusicInfo Load();

        Task<MusicInfo> LoadAsync();

        void Save(string musicFilePath,MusicInfo musicInfo);

        Task SaveAsync(string musicFilePath, MusicInfo musicInfo);
    }
}