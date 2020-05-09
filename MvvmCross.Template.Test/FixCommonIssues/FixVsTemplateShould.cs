using System.IO;
using MvvmCross.Template.Test.Data;
using MvvmCross.Template.Test.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace MvvmCross.Template.Test.FixCommonIssues
{
    public class FixVsTemplateShould
    {
        public FixVsTemplateShould(ITestOutputHelper output)
        {
            _output = output;
            _usingReflection = new UsingReflection(_output);
        }



        #region Test Project Name from Path
        [Theory]
        [Trait("File", ".vstemplate")]
        [InlineData(@"D:\Plugins\MvvmCrossTest\Temp\Proso.MvvmCross.Abstraction\MyTemplate.vstemplate", "Abstraction")]
        [InlineData(@"D:\Plugins\MvvmCrossTest\Temp\Proso.MvvmCross.Core\MyTemplate.vstemplate", "Core")]
        [InlineData(@"D:\Plugins\MvvmCrossTest\Temp\Proso.MvvmCross.Forms\MyTemplate.vstemplate", "Forms")]
        [InlineData(@"D:\Plugins\MvvmCrossTest\Temp\Proso.MvvmCross.UWP\MyTemplate.vstemplate", "UWP")]
        [InlineData(@"D:\Plugins\MvvmCrossTest\Temp\Proso.MvvmCross.Android\MyTemplate.vstemplate", "Android")]
        [InlineData(@"D:\Plugins\MvvmCrossTest\Temp\Proso.MvvmCross.iOS\MyTemplate.vstemplate", "iOS")]
        public void GetProjectNameFromPath(string path, string expectedProjectName)
        {
            // Arrange
            BaseFixProjects sut = new BaseFixProjects();

            // Act
            string actualProjectName =
                _usingReflection.CallPrivateMethod<BaseFixProjects, string>(sut, "ProjectNameFromPath",
                    new object[] { path });

            // Assert
            Assert.Equal(expectedProjectName, actualProjectName);

            _output.WriteLine($"Got project name: {actualProjectName} from path: {path}.");
        }
        #endregion

        #region Test Add Description
        [Theory]
        [Trait("File", ".vstemplate")]
        [VsTemplateFiles]
        public void AddDescriptionInVsTemplate(string path)
        {
            // Arrange
            string contents = File.ReadAllText(path);

            // Act
            Assert.DoesNotContain("<Description>Template's description.", contents);

            _output.WriteLine($"{path}: Added description.");
        }
        #endregion

        #region Test Make Hidden & Remove MvvmCrossTest
        [Theory]
        [Trait("File", ".vstemplate")]
        [VsTemplateFiles]
        public void MakeHiddenAndRemoveMvvmCrossTest(string path)
        {
            // Arrange
            string contents = File.ReadAllText(path);

            // Assert
            Assert.Contains("    <Hidden>true</Hidden>", contents);
            Assert.DoesNotContain("TargetFileName=\"MvvmCrossTest", contents);

            _output.WriteLine($"{path}: Checked.");
        }
        #endregion



        private readonly ITestOutputHelper _output;
        private readonly UsingReflection _usingReflection;
    }
}