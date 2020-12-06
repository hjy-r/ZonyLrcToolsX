using Shouldly;
using Xunit;
using ZonyLrcToolsX.Infrastructure.DependencyInject;

namespace ZonyLrcToolsX.Tests.Infrastructure.DependencyInject
{
    public class AutoInjectExtensionsTests : TestBase
    {
        [Fact]
        public void BeginAutoDependencyInject_Tests()
        {
            Services.BeginAutoDependencyInject<AutoInjectExtensionsTests>();
            
            Services.Count.ShouldBe(2);
            Services.ShouldContain(t=>t.ImplementationType == typeof(MockAFakeDownloader));
            Services.ShouldContain(t=>t.ImplementationType == typeof(MockBFakeDownloader));
        }
    }

    public interface IFakeDownloader
    {
    }

    public class MockAFakeDownloader : IFakeDownloader, ITransientDependency
    {
    }

    public class MockBFakeDownloader : IFakeDownloader, ITransientDependency
    {
    }
}