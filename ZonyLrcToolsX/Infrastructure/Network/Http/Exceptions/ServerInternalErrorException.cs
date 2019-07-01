namespace ZonyLrcToolsX.Infrastructure.Network.Http.Exceptions
{
    /// <summary>
    /// 目标服务器内部异常，当返回的状态码为 500 时，会抛出本异常。
    /// </summary>
    public class ServerInternalErrorException : HttpRequestFailedException
    {
        public ServerInternalErrorException(string message) : base(message)
        {

        }
    }
}
