namespace MvvmCross.Template
{
    interface IFixLibraryProjects
    {
        /// <summary>Fixes all C# files.</summary>
        void FixCSharp();
        /// <summary>Fixes csproj file.</summary>
        void FixCsProj();
        /// <summary>Fixes .vstemplate file.</summary>
        void FixVsTemplate();
        public void CopyItems() { }
    }
}