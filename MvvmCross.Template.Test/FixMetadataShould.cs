using System;
using System.Collections.Generic;
using System.IO;
using MvvmCross.Template.Helpers;
using MvvmCross.Template.Test.Data;
using Xunit;
using Xunit.Abstractions;

namespace MvvmCross.Template.Test
{
    public class FixMetadataShould
    {
        public FixMetadataShould(ITestOutputHelper output) => _output = output;



        [Fact]
        [Trait("Task", "Fix root")]
        public void FixSolutionMetadata()
        {
            // Arrange
            string directoryBuildProps = Path.Combine(TemplateFolder, "Directory.Build.props");
            string[] contents = File.ReadAllLines(directoryBuildProps);
            HashSet<string> starts = new HashSet<string>(4)
                {"    <Product>", "    <Description>", "    <!--<PackageProjectUrl>", "    <!--<RepositoryUrl>"};
            int count = 0;
            foreach (var line in contents)
            {
                string starting = FindStart(line);
                if (!starts.Contains(starting)) continue;

                // Assert
                Assert.DoesNotContain("MvvmCross", line, StringComparison.OrdinalIgnoreCase);
                Assert.DoesNotContain("Template", line, StringComparison.OrdinalIgnoreCase);

                if (++count == starts.Count) break;
            }

            _output.WriteLine("Directory.Build.props fixed.");


            string FindStart(string sentence)
            {
                int end = sentence.IndexOf('>') + 1;
                return sentence[..end];
            }
        }

        [Fact]
        [Trait("Task", "Fix root")]
        public void AddInternalsVisibleTo()
        {
            // Arrange
            string directoryBuildProps = Path.Combine(TemplateFolder, "Directory.Build.props"),
                contents = File.ReadAllText(directoryBuildProps),
                expectedSubstring = @"    <!-- <AssemblyAttribute Include=""System.Runtime.CompilerServices.InternalsVisibleTo"">
      <_Parameter1>Proso..Test.Core</_Parameter1>
    </AssemblyAttribute>";

            // Assert
            Assert.Contains(expectedSubstring, contents);

            _output.WriteLine($"{directoryBuildProps}: InternalsVisibleTo found.");
        }



        private const string TemplateFolder = @"D:\Plugins\MvvmCrossTest\Temp";
        private readonly ITestOutputHelper _output;
    }
}