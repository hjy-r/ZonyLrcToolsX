using System;

namespace ZonyLrcToolsX.Infrastructure.MusicTag
{
    /// <summary>
    /// 歌曲信息定义，存放了软件所需要使用的歌曲元数据。
    /// </summary>
    [Serializable]
    public class MusicInfo
    {
        /// <summary>
        /// 歌曲的名称。
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 歌手，或者说是艺术家。
        /// </summary>
        public string Artist { get; set; }

        /// <summary>
        /// 歌曲的专辑名称。
        /// </summary>
        public string AlbumName { get; set; }

        /// <summary>
        /// 歌曲的专辑图像。
        /// </summary>
        public byte[] AlbumImage { get; set; }

        /// <summary>
        /// 歌曲对应的物理文件路径。
        /// </summary>
        public string FilePath { get; set; }
    }
}