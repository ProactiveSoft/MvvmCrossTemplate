using System.IO;
using MvvmCross.Template.Test.Data;
using Xunit;
using Xunit.Abstractions;

namespace MvvmCross.Template.Test
{
    public class FixCoreShould
    {
        public FixCoreShould(ITestOutputHelper console) => _console = console;


        [Theory]
        [Trait("File", ".csproj")]
        [CsProjFiles]
        public void FixCsProj(string csprojFile)
        {
            // Arrange
            _console.WriteLine($"Checking .csproj file for MvvmCrossTest: {csprojFile}");

            string contents = File.ReadAllText(csprojFile);

            // Assert
            Assert.DoesNotContain("MvvmCrossTest", contents);

            _console.WriteLine("Checked file.");
        }



        private readonly ITestOutputHelper _console;
    }
}