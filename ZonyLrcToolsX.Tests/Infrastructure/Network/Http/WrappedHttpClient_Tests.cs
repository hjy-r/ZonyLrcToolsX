using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Shouldly;
using Xunit;
using ZonyLrcToolsX.Infrastructure.Configuration;
using ZonyLrcToolsX.Infrastructure.Network.Http;

namespace ZonyLrcToolsX.Tests.Infrastructure.Network.Http
{
    public class WrappedHttpClient_Tests
    {
        [Fact]
        public async Task GetAsync_Test()
        {
            // Arrange
            var getParam = new
            {
                method = "baidu.ting.search.common",
                query="丁香花",
                page_size = 30,
                page_no = 1,
                format = "json"
            };
            AppConfiguration.Instance.Configuration.IsEnableProxy = false;
            var httpClient = new WrappedHttpClient();

            // Act
            var result = await httpClient.GetAsync(@"http://tingapi.ting.baidu.com/v1/restserver/ting", getParam);

            // Assert
            result.ShouldNotBeNull();
            Regex.Unescape(result).Contains("丁香花").ShouldBe(true);
            JObject.Parse(result).ShouldNotBeNull();
        }

        [Fact]
        public async Task GetAsync_WithProxy_Test()
        {
            // Arrange
            AppConfiguration.Instance.Configuration.ProxyIp = "127.0.0.1";
            AppConfiguration.Instance.Configuration.ProxyPort = 1080;
            AppConfiguration.Instance.Configuration.IsEnableProxy = true;
            var httpClient = new WrappedHttpClient();

            // Act
            var result = await httpClient.GetAsync(@"http://members.3322.org/dyndns/getip");

            // Assert
            result.ShouldNotBeNull();
        }

        [Fact]
        public async Task PostAsync_Test()
        {
            // Arrange
            var postParam = new
            {
                csrf_token = string.Empty,
                s = "丁香花",
                type = 1,
                offset = 0,
                total = true,
                limit = 5
            };
            AppConfiguration.Instance.Configuration.IsEnableProxy = false;
            var httpClient = new WrappedHttpClient();

            // Act
            var result = await httpClient.PostAsync(@"https://music.163.com/api/search/get/web", postParam,true, "https://music.163.com", "application/x-www-form-urlencoded");

            // Assert
            result.ShouldNotBeNull();
            result.Contains("丁香花").ShouldBe(true);
            JObject.Parse(result).ShouldNotBeNull();
        }
    }
}
