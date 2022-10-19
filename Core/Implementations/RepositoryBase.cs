using System;
using System.Linq.Expressions;
using Core.Services;
using Entity.Base;
using Exceptions.EntityExveptions;
using Microsoft.EntityFrameworkCore;

namespace Core.Implementations;

public class RepositoryBase<TEntity, TContext> : IBaseEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext
{
    private readonly TContext _context;
    private readonly DbSet<TEntity> _dbSet;
    public RepositoryBase(TContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public async Task<TEntity> Get(
        Expression<Func<TEntity, bool>>? expression = null,
        int skip = 0, params string[] includes)
    {
        IQueryable<TEntity> query = _dbSet;
        if (expression is not null)
        {
            query = query.Where(expression);
        }

        query = query.Skip(skip);

        if (includes is not null)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }

        var data = await query.FirstOrDefaultAsync();

        if (data is null)
            throw new EntityIsNullException();
        return data;
    }

    public async Task<List<TEntity>> GetAll(
        Expression<Func<TEntity, bool>>? expression,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        int skip = 0, int take = int.MaxValue, params string[] includes)
    {
        IQueryable<TEntity> query = _dbSet;
        if (expression is not null)
        {
            query = query.Where(expression);
        }

        if (orderBy is not null)
        {
            query = orderBy(query);
        }

        query = query.Skip(skip).Take(take);

        if (includes is not null)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }

        var data = await query.ToListAsync();

        return data;
    }

    public void Create(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Added;
    }

    public void Update(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Deleted;
    }
}