using System;
using System.Collections.Generic;
using MvvmCross;
using MvvmCross.Views;
using MvvmCrossTest.Abstraction.Helpers;
using MvvmCrossTest.Core.ViewModels;
using MvvmCrossTest.Views;

namespace MvvmCrossTest.Helpers
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