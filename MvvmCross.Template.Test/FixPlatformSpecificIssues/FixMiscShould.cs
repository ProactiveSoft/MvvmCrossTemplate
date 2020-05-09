using System;
using System.IO;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace MvvmCross.Template.Test.FixPlatformSpecificIssues
{
    public class FixMiscShould
    {
        public FixMiscShould(ITestOutputHelper output) => _output = output;



        #region Test Assets files Present
        [Fact]
        [Trait("Task", "Fix misc")]
        public void CopyIosAssetsFolder()
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
            // Check destination exists
            Assert.True(Directory.Exists(destinationSubFolderProject));
            Assert.True(Directory.Exists(destinationSubFolderTest));
            // Check no.of folders in destination folder
            Assert.Equal(noOfSourceSubFolders, noOfDestinationSubFoldersProject);
            Assert.Equal(noOfSourceSubFolders, noOfDestinationSubFoldersTest);
            // Check random file is present in destination folder
            Assert.Contains(randomSourceFileName, destinationFilesNameProject);
            Assert.Contains(randomSourceFileName, destinationFilesNameTest);

            _output.WriteLine(
                $"Assets folder successfully copied.{Environment.NewLine}Random file {randomSourceFileName} is present in destination folder");
        }
        #endregion



        private readonly ITestOutputHelper _output;
    }
}