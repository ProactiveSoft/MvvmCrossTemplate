using System.IO;

namespace MvvmCross.Template
{
    public interface IFixMetadata
    {
        protected internal string NewTemplateVersion
        {
            get
            {
                string[] contents =
                    File.ReadAllLines(
                        @"D:\Plugins\MvvmCrossTest\MvvmCrossTest\MvvmCrossTest.Forms\MvvmCrossTest.Forms.csproj");
                foreach (var line in contents)
                    if (line.StartsWith("    <PackageReference Include=\"MvvmCross"))
                    {
                        int end = line.LastIndexOf('"');
                        int start = line.LastIndexOf('"', end - 1) + 1;
                        return line[start..end];
                    }

                return "0.0.0";
            }
        }

        void UpdateVersion();
    }
}