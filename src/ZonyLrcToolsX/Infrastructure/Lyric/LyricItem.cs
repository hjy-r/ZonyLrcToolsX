using System;

namespace ZonyLrcToolsX.Infrastructure.Lyric
{
    /// <summary>
    /// 每一行歌词的对象。
    /// </summary>
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

        /// <summary>
        /// 构造新的 <see cref="LyricItem"/> 对象。
        /// </summary>
        /// <param name="minute">歌词所在的时间(分)。</param>
        /// <param name="second">歌词所在的时间(秒)。</param>
        /// <param name="lyricText">歌词文本数据。</param>
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

        public static bool operator >(LyricItem left, LyricItem right)
        {
            return left.SortScore > right.SortScore;
        }

        public static bool operator <(LyricItem left, LyricItem right)
        {
            return left.SortScore < right.SortScore;
        }

        public static bool operator ==(LyricItem left, LyricItem right)
        {
            return (int?) left?.SortScore == (int?) right?.SortScore;
        }

        public static bool operator !=(LyricItem item1, LyricItem item2)
        {
            return !(item1 == item2);
        }
        
        protected bool Equals(LyricItem other)
        {
            return LyricText == other.LyricText && Minute == other.Minute && Second.Equals(other.Second);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((LyricItem) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(LyricText, Minute, Second);
        }

        public override string ToString() => $"[{Minute:00}:{Second:00.00}]{LyricText}";
    }
}