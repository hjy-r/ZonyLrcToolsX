using System;
using Microsoft.Extensions.DependencyInjection;
using ZonyLrcToolsX.Infrastructure.DependencyInject;

namespace ZonyLrcToolsX.Tests
{
    public abstract class TestBase
    {
        protected IServiceCollection Services;

        protected IServiceProvider ServiceProvider;

        public TestBase()
        {
            Services = new ServiceCollection();

            Services.BeginAutoDependencyInject<TestBase>();
            Services.BeginAutoDependencyInject<ZonyLrcToolsXApp>();

            Services.AddHttpClient();

            ServiceProvider = Services.BuildServiceProvider();
        }
    }
}