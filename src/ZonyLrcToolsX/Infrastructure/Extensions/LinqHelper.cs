using System;
using System.Collections.Generic;

namespace ZonyLrcToolsX.Infrastructure.Extensions
{
    public static class LinqHelper
    {
        public static void Foreach<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach (var item in items)
            {
                action(item);
            }
        }
    }
}