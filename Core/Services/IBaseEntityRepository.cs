using System;
using System.Linq.Expressions;
using Entity.Base;

namespace Core.Services;

public interface IBaseEntityRepository<T>
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
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
}

