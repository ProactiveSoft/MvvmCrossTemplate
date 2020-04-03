using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace MvvmCross.Template.Test
{
    public class FixPlatformVsTemplateShould
    {
        public FixPlatformVsTemplateShould(ITestOutputHelper output) => _output = output;


        [Theory]
        [Trait("File", ".vstemplate")]
        [InlineData("<ProjectItem ReplaceParameters=\"true\" TargetFileName=\"Package.appxmanifest\"", @"D:\Plugins\MvvmCrossTest\Temp\Proso.MvvmCross.UWP\MyTemplate.vstemplate")]
        [InlineData("<ProjectItem ReplaceParameters=\"true\" TargetFileName=\"Entitlements.plist\"", @"D:\Plugins\MvvmCrossTest\Temp\Proso.MvvmCross.iOS\MyTemplate.vstemplate")]
        [InlineData("<ProjectItem ReplaceParameters=\"true\" TargetFileName=\"Info.plist\"", @"D:\Plugins\MvvmCrossTest\Temp\Proso.MvvmCross.iOS\MyTemplate.vstemplate")]
        [InlineData("<ProjectItem ReplaceParameters=\"true\" TargetFileName=\"LaunchScreen.storyboard\"", @"D:\Plugins\MvvmCrossTest\Temp\Proso.MvvmCross.iOS\MyTemplate.vstemplate")]
        public void MakeManifestReplaceable(string expected, string filePath)
        {
            // Arrange
            _output.WriteLine($"Checking {expected} in {filePath}");

            string contents = File.ReadAllText(filePath);

            // Assert
            Assert.Contains(expected, contents);

            _output.WriteLine($"Checked for ReplaceParameters=\"true\"");
        }


        private readonly ITestOutputHelper _output;
    }
}