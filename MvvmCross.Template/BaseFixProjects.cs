using System.Collections.Generic;
using System.IO;
using static System.Console;

namespace MvvmCross.Template
{
    class BaseFixProjects : IFixLibraryProjects
    {
        /// <inheritdoc />
        public void FixCSharp()
        {
            // Fix using statements
            IEnumerable<string> csFiles = Directory.EnumerateFiles(TemplateFolder, "*.cs", SearchOption.AllDirectories);
            foreach (var csFile in csFiles)
            {
                WriteLine($"Editing {csFile}");

                string[] content = File.ReadAllLines(csFile);
                for (int i = 0; i < content.Length; i++)
                {
                    if (content[i].Contains("namespace") && IsFileNotActivity(csFile)) break;

                    content[i] = content[i].Replace("MvvmCrossTest", "$ext_safeprojectname$");
                }

                File.WriteAllLines(csFile, content);

                WriteLine($"Finished {csFile}\n");
            }
        }

        private bool IsFileNotActivity(string filePath)
        {
            string? fileName = Path.GetFileName(filePath);
            if (fileName != null)
                return !(fileName.Contains("Activity") || fileName.Contains("SplashScreen"));

            return true;
        }

        /// <inheritdoc />
        public virtual void FixCsProj()
        {
            CsprojFiles = Directory.EnumerateFiles(TemplateFolder, "*.csproj", SearchOption.AllDirectories);
            foreach (var csprojFile in CsprojFiles)
            {
                WriteLine($"Fixing {csprojFile}: \\MvvmCrossTest --> \\$ext_safeprojectname$ &");
                WriteLine($"Fixing {csprojFile}: ..\\..\\SharedAssemblyInfo.cs  -->  ..\\SharedAssemblyInfo.cs");

                string contents = File.ReadAllText(csprojFile);
                contents = contents
                    .Replace("\\MvvmCrossTest", "\\$ext_safeprojectname$")
                    .Replace("..\\..\\SharedAssemblyInfo.cs", "..\\SharedAssemblyInfo.cs");

                File.WriteAllText(csprojFile, contents);

                WriteLine("Fixed \\MvvmCrossTest --> \\$ext_safeprojectname$ &");
                WriteLine("Fixed ..\\..\\SharedAssemblyInfo.cs --> ..\\SharedAssemblyInfo.cs\n");
            }
        }

        /// <inheritdoc />
        public virtual void FixVsTemplate()
        {
            IEnumerable<string> vsTemplateFiles =
                Directory.EnumerateFiles(TemplateFolder, "*.vstemplate", SearchOption.AllDirectories);
            foreach (var vsTemplateFile in vsTemplateFiles)
            {
                string contents = File.ReadAllText(vsTemplateFile);

                AddHidden(vsTemplateFile, ref contents);
                ReplaceMvvmCrossTest(vsTemplateFile, ref contents);

                File.WriteAllText(vsTemplateFile, contents);

                WriteLine($"Fixed {vsTemplateFile}\n");
            }

            void AddHidden(string vsTemplateFile, ref string contents)
            {
                WriteLine($"Adding <Hidden>true</Hidden> in {vsTemplateFile}");

                string hidden = @"    <Hidden>true</Hidden>
  </TemplateData>";
                contents = contents.Replace("  </TemplateData>", hidden);
            }

            void ReplaceMvvmCrossTest(string vsTemplateFile, ref string contents)
            {
                string projectName = ProjectNameFromPath(vsTemplateFile);
                string oldValue = $"TargetFileName=\"MvvmCrossTest{projectName}";

                WriteLine(
                    $"Fixing TargetFileName=\"MvvmCrossTest{projectName}  -->  TargetFileName=\"$safeprojectname$: {vsTemplateFile}");

                contents = contents.Replace(oldValue, "TargetFileName=\"$safeprojectname$");
            }
        }


        private string ProjectNameFromPath(string path)
        {
            string projectPath = Path.GetDirectoryName(path) ?? string.Empty;
            int lastDotIndex = projectPath.LastIndexOf('.');
            return projectPath[lastDotIndex..];
        }


        protected readonly string TemplateFolder = @"D:\Plugins\MvvmCrossTest\Temp";
        protected IEnumerable<string>? CsprojFiles;
    }
}