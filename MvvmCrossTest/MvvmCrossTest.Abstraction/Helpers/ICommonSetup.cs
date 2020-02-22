using System;
using System.Collections.Generic;

namespace MvvmCrossTest.Abstraction.Helpers
{
    public interface ICommonSetup
    {
        IDictionary<Type, Type> InitializeLookupDictionary();
    }
}