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

            fixPlatformProjects = new FixIosProject(new FolderHelper());
            fixPlatformProjects.FixVsTemplate();
            ((FixIosProject)fixPlatformProjects).CopyItems();
        }
    }
}
