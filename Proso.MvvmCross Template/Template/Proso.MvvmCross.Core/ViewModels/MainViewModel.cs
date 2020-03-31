using $ext_safeprojectname$.Abstraction.ViewModels;

namespace $safeprojectname$.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        //public MainViewModel()
        //{
        //    // Ctor injection
        //}


        /// <inheritdoc />
        public override void Prepare()
        {
            // Initialize VM`s fields & properties 
            Title = "V 6.4.2";
        }

        ///// <inheritdoc />
        //public override async Task Initialize()
        //{
        //    await base.Initialize();


        //    // Other heavy initialization
        //}
    }
}
