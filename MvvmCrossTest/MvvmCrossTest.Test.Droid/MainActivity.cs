using System.Reflection;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Xunit.Runners.UI;
using Xunit.Sdk;
using MvvmCrossTest.Test.Core;

namespace MvvmCrossTest.Test.Droid
{
    //[Activity(Label = "xUnit Android Runner", MainLauncher = true, Theme = "@android:style/Theme.Material.Light")]
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : RunnerActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            // tests can be inside the main assembly
            AddTestAssembly(Assembly.GetExecutingAssembly());

            AddExecutionAssembly(typeof(ExtensibilityPointFactory).Assembly);
            // or in any reference assemblies			

            AddTestAssembly(typeof(MainViewModelShould).Assembly);
            // or in any assembly that you load (since JIT is available)

#if false
            // you can use the default or set your own custom writer (e.g. save to web site and tweet it ;-)
            Writer = new TcpTextWriter ("10.0.1.2", 16384);
            // start running the test suites as soon as the application is loaded
            AutoStart = true;
            // crash the application (to ensure it's ended) and return to springboard
            TerminateAfterExecution = true;
#endif
            // you cannot add more assemblies once calling base
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }

    //[Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    //public class MainActivity : AppCompatActivity
    //{
    //    protected override void OnCreate(Bundle savedInstanceState)
    //    {
    //        base.OnCreate(savedInstanceState);
    //        Xamarin.Essentials.Platform.Init(this, savedInstanceState);
    //        // Set our view from the "main" layout resource
    //        SetContentView(Resource.Layout.activity_main);
    //    }
    //    public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
    //    {
    //        Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

    //        base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
    //    }
    //}
}