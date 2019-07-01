using Shouldly;
using System.Threading.Tasks;
using Xunit;
using ZonyLrcToolsX.Downloader.Lyric.NetEase;
using ZonyLrcToolsX.Infrastructure.MusicTag;

namespace ZonyLrcToolsX.Tests.Downloader.LyricDownloader
{
    public class NetEaseCloudMusicLyricDownloader_Tests
    {
        [Fact]
        public async Task DownloadAsync_Test()
        {
            // Arrange
            var downloader = new NetEaseCloudMusicLyricDownloader();
            var musicInfo = new MusicInfo
            {
                Name = "黄金甲",
                Artist = "周杰伦"
            };

            // Act
            var result = await downloader.DownloadAsync(musicInfo);

            // Assert
            result.ShouldNotBeNull();
            result.Count.ShouldBeGreaterThan(1);
        }
    }
}