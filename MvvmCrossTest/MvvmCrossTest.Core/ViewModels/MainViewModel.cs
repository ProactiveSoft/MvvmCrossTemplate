using MvvmCross.Navigation;

namespace MvvmCrossTest.Core.ViewModels
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