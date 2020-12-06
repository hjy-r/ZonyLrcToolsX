using System;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ZonyLrcToolsX.Infrastructure.DependencyInject;
using ZonyLrcToolsX.Infrastructure.Network.Exceptions;

namespace ZonyLrcToolsX.Infrastructure.Network
{
    public class DefaultWarpHttpClient : IWarpHttpClient, ITransientDependency
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<DefaultWarpHttpClient> _logger;

        public DefaultWarpHttpClient(IHttpClientFactory httpClientFactory,
            ILogger<DefaultWarpHttpClient> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async ValueTask<string> PostAsync(string url,
            object parameters,
            bool isQueryStringParam = false,
            Action<HttpRequestMessage> requestOption = null)
        {
            var parametersStr = isQueryStringParam ? BuildQueryString(parameters) : BuildJsonBodyString(parameters);
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, new Uri(url));
            requestMessage.Content = new StringContent(parametersStr);

            requestOption?.Invoke(requestMessage);

            using (var responseMessage = await _httpClientFactory.CreateClient().SendAsync(requestMessage))
            {
                var responseContentString = await responseMessage.Content.ReadAsStringAsync();

                switch (responseMessage.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return responseContentString;
                    case HttpStatusCode.ServiceUnavailable:
                        _logger.LogWarning("服务接口限制，无法进行请求，请尝试使用代理服务器。");
                        throw new ServerUnavailableException("服务接口限制，无法进行请求，请尝试使用代理服务器。");
                    default:
                        _logger.LogError("对目标服务器执行 Http Get 请求失败。", parametersStr, responseContentString);
                        throw new HttpRequestFailedException("对目标服务器执行 Http Get 请求失败。", parametersStr, responseContentString);
                }
            }
        }

        public async ValueTask<TResponse> PostAsync<TResponse>(string url,
            object parameters,
            bool isQueryStringParam = false,
            Action<HttpRequestMessage> requestOption = null)
        {
            var responseString = await PostAsync(url, parameters, isQueryStringParam, requestOption);
            var throwException = new HttpRequestFailedException("将请求的结果，转换到 JSON 对象时出现错误，无法进行转换。",
                BuildJsonBodyString(parameters),
                responseString);

            try
            {
                var responseObj = JsonConvert.DeserializeObject<TResponse>(responseString);
                if (responseObj != null) return responseObj;

                throw throwException;
            }
            catch (JsonSerializationException)
            {
                throw throwException;
            }
        }

        public async ValueTask<string> GetAsync(string url,
            object parameters,
            Action<HttpRequestMessage> requestOption = null)
        {
            var requestParamsStr = BuildQueryString(parameters);
            var requestMsg = new HttpRequestMessage(HttpMethod.Get, new Uri($"{url}?{requestParamsStr}"));
            requestOption?.Invoke(requestMsg);

            using (var responseMsg = await _httpClientFactory.CreateClient().SendAsync(requestMsg))
            {
                var responseContent = await responseMsg.Content.ReadAsStringAsync();

                return responseMsg.StatusCode switch
                {
                    HttpStatusCode.OK => responseContent,
                    HttpStatusCode.ServiceUnavailable => throw new ServerUnavailableException("服务接口限制，无法进行请求，请尝试使用代理服务器。"),
                    _ => throw new HttpRequestFailedException("对目标服务器执行 Http Get 请求失败。", requestParamsStr, responseContent)
                };
            }
        }

        public async ValueTask<TResponse> GetAsync<TResponse>(string url,
            object parameters,
            Action<HttpRequestMessage> requestOption = null)
        {
            var responseStr = await GetAsync(url, parameters, requestOption);
            var throwException = new HttpRequestFailedException("将请求的结果，转换到 JSON 对象时出现错误，无法进行转换。", BuildQueryString(parameters), responseStr);
            try
            {
                var responseObj = JsonConvert.DeserializeObject<TResponse>(responseStr);
                if (responseObj != null) return responseObj;

                throw throwException;
            }
            catch (JsonSerializationException)
            {
                throw throwException;
            }
        }

        private string BuildQueryString(object parameters)
        {
            if (parameters == null)
            {
                return string.Empty;
            }

            var type = parameters.GetType();
            if (type == typeof(string))
            {
                return parameters as string;
            }

            var properties = type.GetProperties();
            var paramBuilder = new StringBuilder();

            foreach (var propertyInfo in properties)
            {
                var jsonProperty = propertyInfo.GetCustomAttribute<JsonPropertyAttribute>();
                var propertyName = jsonProperty != null ? jsonProperty.PropertyName : propertyInfo.Name;

                paramBuilder.Append($"{propertyName}={propertyInfo.GetValue(parameters)}&");
            }

            return paramBuilder.ToString().TrimEnd('&');
        }

        private string BuildJsonBodyString(object parameters)
        {
            if (parameters == null) return string.Empty;
            if (parameters is string result) return result;

            return JsonConvert.SerializeObject(parameters);
        }
    }
}