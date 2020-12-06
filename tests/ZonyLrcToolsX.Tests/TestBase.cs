using Microsoft.Extensions.DependencyInjection;

namespace ZonyLrcToolsX.Tests
{
    public abstract class TestBase
    {
        protected IServiceCollection Services;

        public TestBase()
        {
            Services = new ServiceCollection();
        }
    }
}