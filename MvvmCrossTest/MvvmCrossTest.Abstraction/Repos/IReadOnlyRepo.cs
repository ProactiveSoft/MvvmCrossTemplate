using System;
using System.Linq;
using MvvmCrossTest.Abstraction.Models;

namespace MvvmCrossTest.Abstraction.Repos
{
    public interface IReadOnlyRepo<out TModel, TId>
        where TModel : ModelBase<TId>
        where TId : struct, IComparable<TId>, IEquatable<TId>
    {
        TModel ReadAsync(TId id);
        IQueryable<TModel> ReadAsync();
        IQueryable<TModel> ReadAsync(Predicate<TId> ids);
    }
}