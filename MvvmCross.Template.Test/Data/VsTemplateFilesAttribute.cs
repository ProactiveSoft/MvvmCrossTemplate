using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Xunit.Sdk;

namespace MvvmCross.Template.Test.Data
{
    public class VsTemplateFilesAttribute : DataAttribute
    {
        /// <inheritdoc />
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            string templateFolder = @"D:\Plugins\MvvmCrossTest\Temp";
            IEnumerable<string> vsTemplateFiles =
                Directory.EnumerateFiles(templateFolder, "*.vstemplate", SearchOption.AllDirectories)
                    .Where(vsTemplateFile =>
                        vsTemplateFile != Path.Combine(templateFolder, "Proso-MvvmCross-Xamarin-Template.vstemplate"));
            return vsTemplateFiles.Select(vsTemplateFile => new object[] { vsTemplateFile });
        }
    }
}