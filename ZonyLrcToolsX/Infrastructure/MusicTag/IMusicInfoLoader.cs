using System.Threading.Tasks;

namespace ZonyLrcToolsX.Infrastructure.MusicTag
{
    public interface IMusicInfoLoader
    {
        MusicInfo Load(string musicFilePath);

        Task<MusicInfo> LoadAsync(string musicFilePath);

        void Save(string musicFilePath,MusicInfo musicInfo);

        Task SaveAsync(string musicFilePath, MusicInfo musicInfo);
    }
}