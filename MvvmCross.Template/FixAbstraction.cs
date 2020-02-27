using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Console;

namespace MvvmCross.Template
{
    internal class FixAbstraction : BaseFixProjects
    {

        /// <inheritdoc />
        public override void FixCsProj()
        {
            throw new System.NotImplementedException();
        }

        public override void FixVsTemplate()
        {
            string abstractionFolder = Path.Combine(TemplateFolder, "Proso.MvvmCross.Abstraction");

            // Edit .vstemplate
            WriteLine(@"Editing Abstraction\MyTemplate.vstemplate");

            // Read file
            List<string> vsTemplate =
                File.ReadAllLines(Path.Combine(abstractionFolder, "MyTemplate.vstemplate")).ToList();


            for (var i = 0; i < vsTemplate.Count; i++)
            {
                if (vsTemplate[i] == "  </TemplateData>")
                {
                    vsTemplate.Insert(i, "    <Hidden>true</Hidden>");
                    i++;

                    continue;
                }

                if (vsTemplate[i].StartsWith("    <Project "))
                {
                    vsTemplate[i] = vsTemplate[i].Replace("TargetFileName=\"MvvmCrossTest.Abstraction.csproj\"",
                        "TargetFileName=\"$safeprojectname$.csproj\"");

                    break;
                }
            }


            // Write file
            File.WriteAllLines(Path.Combine(abstractionFolder, "MyTemplate.vstemplate"), vsTemplate);

            WriteLine(@"Finished Abstraction\MyTemplate.vstemplate");
        }
    }
}