using System.IO;
using static System.Console;

namespace MvvmCross.Template
{
    class FixUwpProject : BaseFixPlatformProjects
    {
        public FixUwpProject() => _uwpFolder = Path.Combine(TemplateFolder, "Proso.MvvmCross.UWP");


        /// <inheritdoc />
        public override void FixCsProj()
        {
            base.FixCsProj();   // Fixes "<Name>MvvmCrossTest"

            string csproj = Path.Combine(_uwpFolder, "MvvmCrossTest.UWP.csproj");
            WriteLine(
                $"Fixing <PackageCertificateKeyFile>MvvmCrossTest.UWP  -->  <PackageCertificateKeyFile>$safeprojectname$: {csproj}");

            string contents = File.ReadAllText(csproj);
            contents = contents.Replace("<PackageCertificateKeyFile>MvvmCrossTest.UWP",
                "<PackageCertificateKeyFile>$safeprojectname$");
            File.WriteAllText(csproj, contents);

            WriteLine(
                "Fixed <PackageCertificateKeyFile>MvvmCrossTest.UWP  -->  <PackageCertificateKeyFile>$safeprojectname$\n");
        }

        /// <inheritdoc />
        public override void FixVsTemplate()
        {
            base.FixVsTemplate();

            string vsTemplate = Path.Combine(_uwpFolder, "MyTemplate.vstemplate");
            WriteLine(
                $"Fixing <ProjectItem ReplaceParameters=\"false\" TargetFileName=\"Package.appxmanifest\"  -->  <ProjectItem ReplaceParameters=\"false\" TargetFileName=\"Package.appxmanifest\": {vsTemplate}");

            string contents = File.ReadAllText(vsTemplate);
            contents = contents.Replace(
                "      <ProjectItem ReplaceParameters=\"false\" TargetFileName=\"Package.appxmanifest\"",
                "      <ProjectItem ReplaceParameters=\"true\" TargetFileName=\"Package.appxmanifest\"");
            File.WriteAllText(vsTemplate, contents);

            WriteLine("Fixed ReplaceParameters=\"false\"  -->  ReplaceParameters=\"true\"\n");
        }

        /// <inheritdoc />
        public override void CorrectManifest()
        {
            throw new System.NotImplementedException();
        }

        private readonly string _uwpFolder;
    }
}