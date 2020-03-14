using MvvmCross.Template.Helpers;

namespace MvvmCross.Template
{
    class Program
    {
        static void Main(string[] args)
        {
            IFixLibraryProjects fixProjects = new BaseFixProjects();
            fixProjects.FixCSharp();

            IFixPlatformProjects fixPlatformProjects = new FixUwpProject();
            fixPlatformProjects.FixCsProj();
            fixPlatformProjects.FixVsTemplate();

            fixPlatformProjects = new FixAndroidProject();
            fixPlatformProjects.FixCsProj();

            IFolderHelper folderHelper = new FolderHelper();
            fixPlatformProjects = new FixIosProject(folderHelper);
            fixPlatformProjects.FixVsTemplate();
            ((FixIosProject)fixPlatformProjects).CopyItems();

            FixTemplateRoot fixTemplateRoot = new FixTemplateRoot(folderHelper);
            fixTemplateRoot.CopyItems();

            string version = args[0];
            IFixMetadata fixMetadata = new FixCore();
            fixMetadata.UpdateVersion(version);
        }
    }
}
