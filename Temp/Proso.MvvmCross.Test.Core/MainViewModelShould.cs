using $ext_safeprojectname$.Core.ViewModels;
using Xunit;
using Xunit.Abstractions;

namespace $safeprojectname$
{
    public class MainViewModelShould
    {
        public MainViewModelShould(ITestOutputHelper output) => _output = output;


        [Fact]
        [Trait("File", ".cs")]
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
