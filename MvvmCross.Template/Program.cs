using MvvmCross.Template.Helpers;

namespace MvvmCross.Template
{
    class Program
    {
        private static void Main(string region = null, string session = null, string package = null,
            string project = null, string[] args = null)
        {
            #region Fix common issues
            // Fix common files
            IFixLibraryProjects fixProjects = new BaseFixProjects();
            fixProjects.FixCSharp();
            #endregion


            #region Fix UWP
            // Fix UWP
            IFixPlatformProjects fixPlatformProjects = new FixUwpProject();
            fixPlatformProjects.FixCsProj();
            fixPlatformProjects.FixVsTemplate();
            fixPlatformProjects.CorrectManifest();
            #endregion


            #region Fix Android
            // Fix Android
            fixPlatformProjects = new FixAndroidProject();
            fixPlatformProjects.FixCsProj();
            fixPlatformProjects.CorrectManifest();
            ((FixAndroidProject)fixPlatformProjects).FixOtherFiles();
            #endregion


            #region Fix iOS
            // Fix iOS
            IFolderHelper folderHelper = new FolderHelper();
            fixPlatformProjects = new FixIosProject(folderHelper);
            fixPlatformProjects.FixCsProj();
            fixPlatformProjects.FixVsTemplate();
            fixPlatformProjects.CorrectManifest();
            ((FixIosProject)fixPlatformProjects).CopyItems();
            #endregion


            #region Fix Root
            // Fix template root & metadata
            FixTemplateRoot fixTemplateRoot = new FixTemplateRoot(folderHelper);
            fixTemplateRoot.CopyItems();

            IFixMetadata fixMetadata = new FixCore();
            fixMetadata.UpdateVersion();
            fixMetadata = fixTemplateRoot;
            fixMetadata.UpdateVersion();

            fixTemplateRoot.FixDirectoryBuildProps();
            #endregion
        }
    }
}