using System;

namespace ZonyLrcToolsX.Infrastructure.Network
{
    public class UpdateModel
    {
        public Version Version { get; set; }

        public string UpdateDescription { get; set; }

        public string Url { get; set; }

        public DateTime UpdateTime { get; set; }
    }
}