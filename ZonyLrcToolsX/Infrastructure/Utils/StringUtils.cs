using System;

namespace ZonyLrcToolsX.Infrastructure.Utils
{
    public static class StringUtils
    {
        public static bool IsNullOrEmptyOrWhite(this string srcStr)
        {
            return string.IsNullOrEmpty(srcStr) && string.IsNullOrWhiteSpace(srcStr);
        }

        public static string TrimEnd(this string srcStr, string trimEndStr)
        {
            if (srcStr.EndsWith(trimEndStr,StringComparison.Ordinal))
            {
                return srcStr.Substring(0,srcStr.Length - trimEndStr.Length);
            }

            return srcStr;
        }
    }
}