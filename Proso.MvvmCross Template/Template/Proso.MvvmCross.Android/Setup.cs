using System;
using System.Collections.Generic;
using MvvmCross;
using MvvmCross.Forms.Platforms.Android.Core;
using MvvmCross.Logging;
using $ext_safeprojectname$.Abstraction.Helpers;
using $ext_safeprojectname$.Forms.Helpers;
using Serilog;

namespace $safeprojectname$
{
    public class Setup : MvxFormsAndroidSetup<Core.App, Forms.App>
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
