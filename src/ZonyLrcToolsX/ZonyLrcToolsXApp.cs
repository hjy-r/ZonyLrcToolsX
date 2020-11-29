using Chromely;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ZonyLrcToolsX
{
    public class ZonyLrcToolsXApp : ChromelyBasicApp
    {
        public override void ConfigureServices(ServiceCollection services)
        {
            base.ConfigureServices(services);

            services.AddLogging(configure => configure.AddConsole());
            services.AddLogging(configure => configure.AddFile("Logs/serilog-{Date}.txt"));
            
            RegisterControllerAssembly(services, typeof(ZonyLrcToolsXApp).Assembly);
        }
    }
}