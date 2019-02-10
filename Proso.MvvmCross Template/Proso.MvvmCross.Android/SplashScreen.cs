using Android.App;
using Android.Content.PM;
using Android.OS;
using MvvmCross.Forms.Platforms.Android.Views;
using System.Threading.Tasks;

namespace $safeprojectname$
{
    [Activity(
        Label = "$ext_safeprojectname$",
        MainLauncher = true,
        Icon = "@mipmap/icon",
        Theme = "@style/MainTheme.Splash",
        NoHistory = true,
        ScreenOrientation = ScreenOrientation.Portrait,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class SplashScreen : MvxFormsSplashScreenActivity<Setup, Core.App, Forms.App>
    {
        public SplashScreen() : base(Resource.Layout.SplashScreen) { }


        /// <inheritdoc />
        protected override Task RunAppStartAsync(Bundle bundle)
        {
            StartActivity(typeof(MainActivity));

            return Task.CompletedTask;
        }
    }
}