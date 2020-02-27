namespace MvvmCross.Template
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseFixProjects fixProjects = new BaseFixProjects();
            fixProjects.FixVsTemplate();

            FixCore fixCore = new FixCore();
            fixCore.FixCSharp();

            FixUwpProject fixUwp = new FixUwpProject();
            fixUwp.FixCsProj();

            FixAndroidProject fixAndroid = new FixAndroidProject();
            fixAndroid.FixCsProj();
        }
    }
}
