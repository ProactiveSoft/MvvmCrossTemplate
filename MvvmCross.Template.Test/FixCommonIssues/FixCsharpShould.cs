using System.IO;
using MvvmCross.Template.Test.Data;
using Xunit;
using Xunit.Abstractions;

namespace MvvmCross.Template.Test.FixCommonIssues
{
    public class FixCsharpShould
    {
        public FixCsharpShould(ITestOutputHelper output) => _output = output;



        #region Fix Usings
        [Theory]
        [Trait("File", ".cs")]
        [CSharpFiles]
        public void RemoveMvvmCrossTestFromUsings(string filePath)
        {
            // Arrange
            _output.WriteLine($"Reading {filePath}");

            string contents = File.ReadAllText(filePath);


            // Assert
            Assert.DoesNotContain("MvvmCrossTest", contents);

            _output.WriteLine($"Checked {filePath}");
        }
        #endregion



        private readonly ITestOutputHelper _output;
    }
}