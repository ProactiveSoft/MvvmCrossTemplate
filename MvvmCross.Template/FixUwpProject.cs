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
            string csproj = Path.Combine(_uwpFolder, "MvvmCrossTest.UWP.csproj");
            WriteLine(
                $"Fixing <PackageCertificateKeyFile>MvvmCrossTest.UWP  -->  <PackageCertificateKeyFile>$safeprojectname$: {csproj}");

            string contents = File.ReadAllText(csproj);
            contents = contents.Replace("<PackageCertificateKeyFile>MvvmCrossTest.UWP",
                "<PackageCertificateKeyFile>$safeprojectname$");
            File.WriteAllText(csproj, contents);

            WriteLine(
                "Fixed <PackageCertificateKeyFile>MvvmCrossTest.UWP  -->  <PackageCertificateKeyFile>$safeprojectname$");
        }

        /// <inheritdoc />
        public override void CorrectManifest()
        {
            throw new System.NotImplementedException();
        }

        private readonly string _uwpFolder;
    }
}