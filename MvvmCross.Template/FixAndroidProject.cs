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


        /// <summary>
        /// Fixes Android.csproj: AssemblyName.
        /// </summary>
        /// <inheritdoc />
        public override void FixCsProj()
        {
            #region Fix AssemblyName
            string csproj = Path.Combine(_androidFolder, "MvvmCrossTest.Android.csproj");
            WriteLine($"{csproj}: Fixing <AssemblyName>MvvmCrossTest.Android  -->  <AssemblyName>$safeprojectname$");

            string contents = File.ReadAllText(csproj);
            contents = contents.Replace("<AssemblyName>MvvmCrossTest.Android", "<AssemblyName>$safeprojectname$");
            File.WriteAllText(csproj, contents);

            WriteLine("Fixed.\n");
            #endregion
        }

        /// <summary>
        /// Correct Android's manifest.
        /// </summary>
        /// <inheritdoc />
        public override void CorrectManifest()
        {
            FixAndroid();
            FixTest();



            #region Fix Android Manifest
            void FixAndroid()
            {
                string manifest = Path.Combine(_androidFolder, "Properties", "AndroidManifest.xml");
                string contents = File.ReadAllText(manifest);
                WriteLine(
                    $"\n{manifest}: Fixing package=\"com.companyname.MvvmCrossTest\"  -->  package=\"com.$ext_safeprojectname$\"");
                WriteLine($"{manifest}: Fixing android:label=\"$safeprojectname$\"  -->  android:label=\"$ext_safeprojectname$\"");

                contents = contents.Replace("package=\"com.companyname.MvvmCrossTest\"",
                        "package=\"com.$ext_safeprojectname$\"")
                    .Replace("android:label=\"$safeprojectname$\"", "android:label=\"$ext_safeprojectname$\"");
                File.WriteAllText(manifest, contents);

                WriteLine("Fixed\n");
            }
            #endregion

            #region Fix Test.Android Manifest
            void FixTest()
            {
                string manifest = Path.Combine(_testAndroidFolder, "Properties", "AndroidManifest.xml");
                string contents = File.ReadAllText(manifest);
                WriteLine($"\n{manifest}: Fix package=\"com.companyname.mvvmcrosstest.test.droid\"  -->  package=\"com.$ext_safeprojectname$.test\"");

                contents = contents.Replace("package=\"com.companyname.mvvmcrosstest.test.droid\"",
                    "package=\"com.$ext_safeprojectname$.test\"");
                File.WriteAllText(manifest, contents);

                WriteLine("Fixed\n");
            }
            #endregion
        }

        /// <summary>
        ///   <para>Fixes other files:</para>
        ///   <list type="bullet">
        ///     <item>strings.xml</item>
        ///   </list>
        /// </summary>
        public void FixOtherFiles()
        {
            #region Fix strings.xml
            // Fix strings.xml
            string strings = Path.Combine(_testAndroidFolder, "Resources", "values", "strings.xml"),
                contents = File.ReadAllText(strings);

            WriteLine(
                $"\n{strings}: Fixing <string name=\"app_name\">$safeprojectname$  -->  <string name=\"app_name\">$ext_safeprojectname$.Test");

            contents = contents.Replace("<string name=\"app_name\">$safeprojectname$",
                "<string name=\"app_name\">$ext_safeprojectname$.Test");
            File.WriteAllText(strings, contents);

            WriteLine("Fixed.\n");
            #endregion
        }



        private readonly string _androidFolder, _testAndroidFolder;
    }
}