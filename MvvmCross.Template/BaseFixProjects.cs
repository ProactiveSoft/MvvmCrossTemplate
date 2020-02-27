using System.Collections.Generic;
using System.IO;
using static System.Console;

namespace MvvmCross.Template
{
    abstract class BaseFixProjects : IFixLibraryProjects
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
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public abstract void FixVsTemplate();


        protected readonly string TemplateFolder = @"D:\Plugins\MvvmCrossTest\Temp";
    }
}