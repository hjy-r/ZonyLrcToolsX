using System.Threading.Tasks;

namespace ZonyLrcToolsX.Infrastructure.MusicTag
{
    public interface IMusicInfoLoader
    {
        MusicInfo Load(string musicFilePath);

        Task<MusicInfo> LoadAsync(string musicFilePath);

        void Save(MusicInfo musicInfo);

        Task SaveAsync(MusicInfo musicInfo);
    }
}