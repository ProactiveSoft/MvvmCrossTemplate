using System.IO;
using System.Reflection;
using MvvmCross.Template.Test.Data;
using Xunit;
using Xunit.Abstractions;

namespace MvvmCross.Template.Test
{
    public class BaseFixProjectsShould
    {
        public BaseFixProjectsShould(ITestOutputHelper console) => _console = console;


        [Theory]
        [Trait("File", ".cs")]
        [CSharpFiles]
        public void FixCSharp(string filePath)
        {
            // Arrange
            _console.WriteLine($"Reading {filePath}");

            string contents = File.ReadAllText(filePath);


            // Assert
            Assert.DoesNotContain("MvvmCrossTest", contents);

            _console.WriteLine($"Checked {filePath}");
        }

        [Theory]
        [Trait("File", ".vstemplate")]
        [InlineData(@"D:\Plugins\MvvmCrossTest\Temp\Proso.MvvmCross.Abstraction\MyTemplate.vstemplate", ".Abstraction")]
        [InlineData(@"D:\Plugins\MvvmCrossTest\Temp\Proso.MvvmCross.Core\MyTemplate.vstemplate", ".Core")]
        [InlineData(@"D:\Plugins\MvvmCrossTest\Temp\Proso.MvvmCross.Forms\MyTemplate.vstemplate", ".Forms")]
        [InlineData(@"D:\Plugins\MvvmCrossTest\Temp\Proso.MvvmCross.UWP\MyTemplate.vstemplate", ".UWP")]
        [InlineData(@"D:\Plugins\MvvmCrossTest\Temp\Proso.MvvmCross.Android\MyTemplate.vstemplate", ".Android")]
        [InlineData(@"D:\Plugins\MvvmCrossTest\Temp\Proso.MvvmCross.iOS\MyTemplate.vstemplate", ".iOS")]
        public void ProjectNameFromPath(string path, string expectedProjectName)
        {
            // Arrange
            BaseFixProjects sut = new BaseFixProjects();
            MethodInfo projectNameFromPathInfo = typeof(BaseFixProjects).GetMethod("ProjectNameFromPath",
                BindingFlags.NonPublic | BindingFlags.Instance);

            // Act
            _console.WriteLine($"Getting project name from {path}");

            var actualProjectName = projectNameFromPathInfo.Invoke(sut, new object?[] { path });

            // Assert
            Assert.Equal(expectedProjectName, actualProjectName);

            _console.WriteLine($"Project name: {actualProjectName}");
        }

        [Theory]
        [Trait("File ", ".vstemplate")]
        [VsTemplateFiles]
        public void FixVsTemplate(string path)
        {
            // Arrange
            _console.WriteLine($"Reading {path}");

            string contents = File.ReadAllText(path);

            // Assert
            Assert.Contains("    <Hidden>true</Hidden>", contents);
            Assert.DoesNotContain("TargetFileName=\"MvvmCrossTest", contents);

            _console.WriteLine($"Checked {path}");
        }



        private readonly ITestOutputHelper _console;
    }
}