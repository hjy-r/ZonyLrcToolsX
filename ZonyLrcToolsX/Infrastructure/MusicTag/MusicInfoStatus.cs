using System;

namespace ZonyLrcToolsX.Infrastructure.MusicTag
{
    [Flags]
    public enum MusicInfoStatus
    {
        WaitingDownload,
        DownloadCompleted
    }
}
