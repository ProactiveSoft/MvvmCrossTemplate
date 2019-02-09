using System;
using System.Collections.Generic;
using MvvmCross;
using MvvmCross.Forms.Platforms.Android.Core;
using MvvmCross.Logging;
using MvvmCross.Views;
using MvvmCrossTest.Abstraction.Helpers;
using MvvmCrossTest.Core.ViewModels;
using MvvmCrossTest.Helpers;
using MvvmCrossTest.Views;
using Serilog;

namespace MvvmCrossTest.Droid
{
    public class Setup : MvxFormsAndroidSetup<Core.App, App>
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


        /// <inheritdoc />
        public override MvxLogProviderType GetDefaultLogProviderType() => MvxLogProviderType.Serilog;

        /// <inheritdoc />
        protected override IMvxLogProvider CreateLogProvider()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.AndroidLog()
                .CreateLogger();

            return base.CreateLogProvider();
        }
    }
}