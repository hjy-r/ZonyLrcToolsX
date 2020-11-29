using System;
using Chromely.Core;
using Chromely.Core.Configuration;
using Chromely.Core.Host;

namespace ZonyLrcToolsX
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var config = Configure();

            AppBuilder
                .Create()
                .UseApp<ZonyLrcToolsXApp>()
                .UseConfig<DefaultConfiguration>(config)
                .Build()
                .Run(args);
        }

        static IChromelyConfiguration Configure()
        {
            var config = DefaultConfiguration.CreateForRuntimePlatform();

            config.AppName = config.WindowOptions.Title = "ZonyLrcToolsX";
            config.WindowOptions.WindowState = WindowState.Normal;
            config.WindowOptions.DisableResizing = true;
            config.WindowOptions.StartCentered = true;
            config.WindowOptions.Size = new WindowSize(1920,1080);
            config.StartUrl = "local://App/index.html";

            return config;
        }
    }
}