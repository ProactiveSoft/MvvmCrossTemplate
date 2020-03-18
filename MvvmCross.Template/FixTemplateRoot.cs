using System.Collections.Generic;
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
            string source = Path.Combine(TemplateFolder, "..", "Proso.MvvmCross Template", "Template");
            _folderHelper.CopyFolderFiles(source, TemplateFolder);
        }


        /// <inheritdoc />
        public void UpdateVersion()
        {
            UpdateMvxVersion();
            UpdateTemplateVersion();
            UpdateCopyright();

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
                List<string> startings = new List<string>(4)
                {
                    "    <InformationalVersion>",
                    "    <Version>",
                    "    <AssemblyVersion>",
                    "    <FileVersion>"
                };

                // ToDo: Extract method which does line-by-line operation
                for (var line = 0; line < contents.Length && startings.Count > 0; line++)
                    for (var starting = 0; starting < startings.Count; starting++)
                    {
                        if (!contents[line].StartsWith(startings[starting])) continue;

                        string oldVersion = FindVersion(contents[line]),
                            newVersion = string.Empty;
                        switch (startings[starting])
                        {
                            case "    <InformationalVersion>":
                            case "    <Version>":
                            case "    <AssemblyVersion>":
                                var (year, month, seconds) = ((IFixMetadata)this).CompactCurrentAppVersion;
                                newVersion = $"{year}.{month}.{seconds}";

                                startings.Remove(startings[starting]);
                                break;
                            case "    <FileVersion>":
                                int day;
                                (year, month, day, seconds) = ((IFixMetadata)this).CurrentAppVersion;
                                newVersion = $"{year}.{month}.{day}.{seconds}";

                                startings.Remove((startings[starting]));
                                break;
                        }

                        contents[line] = contents[line].Replace(oldVersion, newVersion);
                        break;
                    }

                File.WriteAllLines(directoryBuildProps, contents);
            }

            void UpdateCopyright()
            {
                string directoryBuildProps = Path.Combine(TemplateFolder, "Directory.Build.props");
                string[] contents = File.ReadAllLines(directoryBuildProps);
                for (var i = 0; i < contents.Length; i++)
                    if (contents[i].StartsWith("    <Copyright>"))
                    {
                        int year = ((IFixMetadata)this).CurrentAppVersion.Year;
                        contents[i] = $"    <Copyright>© Proso {year}</Copyright>";
                        break;
                    }
                File.WriteAllLines(directoryBuildProps, contents);

                WriteLine("\nAdded copyright to Directory.Build.props\n");
            }

            string FindVersion(string line)
            {
                int start = line.IndexOf('>') + 1,
                    end = line.LastIndexOf('<');
                return line[start..end];
            }
        }



        private readonly IFolderHelper _folderHelper;
        private const string TemplateFolder = @"D:\Plugins\MvvmCrossTest\Temp";
    }
}