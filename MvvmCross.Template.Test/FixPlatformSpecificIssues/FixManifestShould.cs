using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace MvvmCross.Template.Test.FixPlatformSpecificIssues
{
    public class FixManifestShould
    {
        public FixManifestShould(ITestOutputHelper output) => _output = output;



        #region Test MvvmCrossTest Not in Manifest
        [Trait("Task", "Fix Manifest")]
        [Theory]
        [InlineData(@"D:\Plugins\MvvmCrossTest\Temp\Proso.MvvmCross.Android\Properties\AndroidManifest.xml")]
        [InlineData(@"D:\Plugins\MvvmCrossTest\Temp\Proso.MvvmCross.Test.Droid\Properties\AndroidManifest.xml")]
        [InlineData(@"D:\Plugins\MvvmCrossTest\Temp\Proso.MvvmCross.UWP\Package.appxmanifest")]
        [InlineData(@"D:\Plugins\MvvmCrossTest\Temp\Proso.MvvmCross.Test.UWP\Package.appxmanifest")]
        [InlineData(@"D:\Plugins\MvvmCrossTest\Temp\Proso.MvvmCross.iOS\Info.plist")]
        [InlineData(@"D:\Plugins\MvvmCrossTest\Temp\Proso.MvvmCross.Test.iOS\Info.plist")]
        public void CheckMvvmCrossTestNotInManifest(string manifest)
        {
            // Arrange
            string contents = File.ReadAllText(manifest),
                expectedValue = "MvvmCrossTest";
            _output.WriteLine($"{manifest}: Checking {expectedValue} is not present ...");

            // Assert
            Assert.DoesNotContain(expectedValue, contents);

            _output.WriteLine("Checked.");
        }
        #endregion



        private readonly ITestOutputHelper _output;
    }
}