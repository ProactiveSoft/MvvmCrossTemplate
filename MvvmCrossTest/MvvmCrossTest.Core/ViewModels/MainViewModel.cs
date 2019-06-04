using MvvmCrossTest.Abstraction.ViewModels;

namespace MvvmCrossTest.Core.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            // Ctor injection
        }


        /// <inheritdoc />
        public override void Prepare()
        {
            // Initialize VM`s fields & properties 
            Title = "V 6.3.0";
        }

        ///// <inheritdoc />
        //public override async Task Initialize()
        //{
        //    await base.Initialize();


        //    // Other heavy initialization
        //}
    }
}