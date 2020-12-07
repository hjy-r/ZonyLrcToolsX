using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Xunit;
using ZonyLrcToolsX.Infrastructure;
using ZonyLrcToolsX.Infrastructure.Album;
using ZonyLrcToolsX.Infrastructure.Album.NetEase;
using ZonyLrcToolsX.Infrastructure.Album.QQMusic;

namespace ZonyLrcToolsX.Tests.Infrastructure.Album
{
    public class NetEaseAlbumDownloaderTests : TestBase
    {
        [Fact]
        public async Task DownloadAsync_Test()
        {
            var downloader = ServiceProvider.GetRequiredService<NetEaseAlbumDownloader>();

            var result = await downloader.DownloadAsync(new MusicInfo
            {
                Artist = "AC / DC",
                Name = "Back In Black"
            });

            result.Length.ShouldBeGreaterThan(0);
        }
    }

    public class QQMusicAlbumDownloaderTests : TestBase
    {
        [Fact]
        public async Task DownloadAsync_Test()
        {
            var downloader = ServiceProvider.GetRequiredService<QQMusicAlbumDownloader>();

            var result = await downloader.DownloadAsync(new MusicInfo
            {
                Artist = "AC / DC",
                Name = "Back In Black"
            });

            result.Length.ShouldBeGreaterThan(0);
        }
    }
}