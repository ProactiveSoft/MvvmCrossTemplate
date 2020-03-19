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
                WriteLine($"\t..\\..\\SharedAssemblyInfo.cs  -->  ..\\SharedAssemblyInfo.cs");

                string contents = File.ReadAllText(csprojFile);
                contents = contents
                    .Replace("\\MvvmCrossTest", "\\$ext_safeprojectname$")
                    .Replace("..\\..\\SharedAssemblyInfo.cs", "..\\SharedAssemblyInfo.cs");

                File.WriteAllText(csprojFile, contents);

                WriteLine("Fixed \\MvvmCrossTest --> \\$ext_safeprojectname$ &");
                WriteLine("\t..\\..\\SharedAssemblyInfo.cs --> ..\\SharedAssemblyInfo.cs\n");
            }
        }

        /// <inheritdoc />
        public virtual void FixVsTemplate()
        {
            string[] vsTemplates =
                Directory.GetFiles(TemplateFolder, "*.vstemplate", SearchOption.AllDirectories);

            AddDescription();

            foreach (var vsTemplate in vsTemplates)
            {
                string contents = File.ReadAllText(vsTemplate);

                AddHidden(vsTemplate, ref contents);
                ReplaceMvvmCrossTest(vsTemplate, ref contents);

                File.WriteAllText(vsTemplate, contents);

                WriteLine($"Fixed {vsTemplate}\n");
            }


            void AddDescription()
            {
                WriteLine("\nAdding description to .vstemplate files.\n");

                foreach (var vsTemplate in vsTemplates)
                {
                    // Find vstemplate's project
                    string project = ProjectNameFromPath(vsTemplate);

                    // Add description according to project
                    string[] contents = File.ReadAllLines(vsTemplate);
                    for (var line = 0; line < contents.Length; line++)
                    {
                        if (!contents[line].StartsWith("    <Description>")) continue;

                        contents[line] = project switch
                        {
                            "Abstraction" => "    <Description>MvvmCross Forms template's abstractions.</Description>",
                            "Core" => "    <Description>MvvmCross Forms template's core logic.</Description>",
                            "Forms" => "    <Description>MvvmCross Forms template's UI project.</Description>",
                            "UWP" => "    <Description>MvvmCross Forms UWP Template.</Description>",
                            "Android" => "    <Description>MvvmCross Forms template for Android.</Description>",
                            "iOS" => "    <Description>MvvmCross Forms iOS template.</Description>",
                            _ => "    <Description>Template's description.</Description>"
                        };
                        break;
                    }

                    File.WriteAllLines(vsTemplate, contents);
                }

                WriteLine("\nAdded description to .vstemplate files.\n");
            }

            void AddHidden(string vsTemplate, ref string contents)
            {
                WriteLine($"Adding <Hidden>true</Hidden> in {vsTemplate}");

                string hidden = @"    <Hidden>true</Hidden>
  </TemplateData>";
                contents = contents.Replace("  </TemplateData>", hidden);
            }

            void ReplaceMvvmCrossTest(string vsTemplate, ref string contents)
            {
                string projectName = ProjectNameFromPath(vsTemplate);
                string oldValue = $"TargetFileName=\"MvvmCrossTest.{projectName}";

                WriteLine(
                    $"Fixing TargetFileName=\"MvvmCrossTest.{projectName}  -->  TargetFileName=\"$safeprojectname$: {vsTemplate}");

                contents = contents.Replace(oldValue, "TargetFileName=\"$safeprojectname$");
            }
        }


        private string ProjectNameFromPath(string path)
        {
            string projectPath = Path.GetDirectoryName(path);
            int start = projectPath.LastIndexOf('.') + 1;
            return projectPath[start..];
        }


        protected readonly string TemplateFolder = @"D:\Plugins\MvvmCrossTest\Temp";
        protected IEnumerable<string>? CsprojFiles;
    }
}