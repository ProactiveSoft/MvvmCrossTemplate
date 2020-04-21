using System.IO;
using static System.Console;

namespace MvvmCross.Template
{
    class FixUwpProject : BaseFixPlatformProjects
    {
        public FixUwpProject()
        {
            _uwpFolder = Path.Combine(TemplateFolder, "Proso.MvvmCross.UWP");
            _testUwpFolder = Path.Combine(TemplateFolder, "Proso.MvvmCross.Test.UWP");
        }


        #region Replace MvvmCrossTest
        /// <summary>
        /// Replaces name of PackageCertificateKeyFile:  MvvmCrossTest  --&gt; $safeprojectname$.
        /// </summary>
        /// <inheritdoc />
        public override void FixCsProj()
        {
            // Not all MvvmCrossTest is replaced w/ $ext_safeprojectname$ because
            // at some places $safeprojectname$ will be used.
            base.FixCsProj();   // Fixes "<Name>MvvmCrossTest"

            string csproj = Path.Combine(_uwpFolder, "MvvmCrossTest.UWP.csproj");
            WriteLine(
                $"{csproj}: Fixing <PackageCertificateKeyFile>MvvmCrossTest.UWP  -->  <PackageCertificateKeyFile>$safeprojectname$");

            string contents = File.ReadAllText(csproj);
            contents = contents.Replace("<PackageCertificateKeyFile>MvvmCrossTest.UWP",
                "<PackageCertificateKeyFile>$safeprojectname$");
            File.WriteAllText(csproj, contents);

            WriteLine("Fixed.\n");
        }
        #endregion


        /// <summary>UWP: Makes Package.appxmanifest file's value replaceable.</summary>
        /// <inheritdoc />
        public override void FixVsTemplate()
        {
            FixUwp();
            FixTest();



            void FixUwp()   // Fix UWP's .vstemplate
            {
                #region Make UWP Package.appxmanifest replaceable
                // Adds description
                // Make sub-projects hidden
                // Replaces MvvmCrossTest in TargetFileName
                base.FixVsTemplate();

                string vsTemplate = Path.Combine(_uwpFolder, "MyTemplate.vstemplate");
                WriteLine(
                    $"\n{vsTemplate}: Fixing <ProjectItem ReplaceParameters=\"false\" TargetFileName=\"Package.appxmanifest\"  -->  <ProjectItem ReplaceParameters=\"true\" TargetFileName=\"Package.appxmanifest\"");

                string contents = File.ReadAllText(vsTemplate);
                contents = contents.Replace(
                    "      <ProjectItem ReplaceParameters=\"false\" TargetFileName=\"Package.appxmanifest\"",
                    "      <ProjectItem ReplaceParameters=\"true\" TargetFileName=\"Package.appxmanifest\"");
                File.WriteAllText(vsTemplate, contents);

                WriteLine("Fixed.\n");
                #endregion
            }

            void FixTest()   // Fix Test.UWP's .vstemplate
            {
                #region Make Test.UWP Package.appxmanifest replaceable
                string vsTemplate = Path.Combine(_testUwpFolder, "MyTemplate.vstemplate");
                WriteLine(
                    $"\n{vsTemplate}: Fixing <ProjectItem ReplaceParameters=\"false\" TargetFileName=\"Package.appxmanifest\"  -->  <ProjectItem ReplaceParameters=\"true\" TargetFileName=\"Package.appxmanifest\"");

                string contents = File.ReadAllText(vsTemplate);
                contents = contents.Replace(
                    "      <ProjectItem ReplaceParameters=\"false\" TargetFileName=\"Package.appxmanifest\"",
                    "      <ProjectItem ReplaceParameters=\"true\" TargetFileName=\"Package.appxmanifest\"");
                File.WriteAllText(vsTemplate, contents);

                WriteLine("Fixed.\n");
                #endregion
            }
        }

        /// <inheritdoc />
        public override void CorrectManifest()
        {
            FixUwp();
            FixTest();



            void FixUwp()
            {
                string manifest = Path.Combine(_uwpFolder, "Package.appxmanifest");
                string contents = File.ReadAllText(manifest);

                WriteLine($"\n{manifest}: Fixing <DisplayName>MvvmCrossTest.UWP  -->  <DisplayName>$ext_safeprojectname$");
                WriteLine($"{manifest}: Fixing EntryPoint=\"MvvmCrossTest.UWP.App\"  -->  EntryPoint=\"$safeprojectname$.App\"");
                WriteLine($"{manifest}: Fixing DisplayName=\"MvvmCrossTest.UWP\"  -->  DisplayName=\"$ext_safeprojectname$\"");
                WriteLine(
                    $"{manifest}: Fixing Description=\"MvvmCrossTest.UWP\"  -->  Description=\"$ext_safeprojectname$ UWP app.\"");

                contents = contents.Replace("<DisplayName>MvvmCrossTest.UWP", "<DisplayName>$ext_safeprojectname$")
                    .Replace("EntryPoint=\"MvvmCrossTest.UWP.App\"", "EntryPoint=\"$safeprojectname$.App\"")
                    .Replace("DisplayName=\"MvvmCrossTest.UWP\"", "DisplayName=\"$ext_safeprojectname$\"")
                    .Replace("Description=\"MvvmCrossTest.UWP\"", "Description=\"$ext_safeprojectname$ UWP app.\"");

                File.WriteAllText(manifest, contents);

                WriteLine($"{manifest}: Fixed.\n");
            }

            void FixTest()
            {
                string manifest = Path.Combine(_testUwpFolder, "Package.appxmanifest");
                string contents = File.ReadAllText(manifest);

                WriteLine($"\n{manifest}: Fixing:" +
                          "\n\t<DisplayName>MvvmCrossTest.Test.UWP  -->  <DisplayName>$ext_safeprojectname$.Test" +
                          "\n\tEntryPoint=\"MvvmCrossTest.Test.UWP.App\"  -->  EntryPoint=\"$safeprojectname$.App\"" +
                          "\n\tDisplayName=\"MvvmCrossTest.Test.UWP\"  -->  DisplayName=\"$ext_safeprojectname$.Test\"" +
                          "\n\tDescription=\"MvvmCrossTest.Test.UWP\"  -->  Description=\"$ext_safeprojectname$ host for tests.\"");

                contents = contents.Replace("<DisplayName>MvvmCrossTest.Test.UWP", "<DisplayName>$ext_safeprojectname$.Test")
                    .Replace("EntryPoint=\"MvvmCrossTest.Test.UWP.App\"", "EntryPoint=\"$safeprojectname$.App\"")
                    .Replace("DisplayName=\"MvvmCrossTest.Test.UWP\"", "DisplayName=\"$ext_safeprojectname$.Test\"")
                    .Replace("Description=\"MvvmCrossTest.Test.UWP\"", "Description=\"$ext_safeprojectname$ host for tests.\"");

                File.WriteAllText(manifest, contents);

                WriteLine($"{manifest}: Fixed.\n");
            }
        }

        private readonly string _uwpFolder, _testUwpFolder;
    }
}