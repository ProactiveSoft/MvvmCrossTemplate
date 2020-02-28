using System.IO;
using static System.Console;

namespace MvvmCross.Template
{
    class FixIosProject : BaseFixPlatformProjects
    {
        public FixIosProject() => _iOsFolder = Path.Combine(TemplateFolder, "Proso.MvvmCross.iOS");


        /// <inheritdoc />
        public override void FixVsTemplate()
        {
            string vsTemplate = Path.Combine(_iOsFolder, "MyTemplate.vstemplate");
            WriteLine(
                $"Fixing <ProjectItem ReplaceParameters=\"false\" TargetFileName=\"Entitlements.plist\"  -->  ReplaceParameters=\"true\": {vsTemplate}");

            string contents = File.ReadAllText(vsTemplate);
            contents = contents.Replace(
                "      <ProjectItem ReplaceParameters=\"false\" TargetFileName=\"Entitlements.plist\"",
                "      <ProjectItem ReplaceParameters=\"true\" TargetFileName=\"Entitlements.plist\"");
            WriteLine($"Corrected to ReplaceParameters=\"true\" TargetFileName=\"Entitlements.plist\")");
            contents = contents.Replace(
                "      <ProjectItem ReplaceParameters=\"false\" TargetFileName=\"Info.plist\"",
                "      <ProjectItem ReplaceParameters=\"true\" TargetFileName=\"Info.plist\"");
            WriteLine($"Corrected to ReplaceParameters=\"true\" TargetFileName=\"Info.plist\")\n");
            File.WriteAllText(vsTemplate, contents);
        }

        /// <inheritdoc />
        public override void CorrectManifest()
        {
            throw new System.NotImplementedException();
        }


        private readonly string _iOsFolder;
    }
}