using System;
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
            string version = ((IFixMetadata)this).NewTemplateVersion;
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

        /// <summary>
        /// Adds the copyright.
        /// </summary>
        public void AddCopyright()
        {
            string assemblyInfo = @"D:\Plugins\MvvmCrossTest\Temp\SharedAssemblyInfo.cs";
            string[] contents = File.ReadAllLines(assemblyInfo);
            for (var i = 0; i < contents.Length; i++)
                if (contents[i].StartsWith("[assembly: AssemblyCopyright("))
                {
                    contents[i] = $"[assembly: AssemblyCopyright(\"© Proso {DateTime.Today.Year}\")]";
                    break;
                }
            File.WriteAllLines(assemblyInfo, contents);

            WriteLine("Added copyright to SharedAssemblyInfo.cs");
        }


        private readonly IFolderHelper _folderHelper;
    }
}