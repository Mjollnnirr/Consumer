using System;
using System.Linq.Expressions;
using Entity.Base;

namespace Core.Services;

public interface IBaseEntityRepository<T> : IDisposable
    where T : class, IEntity, new()
{
    Task<T> Get(
        Expression<Func<T, bool>>? expression = null,
        int skip = 0, params string[] includes);
    Task<List<T>> GetAll(
        Expression<Func<T, bool>>? expression = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        int skip = 0, int take = int.MaxValue,
        params string[] includes);
    Task Create(T entity);
    Task Update(T entity);
    Task Delete(T entity);
    Task Save();
}

