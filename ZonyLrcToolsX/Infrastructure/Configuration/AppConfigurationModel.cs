using System.Collections.Generic;

namespace ZonyLrcToolsX.Infrastructure.Configuration
{
    public class AppConfigurationModel
    {
        public List<string> SuffixName { get; set; }

        public int CodePage { get; set; }

        public bool IsEnableProxy { get; set; }

        public string ProxyIp { get; set; }

        public int ProxyPort { get; set; }

        public bool IsCoverSourceLyricFile { get; set; }

        public bool IsAutoCheckUpdate { get; set; }

        public AppConfigurationModel()
        {
            SuffixName = new List<string>();
        }
    }
}