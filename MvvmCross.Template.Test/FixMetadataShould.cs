using System;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace MvvmCross.Template.Test
{
    public class FixMetadataShould
    {
        public FixMetadataShould(ITestOutputHelper output) => _output = output;


        [Fact]
        [Trait("Task", "Fix root")]
        public void UpdateVersion()
        {
            // Arrange
            // ToDo: Get latest MvvmCross version "expectedVersion" by scraping
            // https://github.com/MvvmCross/MvvmCross/blob/develop/CHANGELOG.md
            string expectedVersion = "6.4.2",
                mainVm = Path.Combine(TemplateFolder, "Proso.MvvmCross.Core", "ViewModels", "MainViewModel.cs"),
                vsTemplate = Path.Combine(TemplateFolder, "Proso-MvvmCross-Xamarin-Template.vstemplate"),
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

        [Fact]
        [Trait("Task", "Fix root")]
        public void AddCopyright()
        {
            // Arrange
            string assemblyInfo = Path.Combine(TemplateFolder, "SharedAssemblyInfo.cs"),
                expectedCopyright = $"© Proso {DateTime.Today.Year}",
                actualCopyright = string.Empty;
            foreach (var line in File.ReadAllLines(assemblyInfo))
                if (line.StartsWith("[assembly: AssemblyCopyright("))
                {
                    actualCopyright = line;
                    break;
                }

            // Assert
            Assert.Contains(expectedCopyright, actualCopyright);

            _output.WriteLine($"Added copyright: {expectedCopyright}");
        }


        private const string TemplateFolder = @"D:\Plugins\MvvmCrossTest\Temp";
        private readonly ITestOutputHelper _output;
    }
}