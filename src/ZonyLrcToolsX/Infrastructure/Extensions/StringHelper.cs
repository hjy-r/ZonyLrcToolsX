using System;

namespace ZonyLrcToolsX.Infrastructure.Extensions
{
    public static class StringHelper
    {
        public static string TrimEnd(this string @string, string trimEndStr)
        {
            if (@string.EndsWith(trimEndStr, StringComparison.Ordinal))
            {
                return @string.Substring(0, @string.Length - trimEndStr.Length);
            }

            return @string;
        }
    }
}