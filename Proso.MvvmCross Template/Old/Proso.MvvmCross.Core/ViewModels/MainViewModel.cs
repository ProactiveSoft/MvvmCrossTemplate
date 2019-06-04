using MvvmCross.Navigation;
using $ext_safeprojectname$.Abstraction.ViewModels;

namespace $safeprojectname$.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        /// <inheritdoc />
        public MainViewModel(IMvxNavigationService navigationService) : base(navigationService)
        {
            Title = "Home";
        }
    }
}