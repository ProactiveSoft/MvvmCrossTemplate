using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace $safeprojectname$
{
    public partial class App : Application
    {
        public App()
        {
            // Syncfusion license key
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(
                "MjE1MDMzQDMxMzcyZTM0MmUzMENCN2dHMFRYb3h2N2tmSUxtSWVra3JuY0tzTnR2dGhsc0h6SXgxbGxQUG89");



            InitializeComponent();
        }

        //protected override void OnStart()
        //{
        //    base.OnStart();
        //}

        //protected override void OnSleep()
        //{
        //    base.OnSleep();
        //}

        //protected override void OnResume()
        //{
        //    base.OnResume();
        //}
    }
}
