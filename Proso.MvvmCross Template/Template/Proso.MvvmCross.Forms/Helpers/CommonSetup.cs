using System;
using System.Collections.Generic;
using $ext_safeprojectname$.Abstraction.Helpers;
using $ext_safeprojectname$.Core.ViewModels;
using $safeprojectname$.Views;

namespace $safeprojectname$.Helpers
{
    public class CommonSetup : ICommonSetup
    {
        /// <inheritdoc />
        public IDictionary<Type, Type> InitializeLookupDictionary() =>
            new Dictionary<Type, Type>
            {
                [typeof(MainViewModel)] = typeof(MainPage)
            };
    }
}