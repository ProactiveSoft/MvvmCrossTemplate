using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Console;

namespace MvvmCross.Template
{
    public class CorrectProjects
    {
        internal void CorrectAbstraction()
        {
            string abstractionFolder = Path.Combine(_templateFolder, "Proso.MvvmCross.Abstraction");

            // Edit .vstemplate
            WriteLine(@"Editing Abstraction\MyTemplate.vstemplate");

            // Read file
            List<string> vsTemplate =
                File.ReadAllLines(Path.Combine(abstractionFolder, "MyTemplate.vstemplate")).ToList();


            // Manipulate file
            vsTemplate.Insert(16, "    <Hidden>true</Hidden>");
            vsTemplate[19] = vsTemplate[19].Replace("TargetFileName=\"MvvmCrossTest.Abstraction.csproj\"",
                "TargetFileName=\"$safeprojectname$.csproj\"");


            // Write file
            File.WriteAllLines(Path.Combine(abstractionFolder, "MyTemplate.vstemplate"), vsTemplate);

            WriteLine(@"Finished Abstraction\MyTemplate.vstemplate");
        }



        private readonly string _templateFolder = @"D:\Plugins\MvvmCrossTest\Temp";
    }
}