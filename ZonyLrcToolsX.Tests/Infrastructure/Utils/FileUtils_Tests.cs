using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Shouldly;
using Xunit;
using ZonyLrcToolsX.Infrastructure.Lyric;
using ZonyLrcToolsX.Infrastructure.MusicTag;
using ZonyLrcToolsX.Infrastructure.Utils;

namespace ZonyLrcToolsX.Tests.Infrastructure.Utils
{
    public class FileUtils_Tests
    {
        [Fact]
        public async Task FindFilesAsync_Test()
        {
            // Arrange
            var currentDir = Environment.CurrentDirectory;
            var newChildDir = Path.Combine(currentDir, "childDir");
            Directory.CreateDirectory(newChildDir);

            var lyricFiles = new List<string>
            {
                Path.Combine(currentDir,"1.mp3"),
                Path.Combine(newChildDir,"2.mp3"),
                Path.Combine(newChildDir,"3.flac")
            };

            lyricFiles.ForEach(item =>
            {
                var fs = File.Create(item);
                fs.Close();
            });

            // Act
            var result = await FileUtils.Instance.FindFilesAsync(currentDir, new List<string> { "*.mp3", "*.flac" });

            // Assert
            result.ShouldNotBeNull();
            result.Count.ShouldBe(2);
            result.SelectMany(x=>x.Value).Count().ShouldBe(3);

            // Delete files and directory.
            foreach (var lyricFile in lyricFiles)
            {
                if (File.Exists(lyricFile))
                {
                    File.Delete(lyricFile);
                }
            }

            Directory.Delete(newChildDir);
        }

        [Fact]
        public async Task WriteToLyricFile_Test()
        {
            // Arrange
            var musicInfo = new MusicInfo("测试音乐", "测试歌手", "测试专辑", null,
                Path.Combine(ProgramUtils.GetCurrentDirectory(), "test.mp3"));
            var lyricItems = new LyricItemCollection
            {
                new LyricItem(0, 0, "歌词条目1"),
                new LyricItem(0, 0, "歌词条目2")
            };

            // Act
            await FileUtils.Instance.WriteToLyricFileAsync(musicInfo, lyricItems);

            // Assert
            var lyricFilePath = Path.Combine(ProgramUtils.GetCurrentDirectory(), $"{Path.GetFileNameWithoutExtension(musicInfo.FilePath)}.lrc");
            File.Exists(lyricFilePath).ShouldBe(true);
            File.ReadLines(lyricFilePath).Count().ShouldBe(2);
            
            File.Delete(lyricFilePath);
        }
    }
}
