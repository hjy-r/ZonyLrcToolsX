using System.Collections.Generic;
using System.Text;
using ZonyLrcToolsX.Infrastructure.Extensions;

namespace ZonyLrcToolsX.Infrastructure.Lyric
{
    /// <summary>
    /// 歌词数据，包含多条歌词对象(<see cref="LyricItem"/>)。
    /// </summary>
    public class LyricItemCollection : List<LyricItem>
    {
        /// <summary>
        /// 是否为纯音乐，当没有任何歌词数据的时候，属性值为 True。
        /// </summary>
        public bool IsPruneMusic { get; private set; }

        public LyricItemCollection()
        {
            IsPruneMusic = true;
        }

        public override string ToString()
        {
            var lyricBuilder = new StringBuilder();
            ForEach(lyric => lyricBuilder.Append(lyric).Append("\r\n"));
            return lyricBuilder.ToString().TrimEnd("\r\n");
        }
    }
}