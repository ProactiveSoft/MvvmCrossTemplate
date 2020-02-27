using System.IO;
using Xunit;

namespace MvvmCross.Template.Test
{
    public class FixAbstractionShould
    {
        public FixAbstractionShould()
        {
            _templateFolder = @"D:\Plugins\MvvmCrossTest\Temp";
            _abstractionFolder = Path.Combine(_templateFolder, "Proso.MvvmCross.Abstraction");
        }

        private string VsTemplatePath => Path.Combine(_abstractionFolder, "MyTemplate.vstemplate");



        //[Fact]
        //[Trait("File", ".vstemplate")]
        //public void FixVsTemplate()
        //{
        //    // Arrange
        //    // Read file
        //    string vsTemplate = File.ReadAllText(VsTemplatePath);


        //    // Act


        //    // Assert
        //    string hidden = "    <Hidden>true</Hidden>";
        //    Assert.Contains(hidden, vsTemplate);

        //    string safeProjectName = "    <Project TargetFileName=\"$safeprojectname$.csproj\"";
        //    Assert.Contains(safeProjectName, vsTemplate);
        //}



        private readonly string _templateFolder, _abstractionFolder;
    }
}
