using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            return csFiles.Select(csFile => new object[] { csFile });
        }
    }
}