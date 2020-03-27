using System.IO;
using MvvmCrossTest.Core.ViewModels;
using Xunit;
using Xunit.Abstractions;

namespace MvvmCrossTest.Test.Core
{
    public class MainViewModelShould
    {
        public MainViewModelShould(ITestOutputHelper output) => _output = output;


        [Fact(Skip = "csproj file not present on Android & iOS. So test will fail.")]
        public void SetTitle()
        {
            // Arrange
            MainViewModel sot = new MainViewModel();
            string expectedMvxVersion = FindCurrentMvxVersion();

            // Act
            sot.Prepare();

            // Assert
            Assert.Equal(expectedMvxVersion, sot.Title);
            _output.WriteLine($"Title set to current Mvx version: {sot.Title}");



            string FindCurrentMvxVersion()
            {
                string csProj = @"D:\Plugins\MvvmCrossTest\MvvmCrossTest\MvvmCrossTest.Core\MvvmCrossTest.Core.csproj";
                string[] contents = File.ReadAllLines(csProj);
                foreach (var line in contents)
                {
                    if (!line.StartsWith("    <PackageReference Include=\"MvvmCross\"")) continue;

                    int end = line.LastIndexOf('"'),
                        start = line.LastIndexOf('"', end - 1) + 1;
                    return line.Substring(start, end - start);
                }

                return "0.0.0";
            }
        }


        private readonly ITestOutputHelper _output;
    }
}
