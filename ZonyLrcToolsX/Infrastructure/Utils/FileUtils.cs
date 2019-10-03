using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using ZonyLrcToolsX.Infrastructure.Configuration;
using ZonyLrcToolsX.Infrastructure.Lyric;
using ZonyLrcToolsX.Infrastructure.MusicTag;

// ReSharper disable NotResolvedInText

namespace ZonyLrcToolsX.Infrastructure.Utils
{
    /// <summary>
    /// 封装了文件操作相关方法。
    /// </summary>
    public class FileUtils
    {
        private static object _locker = new object();
        private static FileUtils _fileUtils;

        /// <summary>
        /// 获取一个单例的 <see cref="FileUtils"/> 实例。
        /// </summary>
        public static FileUtils Instance
        {
            get
            {
                if(_fileUtils == null)
                {
                    lock (_locker)
                    {
                        if(_fileUtils == null) _fileUtils = new FileUtils();
                    }
                }

                return _fileUtils;
            }
        }

        private FileUtils()
        {

        }

        /// <summary>
        /// 根据指定的编码，将歌词数据写入到 Lyric 文件当中。
        /// </summary>
        /// <param name="musicInfo">歌曲文件的详细信息。</param>
        /// <param name="lyricData">需要写入到文件的歌词数据。</param>
        public async Task WriteToLyricFileAsync(MusicInfo musicInfo, LyricItemCollection lyricData)
        {
            var lyricFilePath = GetLyricFilePathByMusicInfo(musicInfo);
            
            // 覆盖操作时，先删除原有 Lrc 文件，再进行下载。
            if (File.Exists(lyricFilePath) && AppConfiguration.Instance.Configuration.IsCoverSourceLyricFile)
            {
                File.Delete(lyricFilePath);
            }

            using (var newLyricFile = File.Create(lyricFilePath))
            {
                var newLyricFileBytes = GetBytesWithAppConfigurationEncoding(lyricData.ToString());
                await newLyricFile.WriteAsync(newLyricFileBytes,0,newLyricFileBytes.Length);
            }
        }

        /// <summary>
        /// 如果歌曲的 Lrc 文件存在是，是否进行歌词下载。检测时会结合 <see cref="AppConfiguration"/> 的参数判定是否需要为歌曲
        /// 下载歌词。
        /// </summary>
        /// <returns>当方法返回 true 时进行略过，返回 false 则进行覆盖。</returns>
        public bool IsIgnoreWriteLyricFile(MusicInfo musicInfo)
        {
            var lyricFilePath = GetLyricFilePathByMusicInfo(musicInfo);
            return File.Exists(lyricFilePath) && !AppConfiguration.Instance.Configuration.IsCoverSourceLyricFile;
        }
        
        /// <summary>
        /// 递归搜索指定路径下的歌曲文件，搜索的后缀名以 <paramref name="fileExtensions"/> 参数为准。
        /// </summary>
        /// <param name="searchPath">需要搜索的目录路径，如果路径无效则可能会抛出 <see cref="DirectoryNotFoundException"/> 异常。</param>
        /// <param name="fileExtensions">需要搜索的歌曲后缀名集合，该参数一般来自于 <see cref="AppConfiguration"/> 中的配置。</param>
        /// <returns>将会以键值对的形式，返回某个后缀下面的所有歌曲文件路径。</returns>
        public Task<Dictionary<string,List<string>>> FindFilesAsync(string searchPath,IList<string> fileExtensions)
        {
            if(fileExtensions == null) throw new ArgumentNullException(nameof(searchPath),"搜索后缀不能为空。");
            if(fileExtensions.Count == 0) throw new ArgumentException("搜索后缀不能够为空。");
            if(!Directory.Exists(searchPath))throw new DirectoryNotFoundException("指定的路径不存在有效目录。");

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

        public string GetLyricFilePathByMusicInfo(MusicInfo musicInfo)
        {
            return Path.Combine(Path.GetDirectoryName(musicInfo.FilePath) ?? throw new DirectoryNotFoundException("指定的歌曲文件目录存在问题。"),
                $"{Path.GetFileNameWithoutExtension(musicInfo.FilePath)}.lrc");
        }

        private byte[] GetBytesWithAppConfigurationEncoding(string lyricStr)
        {
            if (AppConfiguration.Instance.Configuration.CodePage == ExtendEncodingCodePages.Utf8WithBom)
            {
                var srcUtf8Bytes = Encoding.UTF8.GetBytes(lyricStr);
                
                var newUtf8WithBom = new byte[srcUtf8Bytes.Length + 3];
                newUtf8WithBom[0] = 0xef;
                newUtf8WithBom[1] = 0xbb;
                newUtf8WithBom[2] = 0xbf;
                
                Array.Copy(srcUtf8Bytes,0,newUtf8WithBom,3,srcUtf8Bytes.Length);

                return newUtf8WithBom;
            }
            
            var encoding = Encoding.GetEncoding(AppConfiguration.Instance.Configuration.CodePage);
            return encoding.GetBytes(lyricStr);
        }
    }
}