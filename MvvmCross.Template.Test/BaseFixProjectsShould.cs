using System.IO;
using MvvmCross.Template.Test.Data;
using Xunit;

namespace MvvmCross.Template.Test
{
    public class BaseFixProjectsShould
    {
        [Theory]
        [CSharpFiles]
        public void FixCSharp(string filePath)
        {
            // Arrange
            string contents = File.ReadAllText(filePath);


            // Assert
            Assert.DoesNotContain("MvvmCrossTest", contents);
        }
    }
}