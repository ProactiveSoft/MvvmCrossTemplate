using MvvmCross.Template.Helpers;

namespace MvvmCross.Template
{
    public class FixTemplateRoot
    {
        public FixTemplateRoot(IFolderHelper folderHelper) => _folderHelper = folderHelper;


        public void CopyItems()
        {
            string source = @"D:\Plugins\MvvmCrossTest\Proso.MvvmCross Template\Template",
                destination = @"D:\Plugins\MvvmCrossTest\Temp";
            _folderHelper.CopyFolderFiles(source, destination);
        }


        private readonly IFolderHelper _folderHelper;
    }
}