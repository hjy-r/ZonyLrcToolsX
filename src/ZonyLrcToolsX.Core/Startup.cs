using System.Threading.Tasks;
using ElectronNET.API;
using ElectronNET.API.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ZonyLrcToolsX.Core
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddSpaStaticFiles(configuration => { configuration.RootPath = "ReactApp/build"; });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
            });
            
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ReactApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });

            if (HybridSupport.IsElectronActive)
            {
                Task.Run(ConfigureElectronBootstrap);
            }
        }

        private async Task ConfigureElectronBootstrap()
        {
            var browserWindow = await Electron.WindowManager.CreateWindowAsync(new BrowserWindowOptions
            {
                Height = 600,
                Width = 800,
                Show = false
            });

            await browserWindow.WebContents.Session.ClearCacheAsync();

            browserWindow.OnReadyToShow += () => browserWindow.Show();
            browserWindow.SetTitle("ZonyLrcToolsX");
        }
    }
}