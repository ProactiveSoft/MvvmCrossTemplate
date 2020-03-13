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
        [Trait("Task", "Copy Folder")]
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


        private readonly ITestOutputHelper _output;
    }
}