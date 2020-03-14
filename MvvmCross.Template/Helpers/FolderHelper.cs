using System.IO;

namespace MvvmCross.Template.Helpers
{
    class FolderHelper : IFolderHelper
    {
        /// <inheritdoc />
        public void NaiveCopyFolder(string source, string destination)
        {
            // Check directory exists
            string sourceFolderName = new DirectoryInfo(source).Name;
            destination = Path.Combine(destination, sourceFolderName);
            if (!Directory.Exists(destination)) Directory.CreateDirectory(destination);

            string[] files = Directory.GetFiles(source);
            if (files.Length != 0)
                foreach (var file in files)   // Copy all files
                {
                    string fileName = Path.GetFileName(file);
                    string destFileName = Path.Combine(destination, fileName);
                    File.Copy(file, destFileName);
                }

            string[] subFolders = Directory.GetDirectories(source);
            if (subFolders.Length == 0) return;   // Stop condition

            // Copy sub-folders
            foreach (var subFolder in subFolders) NaiveCopyFolder(subFolder, destination);
        }

        /// <inheritdoc />
        public void CopyFolderFiles(string source, string destination)
        {
            string[] sourceFiles = Directory.GetFiles(source);

            foreach (var sourceFile in sourceFiles)
            {
                string fileName = Path.GetFileName(sourceFile),
                    destFileName = Path.Combine(destination, fileName);
                File.Copy(sourceFile, destFileName);
            }
        }
    }
}