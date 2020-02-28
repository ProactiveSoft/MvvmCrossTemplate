namespace MvvmCross.Template
{
    class Program
    {
        static void Main(string[] args)
        {
            IFixLibraryProjects fixProjects = new BaseFixProjects();
            fixProjects.FixVsTemplate();
            fixProjects.FixCSharp();

            IFixPlatformProjects fixPlatformProjects = new FixUwpProject();
            fixPlatformProjects.FixCsProj();

            fixPlatformProjects = new FixAndroidProject();
            fixPlatformProjects.FixCsProj();
        }
    }
}
