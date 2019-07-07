using System.IO;
using Shouldly;
using Xunit;
using ZonyLrcToolsX.Infrastructure.Configuration;
using ZonyLrcToolsX.Infrastructure.Utils;

namespace ZonyLrcToolsX.Tests.Infrastructure.Configuration
{
    public class AppConfiguration_Tests
    {
        [Fact]
        public void Load_Test()
        {
            /* Arrange */
            var configFile = Path.Combine(ProgramUtils.GetCurrentDirectory(), "config.json");
            if(File.Exists(configFile)) File.Delete(configFile);

            /* Act */
            AppConfiguration.Instance.Load();

            /* Assert */
            AppConfiguration.Instance.Configuration.ShouldNotBeNull();
            AppConfiguration.Instance.Configuration.IsAutoCheckUpdate = true;
            AppConfiguration.Instance.Configuration.SuffixName.Contains("*.mp3").ShouldBe(true);
            AppConfiguration.Instance.Configuration.LyricContentType.ShouldBe(LyricContentTypes.Original);
            File.Exists(configFile).ShouldBe(true);
            File.Delete(configFile);
        }

        [Fact]
        public void Save_Test()
        {
            /* Arrange */
            var configFile = Path.Combine(ProgramUtils.GetCurrentDirectory(), "config.json");
            if (File.Exists(configFile)) File.Delete(configFile);

            /* Act */
            AppConfiguration.Instance.Load();
            AppConfiguration.Instance.Configuration.ProxyIp = "127.0.0.1";
            AppConfiguration.Instance.Save();

            /* Assert */
            File.Exists(configFile).ShouldBe(true);
            AppConfiguration.Instance.Load();
            AppConfiguration.Instance.Configuration.ShouldNotBeNull();
            AppConfiguration.Instance.Configuration.IsAutoCheckUpdate = true;
            AppConfiguration.Instance.Configuration.SuffixName.Contains("*.mp3").ShouldBe(true);
            AppConfiguration.Instance.Configuration.ProxyIp.ShouldBe("127.0.0.1");
            AppConfiguration.Instance.Configuration.LyricContentType.ShouldBe(LyricContentTypes.Original);
            File.Delete(configFile);
        }
    }
}
