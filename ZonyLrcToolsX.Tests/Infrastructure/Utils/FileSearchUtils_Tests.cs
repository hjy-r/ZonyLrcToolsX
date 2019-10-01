using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Shouldly;
using Xunit;
using ZonyLrcToolsX.Infrastructure.Utils;

namespace ZonyLrcToolsX.Tests.Infrastructure.Utils
{
    public class FileSearchUtils_Tests
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
    }
}
