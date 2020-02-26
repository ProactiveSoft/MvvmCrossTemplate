using System;
using System.Collections.Generic;
using MvvmCross;
using MvvmCross.Forms.Platforms.Ios.Core;
using $ext_safeprojectname$.Abstraction.Helpers;
using $ext_safeprojectname$.Forms.Helpers;

namespace $safeprojectname$
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
        //    // Your code


        //    base.InitializeLastChance();
        //}


        /// <inheritdoc />
        protected override IDictionary<Type, Type> InitializeLookupDictionary() =>
            Mvx.IoCProvider.Resolve<ICommonSetup>().InitializeLookupDictionary();
    }
}
