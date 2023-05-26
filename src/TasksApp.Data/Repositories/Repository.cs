using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TasksApp.Domain.Entities;
using TasksApp.Domain.Repositories;

namespace TasksApp.Data.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly DbSet<TEntity> _entities;

    public Repository(DbSet<TEntity> entities) => _entities = entities;

    /// <inheritdoc/>
    public async Task CreateAsync(TEntity entity) => await _entities.AddAsync(entity);

    /// <inheritdoc/>
    public async Task<TEntity?> GetAsync(Guid id, bool shouldTrackEntity = false, params Expression<Func<TEntity, object>>[] includes)
    {
        var query = _entities.AsQueryable();

        if (!shouldTrackEntity)
        {
            query = query.AsNoTracking();
        }
        
        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return await query.FirstOrDefaultAsync(e => e.Id == id);
    }

    /// <inheritdoc/>
    public async Task UpdateAsync(TEntity entity) => await Task.Run(() => { _entities.Update(entity); });

    /// <inheritdoc/>
    public async Task<IEnumerable<TEntity>> GetAllAsync(bool shouldTrackEntity = false, params Expression<Func<TEntity, object>>[] includes)
    {
        var query = _entities.AsQueryable();

        if (!shouldTrackEntity)
        {
            query = query.AsNoTracking();
        }

        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        return await query.ToListAsync();
    }
}