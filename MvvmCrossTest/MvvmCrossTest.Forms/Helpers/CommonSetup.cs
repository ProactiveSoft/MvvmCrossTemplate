using System;
using System.Collections.Generic;
using MvvmCross;
using MvvmCross.Views;
using MvvmCrossTest.Abstraction.Helpers;
using MvvmCrossTest.Core.ViewModels;
using MvvmCrossTest.Forms.Views;

namespace MvvmCrossTest.Forms.Helpers
{
    public class CommonSetup : ICommonSetup
    {
        /// <inheritdoc />
        //public IDictionary<Type, Type> InitializeViewLookup()
        //{
        //    var viewModelViewPairs = new Dictionary<Type, Type>
        //    {
        //        [typeof(MainViewModel)] = typeof(MainPage)
        //    };

        //    var mvxViewModelViewsPairs = Mvx.IoCProvider.Resolve<IMvxViewsContainer>();
        //    mvxViewModelViewsPairs.AddAll(viewModelViewPairs);
        //}
        public IDictionary<Type, Type> InitializeLookupDictionary() =>
            new Dictionary<Type, Type>
            {
                [typeof(MainViewModel)] = typeof(MainPage)
            };
    }
}