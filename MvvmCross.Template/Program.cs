using MvvmCross.Template.Helpers;

namespace MvvmCross.Template
{
    class Program
    {
        static void Main(string[] args)
        {
            // Fix common files
            IFixLibraryProjects fixProjects = new BaseFixProjects();
            fixProjects.FixCSharp();

            // Fix UWP
            IFixPlatformProjects fixPlatformProjects = new FixUwpProject();
            fixPlatformProjects.FixCsProj();
            fixPlatformProjects.FixVsTemplate();
            fixPlatformProjects.CorrectManifest();

            // Fix Android
            fixPlatformProjects = new FixAndroidProject();
            fixPlatformProjects.FixCsProj();
            fixPlatformProjects.CorrectManifest();
            ((FixAndroidProject)fixPlatformProjects).FixOtherFiles();

            // Fix iOS
            IFolderHelper folderHelper = new FolderHelper();
            fixPlatformProjects = new FixIosProject(folderHelper);
            fixPlatformProjects.FixCsProj();
            fixPlatformProjects.FixVsTemplate();
            fixPlatformProjects.CorrectManifest();
            ((FixIosProject)fixPlatformProjects).CopyItems();

            FixTemplateRoot fixTemplateRoot = new FixTemplateRoot(folderHelper);
            fixTemplateRoot.CopyItems();

            IFixMetadata fixMetadata = new FixCore();
            fixMetadata.UpdateVersion();
            fixMetadata = fixTemplateRoot;
            fixMetadata.UpdateVersion();

            fixTemplateRoot.FixDirectoryBuildProps();
        }
    }
}
