using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Shouldly;
using Xunit;
using ZonyLrcToolsX.Infrastructure.Network;

namespace ZonyLrcToolsX.Tests.Infrastructure.Network
{
    public class WarpHttpClientTests : TestBase
    {
        private class PostResponse
        {
            [JsonProperty("showapi_res_code")] public int Code { get; set; }

            [JsonProperty("showapi_res_error")] public string Error { get; set; }
        }
        
        private class GetResponse
        {
            [JsonProperty("code")]
            public int Code { get; set; }

            [JsonProperty("message")]
            public string Message { get; set; }
        }

        [Fact]
        public async Task Post_Test()
        {
            var client = ServiceProvider.GetRequiredService<IWarpHttpClient>();

            var response = await client.PostAsync<PostResponse>("http://route.showapi.com/341-2", new
            {
                page = 1,
                maxResult = 10
            });

            response.Code.ShouldBe(-1002);
            response.Error.ShouldBe("input showapi_appid err");
        }

        [Fact]
        public async Task Get_Test()
        {
            var client = ServiceProvider.GetRequiredService<IWarpHttpClient>();

            var response = await client.GetAsync<GetResponse>("http://api.bilibili.com/x/credit/blocked/list", null);
            
            response.Code.ShouldBe(0);
            response.Message.ShouldBe("0");
        }
    }
}