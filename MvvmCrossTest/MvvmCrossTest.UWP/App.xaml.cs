using MvvmCross.Forms.Platforms.Uap.Views;

namespace MvvmCrossTest.UWP
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : UwpApplication
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App() => InitializeComponent();
    }


    public abstract class UwpApplication : MvxWindowsApplication<Setup, Core.App, Forms.App, MainPage> { }
}
