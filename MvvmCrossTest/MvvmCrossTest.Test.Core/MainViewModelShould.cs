using Xunit;

namespace MvvmCrossTest.Test.Core
{
    public class MainViewModelShould
    {
        [Fact]
        public void SetTitle()
        {
            // Arrange
            string expected = "V 6.4.2";

            // Act
            Assert.Equal(expected, "V 6.4.2");
        }
    }
}
