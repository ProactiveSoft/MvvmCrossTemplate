using System;
using System.IO;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace MvvmCross.Template.Test
{
    public class FixIosProjectShould
    {
        public FixIosProjectShould(ITestOutputHelper output) => _output = output;


        [Fact]
        [Trait("Task", "Fix root")]
        public void CopyAssetsFolder()
        {
            // Arrange
            string source = @"D:\Plugins\MvvmCrossTest\MvvmCrossTest\MvvmCrossTest.iOS\Assets.xcassets",
                destination = @"D:\Plugins\MvvmCrossTest\Temp\Proso.MvvmCross.iOS\Assets.xcassets",
                sourceSubFolder = Path.Combine(source, "AppIcon.appiconset"),
                destinationSubFolder = Path.Combine(destination, "AppIcon.appiconset");

            int noOfSourceSubFolders = Directory.GetDirectories(source).Length,
                noOfDestinationSubFolders = Directory.GetDirectories(destination).Length;

            string[] sourceFiles = Directory.GetFiles(sourceSubFolder),
                destinationFiles = Directory.GetFiles(destinationSubFolder),
                destinationFilesName = destinationFiles.Select(Path.GetFileName).ToArray()!;

            Random random = new Random();
            int index = random.Next(0, sourceFiles.Length);

            string randomSourceFileName = Path.GetFileName(sourceFiles[index]);

            // Assert
            Assert.True(Directory.Exists(destination));
            Assert.True(Directory.Exists(destinationSubFolder));
            Assert.Equal(noOfSourceSubFolders, noOfDestinationSubFolders);
            Assert.Contains(randomSourceFileName, destinationFilesName);
            _output.WriteLine(
                $"Assets folder successfully copied.{Environment.NewLine}Random file {randomSourceFileName} is present in destination folder");
        }

        [Fact]
        [Trait("File", ".vstemplate")]
        public void IncludeAssetsInVsTemplate()
        {
            // Arrange
            string vsTemplate =
                File.ReadAllText(@"D:\Plugins\MvvmCrossTest\Temp\Proso.MvvmCross.iOS\MyTemplate.vstemplate");
            string assets =
                @"      <Folder Name=""Assets.xcassets\AppIcon.appiconset"" TargetFolderName=""Assets.xcassets\AppIcon.appiconset"">
        <ProjectItem TargetFileName=""Contents.json"" ReplaceParameters=""true"">Contents.json</ProjectItem>
        <ProjectItem TargetFileName=""Icon20.png"" ReplaceParameters=""false"">Icon20.png</ProjectItem>
        <ProjectItem TargetFileName=""Icon29.png"" ReplaceParameters=""false"">Icon29.png</ProjectItem>
        <ProjectItem TargetFileName=""Icon40.png"" ReplaceParameters=""false"">Icon40.png</ProjectItem>
        <ProjectItem TargetFileName=""Icon58.png"" ReplaceParameters=""false"">Icon58.png</ProjectItem>
        <ProjectItem TargetFileName=""Icon60.png"" ReplaceParameters=""false"">Icon60.png</ProjectItem>
        <ProjectItem TargetFileName=""Icon76.png"" ReplaceParameters=""false"">Icon76.png</ProjectItem>
        <ProjectItem TargetFileName=""Icon80.png"" ReplaceParameters=""false"">Icon80.png</ProjectItem>
        <ProjectItem TargetFileName=""Icon87.png"" ReplaceParameters=""false"">Icon87.png</ProjectItem>
        <ProjectItem TargetFileName=""Icon120.png"" ReplaceParameters=""false"">Icon120.png</ProjectItem>
        <ProjectItem TargetFileName=""Icon152.png"" ReplaceParameters=""false"">Icon152.png</ProjectItem>
        <ProjectItem TargetFileName=""Icon167.png"" ReplaceParameters=""false"">Icon167.png</ProjectItem>
        <ProjectItem TargetFileName=""Icon180.png"" ReplaceParameters=""false"">Icon180.png</ProjectItem>
        <ProjectItem TargetFileName=""Icon1024.png"" ReplaceParameters=""false"">Icon1024.png</ProjectItem>
      </Folder>";

            // Assert
            Assert.Contains(assets, vsTemplate);
            _output.WriteLine("Assets included in iOS's .vstemplate.");
        }


        private readonly ITestOutputHelper _output;
    }
}