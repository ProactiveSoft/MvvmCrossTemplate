using System;
using System.Collections.Generic;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace MvvmCross.Template.Test.FixRootIssues
{
    public class FixDirectoryBuildPropsShould
    {
        public FixDirectoryBuildPropsShould(ITestOutputHelper output) => _output = output;



        #region Test Solution Metadata Fixed
        [Fact]
        [Trait("Task", "Fix root")]
        public void FixSolutionMetadata()
        {
            // Arrange
            string directoryBuildProps = Path.Combine(TemplateFolder, "Directory.Build.props");
            string[] contents = File.ReadAllLines(directoryBuildProps);
            HashSet<string> fixedOpeningTags = new HashSet<string>(4)
                {"    <Product>", "    <Description>", "    <!--<PackageProjectUrl>", "    <!--<RepositoryUrl>"};
            int count = 0;
            foreach (var line in contents)
            {
                string currentTag = GetOpeningTag(line);
                if (!fixedOpeningTags.Contains(currentTag)) continue;

                // Assert
                Assert.DoesNotContain("MvvmCross", line, StringComparison.OrdinalIgnoreCase);
                Assert.DoesNotContain("Template", line, StringComparison.OrdinalIgnoreCase);

                if (++count == fixedOpeningTags.Count) break;
            }

            _output.WriteLine("Directory.Build.props fixed.");


            string GetOpeningTag(string sentence)
            {
                int end = sentence.IndexOf('>') + 1;
                return sentence[..end];
            }
        }
        #endregion

        #region Test InternalsVisibleTo Attribute Fixed
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
        #endregion



        private const string TemplateFolder = @"D:\Plugins\MvvmCrossTest\Temp";
        private readonly ITestOutputHelper _output;
    }
}