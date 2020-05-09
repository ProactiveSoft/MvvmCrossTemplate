using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace MvvmCross.Template.Test.FixPlatformSpecificIssues
{
    public class FixVsTemplateShould
    {
        public FixVsTemplateShould(ITestOutputHelper output) => _output = output;



        #region Test Manifest Replaceable
        [Trait("File", ".vstemplate")]
        [Theory]
        [InlineData("<ProjectItem ReplaceParameters=\"true\" TargetFileName=\"Package.appxmanifest\"", @"D:\Plugins\MvvmCrossTest\Temp\Proso.MvvmCross.UWP\MyTemplate.vstemplate")]
        [InlineData("<ProjectItem ReplaceParameters=\"true\" TargetFileName=\"Package.appxmanifest\"", @"D:\Plugins\MvvmCrossTest\Temp\Proso.MvvmCross.Test.UWP\MyTemplate.vstemplate")]
        [InlineData("<ProjectItem ReplaceParameters=\"true\" TargetFileName=\"Entitlements.plist\"", @"D:\Plugins\MvvmCrossTest\Temp\Proso.MvvmCross.iOS\MyTemplate.vstemplate")]
        [InlineData("<ProjectItem ReplaceParameters=\"true\" TargetFileName=\"Entitlements.plist\"", @"D:\Plugins\MvvmCrossTest\Temp\Proso.MvvmCross.Test.iOS\MyTemplate.vstemplate")]
        [InlineData("<ProjectItem ReplaceParameters=\"true\" TargetFileName=\"Info.plist\"", @"D:\Plugins\MvvmCrossTest\Temp\Proso.MvvmCross.iOS\MyTemplate.vstemplate")]
        [InlineData("<ProjectItem ReplaceParameters=\"true\" TargetFileName=\"Info.plist\"", @"D:\Plugins\MvvmCrossTest\Temp\Proso.MvvmCross.Test.iOS\MyTemplate.vstemplate")]
        [InlineData("<ProjectItem ReplaceParameters=\"true\" TargetFileName=\"LaunchScreen.storyboard\"", @"D:\Plugins\MvvmCrossTest\Temp\Proso.MvvmCross.iOS\MyTemplate.vstemplate")]
        public void MakeManifestReplaceable(string expected, string filePath)
        {
            // Arrange
            _output.WriteLine($"Checking {expected} in {filePath}");

            string contents = File.ReadAllText(filePath);

            // Assert
            Assert.Contains(expected, contents);

            _output.WriteLine("Checked.");
        }
        #endregion

        #region Test Assets are Added
        [Trait("File", ".vstemplate")]
        [Theory]
        [InlineData(@"D:\Plugins\MvvmCrossTest\Temp\Proso.MvvmCross.iOS\MyTemplate.vstemplate")]
        [InlineData(@"D:\Plugins\MvvmCrossTest\Temp\Proso.MvvmCross.Test.iOS\MyTemplate.vstemplate")]
        public void AddIosAssets(string path)
        {
            // Arrange
            _output.WriteLine($"{path}: Checking for assets ...");
            string expected = @"      <Folder Name=""Assets.xcassets"" TargetFolderName=""Assets.xcassets"">
        <Folder Name=""AppIcon.appiconset"" TargetFolderName=""AppIcon.appiconset"">",
                contents = File.ReadAllText(path);

            // Assert
            Assert.Contains(expected, contents);

            _output.WriteLine("Checked.");
        }
        #endregion



        private readonly ITestOutputHelper _output;
    }
}