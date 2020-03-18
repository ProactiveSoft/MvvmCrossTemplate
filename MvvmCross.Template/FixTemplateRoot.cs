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
                Dictionary<string, string> starts = new Dictionary<string, string>(4)
                {
                    ["    <InformationalVersion>"] = $"{year}.{month}.{seconds}",
                    ["    <Version>"] = $"{year}.{month}.{seconds}",
                    ["    <AssemblyVersion>"] = $"{year}.{month}.{seconds}",
                    ["    <Copyright>"] = $"© Proso {year}"
                };
                (_, _, day, seconds) = ((IFixMetadata)this).CurrentAppVersion;
                starts["    <FileVersion>"] = $"{year}.{month}.{day}.{seconds}";
                UpdateValues(contents, starts);


                //List<string> startings = new List<string>(4)
                //{
                //    "    <InformationalVersion>",
                //    "    <Version>",
                //    "    <AssemblyVersion>",
                //    "    <FileVersion>"
                //};

                //for (var line = 0; line < contents.Length && startings.Count > 0; line++)
                //    for (var starting = 0; starting < startings.Count; starting++)
                //    {
                //        if (!contents[line].StartsWith(startings[starting])) continue;

                //        string oldVersion = FindValue(contents[line]),
                //            newVersion = string.Empty;
                //        switch (startings[starting])
                //        {
                //            case "    <InformationalVersion>":
                //            case "    <Version>":
                //            case "    <AssemblyVersion>":
                //                var (year, month, seconds) = ((IFixMetadata)this).CompactCurrentAppVersion;
                //                newVersion = $"{year}.{month}.{seconds}";

                //                startings.Remove(startings[starting]);
                //                break;
                //            case "    <FileVersion>":
                //                int day;
                //                (year, month, day, seconds) = ((IFixMetadata)this).CurrentAppVersion;
                //                newVersion = $"{year}.{month}.{day}.{seconds}";

                //                startings.Remove((startings[starting]));
                //                break;
                //        }

                //        contents[line] = contents[line].Replace(oldVersion, newVersion);
                //        break;
                //    }

                File.WriteAllLines(directoryBuildProps, contents);

                WriteLine("\nUpdated app version in Directory.Build.props\n");
            }
        }

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


        private readonly IFolderHelper _folderHelper;
        private const string TemplateFolder = @"D:\Plugins\MvvmCrossTest\Temp";
    }
}