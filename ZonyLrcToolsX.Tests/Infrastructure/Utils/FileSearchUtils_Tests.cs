using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shouldly;
using Xunit;
using ZonyLrcToolsX.Infrastructure.Utils;

namespace ZonyLrcToolsX.Tests.Infrastructure.Utils
{
    public class FileSearchUtils_Tests
    {
        [Fact]
        public async Task FindFilesAsync_Test()
        {
            var result = await FileSearchUtils.Instance.FindFilesAsync(@"E:\", new List<string> {"*.txt"});
            result.ShouldNotBeNull();
            result.Count.ShouldBe(1);
            result.FirstOrDefault().Value.Count.ShouldBeGreaterThan(1);
        }
    }
}
