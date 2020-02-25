using System;
using System.Collections.Generic;

namespace MvvmCrossTest.Abstraction.Helpers
{
    public interface ICommonSetup
    {
        /// <summary>  Link ViewModels to Views.</summary>
        /// <returns>IDictionary&lt;ViewModelType, ViewType&gt;.</returns>
        IDictionary<Type, Type> InitializeLookupDictionary();
    }
}