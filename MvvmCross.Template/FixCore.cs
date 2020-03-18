using static System.Console;
using System.IO;

namespace MvvmCross.Template
{
    class FixCore : BaseFixProjects, IFixMetadata
    {
        public FixCore() => _coreFolder = Path.Combine(TemplateFolder, "Proso.MvvmCross.Core");


        /// <inheritdoc />
        public void UpdateVersion()
        {
            string version = ((IFixMetadata) this).CurrentMvxVersion;
            string mainVmPath = Path.Combine(_coreFolder, "ViewModels", "MainViewModel.cs");
            string[] contents = File.ReadAllLines(mainVmPath);
            for (var i = 0; i < contents.Length; i++)
                if (contents[i].StartsWith("            Title ="))
                {
                    contents[i] = $"            Title = \"V {version}\";";
                    break;
                }

            File.WriteAllLines(mainVmPath, contents);

            WriteLine($"\nUpdated MvvmCross template version {version} in MainViewModel.cs");
        }


        private readonly string _coreFolder;
    }
}
