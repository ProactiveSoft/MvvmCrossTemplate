using System;
using System.IO;

namespace MvvmCross.Template
{
    public interface IFixMetadata
    {
        protected internal string CurrentMvxVersion
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


        protected internal (int Year, int Month, int Day, int Seconds) CurrentAppVersion
        {
            get
            {
                DateTime today = DateTime.Today, now = DateTime.Now;
                int totalSeconds = (int)(now - today).TotalSeconds;
                return (today.Year, today.Month, today.Day, totalSeconds);
            }
        }
        
        protected internal (int Year, int Month, int Seconds) CompactCurrentAppVersion
        {
            get
            {
                var version = CurrentAppVersion;
                DateTime month = new DateTime(version.Year, version.Month, 1);
                int totalSeconds = (int)(DateTime.Now - month).TotalSeconds;
                return (version.Year, version.Month, totalSeconds);
            }
        }

        void UpdateVersion();
    }
}