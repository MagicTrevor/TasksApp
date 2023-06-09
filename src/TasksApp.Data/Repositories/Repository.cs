using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TasksApp.Domain.Entities;
using TasksApp.Domain.Repositories;

namespace TasksApp.Data.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly TasksAppContext _context;

    public Repository(TasksAppContext context) => _context = context;

    /// <inheritdoc/>
    public async Task<TEntity?> GetAsync(Guid id, params Expression<Func<TEntity, object>>[] includes)
    {
        var query = _context.Set<TEntity>().AsNoTracking();
        
        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return await query.FirstOrDefaultAsync(e => e.Id == id);
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes)
    {
        var query = _context.Set<TEntity>().AsNoTracking();

        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return await query.ToListAsync();
    }

    /// <inheritdoc/>
    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    /// <inheritdoc/>
    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        _context.Update(entity);
        await _context.SaveChangesAsync();

        return entity;
    }
}