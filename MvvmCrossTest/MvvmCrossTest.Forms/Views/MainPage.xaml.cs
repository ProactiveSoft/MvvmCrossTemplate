﻿using Xamarin.Forms.Xaml;
using MvvmCross.Forms.Views;

namespace MvvmCrossTest.Forms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MvxContentPage
    {
        public MainPage() => InitializeComponent();
    }
}
