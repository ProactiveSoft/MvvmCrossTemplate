namespace MvvmCross.Template.Helpers
{
    public interface IFolderHelper
    {
        /// <summary>Copies the folder.</summary>
        /// <param name="source"> Source folder's path.</param>
        /// <param name="destination"> Destination folder's path (path of parent's folder in destination).</param>
        void CopyFolder(string source, string destination);


        /// <summary>Copies folder's files.
        /// Sub-folders files are not copied.</summary>
        /// <param name="source">  Source folder's path.</param>
        /// <param name="destination"> Destination folder's path.</param>
        void CopyFolderFiles(string source, string destination);
    }
}