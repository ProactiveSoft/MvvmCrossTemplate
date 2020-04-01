using System.IO;
using static System.Console;

namespace MvvmCross.Template
{
    class FixAndroidProject : BaseFixPlatformProjects
    {
        public FixAndroidProject()
        {
            _androidFolder = Path.Combine(TemplateFolder, "Proso.MvvmCross.Android");
            _testAndroidFolder = Path.Combine(TemplateFolder, "Proso.MvvmCross.Test.Droid");
        }


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
            FixAndroid();
            FixTest();



            void FixAndroid()
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

            void FixTest()
            {
                string manifest = Path.Combine(_testAndroidFolder, "Properties", "AndroidManifest.xml");
                string contents = File.ReadAllText(manifest);
                WriteLine($"\n{manifest}: Fix package=\"com.companyname.mvvmcrosstest.test.droid\"  -->  package=\"com.proso.$ext_safeprojectname$.test\"");
                contents = contents.Replace("package=\"com.companyname.mvvmcrosstest.test.droid\"",
                    "package=\"com.proso.$ext_safeprojectname$.test\"");
                File.WriteAllText(manifest, contents);

                WriteLine($"{manifest}: Fixed\n");
            }
        }



        private readonly string _androidFolder, _testAndroidFolder;
    }
}