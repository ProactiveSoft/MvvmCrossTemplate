using MvvmCross;
using MvvmCross.Forms.Platforms.Android.Core;
using MvvmCross.Logging;
using MvvmCrossTest.Abstraction.Helpers;
using MvvmCrossTest.Forms.Helpers;
using Serilog;

namespace MvvmCrossTest.Droid
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