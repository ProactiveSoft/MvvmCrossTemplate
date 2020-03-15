using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace MvvmCross.Template.Test
{
    public class FixMetadataShould
    {
        public FixMetadataShould(ITestOutputHelper output) => _output = output;


        [Fact]
        [Trait("Task ", "Fix root")]
        public void UpdateVersion()
        {
            // Arrange
            // ToDo: Get latest MvvmCross version "expectedVersion" by scraping
            // https://github.com/MvvmCross/MvvmCross/blob/develop/CHANGELOG.md
            string expectedVersion = "6.4.2",
                mainVm = @"D:\Plugins\MvvmCrossTest\Temp\Proso.MvvmCross.Core\ViewModels\MainViewModel.cs",
                vsTemplate = @"D:\Plugins\MvvmCrossTest\Temp\Proso-MvvmCross-Xamarin-Template.vstemplate",
                mainVmVersionLine = string.Empty, vsTemplateVersionLine = string.Empty;

            foreach (var line in File.ReadAllLines(mainVm))
                if (line.StartsWith("            Title ="))
                {
                    mainVmVersionLine = line;
                    break;
                }

            foreach (var line in File.ReadAllLines(vsTemplate))
                if (line.StartsWith("    <Description>"))
                {
                    vsTemplateVersionLine = line;
                    break;
                }

            // Assert
            Assert.Contains(expectedVersion, mainVmVersionLine);
            Assert.Contains(expectedVersion, vsTemplateVersionLine);

            _output.WriteLine($"MvvmCross template updated to version {expectedVersion}.");
        }


        private readonly ITestOutputHelper _output;
    }
}