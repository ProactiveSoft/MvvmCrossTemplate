using System.IO;
using MvvmCross.Template.Helpers;
using static System.Console;

namespace MvvmCross.Template
{
    public class FixTemplateRoot : IFixMetadata
    {
        public FixTemplateRoot(IFolderHelper folderHelper) => _folderHelper = folderHelper;


        public void CopyItems()
        {
            string source = @"D:\Plugins\MvvmCrossTest\Proso.MvvmCross Template\Template",
                destination = @"D:\Plugins\MvvmCrossTest\Temp";
            _folderHelper.CopyFolderFiles(source, destination);
        }


        /// <inheritdoc />
        public void UpdateVersion()
        {
            string version = ((IFixMetadata) this).NewTemplateVersion;
            string[] vsTemplate =
                File.ReadAllLines(@"D:\Plugins\MvvmCrossTest\Temp\Proso-MvvmCross-Xamarin-Template.vstemplate");
            for (var i = 0; i < vsTemplate.Length; i++)
                if (vsTemplate[i].StartsWith("    <Description>"))
                {
                    vsTemplate[i] = $"    <Description>MvvmCross template {version}.</Description>";
                    break;
                }

            File.WriteAllLines(@"D:\Plugins\MvvmCrossTest\Temp\Proso-MvvmCross-Xamarin-Template.vstemplate", vsTemplate);

            WriteLine($"\nUpdated MvvmCross template version {version} in root .vstemplate");
        }


        private readonly IFolderHelper _folderHelper;
    }
}