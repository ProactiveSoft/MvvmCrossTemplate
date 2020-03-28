using MvvmCrossTest.Core.ViewModels;
using Xunit;
using Xunit.Abstractions;

namespace MvvmCrossTest.Test.Core
{
    public class MainViewModelShould
    {
        public MainViewModelShould(ITestOutputHelper output) => _output = output;


        //[Fact(Skip = "csproj file not present on Android & iOS. So test will fail.")]
        [Fact]
        public void SetTitle()
        {
            // Arrange
            MainViewModel sot = new MainViewModel();
            // ToDo: Get Mvx version from Mvx GitHub:
            // https://github.com/MvvmCross/MvvmCross/blob/develop/CHANGELOG.md
            string expectedMvxVersion = "V 6.4.2";

            // Act
            sot.Prepare();

            // Assert
            Assert.Equal(expectedMvxVersion, sot.Title);
            _output.WriteLine($"Title set to current Mvx version: {sot.Title}");
        }


        private readonly ITestOutputHelper _output;
    }
}
