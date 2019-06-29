using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

// ReSharper disable NotResolvedInText

namespace ZonyLrcToolsX.Infrastructure.Utils
{
    public class FileSearchUtils
    {
        private static object _locker = new object();
        private static FileSearchUtils _fileSearchUtils;

        public static FileSearchUtils Instance
        {
            get
            {
                if(_fileSearchUtils == null)
                {
                    lock (_locker)
                    {
                        if(_fileSearchUtils == null) _fileSearchUtils = new FileSearchUtils();
                    }
                }

                return _fileSearchUtils;
            }
        }

        public FileSearchUtils()
        {

        }

        public Task<Dictionary<string,List<string>>> FindFilesAsync(string searchPath,IList<string> fileExtensions)
        {
            if(fileExtensions == null) throw new ArgumentNullException("搜索后缀不能为空。");
            if(fileExtensions.Count == 0) throw new ArgumentException("搜索后缀不能够为空。");

            var files = new Dictionary<string,List<string>>();
            try
            {
                foreach (var extension in fileExtensions)
                {
                    var result = new List<string>();
                    SearchFile(result, searchPath, extension);
                    files.Add(Path.GetExtension(extension) ?? throw new InvalidDataException(" 无法获得文件的后缀！"), result);
                }
            }
            catch (Exception)
            {
                // TODO: 应该使用 Log 进行记录？
                throw;
            }

            return Task.FromResult(files);
        }

        private void SearchFile(IList<string> files,string folder,string extension)
        {
            try
            {
                foreach (var file in Directory.GetFiles(folder, extension))
                {
                    files.Add(file);
                }

                foreach (var directory in Directory.GetDirectories(folder))
                {
                    SearchFile(files,directory,extension);
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}