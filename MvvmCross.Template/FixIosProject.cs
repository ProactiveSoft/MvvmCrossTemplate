using System;
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
            _testIosFolder = Path.Combine(TemplateFolder, "Proso.MvvmCross.Test.iOS");
        }


        /// <inheritdoc />
        public override void FixVsTemplate()
        {
            #region iOS Assets
            string assets =
                    @"      <Folder Name=""Assets.xcassets"" TargetFolderName=""Assets.xcassets"">
        <Folder Name=""AppIcon.appiconset"" TargetFolderName=""AppIcon.appiconset"">
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
      </Folder>
      <Folder Name=""Properties"" TargetFolderName=""Properties"">";
            #endregion

            FixIos();
            FixTest();



            void FixIos()   // Fix iOS's vstemplate   
            {
                #region Make iOS files replaceable
                string vsTemplate = Path.Combine(_iOsFolder, "MyTemplate.vstemplate");
                WriteLine(
                    $"\n{vsTemplate}: Set ReplaceParameters=\"false\" to ReplaceParameters=\"true\" for Entitlements.plist, Info.plist & LaunchScreen.storyboard");

                string contents = File.ReadAllText(vsTemplate);
                contents = contents.Replace(
                        "      <ProjectItem ReplaceParameters=\"false\" TargetFileName=\"Entitlements.plist\"",
                        "      <ProjectItem ReplaceParameters=\"true\" TargetFileName=\"Entitlements.plist\"")
                    .Replace("      <ProjectItem ReplaceParameters=\"false\" TargetFileName=\"Info.plist\"",
                        "      <ProjectItem ReplaceParameters=\"true\" TargetFileName=\"Info.plist\"")
                    .Replace("<ProjectItem ReplaceParameters=\"false\" TargetFileName=\"LaunchScreen.storyboard\"",
                        "<ProjectItem ReplaceParameters=\"true\" TargetFileName=\"LaunchScreen.storyboard\"");
                WriteLine("Corrected.\n");
                #endregion


                #region Add assets in iOS
                WriteLine($"\n{vsTemplate}: Including assets.");

                contents = contents.Replace("      <Folder Name=\"Properties\" TargetFolderName=\"Properties\">", assets);
                File.WriteAllText(vsTemplate, contents);
                WriteLine("Included Assets.\n");
                #endregion
            }

            void FixTest()   // Fix Test.iOS's vstemplate
            {
                #region Make Test.iOS files replaceable
                string vsTemplate = Path.Combine(_testIosFolder, "MyTemplate.vstemplate");
                WriteLine(
                    $"\n{vsTemplate}: Set ReplaceParameters=\"false\" to ReplaceParameters=\"true\" for Entitlements.plist & Info.plist");

                string contents = File.ReadAllText(vsTemplate);
                contents = contents.Replace(
                        "      <ProjectItem ReplaceParameters=\"false\" TargetFileName=\"Entitlements.plist\"",
                        "      <ProjectItem ReplaceParameters=\"true\" TargetFileName=\"Entitlements.plist\"")
                    .Replace("      <ProjectItem ReplaceParameters=\"false\" TargetFileName=\"Info.plist\"",
                        "      <ProjectItem ReplaceParameters=\"true\" TargetFileName=\"Info.plist\"");
                WriteLine("Corrected.\n");
                #endregion


                #region Add assets in Test.iOS
                WriteLine($"\n{vsTemplate}: Including assets.");

                contents = contents.Replace("      <Folder Name=\"Properties\" TargetFolderName=\"Properties\">", assets);

                File.WriteAllText(vsTemplate, contents);
                WriteLine("Included Assets.\n");
                #endregion
            }
        }

        #region Copy Assets folder
        /// <summary>Copies assets to iOS &amp; Test.IOS projects.</summary>
        public void CopyItems()
        {
            string source = Path.Combine(TemplateFolder, "..", "MvvmCrossTest", "MvvmCrossTest.iOS", "Assets.xcassets");
            _folderHelper.CopyFolder(source, _iOsFolder);   // Copy to iOS project
            _folderHelper.CopyFolder(source, _testIosFolder);   // Copy to Test.iOS

        }
        #endregion

        /// <summary>
        /// Correct iOS manifest.
        /// </summary>
        /// <inheritdoc />
        public override void CorrectManifest()
        {
            FixIos();
            FixTest();



            #region Fix iOS Manifest
            void FixIos()
            {
                string manifest = Path.Combine(_iOsFolder, "Info.plist");
                WriteLine($@"{Environment.NewLine}{manifest}: Fixing <key>CFBundleDisplayName</key>
    <string>MvvmCrossTest</string>  -->  <key>CFBundleDisplayName</key>
    <string>$ext_safeprojectname$</string>");
                WriteLine(@"Fixing <key>CFBundleIdentifier</key>
    <string>com.companyname.MvvmCrossTest</string>  -->  <key>CFBundleIdentifier</key>
    <string>com.$ext_safeprojectname$</string>");
                WriteLine(@"<key>CFBundleName</key>
    <string>MvvmCrossTest</string>  -->  <key>CFBundleName</key>
    <string>$ext_safeprojectname$</string>");

                string contents = File.ReadAllText(manifest);
                contents = contents.Replace(@"<key>CFBundleDisplayName</key>
    <string>MvvmCrossTest</string>", @"<key>CFBundleDisplayName</key>
    <string>$ext_safeprojectname$</string>")
                    .Replace(@"<key>CFBundleIdentifier</key>
    <string>com.companyname.MvvmCrossTest</string>", @"<key>CFBundleIdentifier</key>
    <string>com.$ext_safeprojectname$</string>")
                    .Replace(@"<key>CFBundleName</key>
    <string>MvvmCrossTest</string>", @"<key>CFBundleName</key>
    <string>$ext_safeprojectname$</string>");
                File.WriteAllText(manifest, contents);

                WriteLine("Fixed.\n");
            }
            #endregion

            #region Fix Test.iOS Manifest
            void FixTest()
            {
                string manifest = Path.Combine(_testIosFolder, "Info.plist"),
                    contents = File.ReadAllText(manifest);

                WriteLine($"\n{manifest}: Fixing" + $@"{Environment.NewLine}    <key>CFBundleDisplayName</key>
    <string>MvvmCrossTest.Test.iOS</string>  -->  <key>CFBundleDisplayName</key>
    <string>$ext_safeprojectname$.Test</string>" + $@"{Environment.NewLine}    <key>CFBundleIdentifier</key>
    <string>com.companyname.MvvmCrossTest.Test.iOS</string>  -->  <key>CFBundleIdentifier</key>
    <string>com.$ext_safeprojectname$.Test</string>");

                contents = contents.Replace(@"<key>CFBundleDisplayName</key>
    <string>MvvmCrossTest.Test.iOS</string>", @"<key>CFBundleDisplayName</key>
    <string>$ext_safeprojectname$.Test</string>")
                    .Replace(@"<key>CFBundleIdentifier</key>
    <string>com.companyname.MvvmCrossTest.Test.iOS</string>", @"<key>CFBundleIdentifier</key>
    <string>com.$ext_safeprojectname$.Test</string>");

                File.WriteAllText(manifest, contents);

                WriteLine("Fixed.\n");
            }
            #endregion
        }


        private readonly string _iOsFolder, _testIosFolder;
        private readonly IFolderHelper _folderHelper;
    }
}