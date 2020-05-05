using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Xunit.Sdk;

namespace MvvmCross.Template.Test.Data
{
    public class CsProjFilesAttribute : DataAttribute
    {
        #region Get Paths of all .csproj Files
        /// <inheritdoc />
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            string templateFolder = @"D:\Plugins\MvvmCrossTest\Temp";
            IEnumerable<string> csprojFiles =
                Directory.EnumerateFiles(templateFolder, "*.csproj", SearchOption.AllDirectories);
            return csprojFiles.Select(csprojFile => new object[] { csprojFile });
        }
        #endregion
    }
}