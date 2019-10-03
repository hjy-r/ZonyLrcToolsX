using System.Threading.Tasks;
using Shouldly;
using Xunit;
using ZonyLrcToolsX.Downloader.Album.NetEase;
using ZonyLrcToolsX.Infrastructure.MusicTag;

namespace ZonyLrcToolsX.Tests.Downloader.AlbumDownloader
{
    public class NetEaseCloudMusicAlbumDownloader_Tests
    {
        [Fact]
        public async Task DownloadAsync_Test()
        {
            // Arrange
            var downloader = new NetEaseCloudMusicAlbumDownloader();
            var newMusicInfo = new MusicInfo("Back In Black", "AC / DC");
            
            // Act
            var result = await downloader.DownloadAsync(newMusicInfo);
            
            // Assert
            result.ShouldNotBeNull();
            result.Length.ShouldBeGreaterThan(0);
        }

        [Fact]
        public void Download_Test()
        {
            // Arrange
            var downloader = new NetEaseCloudMusicAlbumDownloader();
            var newMusicInfo = new MusicInfo("Back In Black", "AC / DC");
            
            // Act
            var result = downloader.Download(newMusicInfo);
            
            // Assert
            result.ShouldNotBeNull();
            result.Length.ShouldBeGreaterThan(0);
        }
    }
}