﻿using System;
using System.Collections.Generic;
using System.IO;
using MvvmCross.Template.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace MvvmCross.Template.Test
{
    public class FixMetadataShould
    {
        public FixMetadataShould(ITestOutputHelper output) => _output = output;


        [Fact]
        [Trait("Task", "Fix root")]
        public void UpdateMvxVersion()
        {
            // Arrange
            // ToDo: Get latest MvvmCross version "expectedVersion" by scraping
            // https://github.com/MvvmCross/MvvmCross/blob/develop/CHANGELOG.md
            string expectedVersion = "6.4.2",
                mainVm = Path.Combine(TemplateFolder, "Proso.MvvmCross.Core", "ViewModels", "MainViewModel.cs"),
                vsTemplate = Path.Combine(TemplateFolder, "Proso-MvvmCross-Xamarin-Template.vstemplate"),
                mainVmVersionLine = string.Empty, vsTemplateVersionLine = string.Empty;

            foreach (var line in File.ReadAllLines(mainVm))
                if (line.StartsWith("            Title ="))
                {
                    mainVmVersionLine = line;
                    break;
                }

            foreach (var line in File.ReadAllLines(vsTemplate))
                if (line.StartsWith("    <Description>"))
                {
                    vsTemplateVersionLine = line;
                    break;
                }

            // Assert
            Assert.Contains(expectedVersion, mainVmVersionLine);
            Assert.Contains(expectedVersion, vsTemplateVersionLine);

            _output.WriteLine($"MvvmCross template updated to version {expectedVersion}.");
        }

        [Fact]
        [Trait("Task", "Fix root")]
        public void UpdateTemplateVersion()
        {
            // Arrange
            string directoryBuildProps = Path.Combine(TemplateFolder, "Directory.Build.props");
            string contents = File.ReadAllText(directoryBuildProps);
            IFixMetadata fixMetadata = new FixTemplateRoot(new FolderHelper());
            var (year, month, day, _) = fixMetadata.CurrentAppVersion;
            string informationalVersion = $"<InformationalVersion>{year}.{month}",
                fileVersion = $"<FileVersion>{year}.{month}.{day}",
                copyright = $"<Copyright>© Proso {year}";

            // Act
            Assert.Contains(informationalVersion, contents);
            Assert.Contains(fileVersion, contents);
            Assert.Contains(copyright, contents);

            _output.WriteLine($"Template version is latest: {year}.{month}");
        }

        [Fact]
        [Trait("Task", "Fix root")]
        public void FixDirectoryBuildProps()
        {
            // Arrange
            string directoryBuildProps = Path.Combine(TemplateFolder, "Directory.Build.props");
            string[] contents = File.ReadAllLines(directoryBuildProps);
            HashSet<string> starts = new HashSet<string>(4)
                {"    <Product>", "    <Description>", "    <!--<PackageProjectUrl>", "    <!--<RepositoryUrl>"};
            int count = 0;
            foreach (var line in contents)
            {
                string starting = FindStart(line);
                if (!starts.Contains(starting)) continue;

                // Assert
                Assert.DoesNotContain("MvvmCross", line, StringComparison.OrdinalIgnoreCase);
                Assert.DoesNotContain("Template", line, StringComparison.OrdinalIgnoreCase);

                if (++count == starts.Count) break;
            }

            _output.WriteLine("Directory.Build.props fixed.");


            string FindStart(string sentence)
            {
                int end = sentence.IndexOf('>') + 1;
                return sentence[..end];
            }
        }

        private const string TemplateFolder = @"D:\Plugins\MvvmCrossTest\Temp";
        private readonly ITestOutputHelper _output;
    }
}