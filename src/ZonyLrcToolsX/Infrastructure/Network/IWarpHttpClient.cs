using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ZonyLrcToolsX.Infrastructure.Network
{
    /// <summary>
    /// 基于 <see cref="IHttpClientFactory"/> 封装的 HTTP 请求客户端。
    /// </summary>
    public interface IWarpHttpClient
    {
        ValueTask<string> PostAsync(string url,
            object parameters,
            bool isQueryStringParam = false,
            Action<HttpRequestMessage> requestOption = null);

        ValueTask<TResponse> PostAsync<TResponse>(string url,
            object parameters,
            bool isQueryStringParam = false,
            Action<HttpRequestMessage> requestOption = null);

        ValueTask<string> GetAsync(string url,
            object parameters,
            Action<HttpRequestMessage> requestOption = null);

        ValueTask<TResponse> GetAsync<TResponse>(
            string url,
            object parameters,
            Action<HttpRequestMessage> requestOption = null);
    }
}