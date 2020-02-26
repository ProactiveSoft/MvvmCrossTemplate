using Android.App;
using Android.Content.PM;
using Android.OS;
using MvvmCross.Forms.Platforms.Android.Views;


namespace $safeprojectname$
{
    [Activity(
        Label = "$ext_safeprojectname$",
        Icon = "@mipmap/icon",
        Theme = "@style/MainTheme",
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
        LaunchMode = LaunchMode.SingleTask)]
    public class MainActivity : MvxFormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;



            base.OnCreate(bundle);



            // Initialize 3rd-party libraries
        }
    }
}
