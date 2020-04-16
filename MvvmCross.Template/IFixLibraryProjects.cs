namespace MvvmCross.Template
{
    interface IFixLibraryProjects
    {
        /// <summary>Fixes all C# files.</summary>
        void FixCSharp();
        void FixCsProj();
        void FixVsTemplate();
        public void CopyItems() { }
    }
}