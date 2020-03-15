using System;
using System.Collections.Generic;
using MvvmCrossTest.Abstraction.Helpers;
using MvvmCrossTest.Core.ViewModels;
using $safeprojectname$.Views;

namespace $safeprojectname$.Helpers
{
    public class CommonSetup : ICommonSetup
    {
        public IDictionary<Type, Type> InitializeLookupDictionary() =>
            new Dictionary<Type, Type>
            {
                [typeof(MainViewModel)] = typeof(MainPage)
            };
    }
}