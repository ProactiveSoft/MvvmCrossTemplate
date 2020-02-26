using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace MvvmCross.Template.Test
{
    public class AbstractionProjectShould
    {
        public AbstractionProjectShould()
        {
            _templateFolder = @"D:\Plugins\MvvmCrossTest\Temp";
            _abstractionFolder = Path.Combine(_templateFolder, "Proso.MvvmCross.Abstraction");
        }

        private string VsTemplatePath => Path.Combine(_abstractionFolder, "MyTemplate.vstemplate");



        [Fact]
        public void ManipulateVsTemplate()
        {
            // Arrange
            // Read file
            List<string> vsTemplate = File.ReadAllLines(VsTemplatePath).ToList();


            // Act


            // Assert
            string hiddenLine17 = "    <Hidden>true</Hidden>";
            Assert.Equal(hiddenLine17, vsTemplate[16]);
            string safeProjectNameLine20 = "TargetFileName=\"$safeprojectname$.csproj\"";
            Assert.Contains(safeProjectNameLine20, vsTemplate[19]);
        }

        [Fact]
        public void NotHardCodeVsTemplate()
        {
            // Arrange
            string vsTemplate = File.ReadAllText(VsTemplatePath);


            // Assert
            Assert.DoesNotContain("TargetFileName=\"MvvmCrossTest.Abstraction.csproj\"", vsTemplate);
        }


        private readonly string _templateFolder, _abstractionFolder;
    }
}
