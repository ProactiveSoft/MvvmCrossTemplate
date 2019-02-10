using MvvmCross.Navigation;
using MvvmCrossTest.Abstraction.ViewModels;

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