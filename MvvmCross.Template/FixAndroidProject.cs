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
            string manifest = Path.Combine(_androidFolder, "Properties", "AndroidManifest.xml");
            string contents = File.ReadAllText(manifest);
            WriteLine(
                $"\n{manifest}:Fixing package=\"com.companyname.MvvmCrossTest\"  -->  package=\"com.proso.$ext_safeprojectname$\"");
            WriteLine($"{manifest}: Fixing android:label=\"$safeprojectname$\"  -->  android:label=\"$ext_safeprojectname$\"");

            contents = contents.Replace("package=\"com.companyname.MvvmCrossTest\"",
                    "package=\"com.proso.$ext_safeprojectname$\"")
                .Replace("android:label=\"$safeprojectname$\"", "android:label=\"$ext_safeprojectname$\"");
            File.WriteAllText(manifest, contents);

            WriteLine($"{manifest}: Fixed\n");
        }



        private readonly string _androidFolder;
    }
}