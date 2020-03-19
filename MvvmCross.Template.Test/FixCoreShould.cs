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
        public void FixCsProj(string csproj)
        {
            // Arrange
            _output.WriteLine($"Checking {csproj}: for MvvmCrossTest &");
            _output.WriteLine($"\t..\\..\\SharedAssemblyInfo.cs");

            string contents = File.ReadAllText(csproj);

            // Assert
            Assert.DoesNotContain("MvvmCrossTest", contents);
            Assert.Contains("\"..\\SharedAssemblyInfo.cs\"", contents);

            _output.WriteLine("Checked file.");
        }



        private readonly ITestOutputHelper _output;
    }
}