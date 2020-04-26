using System.Collections.Generic;
using System.IO;
using MvvmCross.Template.Helpers;
using static System.Console;

namespace MvvmCross.Template
{
    /// <summary>Class containing methods to fix files in template's root.</summary>
    /// <seealso cref="MvvmCross.Template.IFixMetadata" />
    public class FixTemplateRoot : IFixMetadata
    {
        /// <summary>Initializes a new instance of the <see cref="T:MvvmCross.Template.FixTemplateRoot"/> class.</summary>
        /// <param name="folderHelper">Helper service to handle folder operations.</param>
        public FixTemplateRoot(IFolderHelper folderHelper) => _folderHelper = folderHelper;


        #region Copy Files to Template Root
        /// <summary>Copies files to template's root folder.</summary>
        public void CopyItems()
        {
            string source = Path.Combine(TemplateFolder, "..", "Proso.MvvmCross Template", "Template");
            _folderHelper.CopyFolderFiles(source, TemplateFolder);
        } 
        #endregion


        /// <inheritdoc />
        public void UpdateVersion()
        {
            UpdateMvxVersion();
            UpdateTemplateVersion();

            void UpdateMvxVersion()
            {
                string mvxVersion = ((IFixMetadata)this).CurrentMvxVersion;
                string vsTemplate = Path.Combine(TemplateFolder, "Proso-MvvmCross-Xamarin-Template.vstemplate");
                string[] contents = File.ReadAllLines(vsTemplate);
                for (var i = 0; i < contents.Length; i++)
                    if (contents[i].StartsWith("    <Description>"))
                    {
                        contents[i] = $"    <Description>MvvmCross template for MvvmCross {mvxVersion}.</Description>";
                        break;
                    }

                File.WriteAllLines(vsTemplate, contents);

                WriteLine($"\nUpdated MvvmCross template version {mvxVersion} in root .vstemplate");
            }

            void UpdateTemplateVersion()
            {
                string directoryBuildProps = Path.Combine(TemplateFolder, "Directory.Build.props");
                string[] contents = File.ReadAllLines(directoryBuildProps);

                int year, month, day, seconds;
                (year, month, seconds) = ((IFixMetadata)this).CompactCurrentAppVersion;
                Dictionary<string, string> starts = new Dictionary<string, string>(5)
                {
                    ["    <InformationalVersion>"] = $"{year}.{month}.{seconds}",
                    ["    <Version>"] = $"{year}.{month}.{seconds}",
                    ["    <Copyright>"] = $"© Proso {year}"
                };
                (_, _, day, seconds) = ((IFixMetadata)this).CurrentAppVersion;
                starts["    <AssemblyVersion>"] = $"{year}.{month}.{day}.{seconds}";
                starts["    <FileVersion>"] = $"{year}.{month}.{day}.{seconds}";
                UpdateValues(contents, starts);

                File.WriteAllLines(directoryBuildProps, contents);

                WriteLine("\nUpdated app version in Directory.Build.props\n");
            }
        }

        public void FixDirectoryBuildProps()
        {
            string directoryBuildProps = Path.Combine(TemplateFolder, "Directory.Build.props");
            string[] contents = File.ReadAllLines(directoryBuildProps);

            Dictionary<string, string> starts = new Dictionary<string, string>(4)
            {
                ["    <Product>"] = "Enter product name ...",
                ["    <Description>"] = "Enter product description ...",
                ["    <!--<PackageProjectUrl>"] = "https://github.com/ProactiveSoft/",
                ["    <!--<RepositoryUrl>"] = "https://github.com/ProactiveSoft/"
            };
            UpdateValues(contents, starts);

            File.WriteAllLines(directoryBuildProps, contents);

            WriteLine("\nFixed Directory.Build.props\n");
        }

        #region Helpers

        private void UpdateValues(string[] contents, Dictionary<string, string> starts)
        {
            for (int line = 0, count = 0; line < contents.Length && count < starts.Count; line++)
            {
                string starting = FindStart(contents[line]);
                if (!starts.TryGetValue(starting, out string newValue)) continue;

                string oldValue = FindValue(contents[line]);
                contents[line] = contents[line].Replace(oldValue, newValue);
                count++;
            }
        }

        private string FindStart(string line)
        {
            int end = line.IndexOf('>') + 1;
            return line[..end];
        }

        private string FindValue(string line)
        {
            int start = line.IndexOf('>') + 1,
                end = line.LastIndexOf('<');
            return line[start..end];
        }

        #endregion


        private readonly IFolderHelper _folderHelper;
        private const string TemplateFolder = @"D:\Plugins\MvvmCrossTest\Temp";
    }
}