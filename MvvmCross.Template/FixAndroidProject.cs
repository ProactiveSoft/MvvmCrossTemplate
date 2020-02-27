using System.IO;
using static System.Console;

namespace MvvmCross.Template
{
    class FixAndroidProject : BaseFixPlatformProjects
    {
        public FixAndroidProject() => _androidFolder = Path.Combine(TemplateFolder, "Proso.MvvmCross.Android");


        /// <inheritdoc />
        public override void FixCsProj()
        {
            string csproj = Path.Combine(_androidFolder, "MvvmCrossTest.Android.csproj");
            WriteLine($"Fixing <AssemblyName>MvvmCrossTest.Android  -->  <AssemblyName>$safeprojectname$: {csproj}");

            string contents = File.ReadAllText(csproj);
            contents = contents.Replace("<AssemblyName>MvvmCrossTest.Android", "<AssemblyName>$safeprojectname$");
            File.WriteAllText(csproj, contents);

            WriteLine("Fixed: <AssemblyName>MvvmCrossTest.Android  -->  <AssemblyName>$safeprojectname$");
        }

        /// <inheritdoc />
        public override void CorrectManifest()
        {
            throw new System.NotImplementedException();
        }



        private readonly string _androidFolder;
    }
}