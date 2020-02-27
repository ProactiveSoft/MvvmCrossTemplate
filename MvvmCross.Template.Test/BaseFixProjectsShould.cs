using System.IO;
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



        private readonly ITestOutputHelper _console;
    }
}