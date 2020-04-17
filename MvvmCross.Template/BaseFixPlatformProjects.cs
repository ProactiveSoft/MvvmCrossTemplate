using System.IO;
using static System.Console;

namespace MvvmCross.Template
{
    abstract class BaseFixPlatformProjects : BaseFixProjects, IFixPlatformProjects
    {
        #region Replace MvvmCrossTest
        /// <summary>
        /// Replaces &lt;Name&gt;MvvmCrossTest  --&gt;  &lt;Name&gt;$ext_safeprojectname$.
        /// </summary>
        /// <inheritdoc />
        public override void FixCsProj()
        {
            base.FixCsProj();   // Fixes \MvvmCrossTest

            foreach (var csprojFile in CsprojFiles!)   // Fixes <Name>MvvmCrossTest
            {
                WriteLine($"{csprojFile}: Fixing <Name>MvvmCrossTest  -->  <Name>$ext_safeprojectname$");

                string contents = File.ReadAllText(csprojFile);
                contents = contents.Replace("<Name>MvvmCrossTest", "<Name>$ext_safeprojectname$");
                File.WriteAllText(csprojFile, contents);

                WriteLine("Fixed.\n");
            }
        } 
        #endregion

        /// <inheritdoc />
        public abstract void CorrectManifest();
    }
}