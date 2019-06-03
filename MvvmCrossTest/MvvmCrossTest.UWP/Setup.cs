using System.Collections.Generic;
using System.Reflection;
using MvvmCross;
using MvvmCross.Forms.Platforms.Uap.Core;
using MvvmCrossTest.Abstraction.Helpers;
using MvvmCrossTest.Forms.Helpers;

namespace MvvmCrossTest.UWP
{
    public class Setup : MvxFormsWindowsSetup<Core.App, Forms.App>
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
        protected override void InitializeViewLookup() =>
            Mvx.IoCProvider.Resolve<ICommonSetup>().InitializeViewLookup();

        /// <inheritdoc />
        public override IEnumerable<Assembly> GetViewAssemblies() => new HashSet<Assembly>(base.GetViewAssemblies())
        {
            // Initialize custom controls
            typeof(Forms.Views.MainPage).GetTypeInfo().Assembly
        };
    }
}