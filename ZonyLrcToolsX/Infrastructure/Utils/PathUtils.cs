using System.IO;

namespace ZonyLrcToolsX.Infrastructure.Utils
{
    public static class PathUtils
    {
        /// <summary>
        /// 递归获得指定路径的父级完整路径。
        /// </summary>
        /// <param name="sourcePath">需要递归的路径。</param>
        /// <param name="maxDepth">递归的最大深度。</param>
        public static string RecursivelyGetParentPath(string sourcePath, int maxDepth)
        {
            var directoryInfo = new DirectoryInfo(sourcePath);
            DirectoryInfo resultDirInfo = null;

            void Recursively(DirectoryInfo currentDirInfo,int currentDepth)
            {
                if (currentDepth > maxDepth) return;
                resultDirInfo = currentDirInfo.Parent;
                Recursively(resultDirInfo,currentDepth + 1);
            }
            
            Recursively(directoryInfo,1);
            return resultDirInfo.FullName;
        }
    }
}