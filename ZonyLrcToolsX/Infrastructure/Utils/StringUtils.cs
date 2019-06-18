namespace ZonyLrcToolsX.Infrastructure.Utils
{
    public static class StringUtils
    {
        public static bool IsNullOrEmptyOrWhite(this string srcStr)
        {
            return string.IsNullOrEmpty(srcStr) && string.IsNullOrWhiteSpace(srcStr);
        }
    }
}