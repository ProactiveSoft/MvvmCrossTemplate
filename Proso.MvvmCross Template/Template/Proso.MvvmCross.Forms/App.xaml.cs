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
                "OTQxODRAMzEzNzJlMzEyZTMwWXd5VEZNczJudm5ZekJLVTR1U2k4UFJvWGFUdWI4c3p0RVNkNlc2TWFRMD0=");



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