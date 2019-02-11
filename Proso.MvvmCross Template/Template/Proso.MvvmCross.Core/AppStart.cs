using System.Threading.Tasks;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using $safeprojectname$.ViewModels;

namespace $safeprojectname$
{
    public class AppStart : MvxAppStart
    {
        /// <inheritdoc />
        public AppStart(IMvxApplication application, IMvxNavigationService navigationService) : base(application,
            navigationService)
        {
        }

        /// <inheritdoc />
        protected override Task NavigateToFirstViewModel(object hint = null) =>
            NavigationService.Navigate<MainViewModel>();
    }
}