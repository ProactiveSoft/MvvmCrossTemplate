using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Xunit.Sdk;

namespace MvvmCross.Template.Test.Data
{
    public class CSharpFilesAttribute : DataAttribute
    {
        /// <inheritdoc />
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            string templateFolder = @"D:\Plugins\MvvmCrossTest\Temp";
            IEnumerable<string> csFiles = Directory.EnumerateFiles(templateFolder, "*.cs", SearchOption.AllDirectories);
            foreach (var csFile in csFiles) yield return new object[] { csFile };
        }
    }
}