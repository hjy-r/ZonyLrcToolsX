using System.IO;
using Shouldly;
using Xunit;
using ZonyLrcToolsX.Infrastructure.MusicTag.TagLib;
using ZonyLrcToolsX.Infrastructure.Utils;

namespace ZonyLrcToolsX.Tests.Infrastructure.MusicTag
{
    public class MusicInfoLoaderByTaglib_Tests
    {
        [Fact]
        public void Load_Test()
        {
            // Arrange
            var loader = new MusicInfoLoaderByTagLib();

            var dirPath = PathUtils.RecursivelyGetParentPath(ProgramUtils.GetCurrentDirectory(), 3);
            var musicFilePath = Path.Combine(dirPath,"testFiles","tagLib 读取正常歌曲.mp3");

            // Act
            var info = loader.Load(musicFilePath);
            
            // Assert
            info.ShouldNotBeNull();
            info.Name.ShouldBe("凡人修仙路");
            info.Artist.ShouldBe("小旭音乐");
        }

        [Fact]
        public void Save_Test()
        {
            // Arrange
            var loader = new MusicInfoLoaderByTagLib();

            var dirPath = PathUtils.RecursivelyGetParentPath(ProgramUtils.GetCurrentDirectory(), 3);
            var musicFilePath = Path.Combine(dirPath,"testFiles","tagLib 读取正常歌曲.mp3");

            // Act
            var info = loader.Load(musicFilePath);
            info.Name = "测试音乐";
            info.Artist = "测试作者";
            
            // Assert
            loader.Save(musicFilePath,info);
            
            // 再次读取。
            info = loader.Load(musicFilePath);
            info.ShouldNotBeNull();
            info.Name.ShouldBe("测试音乐");
            info.Artist.ShouldBe("测试作者");
            
            // Finish
            info.Name = "凡人修仙路";
            info.Artist = "小旭音乐";
            loader.Save(musicFilePath,info);
        }
    }
}