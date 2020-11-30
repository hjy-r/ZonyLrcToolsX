using System;
using System.Collections.Generic;

namespace ZonyLrcToolsX.Infrastructure.Lyric
{
    public class LyricItemCollection : List<LyricItem>
    {
    }

    public class LyricItem : IComparable<LyricItem>
    {
        /// <summary>
        /// 原始时间轴，格式类似于 [01:55.12]。
        /// </summary>
        public string OriginalTimeline => $"[{Minute:00}:{Second:00.00}]";

        /// <summary>
        /// 歌词文本数据。
        /// </summary>
        public string LyricText { get; }

        /// <summary>
        /// 歌词所在的时间(分)。
        /// </summary>
        public int Minute { get; }

        /// <summary>
        /// 歌词所在的时间(秒)。
        /// </summary>
        public double Second { get; }

        /// <summary>
        /// 排序分数，用于一组歌词当中的排序权重。<br/>
        /// </summary>
        public double SortScore => Minute * 60 + Second;

        public LyricItem(int minute, double second, string lyricText)
        {
            Minute = minute;
            Second = second;
            LyricText = lyricText;
        }

        public int CompareTo(LyricItem other)
        {
            if (SortScore > other.SortScore)
            {
                return 1;
            }

            if (SortScore < other.SortScore)
            {
                return -1;
            }

            return 0;
        }

        public override string ToString() => $"[{Minute:00}:{Second:00.00}]{LyricText}";
    }
}