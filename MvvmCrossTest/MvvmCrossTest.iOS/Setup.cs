using System;
using System.Collections.Generic;
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
        //    // Your code


        //    base.InitializeLastChance();
        //}


        /// <inheritdoc />
        //protected override void InitializeViewLookup() =>
        //    Mvx.IoCProvider.Resolve<ICommonSetup>().InitializeLookupDictionary();
        /// <inheritdoc />
        protected override IDictionary<Type, Type> InitializeLookupDictionary() =>
            Mvx.IoCProvider.Resolve<ICommonSetup>().InitializeLookupDictionary();
    }
}