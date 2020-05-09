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
                destinationProject = @"D:\Plugins\MvvmCrossTest\Temp\Proso.MvvmCross.iOS\Assets.xcassets",
                destinationTest = @"D:\Plugins\MvvmCrossTest\Temp\Proso.MvvmCross.Test.iOS\Assets.xcassets",
                sourceSubFolder = Path.Combine(source, "AppIcon.appiconset"),
                destinationSubFolderProject = Path.Combine(destinationProject, "AppIcon.appiconset"),
                destinationSubFolderTest = Path.Combine(destinationTest, "AppIcon.appiconset");

            int noOfSourceSubFolders = Directory.GetDirectories(source).Length,
                noOfDestinationSubFoldersProject = Directory.GetDirectories(destinationProject).Length,
                noOfDestinationSubFoldersTest = Directory.GetDirectories(destinationTest).Length;

            string[] sourceFiles = Directory.GetFiles(sourceSubFolder),
                destinationFilesProject = Directory.GetFiles(destinationSubFolderProject),
                destinationFilesTest = Directory.GetFiles(destinationSubFolderTest),
                destinationFilesNameProject = destinationFilesProject.Select(Path.GetFileName).ToArray()!,
                destinationFilesNameTest = destinationFilesTest.Select(Path.GetFileName).ToArray()!;

            Random random = new Random();
            int index = random.Next(0, sourceFiles.Length);

            string randomSourceFileName = Path.GetFileName(sourceFiles[index]);

            // Assert
            Assert.True(Directory.Exists(destinationSubFolderProject));
            Assert.True(Directory.Exists(destinationSubFolderTest));
            Assert.Equal(noOfSourceSubFolders, noOfDestinationSubFoldersProject);
            Assert.Equal(noOfSourceSubFolders, noOfDestinationSubFoldersTest);
            Assert.Contains(randomSourceFileName, destinationFilesNameProject);
            Assert.Contains(randomSourceFileName, destinationFilesNameTest);

            _output.WriteLine(
                $"Assets folder successfully copied.{Environment.NewLine}Random file {randomSourceFileName} is present in destination folder");
        }



        private readonly ITestOutputHelper _output;
    }
}