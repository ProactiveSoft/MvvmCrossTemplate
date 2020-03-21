using MvvmCrossTest.Core.ViewModels;
using Xunit;
using Xunit.Abstractions;

namespace MvvmCrossTest.Test.Core
{
    public class MainViewModelShould
    {
        public MainViewModelShould(ITestOutputHelper output) => _output = output;


        [Fact]
        public void SetTitle()
        {
            // Arrange
            MainViewModel vm = new MainViewModel();

            // Act
            vm.Prepare();

            // Assert
            Assert.Equal(vm.Title, "V 6.4.2");
            _output.WriteLine($"Title set to current Mvx version: {vm.Title}");
        }


        private readonly ITestOutputHelper _output;
    }
}
