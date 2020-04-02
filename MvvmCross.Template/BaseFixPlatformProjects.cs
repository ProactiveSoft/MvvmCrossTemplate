using System.IO;
using static System.Console;

namespace MvvmCross.Template
{
    abstract class BaseFixPlatformProjects : BaseFixProjects, IFixPlatformProjects
    {
        /// <inheritdoc />
        public override void FixCsProj()
        {
            base.FixCsProj();   // Fixes \MvvmCrossTest

            foreach (var csprojFile in CsprojFiles!)   // Fixes <Name>MvvmCrossTest
            {
                WriteLine($"Fixing <Name>MvvmCrossTest  -->  <Name>$ext_safeprojectname$: {csprojFile}");

                string contents = File.ReadAllText(csprojFile);
                contents = contents.Replace("<Name>MvvmCrossTest", "<Name>$ext_safeprojectname$");
                File.WriteAllText(csprojFile, contents);

                WriteLine($"Fixed <Name>MvvmCrossTest  -->  <Name>$ext_safeprojectname$.\n");
            }
        }

        /// <inheritdoc />
        public abstract void CorrectManifest();
    }
}