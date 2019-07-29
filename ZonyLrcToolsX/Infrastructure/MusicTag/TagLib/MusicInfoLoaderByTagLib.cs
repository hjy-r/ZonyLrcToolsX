using System.IO;
using System.Threading.Tasks;
using TagLib;
using TagFile = TagLib.File;
using TagPicture = TagLib.Picture;

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
            result.FilePath = musicFilePath;

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
            return Task.FromResult(Load(musicFilePath));
        }

        public void Save(string musicFilePath, MusicInfo musicInfo)
        {
            var tagFile = TagFile.Create(musicFilePath);

            tagFile.Tag.Title = musicInfo.Name;
            tagFile.Tag.Performers = new[] {musicInfo.Artist};
            tagFile.Tag.Album = musicInfo.AlbumName;
            tagFile.Tag.Pictures = new IPicture[] {new TagPicture(musicInfo.AlbumImage)};

            tagFile.Save();
        }

        public Task SaveAsync(string musicFilePath, MusicInfo musicInfo)
        {
            Save(musicFilePath, musicInfo);
            return Task.CompletedTask;
        }
    }
}