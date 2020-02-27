using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Xunit.Sdk;

namespace MvvmCross.Template.Test.Data
{
    public class CsProjFilesAttribute : DataAttribute
    {
        /// <inheritdoc />
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            string templateFolder = @"D:\Plugins\MvvmCrossTest\Temp";
            IEnumerable<string> csprojFiles =
                Directory.EnumerateFiles(templateFolder, "*.csproj", SearchOption.AllDirectories);
            foreach (var csprojFile in csprojFiles) yield return new object[] { csprojFile };
        }
    }
}