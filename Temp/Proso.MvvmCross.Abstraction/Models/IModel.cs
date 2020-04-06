using System;
using System.ComponentModel;

namespace $safeprojectname$.Models
{
    public interface IModel<TId> : INotifyPropertyChanged, IComparable<ModelBase<TId>>, IComparable,
        IEquatable<ModelBase<TId>> where TId : struct, IComparable<TId>, IEquatable<TId>
    {
        TId Id { set; get; }
    }
}
