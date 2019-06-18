using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using ZonyLrcToolsX.Infrastructure.Utils;

// ReSharper disable InconsistentNaming

namespace ZonyLrcToolsX.Infrastructure.Configuration
{
    public class AppConfiguration
    {
        private static readonly object _locker = new object();
        private static AppConfiguration _instance;

        private AppConfiguration()
        {
            Configuration = new AppConfigurationModel();
        }

        public static AppConfiguration Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_locker)
                    {
                        if(_instance == null) _instance = new AppConfiguration();
                    }
                }

                return _instance;
            }
        }

        public AppConfigurationModel Configuration { get; private set; }

        public AppConfigurationModel Load()
        {
            using (var configFile = File.Open(Path.Combine(ProgramUtils.GetCurrentDirectory(), "config.json"), FileMode.OpenOrCreate))
            {
                using (var configFileReader = new StreamReader(configFile))
                {
                    var jsonStr = configFileReader.ReadToEnd();
                    if (jsonStr.IsNullOrEmptyOrWhite())
                    {
                        Configuration = BuildNewConfigurationModel();
                    }
                    else
                    {
                        var jsonObj = JsonConvert.DeserializeObject<AppConfigurationModel>(jsonStr);
                        Configuration = jsonObj ?? BuildNewConfigurationModel();
                    }
                }
            }
            
            return Configuration;
        }
        
        public AppConfigurationModel Save()
        {
            using (var configFile = File.Open(Path.Combine(ProgramUtils.GetCurrentDirectory(), "config.json"),FileMode.OpenOrCreate))
            {
                configFile.SetLength(0);
                using (var configFileWriter = new StreamWriter(configFile))
                {
                    var jsonStr = JsonConvert.SerializeObject(Configuration);
                    configFileWriter.Write(jsonStr);
                    configFileWriter.Flush();
                }
            }

            return Configuration;
        }

        private AppConfigurationModel BuildNewConfigurationModel()
        {
            return new AppConfigurationModel
            {
                IsAutoCheckUpdate =  true,
                CodePage = 65535,
                IsCoverSourceLyricFile = false,
                IsEnableProxy = false,
                SuffixName = new List<string>
                {
                    "*.mp3",
                    "*.ape",
                    "*.flac",
                    "*.m4a",
                    "*.wav"
                }
            };
        }
    }
}