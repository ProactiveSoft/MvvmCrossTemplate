using System;
using System.Collections.Generic;
using MvvmCross;
using MvvmCross.Views;
using $ext_safeprojectname$.Abstraction.Helpers;
using $ext_safeprojectname$.Core.ViewModels;
using $safeprojectname$.Views;

namespace $safeprojectname$.Helpers
{
    public class CommonSetup : ICommonSetup
    {
        /// <inheritdoc />
        public void InitializeViewLookup()
        {
            var viewModelViewPairs = new Dictionary<Type, Type>
            {
                [typeof(MainViewModel)] = typeof(MainPage)
            };

            var mvxViewModelViewsPairs = Mvx.IoCProvider.Resolve<IMvxViewsContainer>();
            mvxViewModelViewsPairs.AddAll(viewModelViewPairs);
        }
    }
}