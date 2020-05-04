using System.IO;
using MvvmCross.Template.Test.Data;
using MvvmCross.Template.Test.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace MvvmCross.Template.Test
{
    public class BaseFixProjectsShould
    {
        public BaseFixProjectsShould(ITestOutputHelper output)
        {
            _output = output;
            _usingReflection = new UsingReflection(_output);
        }


        #region Fix Usings
        [Theory]
        [Trait("File", ".cs")]
        [CSharpFiles]
        public void FixCSharp(string filePath)
        {
            // Arrange
            _output.WriteLine($"Reading {filePath}");

            string contents = File.ReadAllText(filePath);


            // Assert
            Assert.DoesNotContain("MvvmCrossTest", contents);

            _output.WriteLine($"Checked {filePath}");
        } 
        #endregion

        [Theory]
        [Trait("File", ".vstemplate")]
        [InlineData(@"D:\Plugins\MvvmCrossTest\Temp\Proso.MvvmCross.Abstraction\MyTemplate.vstemplate", "Abstraction")]
        [InlineData(@"D:\Plugins\MvvmCrossTest\Temp\Proso.MvvmCross.Core\MyTemplate.vstemplate", "Core")]
        [InlineData(@"D:\Plugins\MvvmCrossTest\Temp\Proso.MvvmCross.Forms\MyTemplate.vstemplate", "Forms")]
        [InlineData(@"D:\Plugins\MvvmCrossTest\Temp\Proso.MvvmCross.UWP\MyTemplate.vstemplate", "UWP")]
        [InlineData(@"D:\Plugins\MvvmCrossTest\Temp\Proso.MvvmCross.Android\MyTemplate.vstemplate", "Android")]
        [InlineData(@"D:\Plugins\MvvmCrossTest\Temp\Proso.MvvmCross.iOS\MyTemplate.vstemplate", "iOS")]
        public void ProjectNameFromPath(string path, string expectedProjectName)
        {
            // Arrange
            BaseFixProjects sut = new BaseFixProjects();

            // Act
            _output.WriteLine($"Getting project name from {path}");

            string actualProjectName =
                _usingReflection.CallPrivateMethod<BaseFixProjects, string>(sut, "ProjectNameFromPath",
                    new object[] { path });

            // Assert
            Assert.Equal(expectedProjectName, actualProjectName);

            _output.WriteLine($"Project name: {actualProjectName}");
        }

        [Theory]
        [Trait("File", ".vstemplate")]
        [VsTemplateFiles]
        public void HiddenAndRemoveMvvmCrossTest(string path)
        {
            // Arrange
            _output.WriteLine($"Reading {path}");

            string contents = File.ReadAllText(path);

            // Assert
            Assert.Contains("    <Hidden>true</Hidden>", contents);
            Assert.DoesNotContain("TargetFileName=\"MvvmCrossTest", contents);

            _output.WriteLine($"Checked {path}");
        }



        private readonly ITestOutputHelper _output;
        private readonly UsingReflection _usingReflection;
    }
}