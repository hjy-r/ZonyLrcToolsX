using Shouldly;
using Xunit;
using ZonyLrcToolsX.Infrastructure.Utils;

namespace ZonyLrcToolsX.Tests.Infrastructure.Utils
{
    public class StringUtils_Tests
    {
        [Fact]
        public void TrimEnd_Test()
        {
            // Arrange
            var srcStr = "我是测试文本EndWord";
            
            // Act
            var result = srcStr.TrimEnd("EndWord");
            
            // Assert
            result.ShouldBe("我是测试文本");
        }
    }
}