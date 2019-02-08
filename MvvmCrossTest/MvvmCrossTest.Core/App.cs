using MvvmCross.IoC;
using MvvmCross.ViewModels;

namespace MvvmCrossTest.Core
{
    public class App : MvxApplication
    {
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
    }
}