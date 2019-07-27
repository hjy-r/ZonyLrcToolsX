using Shouldly;
using Xunit;
using ZonyLrcToolsX.Infrastructure.MusicTag.TagLib;

namespace ZonyLrcToolsX.Tests.Infrastructure.MusicTag
{
    public class MusicInfoLoaderByTaglib_Tests
    {
        [Fact]
        public void Load_Test()
        {
            var loader = new MusicInfoLoaderByTagLib();

            var info = loader.Load(@"D:\Temp\MusicTest\安九 - 日暮归途.mp3");
            
            info.ShouldNotBeNull();
            info.Name.ShouldBe("安九");
        }
    }
}