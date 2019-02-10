using MvvmCross;
using MvvmCross.Forms.Platforms.Ios.Core;
using MvvmCrossTest.Abstraction.Helpers;
using MvvmCrossTest.Forms.Helpers;

namespace MvvmCrossTest.iOS
{
    public class Setup : MvxFormsIosSetup<Core.App, Forms.App>
    {
        /// <inheritdoc />
        protected override void InitializeFirstChance()
        {
            Mvx.IoCProvider.RegisterSingleton<ICommonSetup>(new CommonSetup());



            base.InitializeFirstChance();
        }


        ///// <inheritdoc />
        //protected override void InitializeLastChance()
        //{
        //    base.InitializeLastChance();
        //}


        /// <inheritdoc />
        protected override void InitializeViewLookup() =>
            Mvx.IoCProvider.Resolve<ICommonSetup>().InitializeViewLookup();
    }
}