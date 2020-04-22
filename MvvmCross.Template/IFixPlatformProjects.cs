namespace MvvmCross.Template
{
    interface IFixPlatformProjects : IFixLibraryProjects
    {
        /// <summary>Corrects manifest of platform specific projects.</summary>
        void CorrectManifest();
    }
}