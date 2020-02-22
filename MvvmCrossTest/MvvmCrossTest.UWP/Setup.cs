using System;
using System.Collections.Generic;
using System.Reflection;
using MvvmCross;
using MvvmCross.Forms.Platforms.Uap.Core;
using MvvmCrossTest.Abstraction.Helpers;
using MvvmCrossTest.Forms.Helpers;
using Syncfusion.XForms.UWP.Border;
using Syncfusion.XForms.UWP.Buttons;

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


        ///// <inheritdoc />
        //protected override void InitializeViewLookup() =>
        //    Mvx.IoCProvider.Resolve<ICommonSetup>().InitializeViewLookup();
        /// <inheritdoc />
        protected override IDictionary<Type, Type> InitializeLookupDictionary() =>
            Mvx.IoCProvider.Resolve<ICommonSetup>().InitializeLookupDictionary();

        /// <inheritdoc />
        public override IEnumerable<Assembly> GetViewAssemblies() => new HashSet<Assembly>(base.GetViewAssemblies())
        {
            // Initialize custom controls
            typeof(SfBorderRenderer).GetTypeInfo().Assembly,
            typeof(SfButtonRenderer).GetTypeInfo().Assembly,
            typeof(Forms.Views.MainPage).GetTypeInfo().Assembly
        };
    }
}