using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MvvmCross.Forms.Views;
using $ext_safeprojectname$.Core.ViewModels;

namespace $safeprojectname$.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MvxContentPage
    {
        public MainPage() => InitializeComponent();
    }
}
