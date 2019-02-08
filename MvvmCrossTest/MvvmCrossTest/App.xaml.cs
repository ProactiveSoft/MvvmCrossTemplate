using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MvvmCrossTest
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
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
