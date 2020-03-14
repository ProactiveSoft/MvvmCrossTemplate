using System.IO;
using MvvmCross.Template.Helpers;
using static System.Console;

namespace MvvmCross.Template
{
    class FixIosProject : BaseFixPlatformProjects
    {
        public FixIosProject(IFolderHelper folderHelper)
        {
            _folderHelper = folderHelper;
            _iOsFolder = Path.Combine(TemplateFolder, "Proso.MvvmCross.iOS");
        }


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


            WriteLine("\nIncluding assets in .vstemplate file:");
            string assets =
                @"      <Folder Name=""Assets.xcassets\AppIcon.appiconset"" TargetFolderName=""Assets.xcassets\AppIcon.appiconset"">
        <ProjectItem TargetFileName=""Contents.json"" ReplaceParameters=""true"">Contents.json</ProjectItem>
        <ProjectItem TargetFileName=""Icon20.png"" ReplaceParameters=""false"">Icon20.png</ProjectItem>
        <ProjectItem TargetFileName=""Icon29.png"" ReplaceParameters=""false"">Icon29.png</ProjectItem>
        <ProjectItem TargetFileName=""Icon40.png"" ReplaceParameters=""false"">Icon40.png</ProjectItem>
        <ProjectItem TargetFileName=""Icon58.png"" ReplaceParameters=""false"">Icon58.png</ProjectItem>
        <ProjectItem TargetFileName=""Icon60.png"" ReplaceParameters=""false"">Icon60.png</ProjectItem>
        <ProjectItem TargetFileName=""Icon76.png"" ReplaceParameters=""false"">Icon76.png</ProjectItem>
        <ProjectItem TargetFileName=""Icon80.png"" ReplaceParameters=""false"">Icon80.png</ProjectItem>
        <ProjectItem TargetFileName=""Icon87.png"" ReplaceParameters=""false"">Icon87.png</ProjectItem>
        <ProjectItem TargetFileName=""Icon120.png"" ReplaceParameters=""false"">Icon120.png</ProjectItem>
        <ProjectItem TargetFileName=""Icon152.png"" ReplaceParameters=""false"">Icon152.png</ProjectItem>
        <ProjectItem TargetFileName=""Icon167.png"" ReplaceParameters=""false"">Icon167.png</ProjectItem>
        <ProjectItem TargetFileName=""Icon180.png"" ReplaceParameters=""false"">Icon180.png</ProjectItem>
        <ProjectItem TargetFileName=""Icon1024.png"" ReplaceParameters=""false"">Icon1024.png</ProjectItem>
      </Folder>
      <Folder Name=""Properties"" TargetFolderName=""Properties"">";
            contents = contents.Replace("      <Folder Name=\"Properties\" TargetFolderName=\"Properties\">", assets);

            File.WriteAllText(vsTemplate, contents);
        }

        public void CopyItems()
        {
            // Copy Assets.xcassets folder
            string source = Path.Combine(TemplateFolder, "..", "MvvmCrossTest", "MvvmCrossTest.iOS", "Assets.xcassets");
            _folderHelper.NaiveCopyFolder(source, _iOsFolder);
        }

        /// <inheritdoc />
        public override void CorrectManifest()
        {
            throw new System.NotImplementedException();
        }


        private readonly string _iOsFolder;
        private readonly IFolderHelper _folderHelper;
    }
}