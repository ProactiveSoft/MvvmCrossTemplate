using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Xunit.Sdk;

namespace MvvmCross.Template.Test.Data
{
    public class VsTemplateFilesAttribute : DataAttribute
    {
        #region Get Paths of all .vstemplate Files
        /// <inheritdoc />
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            string templateFolder = @"D:\Plugins\MvvmCrossTest\Temp";
            IEnumerable<string> vsTemplates =
                Directory.EnumerateFiles(templateFolder, "*.vstemplate", SearchOption.AllDirectories)
                    .Where(vsTemplate =>   // Only return project .vstemplate, not root .vstemplate
                        vsTemplate != Path.Combine(templateFolder, "Proso-MvvmCross-Xamarin-Template.vstemplate"));
            return vsTemplates.Select(vsTemplate => new object[] { vsTemplate });
        }
        #endregion
    }
}