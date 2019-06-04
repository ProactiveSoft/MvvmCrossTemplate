using System.Threading.Tasks;
using MvvmCross.IoC;
using MvvmCross.ViewModels;

namespace $safeprojectname$
{
    public class App : MvxApplication
    {
        /// <summary>
        /// This method is called on a background thread.
        /// Use Startup() for any UI bound actions
        /// </summary>
        /// <inheritdoc />
        public override void Initialize()
        {
            // Register cross-platform services
            //CreatableTypes()
            //    .EndingWith("Service")
            //    .AsInterfaces()
            //    .RegisterAsLazySingleton();



            // Register Xamarin plugins w/ IoC



            RegisterCustomAppStart<AppStart>();
        }

        ///// <summary>
        ///// Do any UI bound startup actions here
        ///// </summary>
        //public override Task Startup()
        //{
        //    return base.Startup();
        //}

        ///// <summary>
        ///// If the application is restarted (eg primary activity on Android
        ///// can be restarted) this method will be called before Startup
        ///// is called again
        ///// </summary>
        //public override void Reset()
        //{
        //    base.Reset();
        //}
    }
}