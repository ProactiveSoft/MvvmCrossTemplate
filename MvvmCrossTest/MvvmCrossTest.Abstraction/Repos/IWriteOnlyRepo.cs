using MvvmCrossTest.Abstraction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvvmCrossTest.Abstraction.Repos
{
    public interface IWriteOnlyRepo<in TModel, TId>
        where TModel : ModelBase<TId>
        where TId : struct, IComparable<TId>, IEquatable<TId>
    {
        Task<TId> AddAsync(TModel item);
        Task<IQueryable<TId>> AddAsync(IEnumerable<TModel> items);



        Task UpdateAsync(TId id);
        Task UpdateAsync(IEnumerable<TId> ids);
        Task UpdateAsync(TModel item);
        Task UpdateAsync(IEnumerable<TModel> items);



        Task DeleteAsync(TId id);
        Task DeleteAsync(IEnumerable<TId> ids);
        Task DeleteAsync(TModel item);
        Task DeleteAsync(IEnumerable<TModel> items);
    }
}