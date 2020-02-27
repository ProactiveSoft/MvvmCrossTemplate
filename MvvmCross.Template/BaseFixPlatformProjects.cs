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

            foreach (var csprojFile in CsprojFiles)
            {
                WriteLine($"Fixing <Name>MvvmCrossTest  -->  <Name>$ext_safeprojectname$: {csprojFile}");

                string contents = File.ReadAllText(csprojFile);
                contents = contents.Replace("<Name>MvvmCrossTest", "<Name>$ext_safeprojectname$");
                File.WriteAllText(csprojFile, contents);

                WriteLine($"Fixed <Name>MvvmCrossTest  -->  <Name>$ext_safeprojectname$.\n");
            }
        }

        /// <inheritdoc />
        public override void FixVsTemplate()
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public abstract void CorrectManifest();
    }
}