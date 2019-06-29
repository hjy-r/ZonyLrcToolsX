using System.Net.Http;

namespace ZonyLrcToolsX.Infrastructure.Network.Http
{
    public class NewHttpClient
    {
        private readonly HttpClient _httpClient;

        public NewHttpClient()
        {
            // 如果启用了网络代理，则构建时增加网络代理参数。
            _httpClient = new HttpClient();
        }
    }
}