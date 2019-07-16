using System.Threading.Tasks;

namespace ZonyLrcToolsX.Infrastructure.MusicTag.TagLib
{
    public class MusicInfoLoaderByTagLib : IMusicInfoLoader
    {
        public MusicInfo Load(string musicFilePath)
        {
            throw new System.NotImplementedException();
        }

        public Task<MusicInfo> LoadAsync(string musicFilePath)
        {
            return Task.FromResult(new MusicInfo());
        }

        public void Save(string musicFilePath, MusicInfo musicInfo)
        {
            throw new System.NotImplementedException();
        }

        public Task SaveAsync(string musicFilePath, MusicInfo musicInfo)
        {
            throw new System.NotImplementedException();
        }
    }
}
