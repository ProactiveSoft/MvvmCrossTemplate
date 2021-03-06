﻿using System.Collections.Generic;
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



            #region Update Mvx Version in Template Description
            void UpdateMvxVersion()   // Updates Mvx version in Template's description
            {
                string mvxVersion = ((IFixMetadata)this).CurrentMvxVersion;
                string vsTemplate = Path.Combine(TemplateFolder, "Proso-MvvmCross-Xamarin-Template.vstemplate");

                WriteLine($"{vsTemplate}: Updating Mvx version to {mvxVersion} in template's description...");

                string[] contents = File.ReadAllLines(vsTemplate);
                for (var i = 0; i < contents.Length; i++)
                    if (contents[i].StartsWith("    <Description>"))
                    {
                        contents[i] = $"    <Description>MvvmCross template for MvvmCross {mvxVersion}.</Description>";
                        break;
                    }

                File.WriteAllLines(vsTemplate, contents);

                WriteLine($"Updated.\n");
            }
            #endregion

            #region Update Template Version
            void UpdateTemplateVersion()   // Updates Template's version
            {
                string directoryBuildProps = Path.Combine(TemplateFolder, "Directory.Build.props");
                WriteLine($"{directoryBuildProps}: Updating template's version...");
                string[] contents = File.ReadAllLines(directoryBuildProps);

                int year, month, day, seconds;
                (year, month, seconds) = ((IFixMetadata)this).CompactCurrentAppVersion;

                #region Dictionary of Tags to Update
                // Dictionary of tags to be updated.
                Dictionary<string, string> openingTags = new Dictionary<string, string>(5)
                {
                    ["    <InformationalVersion>"] = $"{year}.{month}.{seconds}",
                    ["    <Version>"] = $"{year}.{month}.{seconds}",
                    ["    <Copyright>"] = $"© Proso {year}"
                };
                (_, _, day, seconds) = ((IFixMetadata)this).CurrentAppVersion;
                openingTags["    <AssemblyVersion>"] = $"{year}.{month}.{day}.{seconds}";
                openingTags["    <FileVersion>"] = $"{year}.{month}.{day}.{seconds}";
                #endregion

                UpdateTexts(contents, openingTags);   // Update tag's text

                File.WriteAllLines(directoryBuildProps, contents);

                WriteLine("Updated.\n");
            }
            #endregion
        }

        /// <summary>Fixes solution's metadata in Directory.Build.props.</summary>
        public void FixDirectoryBuildProps()
        {
            string directoryBuildProps = Path.Combine(TemplateFolder, "Directory.Build.props");
            FixSolutionMetadata();
            MakeInternalsVisibleToTest();



            #region Fix Solution's Metadata
            void FixSolutionMetadata()
            {
                WriteLine($"{directoryBuildProps}: Fixing solution's metadata.");
                string[] contents = File.ReadAllLines(directoryBuildProps);

                // Dictionary of tags to be updated.
                Dictionary<string, string> openingTags = new Dictionary<string, string>(4)
                {
                    ["    <Product>"] = "Enter product name ...",
                    ["    <Description>"] = "Enter product description ...",
                    ["    <!--<PackageProjectUrl>"] = "https://github.com/ProactiveSoft/",
                    ["    <!--<RepositoryUrl>"] = "https://github.com/ProactiveSoft/"
                };
                UpdateTexts(contents, openingTags);   // Update tag's text

                File.WriteAllLines(directoryBuildProps, contents);

                WriteLine("Fixed.\n");
            }
            #endregion

            #region Make Internals Visible To Test
            void MakeInternalsVisibleToTest()
            {
                WriteLine($"{directoryBuildProps}: Adding <InternalsVisibleTo/> attribute.");
                string contents = File.ReadAllText(directoryBuildProps);

                string oldValue = @"  <ItemGroup>
    <AssemblyAttribute Include=""System.Runtime.CompilerServices.InternalsVisibleTo"">
      <_Parameter1>MvvmCrossTest.Test.Core</_Parameter1>
    </AssemblyAttribute>
    <AssemblyAttribute Include=""System.Runtime.CompilerServices.InternalsVisibleTo"">
      <_Parameter1>MvvmCrossTest.Test.Droid</_Parameter1>
    </AssemblyAttribute>
    <AssemblyAttribute Include=""System.Runtime.CompilerServices.InternalsVisibleTo"">
      <_Parameter1>MvvmCrossTest.Test.iOS</_Parameter1>
    </AssemblyAttribute>
    <AssemblyAttribute Include=""System.Runtime.CompilerServices.InternalsVisibleTo"">
      <_Parameter1>MvvmCrossTest.Test.UWp</_Parameter1>
    </AssemblyAttribute>
    <AssemblyAttribute Include=""System.Runtime.CompilerServices.InternalsVisibleTo"">
      <_Parameter1>MvvmCross.Template.Test</_Parameter1>
    </AssemblyAttribute>
  </ItemGroup>",
                    newValue = @"  <ItemGroup>
    <!-- <AssemblyAttribute Include=""System.Runtime.CompilerServices.InternalsVisibleTo"">
      <_Parameter1>Proso..Test.Core</_Parameter1>
    </AssemblyAttribute>
    <AssemblyAttribute Include=""System.Runtime.CompilerServices.InternalsVisibleTo"">
      <_Parameter1>Proso..Test.Droid</_Parameter1>
    </AssemblyAttribute>
    <AssemblyAttribute Include=""System.Runtime.CompilerServices.InternalsVisibleTo"">
      <_Parameter1>Proso..Test.iOS</_Parameter1>
    </AssemblyAttribute>
    <AssemblyAttribute Include=""System.Runtime.CompilerServices.InternalsVisibleTo"">
      <_Parameter1>Proso..Test.UWp</_Parameter1>
    </AssemblyAttribute> -->
  </ItemGroup>";

                contents = contents.Replace(oldValue, newValue);
                File.WriteAllText(directoryBuildProps, contents);

                WriteLine("Fixed.\n");
            }
            #endregion
        }

        #region Helpers

        #region Update Element Text
        /// <summary>Updates text of specified tags.</summary>
        /// <param name="contents">The contents.</param>
        /// <param name="openingTags">The opening tags.</param>
        private void UpdateTexts(string[] contents, Dictionary<string, string> openingTags)
        {
            // Process each line
            // Stop when all required elements have been updated
            for (int line = 0, count = 0; line < contents.Length && count < openingTags.Count; line++)
            {
                string openingTag = GetOpeningTag(contents[line]);   // Get opening tag of current element
                // Check if element needs to be updated
                if (!openingTags.TryGetValue(openingTag, out string? newValue)) continue;

                string oldValue = GetText(contents[line]);   // Get element's current text
                contents[line] = contents[line].Replace(oldValue, newValue);   // Update element's text
                count++;
            }
        }
        #endregion

        #region Get Element Opening Tag
        /// <summary>Gets the opening tag of XML Element.</summary>
        /// <param name="element">The Element.</param>
        /// <returns>Opening tag.</returns>
        private string GetOpeningTag(string element)
        {
            int end = element.IndexOf('>') + 1;
            return element[..end];
        }
        #endregion

        #region Get Element Text
        /// <summary>Gets the text of XML Element.</summary>
        /// <param name="element">The element.</param>
        /// <returns>Element's text.</returns>
        private string GetText(string element)
        {
            int start = element.IndexOf('>') + 1,
                end = element.LastIndexOf('<');
            return element[start..end];
        }
        #endregion
        #endregion


        private readonly IFolderHelper _folderHelper;
        private const string TemplateFolder = @"D:\Plugins\MvvmCrossTest\Temp";
    }
}