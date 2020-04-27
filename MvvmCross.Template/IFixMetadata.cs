using System;
using System.IO;

namespace MvvmCross.Template
{
    /// <summary>
    /// Interface to fix metadata (like version numbers).
    /// </summary>
    public interface IFixMetadata
    {
        #region Current Mvx Version
        /// <summary>
        /// Current Mvx version.
        /// </summary>
        protected internal string CurrentMvxVersion
        {
            get
            {
                string[] contents =
                    File.ReadAllLines(
                        @"D:\Plugins\MvvmCrossTest\MvvmCrossTest\MvvmCrossTest.Core\MvvmCrossTest.Core.csproj");
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
        #endregion

        #region Version based on Time
        /// <summary>
        /// Version based on time: Year.Month.Day.NormalizedSeconds
        /// </summary>
        protected internal (int Year, int Month, int Day, int Seconds) CurrentAppVersion
        {
            get
            {
                DateTime today = DateTime.Today, now = DateTime.Now;
                int totalSeconds = (int)(now - today).TotalSeconds;
                // Normalize multiplier = Max uint / no.of sec in 1 day
                // Source: Normalize no. between 0-1: https://stackoverflow.com/a/39776893/4038979
                double normalizeMultiplier = (double)65_534 / 86_400;
                totalSeconds = (int)Math.Round(totalSeconds * normalizeMultiplier);
                return (today.Year, today.Month, today.Day, totalSeconds);
            }
        }
        #endregion

        #region Compact version based on time
        /// <summary>
        /// Compact version based on time: Year.Month.NormalizedSeconds
        /// </summary>
        protected internal (int Year, int Month, int Seconds) CompactCurrentAppVersion
        {
            get
            {
                var version = CurrentAppVersion;
                DateTime month = new DateTime(version.Year, version.Month, 1);
                int totalSeconds = (int)(DateTime.Now - month).TotalSeconds;
                // Normalize multiplier = Max uint / no.of sec in 1 month
                // Source: Normalize no. between 0-1: https://stackoverflow.com/a/39776893/4038979
                double normalizeMultiplier = (double)65_534 / 26_78_400;
                totalSeconds = (int)Math.Round(totalSeconds * normalizeMultiplier);

                return (version.Year, version.Month, totalSeconds);
            }
        }
        #endregion

        /// <summary>
        /// Updates Mvx &amp; Template's version.
        /// </summary>
        void UpdateVersion();
    }
}