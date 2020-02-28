using System;
using System.IO;

namespace MvvmCross.Template
{
    class FixCore : BaseFixProjects
    {
        public FixCore() => _coreFolder = Path.Combine(TemplateFolder, "Proso.MvvmCross.Core");



        private readonly string _coreFolder;
    }
}
