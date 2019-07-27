using System.IO;
using System.Threading.Tasks;
using TagFile = TagLib.File;

namespace ZonyLrcToolsX.Infrastructure.MusicTag.TagLib
{
    public class MusicInfoLoaderByTagLib : IMusicInfoLoader
    {
        public MusicInfo Load(string musicFilePath)
        {
            var result = new MusicInfo();
            var fileName = Path.GetFileNameWithoutExtension(musicFilePath);
            
            var tagFile = TagFile.Create(musicFilePath);
            result.Name = tagFile.Tag.Title;
            result.Artist = tagFile.Tag.FirstPerformer;
            if (!string.IsNullOrEmpty(tagFile.Tag.FirstAlbumArtist)) result.Artist = tagFile.Tag.FirstAlbumArtist;
            result.AlbumName = tagFile.Tag.Album;
            
            // 如果都没有标签信息，则使用文件名作为歌手名和歌曲名。
            if (string.IsNullOrEmpty(result.Name)) result.Name = fileName;
            if (string.IsNullOrEmpty(result.Artist)) result.Artist = fileName;

            if (tagFile.Tag.Pictures.Length > 0)
            {
                result.AlbumImage = tagFile.Tag.Pictures[0].Data.Data;
            }
            
            return result;
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
