using System;
using System.ComponentModel;

namespace MvvmCrossTest.Abstraction.Models
{
    public interface IModel<TId> : INotifyPropertyChanged, IComparable<ModelBase<TId>>, IComparable,
        IEquatable<ModelBase<TId>> where TId : struct, IComparable<TId>, IEquatable<TId>
    {
        TId Id { set; get; }
    }
}