using System.IO;
using Shouldly;
using Xunit;
using ZonyLrcToolsX.Infrastructure.MusicTag;
using ZonyLrcToolsX.Infrastructure.MusicTag.TagLib;
using ZonyLrcToolsX.Infrastructure.Utils;

namespace ZonyLrcToolsX.Tests.Infrastructure.MusicTag
{
    public class MusicInfoLoaderByTaglib_Tests
    {
        protected IMusicInfoLoader Loader;
        protected string MusicFilePath;
        
        public MusicInfoLoaderByTaglib_Tests()
        {
            Loader = new MusicInfoLoaderByTagLib();

            var dirPath = PathUtils.RecursivelyGetParentPath(ProgramUtils.GetCurrentDirectory(), 3);
            MusicFilePath = Path.Combine(dirPath,"testFiles","tagLib 读取正常歌曲.mp3");
        }
        
        [Fact]
        public void Load_Test()
        {
            // Act
            var info = Loader.Load(MusicFilePath);
            
            // Assert
            info.ShouldNotBeNull();
            info.Name.ShouldBe("凡人修仙路");
            info.Artist.ShouldBe("小旭音乐");
            info.Duration.ShouldBe(234281);
        }

        [Fact]
        public void Save_Test()
        {
            // Act
            var info = Loader.Load(MusicFilePath);
            info.Name = "测试音乐";
            info.Artist = "测试作者";
            info.AlbumImage = new byte[0];
            
            // Assert
            Loader.Save(info);
            
            // 再次读取。
            info = Loader.Load(MusicFilePath);
            info.ShouldNotBeNull();
            info.Name.ShouldBe("测试音乐");
            info.Artist.ShouldBe("测试作者");
            info.AlbumImage.Length.ShouldBe(0);
            
            // Finish
            info.Name = "凡人修仙路";
            info.Artist = "小旭音乐";
            using (var imgStream = File.Open(
                    Path.Combine(PathUtils.RecursivelyGetParentPath(ProgramUtils.GetCurrentDirectory(), 3), "testFiles", "album.jpg"), FileMode.Open))
            {
                using (var ms = new MemoryStream())
                {
                    var buffer = new byte[1024 * 16];
                    int readCount = 0;
                    while ((readCount = imgStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ms.Write(buffer, 0, readCount);
                    }

                    info.AlbumImage = ms.ToArray();
                }
            }
            Loader.Save(info);
        }
    }
}