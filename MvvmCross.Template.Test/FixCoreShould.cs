using System.IO;
using MvvmCross.Template.Test.Data;
using Xunit;
using Xunit.Abstractions;

namespace MvvmCross.Template.Test
{
    public class FixCoreShould
    {
        public FixCoreShould(ITestOutputHelper output) => _output = output;


        #region Test Fixes for Common Issues in .csproj
        [Theory]
        [Trait("File", ".csproj")]
        [CsProjFiles]
        public void FixCsProj(string csproj)
        {
            // Arrange
            _output.WriteLine($"{csproj}: Checking for MvvmCrossTest &");
            _output.WriteLine("\t..\\..\\SharedAssemblyInfo.cs");

            string contents = File.ReadAllText(csproj);

            // Assert
            Assert.DoesNotContain("MvvmCrossTest", contents);
            Assert.Contains("\"..\\SharedAssemblyInfo.cs\"", contents);

            _output.WriteLine("Checked.");
        }
        #endregion



        private readonly ITestOutputHelper _output;
    }
}