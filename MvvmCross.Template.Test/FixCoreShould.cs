using System.IO;
using MvvmCross.Template.Test.Data;
using Xunit;
using Xunit.Abstractions;

namespace MvvmCross.Template.Test
{
    public class FixCoreShould
    {
        public FixCoreShould(ITestOutputHelper output) => _output = output;


        [Theory]
        [Trait("File", ".csproj")]
        [CsProjFiles]
        public void FixCsProj(string csprojFile)
        {
            // Arrange
            _output.WriteLine($"Checking .csproj file for MvvmCrossTest: {csprojFile}");

            string contents = File.ReadAllText(csprojFile);

            // Assert
            Assert.DoesNotContain("MvvmCrossTest", contents);

            _output.WriteLine("Checked file.");
        }



        private readonly ITestOutputHelper _output;
    }
}