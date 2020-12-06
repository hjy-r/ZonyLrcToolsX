using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Xunit;
using ZonyLrcToolsX.Infrastructure;
using ZonyLrcToolsX.Infrastructure.Album;

namespace ZonyLrcToolsX.Tests.Infrastructure.Album
{
    public class NetEaseAlbumDownloaderTests : TestBase
    {
        [Fact]
        public async Task DownloadAsync_Test()
        {
            var netEase = ServiceProvider.GetRequiredService<IAlbumDownloader>();

            var result = await netEase.DownloadAsync(new MusicInfo
            {
                Artist = "AC / DC",
                Name = "Back In Black"
            });
            
            result.Length.ShouldBeGreaterThan(0);
        }
    }
}